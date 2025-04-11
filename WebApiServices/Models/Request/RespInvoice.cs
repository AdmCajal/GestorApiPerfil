using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models.Request
{
    public class InvoiceResponse
    {
        public Invoice Invoice { get; set; }
    }

    public class Invoice
    {
        public string serie { get; set; }
        public string numero { get; set; }
        public string key { get; set; }
        public string aceptada_por_sunat { get; set; }
        public string sunat_description { get; set; }
        public string sunat_note { get; set; }
        public string sunat_responsecode { get; set; }
        public string digest_value { get; set; }
        public string codigo_de_barras { get; set; }
        public string link_pdf { get; set; }


    }
}