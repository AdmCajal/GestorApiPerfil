using System;

namespace WebApiServices.Models.Request
{
    public class Perfil
    {
        public string perfil { get; set; }
        public Nullable<int> tipousuario { get; set; }
        public string desestado { get; set; }
        public string ultimousuario { get; set; }
        public string estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> UltimaFechaModif { get; set; }
        public object ListaPaginas { get; set; }

        // public List<file> ListaPaginas { get; set; }
        // public List<WCO_ListarMenuOpcionesPerfil_Result> ListaPaginas { get; set; }

    }
}