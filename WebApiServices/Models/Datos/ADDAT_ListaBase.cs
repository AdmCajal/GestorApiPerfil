using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_ListaBase
    {
        #region ListaBase

        //public List<WCO_ListarListaBase_Result> ListadoBasePaginado(WCO_ListarListaBase_Result ObjEntidad)
        //{
        //    List<WCO_ListarListaBase_Result> lst = new List<WCO_ListarListaBase_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarListaBase(ObjEntidad.Descripcion, ObjEntidad.Estado).ToList();
        //    }
        //    return lst;
        //}
        //public static int Insertar(WCO_ListarListaBase_Result objBEListaBase)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InsertarListaBase");
        //    Parameter[] prm_Params = new Parameter[15];
        //    prm_Params[0] = new Parameter("@Moneda", objBEListaBase.Moneda);
        //    prm_Params[1] = new Parameter("@TipoLista", objBEListaBase.TipoLista);
        //    prm_Params[2] = new Parameter("@IdCliente", objBEListaBase.IdCliente);
        //    prm_Params[3] = new Parameter("@FechaValidezInicio", objBEListaBase.FechaValidezInicio);
        //    prm_Params[4] = new Parameter("@FechaValidezFin", objBEListaBase.FechaValidezFin);
        //    prm_Params[5] = new Parameter("@Nombre", objBEListaBase.Nombre);
        //    prm_Params[6] = new Parameter("@Descripcion", objBEListaBase.Descripcion);
        //    prm_Params[7] = new Parameter("@Codigo", objBEListaBase.Codigo);
        //    prm_Params[8] = new Parameter("@IndicadorPrecioFijo", objBEListaBase.IndicadorPrecioFijo);
        //    prm_Params[9] = new Parameter("@IdEmpresaAnteriorUnificacion", objBEListaBase.IdEmpresaAnteriorUnificacion);
        //    prm_Params[10] = new Parameter("@TipoPaciente", objBEListaBase.TipoPaciente);
        //    prm_Params[11] = new Parameter("@Estado", objBEListaBase.Estado);
        //    prm_Params[12] = new Parameter("@FechaCreacion", objBEListaBase.FechaCreacion);
        //    prm_Params[13] = new Parameter("@UsuarioCreacion", objBEListaBase.UsuarioCreacion);
        //    prm_Params[14] = new Parameter("@IdListaBase", DbType.Int32);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    return int.Parse(dop_Operacion.GetParameterByName("@IdListaBase").Value.ToString());
        //}

        /////<summary>Actualizar el registro en la tabla PERSONAMAST.</summary>
        /////<param name="obj_pSA_Curriculo">Entidad de Negocio</param>
        /////<remarks><list type="bullet">
        /////<item><CreadoPor>Creado PorJordan Mateo Pizarro</CreadoPor></item>
        /////<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        //public static void Actualizar(WCO_ListarListaBase_Result objBEListaBase)
        //{

        //    DataOperation dop_Operacion = new DataOperation("WCO_ActualizarListaBase");
        //    Parameter[] prm_Params = new Parameter[15];
        //    prm_Params[0] = new Parameter("@Moneda", objBEListaBase.Moneda);
        //    prm_Params[1] = new Parameter("@TipoLista", objBEListaBase.TipoLista);
        //    prm_Params[2] = new Parameter("@IdCliente", objBEListaBase.IdCliente);
        //    prm_Params[3] = new Parameter("@FechaValidezInicio", objBEListaBase.FechaValidezInicio);
        //    prm_Params[4] = new Parameter("@FechaValidezFin", objBEListaBase.FechaValidezFin);
        //    prm_Params[5] = new Parameter("@Nombre", objBEListaBase.Nombre);
        //    prm_Params[6] = new Parameter("@Descripcion", objBEListaBase.Descripcion);
        //    prm_Params[7] = new Parameter("@Codigo", objBEListaBase.Codigo);
        //    prm_Params[8] = new Parameter("@IndicadorPrecioFijo", objBEListaBase.IndicadorPrecioFijo);
        //    prm_Params[9] = new Parameter("@IdEmpresaAnteriorUnificacion", objBEListaBase.IdEmpresaAnteriorUnificacion);
        //    prm_Params[10] = new Parameter("@TipoPaciente", objBEListaBase.TipoPaciente);
        //    prm_Params[11] = new Parameter("@Estado", objBEListaBase.Estado);
        //    prm_Params[12] = new Parameter("@FechaModificacion", objBEListaBase.FechaModificacion);
        //    prm_Params[13] = new Parameter("@UsuarioModificacion", objBEListaBase.UsuarioModificacion);
        //    prm_Params[14] = new Parameter("@IdListaBase", objBEListaBase.IdListaBase);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}

        /////<summary>Actualizar el registro en la tabla PERSONAMAST.</summary>
        /////<param name="obj_pSA_Curriculo">Entidad de Negocio</param>
        /////<remarks><list type="bullet">
        /////<item><CreadoPor>Creado PorJordan Mateo Pizarro</CreadoPor></item>
        /////<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        //public static void Inactivar(WCO_ListarListaBase_Result objBEListaBase)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InactivarListaBase");
        //    Parameter[] prm_Params = new Parameter[4];
        //    prm_Params[0] = new Parameter("@Estado", objBEListaBase.Estado);
        //    prm_Params[1] = new Parameter("@FechaModificacion", objBEListaBase.FechaModificacion);
        //    prm_Params[2] = new Parameter("@UsuarioModificacion", objBEListaBase.UsuarioModificacion);
        //    prm_Params[3] = new Parameter("@IdListaBase", objBEListaBase.IdListaBase);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}

        //public static bool ValidarExiste(WCO_ListarListaBase_Result objBEListaBase)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_ExisteListaBase");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@IdListaBase", objBEListaBase.IdListaBase);
        //    prm_Params[1] = new Parameter("@Descripcion", objBEListaBase.Descripcion);
        //    prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
        //    dop_DataOperation.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
        //    if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //public static bool ValidarExisteCodigo(WCO_ListarListaBase_Result objBEListaBase)
        //{
        //    DataOperation dop_DataOperation = new DataOperation("WCO_ExisteListaBaseCodigo");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@IdListaBase", objBEListaBase.IdListaBase);
        //    prm_Params[1] = new Parameter("@Codigo", objBEListaBase.Codigo);
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

        #region ListaBaseComponente

        #endregion

    }
}