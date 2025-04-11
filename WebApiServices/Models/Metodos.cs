using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApiServices.Models.Entidades;

namespace WebApiServices.Models
{
    public class Metodos
    {
        //static string Co_ConnecPrecisa = ConfigurationManager.ConnectionStrings["ConexionReportes"].ConnectionString;

        public void InsertarWServicioLog(ADBE_WServicioLog obj_pWServicioLog)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_InsertarWServicioLog");
            try
            {
                Parameter[] prm_Params = new Parameter[11];
                prm_Params[0] = new Parameter("@IdCodigo", obj_pWServicioLog.Pk.IdCodigo);
                prm_Params[1] = new Parameter("@Secuencia", obj_pWServicioLog.Pk.Secuencia);
                prm_Params[2] = new Parameter("@TipoMsj", obj_pWServicioLog.TipoMsj);
                prm_Params[3] = new Parameter("@Sucursal", obj_pWServicioLog.Sucursal);
                prm_Params[4] = new Parameter("@CodigoOA", obj_pWServicioLog.CodigoOA);
                prm_Params[5] = new Parameter("@IdSede", obj_pWServicioLog.IdSede);
                prm_Params[6] = new Parameter("@FechaIni", obj_pWServicioLog.FechaIni);
                prm_Params[7] = new Parameter("@FechaFin", obj_pWServicioLog.FechaFin);
                prm_Params[8] = new Parameter("@Parametros", obj_pWServicioLog.Parametros);
                prm_Params[9] = new Parameter("@Trama", obj_pWServicioLog.Trama);
                prm_Params[10] = new Parameter("@Observacion", obj_pWServicioLog.Observacion);
                dop_DataOperation.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region usuario
        public List<WCO_AccesoUsuario_Result> ListaAccesoUsuario(WCO_AccesoUsuario_Result ObjUsuario)
        {
            List<WCO_AccesoUsuario_Result> lst = new List<WCO_AccesoUsuario_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_AccesoUsuario(ObjUsuario.Usuario, ObjUsuario.Clave, ObjUsuario.IdSede, ObjUsuario.Persona, ObjUsuario.Documento, ObjUsuario.ExpirarPasswordFlag).ToList();
            }
            return lst;
        }

        ///<summary>Método para listar registros de la tabla Usuario con paginación</summary>
        ///<param name="obj_pBEPerfil">Entidad de Negocio</param>
        ///<returns>Listado de los registros de la página actual.</returns>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado Por Isaac Jurado</CreadoPor></item>
        ///<item><FecCrea>09/12/2011</FecCrea></item></list></remarks>
        public List<WCO_LISTARASIGNARPERFILPAG_Result> ListaUsuario(WCO_LISTARASIGNARPERFILPAG_Result obj_pBEPerfil)
        {
            List<WCO_LISTARASIGNARPERFILPAG_Result> lst = new List<WCO_LISTARASIGNARPERFILPAG_Result>();
            using (var context = new BDInmobiliariaEntities())
            {


                lst = context.WCO_LISTARASIGNARPERFILPAG(obj_pBEPerfil.PERFIL, obj_pBEPerfil.USUARIO, obj_pBEPerfil.NOMBRECOMPLETO).ToList();
            }
            return lst;
        }
        ///<summary>Método para listar registros de la tabla Usuario con paginación</summary>
        ///<param name="obj_pBEPerfil">Entidad de Negocio</param>
        ///<returns>Listado de los registros de la página actual.</returns>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado Por Isaac Jurado</CreadoPor></item>
        ///<item><FecCrea>09/12/2011</FecCrea></item></list></remarks>
        //public List<WCO_TRAERUSUARIOXCODIGO_Result> TrareUsuarioxCodigo(WCO_TRAERUSUARIOXCODIGO_Result obj_pBEPerfil)
        //{
        //    List<WCO_TRAERUSUARIOXCODIGO_Result> lst = new List<WCO_TRAERUSUARIOXCODIGO_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_TRAERUSUARIOXCODIGO(obj_pBEPerfil.USUARIO).ToList();
        //    }
        //    return lst;
        //}


