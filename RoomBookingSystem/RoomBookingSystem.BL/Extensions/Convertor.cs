using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace RoomBookingSystem.BL.Extensions
{
    public static class Convertor
    {
        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    var columnName = GetPropertyName(pro).ToLower();
                    if (columnNames.Contains(columnName))
                    {
                        try
                        {
                            pro.SetValue(objT, row[columnName]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

        private static string GetPropertyName(PropertyInfo pro)
        {
            var customAttribute = pro.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(ColumnAttribute)) as ColumnAttribute;
            if (customAttribute != null)
            {
                return customAttribute.ColumnName;
            }
            else
            {
                return pro.Name;
            }
        }
    }
}