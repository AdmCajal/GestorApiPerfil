using System;

namespace WebApiServices.Models.Request
{
    public class ViewResponse
    {
        public Boolean ok { get; set; }
        public Object msg { get; set; }
        public Nullable<int> valor { get; set; }
        public string tokem { get; set; }
    }
}