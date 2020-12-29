using System;

namespace RoomBookingSystem.BL.Extensions
{
    internal class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string columnName)
        {
            this.ColumnName = columnName;
        }

        public string ColumnName { get; }
    }
}