using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YandexAPI;

namespace RouteBot.Extensions
{
    public static class Utils
    {
       public static bool Contains(this string str, string pat)
       {
            for (int i = 0; i < str.Length; i++)
            {
                if (str == pat) return true;
            }
            return false;
        }

        public static bool Contains(this IMessageActivity message, string value)
        {
            return message.Text.ToLower().Contains(value);
        }

        public static bool IsValid(this PointD point)
        {
            return point.X != 0 && point.Y != 0;
        }
    }
}