using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_Banco
    {
        public List<WCO_ListarBanco_Result> ListarBanco(WCO_ListarBanco_Result ObjEntidad)
        {
            List<WCO_ListarBanco_Result> lst = new List<WCO_ListarBanco_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarBanco(ObjEntidad.Banco, ObjEntidad.Estado, ObjEntidad.DescripcionCorta).ToList();
            }
            return lst;
        }

        public string Insertar(WCO_ListarBanco_Result ObjEntidad)
        {
            int valor = 0;
            var lst = ListarBanco(ObjEntidad);
            valor = lst.Count;
            if (valor == 0)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarBanco");
                Parameter[] prm_Params = new Parameter[19];
                prm_Params[0] = new Parameter("@Banco", "001");
                prm_Params[1] = new Parameter("@DescripcionCorta", ObjEntidad.DescripcionCorta);
                prm_Params[2] = new Parameter("@DescripcionLarga", ObjEntidad.DescripcionLarga);
                prm_Params[3] = new Parameter("@BancoNumero", ObjEntidad.BancoNumero);
                prm_Params[4] = new Parameter("@PersonaContacto", ObjEntidad.PersonaContacto);
                prm_Params[5] = new Parameter("@ConciliacionAutomaticaFlag", ObjEntidad.ConciliacionAutomaticaFlag);
                prm_Params[6] = new Parameter("@FormatoPropioFlag", ObjEntidad.FormatoPropioFlag);
                prm_Params[7] = new Parameter("@FormatoDatawindow", ObjEntidad.FormatoDatawindow);
                prm_Params[8] = new Parameter("@ConciliacionFormatoFlag", ObjEntidad.ConciliacionFormatoFlag);
                prm_Params[9] = new Parameter("@Estado", ObjEntidad.Estado);
                prm_Params[10] = new Parameter("@UsuarioCreacion", ObjEntidad.UsuarioCreacion);
                prm_Params[11] = new Parameter("@IpCreacion", ObjEntidad.IpCreacion);
                prm_Params[12] = new Parameter("@CODIGOINTERFASEAFP", ObjEntidad.CODIGOINTERFASEAFP);
                prm_Params[13] = new Parameter("@DisponibleEDflag", ObjEntidad.DisponibleEDflag);
                prm_Params[14] = new Parameter("@FormatoDatawindowenvio", ObjEntidad.FormatoDatawindowenvio);
                prm_Params[15] = new Parameter("@TasaEfectivaAnual", ObjEntidad.TasaEfectivaAnual);
                prm_Params[16] = new Parameter("@CodigoFiscal", ObjEntidad.CodigoFiscal);
                prm_Params[17] = new Parameter("@Telefono", ObjEntidad.Telefono);
                prm_Params[18] = new Parameter("@CorreoElectronico", ObjEntidad.CorreoElectronico);

                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                return dop_Operacion.GetParameterByName("@Banco").Value.ToString();
            }
            else
            {
                return "";
            }
        }

        ///<summary>Actualizar el registro en la tabla Banco.</summary>
        ///<param name="WCO_ListarBanco_Result">Entidad de Negocio</param>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado Por Jordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        public string Actualizar(WCO_ListarBanco_Result objBECuentaBancaria)
        {
            try
            {
                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarBanco");
                Parameter[] prm_Params = new Parameter[19];
                prm_Params[0] = new Parameter("@Banco", objBECuentaBancaria.Banco);
                prm_Params[1] = new Parameter("@DescripcionCorta", objBECuentaBancaria.DescripcionCorta);
                prm_Params[2] = new Parameter("@DescripcionLarga", objBECuentaBancaria.DescripcionLarga);
                prm_Params[3] = new Parameter("@BancoNumero", objBECuentaBancaria.BancoNumero);
                prm_Params[4] = new Parameter("@PersonaContacto", objBECuentaBancaria.PersonaContacto);
                prm_Params[5] = new Parameter("@ConciliacionAutomaticaFlag", objBECuentaBancaria.ConciliacionAutomaticaFlag);
                prm_Params[6] = new Parameter("@FormatoPropioFlag", objBECuentaBancaria.FormatoPropioFlag);
                prm_Params[7] = new Parameter("@FormatoDatawindow", objBECuentaBancaria.FormatoDatawindow);
                prm_Params[8] = new Parameter("@ConciliacionFormatoFlag", objBECuentaBancaria.ConciliacionFormatoFlag);
                prm_Params[9] = new Parameter("@Estado", objBECuentaBancaria.Estado);
                prm_Params[10] = new Parameter("@UltimoUsuario", objBECuentaBancaria.UsuarioCreacion);
                prm_Params[11] = new Parameter("@IpModificacion", objBECuentaBancaria.IpCreacion);
                prm_Params[12] = new Parameter("@CODIGOINTERFASEAFP", objBECuentaBancaria.CODIGOINTERFASEAFP);
                prm_Params[13] = new Parameter("@DisponibleEDflag", objBECuentaBancaria.DisponibleEDflag);
                prm_Params[14] = new Parameter("@FormatoDatawindowenvio", objBECuentaBancaria.FormatoDatawindowenvio);
                prm_Params[15] = new Parameter("@TasaEfectivaAnual", objBECuentaBancaria.TasaEfectivaAnual);
                prm_Params[16] = new Parameter("@CodigoFiscal", objBECuentaBancaria.CodigoFiscal);
                prm_Params[17] = new Parameter("@Telefono", objBECuentaBancaria.Telefono);
                prm_Params[18] = new Parameter("@CorreoElectronico", objBECuentaBancaria.CorreoElectronico);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);

                return objBECuentaBancaria.Banco;
            }
            catch (Exception ex)
            {
                return "0";
            }

        }

        ///<summary>Actualizar el registro en la tabla PERSONAMAST.</summary>
        ///<param name="obj_pSA_Curriculo">Entidad de Negocio</param>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado PorJordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        public string Inactivar(WCO_ListarBanco_Result objBECuentaBancaria)
        {
            try
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InactivarBanco");
                Parameter[] prm_Params = new Parameter[4];
                prm_Params[0] = new Parameter("@Estado", objBECuentaBancaria.Estado);
                prm_Params[1] = new Parameter("@UltimoUsuario", objBECuentaBancaria.UltimoUsuario);
                prm_Params[2] = new Parameter("@UltimaFechaModif", objBECuentaBancaria.UltimaFechaModif);
                prm_Params[3] = new Parameter("@Banco", objBECuentaBancaria.Banco);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                return objBECuentaBancaria.Banco;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

    }
}