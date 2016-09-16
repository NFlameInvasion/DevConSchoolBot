using System;

namespace RouteBot.Data
{
    [Serializable]
    public class RouteData
    {
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }

        public RouteDescription Description { get; set; } 
    }
}