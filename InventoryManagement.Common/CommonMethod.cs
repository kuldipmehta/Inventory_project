using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InventoryManagement.Common
{
    public class CommonMethod
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }

        public static string GetEnumDescriptionByEnumType(Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static bool IsValidStartEndDate(string startDate, string endDate)
        {
            try
            {
                var date1 = Convert.ToDateTime(startDate);
                var date2 = Convert.ToDateTime(endDate);
                var result = DateTime.Compare(date1, date2);
                if (result > 0) return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidStartEndDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = DateTime.Compare(startDate, endDate);
                if (result > 0) return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
