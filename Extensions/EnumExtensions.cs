using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Demo1CoreCRUD.Extensions
{
    public static class EnumExtensions
    {
        // Get name attribute with string input
        public static string GetDisplayName<TEnum>(this string stringValue) where TEnum : struct
        {
            string? enumAttribute = null;
            if (stringValue != null)
            {
                var enumValue = Enum.Parse<TEnum>(stringValue.Trim());
                enumAttribute = enumValue
                                    .GetType()
                                    .GetMember(enumValue.ToString())
                                    .First()?
                                    .GetCustomAttribute<DisplayAttribute>()?.Name
                                    .ToString();
                enumAttribute = enumAttribute ?? stringValue;
            }
            return enumAttribute;
        }

        // Get name attribute with Enum input
        public static string GetDisplayName(this Enum enumValue)
        {
            string? enumAttribute = enumValue
                                      .GetType()
                                      .GetMember(enumValue.ToString())
                                      .First()?
                                      .GetCustomAttribute<DisplayAttribute>()?.Name
                                      .ToString();
            return enumAttribute ?? enumValue.ToString();
        }

        public static IEnumerable<SelectListItem> GetEnumList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = x.GetDisplayName(),
                        Value = x.ToString()
                    }), "Value", "Text");
        }
    }
}
