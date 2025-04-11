using System;

namespace WebApiServices.Models.Request
{
    public class Archivo
    {
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public long lastModified { get; set; }
        public DateTime lastModifiedDate { get; set; }
    }
}