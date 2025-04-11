using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiServices.Models;
using WebApiServices.Models.Datos;
using WebApiServices.Models.Entidades;
using WebApiServices.Models.Request;

namespace WebApiServices.Controllers
{
    public class MensajeriaController : ApiController
    {

        #region Mensaje

        //[HttpPost]
        //[Route("api/Mensajeria/ListarMensaje")]
        //public IEnumerable<WCO_ListarMensaje_Result> ListarMensaje(WCO_ListarMensaje_Result ObjDetalle)
        //{
        //    List<WCO_ListarMensaje_Result> lst = new List<WCO_ListarMensaje_Result>();
        //    try
        //    {
        //        ADDAT_Mensajeria Reserva = new ADDAT_Mensajeria();
        //        lst = Reserva.ListarMensaje(ObjDetalle);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return lst;
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("api/Mensajeria/MantenimientoMensaje/{id}")]
        //public async Task<IHttpActionResult> MantenimientoMensaje(int id, [FromBody] WCO_ListarMensaje_Result ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();
        //    try
        //    {
        //        ADDAT_Mensajeria Reserva = new ADDAT_Mensajeria();
        //        int valor = 0;
        //        if (id < 1 || id == null) { return NotFound(); }
        //        else if (id == 1)
        //        {
        //            valor = Reserva.InsertarMensaje(ObjDetalle);
        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                objLogin.data = null;
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Created";
        //                ObjDetalle = valor;
        //                objLogin.data = ObjDetalle;
        //                statusCode = HttpStatusCode.Created;
        //            }
        //        }
        //        else if (id == 2)
        //        {
        //            valor = Reserva.ActualizarMensaje(ObjDetalle);
        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = 1;
        //                objLogin.mensaje = "Ok";
        //                statusCode = HttpStatusCode.OK;
        //            }

        //        }
        //        else if (id == 3)
        //        {
        //            Reserva.InactivarMensaje(ObjDetalle);
        //            objLogin.success = true;
        //            objLogin.valor = 1;
        //            objLogin.mensaje = "Ok";
        //            statusCode = HttpStatusCode.OK;
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //        return Content(statusCode, objLogin);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
        //    }
        //}

        #endregion

        #region Programacion          

