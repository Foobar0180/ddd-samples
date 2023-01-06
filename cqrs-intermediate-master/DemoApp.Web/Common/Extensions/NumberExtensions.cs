using System;

namespace DemoApp.Web.Common.Extensions
{
    public static class NumberExtensions
    {
        public static string ToDefaultIfNegativeOrZero(this int number)
        {
            return number <= 0 ? String.Empty : number.ToString();
        }
    }
}