        public bool Exiteusuario(WCO_AccesoUsuario_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_Exiteusuario");
            Parameter[] prm_Params = new Parameter[2];
            prm_Params[0] = new Parameter("@pUsuario", obj_pBEUsuario.Usuario);
            prm_Params[1] = new Parameter("@pExiste", DbType.Int32);
            dop_DataOperation.Parameters.AddRange(prm_Params);

            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            if (Convert.ToInt32(dop_DataOperation.GetParameterByName("@pExiste").Value) == 1)
            {
                return true;
            }
            return false;
        }

        public void Insertarusuario(WCO_AccesoUsuario_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_INSERTARUSUARIO");
            try
            {
                Parameter[] prm_Params = new Parameter[9];
                prm_Params[0] = new Parameter("@USUARIO", obj_pBEUsuario.Documento);
                prm_Params[1] = new Parameter("@NOMBRE", obj_pBEUsuario.NombreCompleto);
                prm_Params[2] = new Parameter("@PERSONA", obj_pBEUsuario.Persona);
                prm_Params[3] = new Parameter("@ULTIMOUSUARIO", obj_pBEUsuario.UltimoUsuario);
                prm_Params[4] = new Parameter("@Tipousuario", obj_pBEUsuario.TipoUsuario);
                prm_Params[5] = new Parameter("@PERFIL", obj_pBEUsuario.UsuarioPerfil);
                prm_Params[6] = new Parameter("@IdSede", obj_pBEUsuario.IdSede);
                prm_Params[7] = new Parameter("@IdClasificadorMovimiento", obj_pBEUsuario.ClasificadorMovimiento);
                prm_Params[8] = new Parameter("@PASSWORD", obj_pBEUsuario.Clave);
                dop_DataOperation.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inactivarusuario(WCO_AccesoUsuario_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_INACTIVARUSUARIO");
            Parameter[] prm_Params = new Parameter[2];
            prm_Params[0] = new Parameter("@USUARIO", obj_pBEUsuario.Usuario);
            prm_Params[1] = new Parameter("@ULTIMOUSUARIO", obj_pBEUsuario.UltimoUsuario);
            dop_DataOperation.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        }

        public void Actualizarusuario(WCO_AccesoUsuario_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_ACTUALIZARUSUARIO");
            try
            {
                Parameter[] prm_Params = new Parameter[10];
                prm_Params[0] = new Parameter("@USUARIO", obj_pBEUsuario.Usuario);
                prm_Params[1] = new Parameter("@EXPERIRARPASSWORDFLAG", obj_pBEUsuario.ExpirarPasswordFlag);
                prm_Params[2] = new Parameter("@ESTADO", obj_pBEUsuario.Estado);
                prm_Params[3] = new Parameter("@ULTIMOUSUARIO", obj_pBEUsuario.UltimoUsuario);
                prm_Params[4] = new Parameter("@Tipousuario", obj_pBEUsuario.TipoUsuario);
                prm_Params[5] = new Parameter("@PERFIL", obj_pBEUsuario.UsuarioPerfil);
                prm_Params[6] = new Parameter("@NOMBRE", obj_pBEUsuario.NombreCompleto);
                prm_Params[7] = new Parameter("@IdSede", obj_pBEUsuario.IdSede);
                prm_Params[8] = new Parameter("@IdClasificadorMovimiento", obj_pBEUsuario.ClasificadorMovimiento);
                prm_Params[9] = new Parameter("@PASSWORD", obj_pBEUsuario.Clave);
                dop_DataOperation.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<WCO_ListarUsuarioSede_Result> ListaUsuarioSede(WCO_ListarUsuarioSede_Result obj_pBEUsuSede)
        //{
        //    List<WCO_ListarUsuarioSede_Result> lst = new List<WCO_ListarUsuarioSede_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarUsuarioSede(obj_pBEUsuSede.Usuario, obj_pBEUsuSede.IdSede).ToList();
        //    }
        //    return lst;
        //}

        //public void Insertarusuariosede(WCO_ListarUsuarioSede_Result obj_pBEUsuSede)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_InsertarUsuarioSede");
        //    try
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_InsertarUsuarioSede");
        //        Parameter[] prm_Params = new Parameter[4];
        //        prm_Params[0] = new Parameter("@usuario", obj_pBEUsuSede.Usuario);
        //        prm_Params[1] = new Parameter("@IdSede", obj_pBEUsuSede.IdSede);
        //        prm_Params[2] = new Parameter("@UsuarioCreacion", obj_pBEUsuSede.UsuarioCreacion);
        //        prm_Params[3] = new Parameter("@IpCreacion", obj_pBEUsuSede.IpCreacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void Actualizarusuariosede(WCO_ListarUsuarioSede_Result obj_pBEUsuSede)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_INSERTARUSUARIO");
        //    try
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_ActualizarUsuarioSede");
        //        Parameter[] prm_Params = new Parameter[4];
        //        prm_Params[0] = new Parameter("@usuario", obj_pBEUsuSede.Usuario);
        //        prm_Params[1] = new Parameter("@IdSede", obj_pBEUsuSede.IdSede);
        //        prm_Params[2] = new Parameter("@UsuarioModificacion", obj_pBEUsuSede.UsuarioCreacion);
        //        prm_Params[3] = new Parameter("@IpModificacion", obj_pBEUsuSede.IpCreacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion

        #region Perfiles
        public List<WCO_PerfilPaginas_Result> ListaPerfilPaginas(WCO_PerfilPaginas_Result ObjPaginas)
        {
            List<WCO_PerfilPaginas_Result> lst = new List<WCO_PerfilPaginas_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_PerfilPaginas(ObjPaginas.Usuario, ObjPaginas.TipodeDetalle, ObjPaginas.Perfil, ObjPaginas.ORDEN, ObjPaginas.Perfil).ToList();
            }
            return lst;
        }




        public List<WCO_ListarMenuOpcionesPerfil_Result> WCO_ListarMenuOpcionesPerfil(WCO_LISTARPERFILPAG_Result ObjPaginas)
        {
            List<WCO_ListarMenuOpcionesPerfil_Result> lst = new List<WCO_ListarMenuOpcionesPerfil_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarMenuOpcionesPerfil(ObjPaginas.Perfil, "").ToList();
            }
            return lst;
        }

        #endregion

        #region Portal
        //public List<WCO_ListarPortal_Result> ListaPortal(WCO_ListarPortal_Result ObjPortal)
        //{
        //    List<WCO_ListarPortal_Result> lst = new List<WCO_ListarPortal_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {

        //        lst = context.WCO_ListarPortal(ObjPortal.IdPortal, ObjPortal.Estado).ToList();

        //    }
        //    return lst;
        //}

        //public static void ActualizarPortal(WCO_ListarPortal_Result objBEPortal)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_ActualizarPortal");
        //    Parameter[] prm_Params = new Parameter[9];
        //    prm_Params[0] = new Parameter("@IdPortal", objBEPortal.IdPortal);
        //    prm_Params[1] = new Parameter("@Logo", objBEPortal.Logo);
        //    prm_Params[2] = new Parameter("@RutaImagen", objBEPortal.RutaImagen);
        //    prm_Params[3] = new Parameter("@Direccion", objBEPortal.Direccion);
        //    prm_Params[4] = new Parameter("@Telefono", objBEPortal.Telefono);
        //    prm_Params[5] = new Parameter("@Correo", objBEPortal.Correo);
        //    prm_Params[6] = new Parameter("@Estado", objBEPortal.Estado);
        //    prm_Params[7] = new Parameter("@UsuarioModificacion", objBEPortal.UsuarioModificacion);
        //    prm_Params[8] = new Parameter("@IpModificacion", objBEPortal.IpModificacion);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}
        #endregion





        #region Ubigeo
        public List<WCO_ListarUbigeo_Result> ListaUbigeo(WCO_ListarUbigeo_Result ObjUbigeo)
        {
            List<WCO_ListarUbigeo_Result> lst = new List<WCO_ListarUbigeo_Result>();
            using (var context = new BDInmobiliariaEntities())
            {

                lst = context.WCO_ListarUbigeo(ObjUbigeo.Codigo, ObjUbigeo.Num).ToList();

            }
            return lst;
        }

        #endregion


        #region Especialidad

        //public List<WCO_ListarEspecialidad_Result> ListaEspecialidad(WCO_ListarEspecialidad_Result ObjEspecialidad)
        //{
        //    List<WCO_ListarEspecialidad_Result> lst = new List<WCO_ListarEspecialidad_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarEspecialidad(ObjEspecialidad.IndicadorWeb, ObjEspecialidad.Codigo, ObjEspecialidad.Descripcion, ObjEspecialidad.Estado).ToList();
        //    }
        //    return lst;
        //}

        #endregion

        #region TipoAdmision
        //public List<WCO_ListarTipodeAdmision_Result> ListaTipoAdmision(WCO_ListarTipodeAdmision_Result ObjResul)
        //{
        //    List<WCO_ListarTipodeAdmision_Result> lst = new List<WCO_ListarTipodeAdmision_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarTipodeAdmision(ObjResul.AdmCodigo, ObjResul.AdmDescripcion, ObjResul.AdmEstado).ToList();
        //    }
        //    return lst;
        //}

        //public int InsertarTipoAdmision(WCO_ListarTipodeAdmision_Result objBETipoAdmision)
        //{
        //    int valor = 0;
        //    bool isExists = false;
        //    isExists = ValidarExisteDescTipoAdmision(objBETipoAdmision);
        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_InsertarTipoAdmision");
        //        Parameter[] prm_Params = new Parameter[8];
        //        prm_Params[0] = new Parameter("@UneuNegocioId", objBETipoAdmision.UneuNegocioId);
        //        prm_Params[1] = new Parameter("@TipoAdmisionId", DbType.Int32);
        //        prm_Params[2] = new Parameter("@AdmCodigo", objBETipoAdmision.AdmCodigo);
        //        prm_Params[3] = new Parameter("@AdmDescripcion", objBETipoAdmision.AdmDescripcion);
        //        prm_Params[4] = new Parameter("@AdmEstado", objBETipoAdmision.AdmEstado);
        //        prm_Params[5] = new Parameter("@FechaCreacion", objBETipoAdmision.FechaCreacion);
        //        prm_Params[6] = new Parameter("@UsuarioCreacion", objBETipoAdmision.UsuarioCreacion);
        //        prm_Params[7] = new Parameter("@IpCreacion", objBETipoAdmision.IpCreacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //        return int.Parse(dop_Operacion.GetParameterByName("@TipoAdmisionId").Value.ToString());
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public int ActualizarTipoAdmision(WCO_ListarTipodeAdmision_Result objBETipoAdmision)
        //{
        //    int valor = 0;
        //    bool isExists = false;
        //    isExists = ValidarExisteDescTipoAdmision(objBETipoAdmision);

        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_ActualizarTipoAdmision");
        //        Parameter[] prm_Params = new Parameter[8];
        //        prm_Params[0] = new Parameter("@UneuNegocioId", objBETipoAdmision.TipoAdmisionId);
        //        prm_Params[1] = new Parameter("@TipoAdmisionId", objBETipoAdmision.TipoAdmisionId);
        //        prm_Params[2] = new Parameter("@AdmCodigo", objBETipoAdmision.AdmCodigo);
        //        prm_Params[3] = new Parameter("@AdmDescripcion", objBETipoAdmision.AdmDescripcion);
        //        prm_Params[4] = new Parameter("@AdmEstado", objBETipoAdmision.AdmEstado);
        //        prm_Params[5] = new Parameter("@FechaModificacion", objBETipoAdmision.FechaCreacion);
        //        prm_Params[6] = new Parameter("@UsuarioModificacion", objBETipoAdmision.UsuarioCreacion);
        //        prm_Params[7] = new Parameter("@IpModificacion", objBETipoAdmision.IpCreacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public void InactivarTipoAdmision(WCO_ListarTipodeAdmision_Result objBETipoAdmision)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InactivarTipoAdmision");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@TipoAdmisionId", objBETipoAdmision.TipoAdmisionId);
        //    prm_Params[1] = new Parameter("@UsuarioModificacion", objBETipoAdmision.UsuarioCreacion);
        //    prm_Params[2] = new Parameter("@IpModificacion", objBETipoAdmision.IpCreacion);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}

        //public static bool ValidarExisteDescTipoAdmision(WCO_ListarTipodeAdmision_Result objBETipoAdmision)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_EXISTEDescTipoAdmision");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@TipoAdmisionId", objBETipoAdmision.TipoAdmisionId);
        //    prm_Params[1] = new Parameter("@admdescripcion", objBETipoAdmision.AdmDescripcion);
        //    prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
        //    dop_DataOperation.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        //    if (Convert.ToInt32(dop_DataOperation.GetParameterByName("@flagSalida").Value) >= 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        #endregion



        #region Aseguradora

        //public List<WCO_ListarAseguradora_Result> ListaAseguradora(WCO_ListarAseguradora_Result BE_Aseguradora)
        //{
        //    List<WCO_ListarAseguradora_Result> lst = new List<WCO_ListarAseguradora_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarAseguradora(BE_Aseguradora.NombreEmpresa, BE_Aseguradora.IdAseguradora, BE_Aseguradora.Estado).ToList();
        //    }
        //    return lst;
        //}

        //public int InsertarAseguradora(WCO_ListarAseguradora_Result objBEAseguradora)
        //{
        //    int valor = 0;
        //    WCO_ListarAseguradora_Result obj = new WCO_ListarAseguradora_Result()
        //    {
        //        IdAseguradora = 0,
        //        NombreEmpresa = ""
        //    };

        //    bool isExists = false;
        //    isExists = ListaAseguradora(obj).Exists(x => x.IdAseguradora == objBEAseguradora.IdAseguradora && x.NombreEmpresa == objBEAseguradora.NombreEmpresa
        //    || x.NombreEmpresa == objBEAseguradora.NombreEmpresa);

        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_InsertarAseguradora");
        //        Parameter[] prm_Params = new Parameter[5];
        //        prm_Params[0] = new Parameter("@Nombre", objBEAseguradora.NombreEmpresa);
        //        prm_Params[1] = new Parameter("@Clasificacion", objBEAseguradora.Clasificacion_1);
        //        prm_Params[2] = new Parameter("@IdAseguradora", DbType.Int32);
        //        prm_Params[3] = new Parameter("@TipoAseguradora", objBEAseguradora.TipoAseguradora);
        //        prm_Params[4] = new Parameter("@Estado", objBEAseguradora.Estado);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //        return int.Parse(dop_Operacion.GetParameterByName("@IdAseguradora").Value.ToString());
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public int ActualizarAseguradora(WCO_ListarAseguradora_Result objBEAseguradora)
        //{
        //    int valor = 0;
        //    WCO_ListarAseguradora_Result obj = new WCO_ListarAseguradora_Result()
        //    {
        //        IdAseguradora = 0,
        //        NombreEmpresa = ""
        //    };

        //    bool isExists = false;
        //    isExists = ListaAseguradora(obj).Exists(x => x.IdAseguradora == objBEAseguradora.IdAseguradora && x.NombreEmpresa == objBEAseguradora.NombreEmpresa
        //    || x.NombreEmpresa == objBEAseguradora.NombreEmpresa);

        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_ActualizarAseguradora");
        //        Parameter[] prm_Params = new Parameter[5];
        //        prm_Params[0] = new Parameter("@IdAseguradora", objBEAseguradora.IdAseguradora);
        //        prm_Params[1] = new Parameter("@Nombre", objBEAseguradora.NombreEmpresa);
        //        prm_Params[2] = new Parameter("@Clasificacion", objBEAseguradora.Clasificacion_1);
        //        prm_Params[3] = new Parameter("@TipoAseguradora", objBEAseguradora.TipoAseguradora);
        //        prm_Params[4] = new Parameter("@Estado", objBEAseguradora.Estado);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public void InactivarAseguradora(WCO_ListarAseguradora_Result objBEAseguradora)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InactivarAseguradora");
        //    Parameter[] prm_Params = new Parameter[2];
        //    prm_Params[0] = new Parameter("@IdAseguradora", objBEAseguradora.IdAseguradora);
        //    prm_Params[1] = new Parameter("@Estado", objBEAseguradora.Estado);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}

        #endregion

        #region Medico

        //public List<WCO_ListarMedico_Result> ListarMedico(WCO_ListarMedico_Result ObjResul)
        //{
        //    List<WCO_ListarMedico_Result> lst = new List<WCO_ListarMedico_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarMedico(ObjResul.Nombres, ObjResul.Estado, ObjResul.TipoDocumento, ObjResul.Documento, ObjResul.CMP, ObjResul.MedicoId, ObjResul.IdEspecialidad).ToList();
        //    }
        //    return lst;
        //}

        ///<summary>Insertar el registro en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param>
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/02/2013</FecCrea></item></list></remarks>
        //public int InsertarMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    int valor = 0;
        //    bool isExists = true;
        //    if (!ValidarExisteMedico(objBEMedico))
        //    {
        //        valor = -2;
        //        return valor;
        //    }
        //    if (!ValidarExisteCodigoMedico(objBEMedico))
        //    {
        //        valor = -3;
        //        return valor;
        //    }
        //    if (!string.IsNullOrEmpty(objBEMedico.Documento))
        //    {
        //        if (!ValidarExisteDNIMedico(objBEMedico))
        //        {
        //            valor = -4;
        //            return valor;
        //        }
        //    }

        //    if (objBEMedico.ApellidoMaterno != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.ApellidoMaterno.ToString()))
        //        {
        //            objBEMedico.ApellidoMaterno = objBEMedico.ApellidoMaterno.ToUpper();
        //        }
        //    }

        //    if (objBEMedico.ApellidoPaterno != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.ApellidoPaterno.ToString()))
        //        {
        //            objBEMedico.ApellidoPaterno = objBEMedico.ApellidoPaterno.ToUpper();
        //        }
        //    }

        //    if (objBEMedico.Nombres != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.Nombres.ToString()))
        //        {
        //            objBEMedico.Nombres = objBEMedico.Nombres.ToUpper();
        //        }
        //    }
        //    if (objBEMedico.Busqueda != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.Busqueda.ToString()))
        //        {
        //            objBEMedico.Busqueda = objBEMedico.Busqueda.ToUpper();
        //        }
        //    }

        //    DataOperation dop_Operacion = new DataOperation("WCO_InsertarMedico");
        //    Parameter[] prm_Params = new Parameter[16];
        //    prm_Params[0] = new Parameter("@ApellidoMaterno", objBEMedico.ApellidoMaterno);
        //    prm_Params[1] = new Parameter("@ApellidoPaterno", objBEMedico.ApellidoPaterno);
        //    prm_Params[2] = new Parameter("@Nombres", objBEMedico.Nombres);
        //    prm_Params[3] = new Parameter("@NombreCompleto", objBEMedico.Busqueda);
        //    prm_Params[4] = new Parameter("@TipoDocumento", objBEMedico.TipoDocumento);
        //    prm_Params[5] = new Parameter("@Documento", objBEMedico.Documento);
        //    prm_Params[6] = new Parameter("@CMP", objBEMedico.CMP);
        //    prm_Params[7] = new Parameter("@Estado", objBEMedico.Estado);
        //    prm_Params[8] = new Parameter("@IpCreacion", objBEMedico.IpCreacion);
        //    prm_Params[9] = new Parameter("@UsuarioCreacion", objBEMedico.UsuarioCreacion);
        //    prm_Params[10] = new Parameter("@MedicoId", DbType.Int32);
        //    prm_Params[11] = new Parameter("@Correo", objBEMedico.Correo);
        //    prm_Params[12] = new Parameter("@RNE", objBEMedico.RNE);
        //    prm_Params[13] = new Parameter("@Sexo", objBEMedico.Sexo);
        //    prm_Params[14] = new Parameter("@Telefono", objBEMedico.Telefono);
        //    prm_Params[15] = new Parameter("@IdEspecialidad", objBEMedico.IdEspecialidad);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    return int.Parse(dop_Operacion.GetParameterByName("@MedicoId").Value.ToString());

        //    //return valor;
        //}

        ///<summary>Actualizar el registro en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param>
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/02/2013</FecCrea></item></list></remarks>
        //public int ActualizarMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    int valor = 0;
        //    bool isExists = true;
        //    if (!ValidarExisteMedico(objBEMedico))
        //    {
        //        valor = -2;
        //        return valor;
        //    }
        //    if (!ValidarExisteCodigoMedico(objBEMedico))
        //    {
        //        valor = -3;
        //        return valor;
        //    }
        //    if (!string.IsNullOrEmpty(objBEMedico.Documento))
        //    {
        //        if (!ValidarExisteDNIMedico(objBEMedico))
        //        {
        //            valor = -4;
        //            return valor;
        //        }
        //    }
        //    if (objBEMedico.ApellidoMaterno != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.ApellidoMaterno.ToString()))
        //        {
        //            objBEMedico.ApellidoMaterno = objBEMedico.ApellidoMaterno.ToUpper();
        //        }
        //    }

        //    if (objBEMedico.ApellidoPaterno != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.ApellidoPaterno.ToString()))
        //        {
        //            objBEMedico.ApellidoPaterno = objBEMedico.ApellidoPaterno.ToUpper();
        //        }
        //    }

        //    if (objBEMedico.Nombres != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.Nombres.ToString()))
        //        {
        //            objBEMedico.Nombres = objBEMedico.Nombres.ToUpper();
        //        }
        //    }
        //    if (objBEMedico.Busqueda != null)
        //    {
        //        if (!string.IsNullOrEmpty(objBEMedico.Busqueda.ToString()))
        //        {
        //            objBEMedico.Busqueda = objBEMedico.Busqueda.ToUpper();
        //        }
        //    }
        //    DataOperation dop_Operacion = new DataOperation("WCO_ActualizarMedico");
        //    Parameter[] prm_Params = new Parameter[16];
        //    prm_Params[0] = new Parameter("@ApellidoMaterno", objBEMedico.ApellidoMaterno);
        //    prm_Params[1] = new Parameter("@ApellidoPaterno", objBEMedico.ApellidoPaterno);
        //    prm_Params[2] = new Parameter("@Nombres", objBEMedico.Nombres);
        //    prm_Params[3] = new Parameter("@NombreCompleto", objBEMedico.Busqueda);
        //    prm_Params[4] = new Parameter("@TipoDocumento", objBEMedico.TipoDocumento);
        //    prm_Params[5] = new Parameter("@Documento", objBEMedico.Documento);
        //    prm_Params[6] = new Parameter("@CMP", objBEMedico.CMP);
        //    prm_Params[7] = new Parameter("@Estado", objBEMedico.Estado);
        //    prm_Params[8] = new Parameter("@UltimoIp", objBEMedico.IpModificacion);
        //    prm_Params[9] = new Parameter("@UsuarioModificacion", objBEMedico.UsuarioModificacion);
        //    prm_Params[10] = new Parameter("@MedicoId", objBEMedico.MedicoId);
        //    prm_Params[11] = new Parameter("@Correo", objBEMedico.Correo);
        //    prm_Params[12] = new Parameter("@RNE", objBEMedico.RNE);
        //    prm_Params[13] = new Parameter("@Sexo", objBEMedico.Sexo);
        //    prm_Params[14] = new Parameter("@Telefono", objBEMedico.Telefono);
        //    prm_Params[15] = new Parameter("@IdEspecialidad", objBEMedico.IdEspecialidad);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    valor = objBEMedico.MedicoId;
        //    return valor;
        //}

        ///<summary>Inactiva el registro en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param> 
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        //public void InactivarMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InactivarMedico");
        //    Parameter[] prm_Params = new Parameter[4];
        //    prm_Params[0] = new Parameter("@Estado", objBEMedico.Estado);
        //    prm_Params[1] = new Parameter("@UltimoIp", objBEMedico.IpModificacion);
        //    prm_Params[2] = new Parameter("@UsuarioModificacion", objBEMedico.UsuarioModificacion);
        //    prm_Params[3] = new Parameter("@MedicoId", objBEMedico.MedicoId);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}

        ///<summary>Valida el Nombre Completo en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param>
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/02/2013</FecCrea></item></list></remarks>
        //public static bool ValidarExisteMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_ExisteMedico");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@MedicoId", objBEMedico.MedicoId);
        //    prm_Params[1] = new Parameter("@NombreCompleto", objBEMedico.Busqueda);
        //    prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
        //    dop_DataOperation.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        //    if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///<summary>Valida el CMP en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param>
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/02/2013</FecCrea></item></list></remarks>
        //public static bool ValidarExisteCodigoMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_ExisteMedicoCodigo");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@MedicoId", objBEMedico.MedicoId);
        //    prm_Params[1] = new Parameter("@CMP", objBEMedico.CMP);
        //    prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
        //    dop_DataOperation.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        //    if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///<summary>Valida el CMP en la tabla Medico.</summary>
        ///<param name="objBEMedico">Entidad de Negocio</param>
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/02/2013</FecCrea></item></list></remarks>
        //public static bool ValidarExisteDNIMedico(WCO_ListarMedico_Result objBEMedico)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_ExisteMedicoDNI");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@MedicoId", objBEMedico.MedicoId);
        //    prm_Params[1] = new Parameter("@Documento", objBEMedico.Documento);
        //    prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
        //    dop_DataOperation.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        //    if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        #endregion

        #region eeeeeeeeeeeee


        #endregion

        //public int InsertarPreAdmision(WCO_ListarPreCarga_Result Obj_PreAdmision)
        //{
        //    System.Nullable<int> iReturnValue;
        //    int valorRetorno = 0; //ERROR
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        try
        //        {
        //            iReturnValue = context.WCO_InsertarPreAdmision(Obj_PreAdmision.IdPreAdmision, Obj_PreAdmision.FechaProgramacion, Obj_PreAdmision.TipoOperacionId,
        //                Obj_PreAdmision.Cliente, Obj_PreAdmision.Acceso, Obj_PreAdmision.Servicio,
        //                Obj_PreAdmision.Sucursal, Obj_PreAdmision.CodigoHC, Obj_PreAdmision.CodigoOA,
        //                Obj_PreAdmision.TipoAtencion, Obj_PreAdmision.TipoOrden, Obj_PreAdmision.Numerocama,
        //                Obj_PreAdmision.PacienteNombres, Obj_PreAdmision.PacienteAPPaterno, Obj_PreAdmision.PacienteAPMaterno,
        //                Obj_PreAdmision.FechaNacimiento, Obj_PreAdmision.Sexo, Obj_PreAdmision.TipoDocumento,
        //                Obj_PreAdmision.Documento, Obj_PreAdmision.Especialidad_Nombre, Obj_PreAdmision.IdOrdenAtencion,
        //                Obj_PreAdmision.Linea, Obj_PreAdmision.Componente, Obj_PreAdmision.ComponenteNombre,
        //                Obj_PreAdmision.CantidadSolicitada, Obj_PreAdmision.MedicoNombres, Obj_PreAdmision.MedicoAPPaterno,
        //                Obj_PreAdmision.MedicoAPMaterno, Obj_PreAdmision.CMP, Obj_PreAdmision.Aseguradora_RUC,
        //                Obj_PreAdmision.Aseguradora_Nombre, Obj_PreAdmision.Empleadora_RUC, Obj_PreAdmision.Empleadora_Nombre,
        //                Obj_PreAdmision.FechaLimiteAtencion, Obj_PreAdmision.PacienteTelefono, Obj_PreAdmision.Pacienteemail,
        //                Obj_PreAdmision.Observacion, Obj_PreAdmision.NroLote, Obj_PreAdmision.Estado, Obj_PreAdmision.IpCreacion,
        //                Obj_PreAdmision.UsuarioCreacion).SingleOrDefault();
        //            valorRetorno = Convert.ToInt32(iReturnValue.ToString().Trim());
        //        }
        //        catch (Exception ex)
        //        {
        //            valorRetorno = -1;
        //            throw ex;
        //        }
        //    }
        //    return valorRetorno;
        //}

        //public int AnulacionPreAdmision(string EmpresaProveedor, string Acceso, int IdOrdenAtencion, int Linea, string Mensaje)
        //{
        //    System.Nullable<int> iReturnValue;
        //    int valorRetorno = 0; //ERROR
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        try
        //        {
        //            int id = 0;
        //            iReturnValue = context.WCO_AnulacionPreAdmision(EmpresaProveedor, Acceso, IdOrdenAtencion, Linea, Mensaje, 3, 0).SingleOrDefault();
        //            if (id == 0)
        //            {
        //                valorRetorno = -2; //"LA ATENCION YA NO SE PUEDE ANULAR";
        //            }
        //            else
        //            {
        //                valorRetorno = Convert.ToInt32(iReturnValue);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //throw ex;
        //            valorRetorno = -1; //"4|Se perdio el Token";   //"Insercion CorrectA";
        //        }
        //    }
        //    return valorRetorno;
        //}

        //public List<WCO_ListarHomologacionPreAdmision_Result> ListaHomologacionPreAdmision(string EmpresaProveedor)
        //{
        //    List<WCO_ListarHomologacionPreAdmision_Result> lst = new List<WCO_ListarHomologacionPreAdmision_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        if (EmpresaProveedor.Length == 11)
        //        {
        //            lst = context.WCO_ListarHomologacionPreAdmision(null, null, null, null, null, EmpresaProveedor).ToList();
        //        }
        //    }
        //    return lst;
        //}

    }
}