using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SJ.One_Core.HtmlExtensions
{
    public static class EnumValueDisplay
    {
        public static string DisplayName(this Enum value)
        {
            Type enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            string outString;
            if (enumValue == null)
            {
                outString = "Значение не найдено";
            }
            else
            {
                MemberInfo member = enumType.GetMember(enumValue)[0];

                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }
            }
            return outString;
        }
    }
}
