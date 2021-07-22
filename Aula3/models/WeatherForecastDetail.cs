using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula3.models
{
    public class WeatherForecastDetail
    {
        public string By { get; set; }
        public bool Valid_key { get; set; }
        public Result Results { get; set; }
        public float Execution_Time { get; set; }
        public bool From_cache { get; set; }
    }
    public class Result
    {
        public int Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Condition_Code { get; set; }
        public string Description { get; set; }
        public string Currently { get; set; }
        public string Cid { get; set; }
        public string City { get; set; }
        public string Img_id { get; set; }
        public string Humidity { get; set; }
        public string Wind_speedy { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Condition_slug { get; set; }
        public string City_name { get; set; }
        public List<Forecast> forecast { get; set; }
    }

    public class Forecast 
    {
        public string Date { get; set; }
        public string Weekday { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
    }
}
