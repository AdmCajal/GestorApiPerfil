using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_Mensajeria
    {

        //public List<WCO_ListarMensaje_Result> ListarMensaje(WCO_ListarMensaje_Result ObjEntidad)
        //{
        //    List<WCO_ListarMensaje_Result> lst = new List<WCO_ListarMensaje_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarMensaje(ObjEntidad.IdMensaje, ObjEntidad.IdEmpresa, ObjEntidad.Codigo, ObjEntidad.Nombre,
        //            ObjEntidad.TipoMensaje, ObjEntidad.Estado).ToList();
        //    }
        //    return lst;
        //}

        //public int InsertarMensaje(WCO_ListarMensaje_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = Convert.ToInt32(context.WCO_InsertarMensaje(ObjEntidad.IdMensaje, ObjEntidad.IdEmpresa, ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.TipoMensaje,
        //            ObjEntidad.Asunto, ObjEntidad.Mensaje, ObjEntidad.Estado, ObjEntidad.UsuarioCreacion, ObjEntidad.IpCreacion).FirstOrDefault());
        //    }
        //    return valor;
        //}

        //public int ActualizarMensaje(WCO_ListarMensaje_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_ActualizarMensaje(ObjEntidad.IdMensaje, ObjEntidad.IdEmpresa, ObjEntidad.Codigo, ObjEntidad.Nombre,
        //            ObjEntidad.TipoMensaje, ObjEntidad.Asunto, ObjEntidad.Mensaje, ObjEntidad.Estado,
        //            ObjEntidad.UsuarioModificacion, ObjEntidad.IpModificacion);
        //    }
        //    return valor;
        //}

        //public int InactivarMensaje(WCO_ListarMensaje_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_InactivarMensaje(ObjEntidad.IdMensaje, ObjEntidad.Estado, ObjEntidad.UsuarioModificacion, "");
        //    }
        //    return valor;
        //}


        //public List<WCO_ListarMensajeProgramacion_Result> ListarMensajeProgramacion(WCO_ListarMensajeProgramacion_Result ObjEntidad)
        //{
        //    List<WCO_ListarMensajeProgramacion_Result> lst = new List<WCO_ListarMensajeProgramacion_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarMensajeProgramacion(ObjEntidad.IdProgramacion, ObjEntidad.IdMensaje, ObjEntidad.TipoMensaje,
        //           ObjEntidad.IdResponsable, ObjEntidad.IdEmpresa, ObjEntidad.Responsable, ObjEntidad.Documento, ObjEntidad.TipoDocumento,
        //              ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.FechaInicio, ObjEntidad.FechaFin, ObjEntidad.Estado).ToList();
        //    }
        //    return lst;
        //}

        //public int InsertarMensajeProgramacion(WCO_ListarMensajeProgramacion_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = Convert.ToInt32(context.WCO_InsertarMensajeProgramacion(ObjEntidad.IdProgramacion, ObjEntidad.IdMensaje,
        //            ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.IdResponsable, ObjEntidad.TipoProgramacion, 0, ObjEntidad.FechaInicio,
        //            ObjEntidad.FechaFin, ObjEntidad.HoraInicio, ObjEntidad.HoraFin, ObjEntidad.Total,
        //            ObjEntidad.Estado, ObjEntidad.UsuarioCreacion, ObjEntidad.IpCreacion).FirstOrDefault());
        //    }
        //    return valor;
        //}

        //public int ActualizarMensajeProgramacion(WCO_ListarMensajeProgramacion_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_ActualizarMensajeProgramacion(ObjEntidad.IdProgramacion, ObjEntidad.IdMensaje,
        //            ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.IdResponsable, ObjEntidad.TipoProgramacion, 0, ObjEntidad.FechaInicio,
        //            ObjEntidad.FechaFin, ObjEntidad.HoraInicio, ObjEntidad.HoraFin, ObjEntidad.Total,
        //            ObjEntidad.TotalEnviado, ObjEntidad.TotalExito, ObjEntidad.TotalError,
        //            ObjEntidad.Estado, ObjEntidad.UsuarioModificacion, ObjEntidad.IpModificacion);
        //    }
        //    return valor;
        //}

        //public int InactivarMensajeProgramacion(WCO_ListarMensajeProgramacion_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_InactivarMensajeProgramacion(ObjEntidad.IdProgramacion, ObjEntidad.Codigo, ObjEntidad.Estado, ObjEntidad.UsuarioModificacion, ObjEntidad.IpModificacion);
        //    }
        //    return valor;
        //}


        //public List<WCO_ListarMensajeProgramacionPersona_Result> ListarMensajeProgramacionPersona(WCO_ListarMensajeProgramacionPersona_Result ObjEntidad)
        //{
        //    List<WCO_ListarMensajeProgramacionPersona_Result> lst = new List<WCO_ListarMensajeProgramacionPersona_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        WCO_ListarMensajeProgramacion_Result ENTY = new WCO_ListarMensajeProgramacion_Result();

        //        lst = context.WCO_ListarMensajeProgramacionPersona(ObjEntidad.IdProgramacion, ObjEntidad.Codigo,
        //            ObjEntidad.Estado).ToList();
        //    }
        //    return lst;
        //}

        //public int InsertarMensajeProgramacionDetalle(WCO_ListarMensajeProgramacionPersona_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = Convert.ToInt32(context.WCO_InsertarMensajeProgramacionPersona(ObjEntidad.Id, ObjEntidad.IdProgramacion,
        //        ObjEntidad.IdPersona, ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.Indicador,
        //            ObjEntidad.Estado, ObjEntidad.UsuarioCreacion, ObjEntidad.IpCreacion).FirstOrDefault());
        //    }
        //    return valor;
        //}

        //public int ActualizarMensajeProgramacionDetalle(WCO_ListarMensajeProgramacionPersona_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_ActualizarMensajeProgramacionPersona(ObjEntidad.Id, ObjEntidad.IdProgramacion,
        //        ObjEntidad.IdPersona, ObjEntidad.Codigo, ObjEntidad.Nombre, ObjEntidad.Indicador,
        //            ObjEntidad.Estado, ObjEntidad.UsuarioModificacion, ObjEntidad.IpModificacion, 0);
        //    }
        //    return valor;
        //}

        //public int EliminarMensajeProgramacionDetalle(WCO_ListarMensajeProgramacionPersona_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        valor = context.WCO_EliminarMensajeProgramacionPersona(ObjEntidad.Id, ObjEntidad.IdProgramacion);
        //    }
        //    return valor;
        //}
    }
}