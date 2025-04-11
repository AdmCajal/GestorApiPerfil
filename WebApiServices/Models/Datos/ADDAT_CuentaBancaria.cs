using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace WebApiServices.Models.Datos
{
    public class ADDAT_CuentaBancaria
    {
        public List<WCO_ListarCuentaBancaria_Result> Listar(WCO_ListarCuentaBancaria_Result ObjEntidad)
        {
            List<WCO_ListarCuentaBancaria_Result> lst = new List<WCO_ListarCuentaBancaria_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarCuentaBancaria(ObjEntidad.CuentaBancaria, ObjEntidad.CompaniaCodigo, ObjEntidad.Persona, ObjEntidad.Banco, ObjEntidad.Descripcion, ObjEntidad.Estado).ToList();
            }
            return lst;
        }

        public int Insertar(WCO_ListarCuentaBancaria_Result ObjEntidad)
        {
            int valor = 0;
            var lst = Listar(ObjEntidad);
            valor = lst.Count;
            if (valor == 0)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarCuentaBancaria");
                Parameter[] prm_Params = new Parameter[35];
                prm_Params[0] = new Parameter("@CuentaBancaria", "200");
                prm_Params[1] = new Parameter("@Banco", ObjEntidad.Banco);
                prm_Params[2] = new Parameter("@Descripcion", ObjEntidad.Descripcion);
                prm_Params[3] = new Parameter("@CompaniaCodigo", ObjEntidad.CompaniaCodigo);
                prm_Params[4] = new Parameter("@Estado", ObjEntidad.Estado);
                prm_Params[5] = new Parameter("@FechaApertura", ObjEntidad.FechaApertura);
                prm_Params[6] = new Parameter("@FechaCierreCuenta", ObjEntidad.FechaCierreCuenta);
                prm_Params[7] = new Parameter("@MonedaCodigo", ObjEntidad.MonedaCodigo);
                prm_Params[8] = new Parameter("@TipoCuenta", ObjEntidad.TipoCuenta);
                prm_Params[9] = new Parameter("@CuentaContable", ObjEntidad.CuentaContable);
                prm_Params[10] = new Parameter("@CuentaContableDescuento", ObjEntidad.CuentaContableDescuento);
                prm_Params[11] = new Parameter("@SobregiroAutorizado", ObjEntidad.SobregiroAutorizado);
                prm_Params[12] = new Parameter("@AgenciaBanco", ObjEntidad.AgenciaBanco);
                prm_Params[13] = new Parameter("@AgenciaDistrito", ObjEntidad.AgenciaDistrito);
                prm_Params[14] = new Parameter("@SucursalCodigo", ObjEntidad.SucursalCodigo);
                prm_Params[15] = new Parameter("@Idioma", ObjEntidad.Idioma);
                prm_Params[16] = new Parameter("@UltimoPeriodoConciliacion", ObjEntidad.UltimoPeriodoConciliacion);
                prm_Params[17] = new Parameter("@VoucherTipo", ObjEntidad.VoucherTipo);
                prm_Params[18] = new Parameter("@VoucherClasificacion", ObjEntidad.VoucherClasificacion);
                prm_Params[19] = new Parameter("@AtencionPersona", ObjEntidad.AtencionPersona);
                prm_Params[20] = new Parameter("@AtencionCargo", ObjEntidad.AtencionCargo);
                prm_Params[21] = new Parameter("@FlujodeCajaFlag", ObjEntidad.FlujodeCajaFlag);
                prm_Params[22] = new Parameter("@FlujodeCajaOrden", ObjEntidad.FlujodeCajaOrden);
                prm_Params[23] = new Parameter("@CodigoDiskette", ObjEntidad.CodigoDiskette);
                prm_Params[24] = new Parameter("@ConciliacionBancariaFlag", ObjEntidad.ConciliacionBancariaFlag);
                prm_Params[25] = new Parameter("@CuentaBancariaConsolidada", ObjEntidad.CuentaBancariaConsolidada);
                prm_Params[26] = new Parameter("@CuentaBancoOriginal", ObjEntidad.CuentaBancoOriginal);
                prm_Params[27] = new Parameter("@ArchivoDiskette", ObjEntidad.ArchivoDiskette);
                prm_Params[28] = new Parameter("@ReferenciaFiscal03", ObjEntidad.ReferenciaFiscal03);
                prm_Params[29] = new Parameter("@ITFFlag", ObjEntidad.ITFFlag);
                prm_Params[30] = new Parameter("@ConciliacionAPFlag", ObjEntidad.ConciliacionAPFlag);
                prm_Params[31] = new Parameter("@PagosInterfaseFlag", ObjEntidad.PagosInterfaseFlag);
                prm_Params[32] = new Parameter("@ConciliacionPeriodo", ObjEntidad.ConciliacionPeriodo);
                prm_Params[33] = new Parameter("@UltimoUsuario", ObjEntidad.UltimoUsuario);
                prm_Params[34] = new Parameter("@UltimaFechaModif", ObjEntidad.UltimaFechaModif);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = -1;
            }
            return valor;
        }


        public int Actualizar(WCO_ListarCuentaBancaria_Result objBECuentaBancaria)
        {
            int valor = 0;
            bool isExists = false;
            isExists = ValidarExiste(objBECuentaBancaria);
            if (!isExists)
            {

                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarCuentaBancaria");
                Parameter[] prm_Params = new Parameter[35];
                prm_Params[0] = new Parameter("@CuentaBancaria", objBECuentaBancaria.CuentaBancaria);
                prm_Params[1] = new Parameter("@Banco", objBECuentaBancaria.Banco);
                prm_Params[2] = new Parameter("@Descripcion", objBECuentaBancaria.Descripcion);
                prm_Params[3] = new Parameter("@CompaniaCodigo", objBECuentaBancaria.CompaniaCodigo);
                prm_Params[4] = new Parameter("@Estado", objBECuentaBancaria.Estado);
                prm_Params[5] = new Parameter("@FechaApertura", objBECuentaBancaria.FechaApertura);
                prm_Params[6] = new Parameter("@FechaCierreCuenta", objBECuentaBancaria.FechaCierreCuenta);
                prm_Params[7] = new Parameter("@MonedaCodigo", objBECuentaBancaria.MonedaCodigo);
                prm_Params[8] = new Parameter("@TipoCuenta", objBECuentaBancaria.TipoCuenta);
                prm_Params[9] = new Parameter("@CuentaContable", objBECuentaBancaria.CuentaContable);
                prm_Params[10] = new Parameter("@CuentaContableDescuento", objBECuentaBancaria.CuentaContableDescuento);
                prm_Params[11] = new Parameter("@SobregiroAutorizado", objBECuentaBancaria.SobregiroAutorizado);
                prm_Params[12] = new Parameter("@AgenciaBanco", objBECuentaBancaria.AgenciaBanco);
                prm_Params[13] = new Parameter("@AgenciaDistrito", objBECuentaBancaria.AgenciaDistrito);
                prm_Params[14] = new Parameter("@SucursalCodigo", objBECuentaBancaria.SucursalCodigo);
                prm_Params[15] = new Parameter("@Idioma", objBECuentaBancaria.Idioma);
                prm_Params[16] = new Parameter("@UltimoPeriodoConciliacion", objBECuentaBancaria.UltimoPeriodoConciliacion);
                prm_Params[17] = new Parameter("@VoucherTipo", objBECuentaBancaria.VoucherTipo);
                prm_Params[18] = new Parameter("@VoucherClasificacion", objBECuentaBancaria.VoucherClasificacion);
                prm_Params[19] = new Parameter("@AtencionPersona", objBECuentaBancaria.AtencionPersona);
                prm_Params[20] = new Parameter("@AtencionCargo", objBECuentaBancaria.AtencionCargo);
                prm_Params[21] = new Parameter("@FlujodeCajaFlag", objBECuentaBancaria.FlujodeCajaFlag);
                prm_Params[22] = new Parameter("@FlujodeCajaOrden", objBECuentaBancaria.FlujodeCajaOrden);
                prm_Params[23] = new Parameter("@CodigoDiskette", objBECuentaBancaria.CodigoDiskette);
                prm_Params[24] = new Parameter("@ConciliacionBancariaFlag", objBECuentaBancaria.ConciliacionBancariaFlag);
                prm_Params[25] = new Parameter("@CuentaBancariaConsolidada", objBECuentaBancaria.CuentaBancariaConsolidada);
                prm_Params[26] = new Parameter("@CuentaBancoOriginal", objBECuentaBancaria.CuentaBancoOriginal);
                prm_Params[27] = new Parameter("@ArchivoDiskette", objBECuentaBancaria.ArchivoDiskette);
                prm_Params[28] = new Parameter("@ReferenciaFiscal03", objBECuentaBancaria.ReferenciaFiscal03);
                prm_Params[29] = new Parameter("@ITFFlag", objBECuentaBancaria.ITFFlag);
                prm_Params[30] = new Parameter("@ConciliacionAPFlag", objBECuentaBancaria.ConciliacionAPFlag);
                prm_Params[31] = new Parameter("@PagosInterfaseFlag", objBECuentaBancaria.PagosInterfaseFlag);
                prm_Params[32] = new Parameter("@ConciliacionPeriodo", objBECuentaBancaria.ConciliacionPeriodo);
                prm_Params[33] = new Parameter("@UltimoUsuario", objBECuentaBancaria.UltimoUsuario);
                prm_Params[34] = new Parameter("@UltimaFechaModif", objBECuentaBancaria.UltimaFechaModif);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        ///<summary>Actualizar el registro en la tabla PERSONAMAST.</summary>
        ///<param name="obj_pSA_Curriculo">Entidad de Negocio</param>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado PorJordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        public void Inactivar(WCO_ListarCuentaBancaria_Result objBECuentaBancaria)
        {

            DataOperation dop_Operacion = new DataOperation("WCO_InactivarCuentaBancaria");
            Parameter[] prm_Params = new Parameter[4];
            prm_Params[0] = new Parameter("@Estado", objBECuentaBancaria.Estado);
            prm_Params[1] = new Parameter("@UltimoUsuario", objBECuentaBancaria.UltimoUsuario);
            prm_Params[2] = new Parameter("@UltimaFechaModif", objBECuentaBancaria.UltimaFechaModif);
            prm_Params[3] = new Parameter("@CuentaBancaria", objBECuentaBancaria.CuentaBancaria);
            dop_Operacion.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        }

        public static bool ValidarExiste(WCO_ListarCuentaBancaria_Result objBECuentaBancaria)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_ExisteCuentaBancaria");
            Parameter[] prm_Params = new Parameter[3];
            prm_Params[0] = new Parameter("@CuentaBancaria", objBECuentaBancaria.CuentaBancaria);
            prm_Params[1] = new Parameter("@Banco", objBECuentaBancaria.Banco);
            prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
            dop_DataOperation.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
            {
                return false;
            }
            return true;
        }

    }
}