using System;

namespace WebApiServices.Models.Request
{
    public class ViewModalExite
    {
        public bool success { get; set; }

        public Nullable<int> valor { get; set; }

        public string tokem { get; set; }

        public string mensaje { get; set; }

        public object data { get; set; }

    }
}