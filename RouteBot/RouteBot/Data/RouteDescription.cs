using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RouteBot.Data
{
    public class RouteDescription
    {
        public double Length { get; set; } //km
        public string Result { get; set; } = "Route was not found";
    }
}