        //[HttpPost]
        //[Route("api/Mensajeria/ListarMensajeProgramacion")]
        //public IEnumerable<WCO_ListarMensajeProgramacion_Result> ListarMensajeProgramacion(WCO_ListarMensajeProgramacion_Result ObjDetalle)
        //{
        //    List<WCO_ListarMensajeProgramacion_Result> lst = new List<WCO_ListarMensajeProgramacion_Result>();
        //    try
        //    {
        //        ADDAT_Mensajeria conexi = new ADDAT_Mensajeria();
        //        lst = conexi.ListarMensajeProgramacion(ObjDetalle);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return lst;
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("api/Mensajeria/MantenimientoProgramacion/{id}")]
        //public async Task<IHttpActionResult> MantenimientoProgramacion(int id, [FromBody] ClassMensajeria ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();
        //    ADDAT_Mensajeria conexi = new ADDAT_Mensajeria();
        //    try
        //    {
        //        int valor = 0;
        //        if (id == 1)
        //        {
        //            if (ObjDetalle.Detalle.Count > 0)
        //            {
        //                //using (TransactionScope scope = new TransactionScope())
        //                //{
        //                //    try
        //                //    {
        //                List<WCO_ListarMensajeProgramacion_Result> lst = new List<WCO_ListarMensajeProgramacion_Result>();
        //                valor = conexi.InsertarMensajeProgramacion(ObjDetalle.Programacion);
        //                foreach (WCO_ListarMensajeProgramacionPersona_Result ResDet in ObjDetalle.Detalle)
        //                {
        //                    ResDet.IdProgramacion = valor;
        //                    conexi.InsertarMensajeProgramacionDetalle(ResDet);
        //                }
        //                //        scope.Complete();
        //                //        scope.Dispose();
        //                //    }
        //                //    catch (TransactionAbortedException ex)
        //                //    {
        //                //        scope.Dispose();
        //                //    }
        //                //    catch (ApplicationException ex)
        //                //    {
        //                //        scope.Dispose();
        //                //    }
        //                //}
        //            }

        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                objLogin.data = null;
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Created";
        //                objLogin.data = ObjDetalle;
        //                statusCode = HttpStatusCode.Created;
        //            }
        //        }
        //        else if (id == 2)
        //        {
        //            valor = conexi.ActualizarMensajeProgramacion(ObjDetalle.Programacion);
        //            WCO_ListarMensajeProgramacionPersona_Result objeli = new WCO_ListarMensajeProgramacionPersona_Result();
        //            objeli.IdProgramacion = ObjDetalle.Programacion.IdProgramacion;
        //            conexi.EliminarMensajeProgramacionDetalle(objeli);
        //            foreach (WCO_ListarMensajeProgramacionPersona_Result ResDet in ObjDetalle.Detalle)
        //            {
        //                ResDet.IdProgramacion = ObjDetalle.Programacion.IdProgramacion;
        //                conexi.InsertarMensajeProgramacionDetalle(ResDet);
        //            }

        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = 1;
        //                objLogin.mensaje = "Ok";
        //                statusCode = HttpStatusCode.OK;
        //            }

        //        }
        //        else if (id == 3)
        //        {
        //            conexi.InactivarMensajeProgramacion(ObjDetalle.Programacion);
        //            objLogin.success = true;
        //            objLogin.valor = 1;
        //            objLogin.mensaje = "Ok";
        //            statusCode = HttpStatusCode.OK;
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //        return Content(statusCode, objLogin);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
        //    }
        //}

        //[HttpPost]
        //[Route("api/Mensajeria/ListarMensajeProgramacionDetalle")]
        //public IEnumerable<WCO_ListarMensajeProgramacionPersona_Result> ListarMensajeProgramacionDetalle(WCO_ListarMensajeProgramacionPersona_Result ObjDetalle)
        //{
        //    List<WCO_ListarMensajeProgramacionPersona_Result> lst = new List<WCO_ListarMensajeProgramacionPersona_Result>();
        //    try
        //    {
        //        ADDAT_Mensajeria conexi = new ADDAT_Mensajeria();
        //        lst = conexi.ListarMensajeProgramacionPersona(ObjDetalle);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return lst;
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("api/Mensajeria/MantenimientoProgramacionDetalle/{id}")]
        //public async Task<IHttpActionResult> MantenimientoProgramacionDetalle(int id, [FromBody] WCO_ListarMensajeProgramacionPersona_Result ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();
        //    ADDAT_Mensajeria conexi = new ADDAT_Mensajeria();
        //    try
        //    {
        //        int valor = 0;
        //        if (id == 1)
        //        {
        //            valor = conexi.InsertarMensajeProgramacionDetalle(ObjDetalle);

        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                objLogin.data = null;
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Created";
        //                objLogin.data = ObjDetalle;
        //                statusCode = HttpStatusCode.Created;
        //            }
        //        }
        //        else if (id == 2)
        //        {
        //            valor = conexi.ActualizarMensajeProgramacionDetalle(ObjDetalle);
        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = 1;
        //                objLogin.mensaje = "Ok";
        //                statusCode = HttpStatusCode.OK;
        //            }

        //        }
        //        else if (id == 3)
        //        {
        //            conexi.EliminarMensajeProgramacionDetalle(ObjDetalle);
        //            objLogin.success = true;
        //            objLogin.valor = 1;
        //            objLogin.mensaje = "Ok";
        //            statusCode = HttpStatusCode.OK;
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //        return Content(statusCode, objLogin);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
        //    }
        //}


        //[HttpPost]
        //[Route("api/Mensajeria/ListarMensajeApp")]
        //public async Task<IHttpActionResult> ListarMensajeApp(ClassMensajeApp ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();
        //    ADDAT_Mensajeria conexi = new ADDAT_Mensajeria();
        //    try
        //    {
        //        List<WCO_ListarMensajeProgramacion_Result> lst = new List<WCO_ListarMensajeProgramacion_Result>();
        //        WCO_ListarMensajeProgramacion_Result Objaaa = new WCO_ListarMensajeProgramacion_Result();
        //        Objaaa.FechaInicio = Convert.ToDateTime(ObjDetalle.Fecha);
        //        Objaaa.FechaFin = Convert.ToDateTime(ObjDetalle.Fecha);
        //        Objaaa.Estado = 1;
        //        lst = conexi.ListarMensajeProgramacion(Objaaa);
        //        if (lst.Count > 0)
        //        {
        //            List<ClassMensajeria> Mensajeria = new List<ClassMensajeria>(); 
        //            foreach (var xmsj in lst)
        //            {
        //                ClassMensajeria clas = new ClassMensajeria();
        //                List<WCO_ListarMensaje_Result> lsttipomsj = new List<WCO_ListarMensaje_Result>();   
        //                ADDAT_Mensajeria Reserva = new ADDAT_Mensajeria();
        //                WCO_ListarMensaje_Result Objtipo = new WCO_ListarMensaje_Result();
        //                Objtipo.IdMensaje = xmsj.IdMensaje;
        //                lsttipomsj = Reserva.ListarMensaje(Objtipo);
        //                foreach (var xtipo in lsttipomsj)
        //                {
        //                    xmsj.Codigo = xtipo.Mensaje;
        //                }                        
        //                WCO_ListarMensajeProgramacionPersona_Result Objxx = new WCO_ListarMensajeProgramacionPersona_Result();
        //                List<WCO_ListarMensajeProgramacionPersona_Result> lstxxx = new List<WCO_ListarMensajeProgramacionPersona_Result>();
        //                Objxx.IdProgramacion = xmsj.IdProgramacion;
        //                lstxxx = conexi.ListarMensajeProgramacionPersona(Objxx);
        //                clas.Programacion = xmsj;
        //                clas.Detalle = lstxxx;
        //                Mensajeria.Add(clas);
        //            }
        //            objLogin.success = true;
        //            objLogin.valor = lst.Count;
        //            objLogin.mensaje = "lista";
        //            objLogin.data = Newtonsoft.Json.JsonConvert.SerializeObject(Mensajeria);
        //            statusCode = HttpStatusCode.Created;
        //        }
        //        else
        //        {
        //            objLogin.success = false;
        //            objLogin.valor = 0;
        //            objLogin.mensaje = "Los campos ingresados no coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //            objLogin.data = null;
        //            statusCode = HttpStatusCode.OK;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objLogin.success = false;
        //        objLogin.valor = -1;
        //        objLogin.mensaje = ex.Message;
        //        objLogin.data = null;
        //        statusCode = HttpStatusCode.OK;
        //    }

        //    return Content(statusCode, objLogin);

        //}


        #endregion

    }
}
