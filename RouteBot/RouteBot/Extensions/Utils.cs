using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}