//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiServices.Models
{
    using System;
    
    public partial class WCO_ListarTablaMaestroArchivo_Result
    {
        public int Id { get; set; }
        public string Tabla { get; set; }
        public int IdTabla { get; set; }
        public int Linea { get; set; }
        public string NombrePDF { get; set; }
        public string Contenido { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string ESTADOdesc { get; set; }
    }
}
