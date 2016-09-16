using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YandexAPI;

namespace RouteBot.Data
{
    public class RouteDescription
    {
        public Route Route { get; set; }
        public string Result { get; set; } = "Route was not found";
    }
}