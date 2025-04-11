using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiServices.Models;
using WebApiServices.Models.Datos;
using WebApiServices.Models.Request;

namespace WebApiServices.Controllers
{
    public class MaestroController : ApiController
    {
        Metodos m = new Metodos();
        UT_Kerberos Ker = new UT_Kerberos();
        ADDAT_Sede sd = new ADDAT_Sede();
        ADDAT_PersonaMast per = new ADDAT_PersonaMast();
        ADDAT_Parametro Para = new ADDAT_Parametro();
        ADDAT_TipoCambio tipcam = new ADDAT_TipoCambio();
        ADDAT_CuentaBancaria CuentaBancaria = new ADDAT_CuentaBancaria();

        #region Maestro

        [HttpPost]
        [Route("api/Maestro/ListaTablasMaestras")]
        public IEnumerable<WCO_ListarTablasMaestras_Result> ListaTablasMaestras(WCO_ListarTablasMaestras_Result ObjDetalle)
        {
            List<WCO_ListarTablasMaestras_Result> lst = new List<WCO_ListarTablasMaestras_Result>();
            try
            {
                ADDAT_TablaMaestroDetalle MaDet = new ADDAT_TablaMaestroDetalle();
                lst = MaDet.ListaTablasMaestras(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoTablaMaestro/{id}")]
        public async Task<IHttpActionResult> MantenimientoTablaMaestro(int id, [FromBody] WCO_ListarTablasMaestras_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            ADDAT_TablaMaestroDetalle MaDet = new ADDAT_TablaMaestroDetalle();
            try
            {
                int valor = 0;
                if (id < 1) { return NotFound(); }
                else if (id == 1)
                {
                    valor = MaDet.InsertarTablaMaestro(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        ObjDetalle.IdTablaMaestro = valor;
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = MaDet.ActualizarTablaMaestro(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    MaDet.InactivarTablaMaestro(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }

        #endregion

        #region Parametros
        [HttpPost]
        [Route("api/Maestro/ListaParametros")]
        public IEnumerable<WCO_ListarParametro_Result> ListaParametro(WCO_ListarParametro_Result ObjDetalle)
        {
            List<WCO_ListarParametro_Result> lst = new List<WCO_ListarParametro_Result>();
            try
            {
                lst = Para.ListaParametro(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoParametro/{id}")]
        public async Task<IHttpActionResult> MantenimientoParametro(int id, [FromBody] WCO_ListarParametro_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();

            try
            {
                string valor = "0";
                if (ObjDetalle.ParametroClave != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.ParametroClave.ToString()))
                    {
                        ObjDetalle.ParametroClave = ObjDetalle.ParametroClave.ToUpper();
                    }
                }
                if (ObjDetalle.DescripcionParametro != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.DescripcionParametro.ToString()))
                    {
                        ObjDetalle.DescripcionParametro = ObjDetalle.DescripcionParametro.ToUpper();
                    }
                }
                if (ObjDetalle.Explicacion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Explicacion.ToString()))
                    {
                        ObjDetalle.Explicacion = ObjDetalle.Explicacion.ToUpper();
                    }
                }
                if (ObjDetalle.Texto != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Texto.ToString()))
                    {
                        ObjDetalle.Explicacion = ObjDetalle.Texto.ToUpper();
                    }
                }
                if (id == 1)
                {
                    valor = Para.InsertarParametro(ObjDetalle);
                    if (valor == "falso")
                    {
                        objLogin.success = false;
                        objLogin.valor = 0;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Created";
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = Para.ActualizarParametro(ObjDetalle);
                    if (valor == "falso")
                    {
                        objLogin.success = false;
                        objLogin.valor = 0;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.OK;
                    }
                }
                else if (id == 3)
                {
                    ObjDetalle.Estado = "I";
                    valor = Para.ActualizarParametro(ObjDetalle);
                    if (valor == "falso")
                    {
                        objLogin.success = false;
                        objLogin.valor = 0;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.OK;
                    }
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.StackTrace, valor = -1 });
            }
        }


        #endregion

        #region MaestroDetalleTabla

        [Route("api/Maestro/ListaTablaMaestroDetalle")]
        public IEnumerable<WCO_ListarTablaMaestroDetalle_Result> ListaTablaMaestroDetalle(WCO_ListarTablaMaestroDetalle_Result ObjDetalle)
        {
            List<WCO_ListarTablaMaestroDetalle_Result> lst = new List<WCO_ListarTablaMaestroDetalle_Result>();
            try
            {
                ADDAT_TablaMaestroDetalle MaDet = new ADDAT_TablaMaestroDetalle();
                lst = MaDet.ListaTablaMaestroDetalle(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }


        [HttpPost]
        [Route("api/Maestro/ListaMaestroDetalle")]
        public IEnumerable<WCO_ListarTMAestroDetalles_Result> ListaMaestroDetalle(WCO_ListarTMAestroDetalles_Result ObjDetalle)
        {
            List<WCO_ListarTMAestroDetalles_Result> lst = new List<WCO_ListarTMAestroDetalles_Result>();
            try
            {
                ADDAT_TablaMaestroDetalle MaDet = new ADDAT_TablaMaestroDetalle();
                lst = MaDet.ListaMaestroDetalle(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoMaestroDetalle/{id}")]
        public async Task<IHttpActionResult> MantenimientoMaestroDetalle(int id, [FromBody] WCO_ListarTMAestroDetalles_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            ADDAT_TablaMaestroDetalle MaDet = new ADDAT_TablaMaestroDetalle();
            try
            {
                int valor = 0;
                if (ObjDetalle.Codigo != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Codigo.ToString()))
                    {
                        ObjDetalle.Codigo = ObjDetalle.Codigo.ToUpper();
                    }
                }
                if (ObjDetalle.Nombre != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Nombre.ToString()))
                    {
                        ObjDetalle.Nombre = ObjDetalle.Nombre.ToUpper();
                    }
                }
                if (ObjDetalle.Descripcion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Descripcion.ToString()))
                    {
                        ObjDetalle.Descripcion = ObjDetalle.Descripcion.ToUpper();
                    }
                }
                if (id == 1)
                {
                    valor = MaDet.InsertarMaestroDetalle(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        ObjDetalle.IdTablaMaestro = valor;
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = MaDet.ActualizarMaestroDetalle(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    MaDet.InactivarMaestroDetalle(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }

        #endregion

        #region Ubigeo
        [HttpPost]
        [Route("api/Maestro/ListaUbigeo")]
        public IEnumerable<WCO_ListarUbigeo_Result> ListaUbigeo(WCO_ListarUbigeo_Result ObjDetalle)
        {
            List<WCO_ListarUbigeo_Result> lst = new List<WCO_ListarUbigeo_Result>();
            try
            {
                lst = m.ListaUbigeo(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }
        #endregion

        #region Persona

        [HttpPost]
        [Route("api/Maestro/ListaPersona")]
        public IEnumerable<WCO_ListarPersonasGeneral_Result> ListaPersona(WCO_ListarPersonasGeneral_Result ObjDetalle)
        {
            List<WCO_ListarPersonasGeneral_Result> lst = new List<WCO_ListarPersonasGeneral_Result>();
            try
            {
                lst = per.ListaPersona(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [HttpPost]
        [Route("api/Maestro/TraerXPersonaId")]
        public IEnumerable<WCO_TraerXCodigoPersonaId_Result> TraerXPersonaId(WCO_ListarPersonasGeneral_Result ObjDetalle)
        {
            List<WCO_TraerXCodigoPersonaId_Result> lst = new List<WCO_TraerXCodigoPersonaId_Result>();
            try
            {
                lst = per.TraerXPersonaId(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        //[HttpPost]
        //[Route("api/Maestro/ListaPersonaUsuario")]
        //public IEnumerable<WCO_BUSCARPERSONAUSUARIO_Result> ListaPersonaUsuario(WCO_BUSCARPERSONAUSUARIO_Result ObjDetalle)
        //{
        //    List<WCO_BUSCARPERSONAUSUARIO_Result> lst = new List<WCO_BUSCARPERSONAUSUARIO_Result>();
        //    try
        //    {
        //        lst = per.ListaPersonaUsuario(ObjDetalle);
        //    }
        //    catch
        //    {

        //    }
        //    return lst;
        //}

        //[Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoPersona/{id}")]
        public async Task<IHttpActionResult> MantenimientoPersona(int id, [FromBody] WCO_ListarPersonasGeneral_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            int valor = 0;
            try
            {
                if (ObjDetalle.TipoPersona != null)
                {
                    if (ObjDetalle.TipoPersona == "N")
                    {
                        if (ObjDetalle.Nombres != null)
                        {
                            if (!string.IsNullOrEmpty(ObjDetalle.Nombres.ToString()))
                            {
                                ObjDetalle.Nombres = ObjDetalle.Nombres.ToUpper();
                            }
                        }
                        if (ObjDetalle.ApellidoPaterno != null)
                        {
                            if (!string.IsNullOrEmpty(ObjDetalle.ApellidoPaterno.ToString()))
                            {
                                ObjDetalle.ApellidoPaterno = ObjDetalle.ApellidoPaterno.ToUpper();
                            }
                        }
                        else
                        {
                            valor = -2;
                        }
                        if (ObjDetalle.ApellidoMaterno != null)
                        {
                            if (!string.IsNullOrEmpty(ObjDetalle.ApellidoMaterno.ToString()))
                            {
                                ObjDetalle.ApellidoMaterno = ObjDetalle.ApellidoMaterno.ToUpper();
                            }
                        }
                    }
                    else
                    {
                        if (ObjDetalle.Nombres != null)
                        {
                            if (!string.IsNullOrEmpty(ObjDetalle.Nombres.ToString()))
                            {
                                ObjDetalle.Nombres = ObjDetalle.Nombres.ToUpper();
                            }
                        }
                        if (ObjDetalle.NombreCompleto != null)
                        {
                            if (!string.IsNullOrEmpty(ObjDetalle.NombreCompleto.ToString()))
                            {
                                ObjDetalle.NombreCompleto = ObjDetalle.NombreCompleto.ToUpper();
                            }
                        }

                    }
                }

                if (ObjDetalle.Documento != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Documento.ToString()))
                    {
                        ObjDetalle.Documento = ObjDetalle.Documento.ToUpper();
                    }
                }
                else
                {
                    valor = -2;
                }

                if (ObjDetalle.CorreoElectronico != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.CorreoElectronico.ToString()))
                    {
                        ObjDetalle.CorreoElectronico = ObjDetalle.CorreoElectronico.ToUpper();
                    }
                }
                if (ObjDetalle.DireccionReferencia != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.DireccionReferencia.ToString()))
                    {
                        ObjDetalle.DireccionReferencia = ObjDetalle.DireccionReferencia.ToUpper();
                    }
                }
                if (ObjDetalle.Direccion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Direccion.ToString()))
                    {
                        ObjDetalle.Direccion = ObjDetalle.Direccion.ToUpper();
                    }
                }
                if (ObjDetalle.Comentario != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Comentario.ToString()))
                    {
                        ObjDetalle.Comentario = ObjDetalle.Comentario.ToUpper();
                    }
                }


                if (id < 1 || id == null) { return NotFound(); }
                else if (id == 1)
                {
                    valor = per.InsertarPersona(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        ObjDetalle.Persona = valor;
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = per.ActualizarPersona(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    per.InactivarPersona(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }


        //[Authorize]
        //[HttpPost]
        //[Route("api/Maestro/MantenimientoUsuarioWebExternos/{id}")]
        //public async Task<IHttpActionResult> MantenimientoUsuarioWebExternos(int id, [FromBody] WCO_ListarUsuarioWeb_Result ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();

        //    try
        //    {
        //        int valor = 0;
        //        if (id < 1 || id == null) { return NotFound(); }
        //        else if (id == 1)
        //        {
        //            valor = per.InsertarUsuarioWeb(ObjDetalle);
        //            if (valor > 0)
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Created";
        //                ObjDetalle.IdPersona = valor;
        //                objLogin.data = ObjDetalle;
        //                statusCode = HttpStatusCode.Created;
        //            }
        //            else
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                objLogin.data = null;
        //                statusCode = HttpStatusCode.OK;
        //            }
        //        }
        //        else if (id == 2)
        //        {
        //            valor = per.ActualizarUsuarioWeb(ObjDetalle);
        //            if (valor > 0)
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = 1;
        //                objLogin.mensaje = "Ok";
        //                statusCode = HttpStatusCode.OK;

        //            }
        //            else
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                statusCode = HttpStatusCode.OK;
        //            }

        //        }
        //        return Content(statusCode, objLogin);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
        //    }
        //}

        //[HttpPost]
        //[Route("api/Maestro/ListaUsuarioWeb")]
        //public IEnumerable<WCO_ListarUsuarioWeb_Result> ListaUsuarioWeb(WCO_ListarUsuarioWeb_Result ObjDetalle)
        //{
        //    List<WCO_ListarUsuarioWeb_Result> lst = new List<WCO_ListarUsuarioWeb_Result>();
        //    try
        //    {
        //        lst = per.ListarUsuarioWeb(ObjDetalle);
        //    }
        //    catch
        //    {

        //    }
        //    return lst;
        //}

        //[HttpPost]
        //[Route("api/Maestro/ListarConsentimiento")]
        //public IEnumerable<Sp_PDP_validacion_Result> ListarConsentimiento(WCO_ListarPersonasGeneral_Result ObjDetalle)
        //{
        //    List<Sp_PDP_validacion_Result> lst = new List<Sp_PDP_validacion_Result>();
        //    try
        //    {
        //        lst = per.ListarConsentimiento(ObjDetalle);
        //    }
        //    catch
        //    {

        //    }
        //    return lst;
        //}


        #endregion

        #region MaestroSede

        [HttpPost]
        [Route("api/Maestro/ListaSede")]
        public IEnumerable<WCO_ListarSede_Result> ListaSede(WCO_ListarSede_Result ObjDetalle)
        {
            List<WCO_ListarSede_Result> lst = new List<WCO_ListarSede_Result>();
            try
            {
                lst = sd.ListadoPaginado(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [HttpPost]
        [Route("api/Maestro/MantenimientoSede/{id}")]
        public async Task<IHttpActionResult> MantenimientoSede(int id, [FromBody] WCO_ListarSede_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();

            try
            {
                int valor = 0;
                if (ObjDetalle.SedCodigo != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.SedCodigo.ToString()))
                    {
                        ObjDetalle.SedCodigo = ObjDetalle.SedCodigo.ToUpper();
                    }
                }
                if (ObjDetalle.SedDescripcion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.SedDescripcion.ToString()))
                    {
                        ObjDetalle.SedDescripcion = ObjDetalle.SedDescripcion.ToUpper();
                    }
                }
                if (ObjDetalle.Direccion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Direccion.ToString()))
                    {
                        ObjDetalle.Direccion = ObjDetalle.Direccion.ToUpper();

                    }
                }

                if (id == 1)
                {
                    valor = sd.Insertar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        if (valor == -2)
                        {
                            objLogin.mensaje = "Ya Existe el Nombre. Por favor ingrese un nuevo valor";
                        }
                        if (valor == -3)
                        {
                            objLogin.mensaje = "Ya Existe el código. Por favor ingrese un nuevo valor";
                        }
                        if (valor == -1)
                        {
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        }
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        ObjDetalle.IdSede = valor;
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = sd.Actualizar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        if (valor == -2)
                        {
                            objLogin.mensaje = "Ya Existe el Nombre del Medico. Por favor ingrese un nuevo valor";
                        }
                        if (valor == -3)
                        {
                            objLogin.mensaje = "Ya Existe el código para el Médico. Por favor ingrese un nuevo valor";
                        }
                        if (valor == -4)
                        {
                            objLogin.mensaje = "Ya Existe el DNI para el Médico. Por favor ingrese un nuevo valor";
                        }
                        if (valor == -1)
                        {
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        }
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    sd.Inactivar(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }


        //[Route("api/Maestro/ListadoSedeHistoria")]
        //public IEnumerable<WCO_TraerXIdSede_Result> ListadoSedeHistoria(WCO_TraerXIdSede_Result ObjDetalle)
        //{
        //    List<WCO_TraerXIdSede_Result> lst = new List<WCO_TraerXIdSede_Result>();
        //    try
        //    {
        //        lst = sd.ListadoSedeHistoria(ObjDetalle);
        //    }
        //    catch
        //    {

        //    }
        //    return lst;
        //}


        //[HttpPost]
        //[Route("api/Maestro/MantenimientoSedeCliente/{id}")]
        //public async Task<IHttpActionResult> MantenimientoSedeCliente(int id, [FromBody] WCO_ListarSedeCliente_Result ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();

        //    try
        //    {
        //        int valor = 0;
        //        if (id < 1 || id == null) { return NotFound(); }
        //        else if (id == 1)
        //        {
        //            sd.InsertarSedeCliente(ObjDetalle);
        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                if (valor == -2)
        //                {
        //                    objLogin.mensaje = "Ya Existe el Nombre. Por favor ingrese un nuevo valor";
        //                }
        //                if (valor == -3)
        //                {
        //                    objLogin.mensaje = "Ya Existe el código. Por favor ingrese un nuevo valor";
        //                }
        //                if (valor == -1)
        //                {
        //                    objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                }
        //                objLogin.data = null;
        //                statusCode = HttpStatusCode.OK;
        //            }
        //            else
        //            {
        //                objLogin.success = true;
        //                objLogin.valor = valor;
        //                objLogin.mensaje = "Created";
        //                ObjDetalle.IdSede = valor;
        //                objLogin.data = ObjDetalle;
        //                statusCode = HttpStatusCode.Created;
        //            }
        //        }

        //        else if (id == 3)
        //        {
        //            sd.InactivarSedeCliente(ObjDetalle);
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


        //[Route("api/Maestro/ListadoSedePrinter")]
        //public IEnumerable<WCO_ListarSedePrinter_Result> ListadoSedePrinter(WCO_ListarSedePrinter_Result ObjDetalle)
        //{
        //    List<WCO_ListarSedePrinter_Result> lst = new List<WCO_ListarSedePrinter_Result>();
        //    try
        //    {
        //        lst = sd.ListadoSedePrinter(ObjDetalle);
        //    }
        //    catch
        //    {

        //    }
        //    return lst;
        //}


        //[HttpPost]
        //[Route("api/Maestro/MantenimientoSedePrinter/{id}")]
        //public async Task<IHttpActionResult> MantenimientoSedePrinter(int id, [FromBody] WCO_ListarSedePrinter_Result ObjDetalle)
        //{
        //    ViewModalExite objLogin = new ViewModalExite();
        //    HttpStatusCode statusCode = new HttpStatusCode();

        //    try
        //    {
        //        int valor = 0;
        //        if (id < 1 || id == null) { return NotFound(); }
        //        else if (id == 1)
        //        {
        //            sd.InsertarSedePrinter(ObjDetalle);
        //            if (valor < 0)
        //            {
        //                objLogin.success = false;
        //                objLogin.valor = valor;
        //                if (valor == -2)
        //                {
        //                    objLogin.mensaje = "Ya Existe el Nombre. Por favor ingrese un nuevo valor";
        //                }
        //                if (valor == -3)
        //                {
        //                    objLogin.mensaje = "Ya Existe el código. Por favor ingrese un nuevo valor";
        //                }
        //                if (valor == -1)
        //                {
        //                    objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
        //                }
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

        //        else if (id == 3)
        //        {
        //            sd.EliminarSedePrinter(ObjDetalle);
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

        #region TipoCambio 
        [HttpPost]
        [Route("api/Maestro/ListadoTipoCambio")]
        public IEnumerable<WCO_ListarTipoCambioMast_Result> ListadoTipoCambio(WCO_ListarTipoCambioMast_Result ObjDetalle)
        {
            List<WCO_ListarTipoCambioMast_Result> lst = new List<WCO_ListarTipoCambioMast_Result>();
            try
            {
                lst = tipcam.ListarTipoCambioMast(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoTipoCambio/{id}")]
        public async Task<IHttpActionResult> MantenimientoTipoCambio(int id, [FromBody] WCO_ListarTipoCambioMast_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                int valor = 0;
                switch (id)
                {
                    case 1:
                        valor = tipcam.Insertar(ObjDetalle);
                        if (valor < 0)
                        {
                            objLogin.success = false;
                            objLogin.valor = valor;
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            objLogin.data = null;
                            statusCode = HttpStatusCode.OK;
                        }
                        else
                        {
                            objLogin.success = true;
                            objLogin.valor = valor;
                            objLogin.mensaje = "Created";
                            objLogin.data = ObjDetalle;
                            statusCode = HttpStatusCode.Created;
                        }
                        break;
                    case 2:
                        valor = tipcam.Actualizar(ObjDetalle);
                        if (valor < 0)
                        {
                            objLogin.success = false;
                            objLogin.valor = valor;
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            statusCode = HttpStatusCode.OK;
                        }
                        else
                        {
                            objLogin.success = true;
                            objLogin.valor = 1;
                            objLogin.mensaje = "Ok";
                            statusCode = HttpStatusCode.OK;
                        }
                        break;

                    case 3:
                        tipcam.Inactivar(ObjDetalle);
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                        break;
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }

        #endregion

        #region Banco 

        [HttpPost]
        [Route("api/Maestro/ListarBanco")]
        public IEnumerable<WCO_ListarBanco_Result> ListarBanco(WCO_ListarBanco_Result ObjDetalle)
        {
            ADDAT_Banco Ban = new ADDAT_Banco();
            List<WCO_ListarBanco_Result> lst = new List<WCO_ListarBanco_Result>();
            try
            {
                lst = Ban.ListarBanco(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoBanco/{id}")]
        public async Task<IHttpActionResult> MantenimientoBanco(int id, [FromBody] WCO_ListarBanco_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            ADDAT_Banco Ban = new ADDAT_Banco();
            try
            {
                string valor = "0";
                if (ObjDetalle.DescripcionCorta != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.DescripcionCorta.ToString()))
                    {
                        ObjDetalle.DescripcionCorta = ObjDetalle.DescripcionCorta.ToUpper();
                    }
                }
                if (ObjDetalle.CorreoElectronico != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.CorreoElectronico.ToString()))
                    {
                        ObjDetalle.CorreoElectronico = ObjDetalle.CorreoElectronico.ToUpper();
                    }
                }
                if (ObjDetalle.DescripcionLarga != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.DescripcionLarga.ToString()))
                    {
                        ObjDetalle.DescripcionLarga = ObjDetalle.DescripcionLarga.ToUpper();

                    }
                }


                switch (id)
                {
                    case 1:
                        valor = Ban.Insertar(ObjDetalle);
                        if (valor != null)
                        {
                            //objLogin.success = false;
                            //objLogin.valor = 0;
                            //objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            //objLogin.data = null;
                            //statusCode = HttpStatusCode.OK;
                            objLogin.success = true;
                            objLogin.valor = 1;
                            objLogin.mensaje = "Created";
                            objLogin.data = ObjDetalle;
                            statusCode = HttpStatusCode.Created;
                        }
                        else
                        {
                            objLogin.success = false;
                            objLogin.valor = 0;
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            objLogin.data = null;
                            statusCode = HttpStatusCode.OK;
                        }
                        break;
                    case 2:
                        valor = Ban.Actualizar(ObjDetalle);
                        if (valor != "0")
                        {
                            objLogin.success = true;
                            objLogin.valor = 1;
                            objLogin.mensaje = "Ok";
                            statusCode = HttpStatusCode.OK;
                            //objLogin.success = false;
                            //objLogin.valor = 0;
                            //objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            //statusCode = HttpStatusCode.OK;
                        }
                        else
                        {
                            objLogin.success = false;
                            objLogin.valor = 0;
                            objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                            statusCode = HttpStatusCode.OK;
                        }
                        break;

                    case 3:
                        Ban.Inactivar(ObjDetalle);
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                        break;
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }

        #endregion

        #region CuentaBancaria 

        [HttpPost]
        [Route("api/Maestro/ListarCuentaBancaria")]
        public IEnumerable<WCO_ListarCuentaBancaria_Result> ListarCuentaBancaria(WCO_ListarCuentaBancaria_Result ObjDetalle)
        {
            List<WCO_ListarCuentaBancaria_Result> lst = new List<WCO_ListarCuentaBancaria_Result>();
            try
            {
                lst = CuentaBancaria.Listar(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }


        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoCuentaBancaria/{id}")]
        public async Task<IHttpActionResult> MantenimientoCuentaBancaria(int id, [FromBody] WCO_ListarCuentaBancaria_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();

            try
            {
                int valor = 0;
                if (ObjDetalle.DescripcionCorta != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.DescripcionCorta.ToString()))
                    {
                        ObjDetalle.DescripcionCorta = ObjDetalle.DescripcionCorta.ToUpper();
                    }
                }
                if (ObjDetalle.CuentaBancaria != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.CuentaBancaria.ToString()))
                    {
                        ObjDetalle.CuentaBancaria = ObjDetalle.CuentaBancaria.ToUpper();
                    }
                }
                if (ObjDetalle.Descripcion != null)
                {
                    if (!string.IsNullOrEmpty(ObjDetalle.Descripcion.ToString()))
                    {
                        ObjDetalle.Descripcion = ObjDetalle.Descripcion.ToUpper();
                    }
                }

                if (id == 1)
                {
                    valor = CuentaBancaria.Insertar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        //ObjDetalle = valor;
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = CuentaBancaria.Actualizar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    CuentaBancaria.Inactivar(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }


        #endregion

        #region EmpleadoMast

        [HttpPost]
        [Route("api/Maestro/ListarEmpleadoMast")]
        public IEnumerable<WCO_ListarEmpleados_Result> ListarEmpleadoMast(WCO_ListarEmpleados_Result ObjDetalle)
        {
            ADDAT_EmpleadoMast Empleado = new ADDAT_EmpleadoMast();
            List<WCO_ListarEmpleados_Result> lst = new List<WCO_ListarEmpleados_Result>();
            try
            {
                lst = Empleado.ListarEmpleados(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoEmpleado/{id}")]
        public async Task<IHttpActionResult> MantenimientoEmpleado(int id, [FromBody] WCO_ListarEmpleados_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            ADDAT_EmpleadoMast Empleado = new ADDAT_EmpleadoMast();
            statusCode = HttpStatusCode.OK;
            try
            {
                int valor = 0;
                if (id == 2)
                {
                    valor = Empleado.Actualizar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }
                }
                else if (id == 3)
                {
                    Empleado.Inactivar(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }


        #endregion

        #region CorrelativosMast

        [HttpPost]
        [Route("api/Maestro/ListarCorrelativosMast")]
        public IEnumerable<WCO_ListarCorrelativosMast_Result> ListarCorrelativosMast(WCO_ListarCorrelativosMast_Result ObjDetalle)
        {
            List<WCO_ListarCorrelativosMast_Result> lst = new List<WCO_ListarCorrelativosMast_Result>();
            try
            {
                ADDAT_CorrelativosMast Mant = new ADDAT_CorrelativosMast();
                lst = Mant.ListarCorrelativosMast(ObjDetalle);
            }
            catch
            {

            }
            return lst;
        }

        [Authorize]
        [HttpPost]
        [Route("api/Maestro/MantenimientoCorrelativosMast/{id}")]
        public async Task<IHttpActionResult> MantenimientoCorrelativosMast(int id, [FromBody] WCO_ListarCorrelativosMast_Result ObjDetalle)
        {
            ViewModalExite objLogin = new ViewModalExite();
            HttpStatusCode statusCode = new HttpStatusCode();
            ADDAT_CorrelativosMast Mant = new ADDAT_CorrelativosMast();
            try
            {
                int valor = 0;

                if (id == 1)
                {
                    valor = Mant.Insertar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        objLogin.data = null;
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Created";
                        objLogin.data = ObjDetalle;
                        statusCode = HttpStatusCode.Created;
                    }
                }
                else if (id == 2)
                {
                    valor = Mant.Actualizar(ObjDetalle);
                    if (valor < 0)
                    {
                        objLogin.success = false;
                        objLogin.valor = valor;
                        objLogin.mensaje = "Los campos ingresados coinciden con un registro en nuestra base. Por favor ingrese un nuevo valor";
                        statusCode = HttpStatusCode.OK;
                    }
                    else
                    {
                        objLogin.success = true;
                        objLogin.valor = 1;
                        objLogin.mensaje = "Ok";
                        statusCode = HttpStatusCode.OK;
                    }

                }
                else if (id == 3)
                {
                    Mant.Inactivar(ObjDetalle);
                    objLogin.success = true;
                    objLogin.valor = 1;
                    objLogin.mensaje = "Ok";
                    statusCode = HttpStatusCode.OK;
                }
                else
                {
                    return BadRequest();
                }
                return Content(statusCode, objLogin);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new ViewModalExite() { success = false, mensaje = ex.Message, valor = -1 });
            }
        }

        #endregion
  
    }
}
