using RoyalSystems.Data;
using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_Parametro
    {
        #region Parametros
        public List<WCO_ListarParametro_Result> ListaParametro(WCO_ListarParametro_Result ObjUsuario)
        {
            List<WCO_ListarParametro_Result> lst = new List<WCO_ListarParametro_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarParametro(ObjUsuario.CompaniaCodigo, ObjUsuario.AplicacionCodigo,
                    ObjUsuario.ParametroClave, ObjUsuario.DescripcionParametro, ObjUsuario.TipodeDatoFlag,
                    ObjUsuario.Estado).ToList();
            }
            return lst;
        }

        public string InsertarParametro(WCO_ListarParametro_Result objBETablaMaestrodeta)
        {
            int valor = 0;
            var lst = ListaParametro(objBETablaMaestrodeta);
            valor = lst.Count;
            if (valor == 0)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarParametro");
                Parameter[] prm_Params = new Parameter[14];
                prm_Params[0] = new Parameter("@CompaniaCodigo", objBETablaMaestrodeta.CompaniaCodigo);
                prm_Params[1] = new Parameter("@AplicacionCodigo", objBETablaMaestrodeta.AplicacionCodigo);
                prm_Params[2] = new Parameter("@ParametroClave", objBETablaMaestrodeta.ParametroClave);
                prm_Params[3] = new Parameter("@DescripcionParametro", objBETablaMaestrodeta.DescripcionParametro);
                prm_Params[4] = new Parameter("@Explicacion", objBETablaMaestrodeta.Explicacion);
                prm_Params[5] = new Parameter("@TipodeDatoFlag", objBETablaMaestrodeta.TipodeDatoFlag);
                prm_Params[6] = new Parameter("@Texto", objBETablaMaestrodeta.Texto);
                prm_Params[7] = new Parameter("@Numero", objBETablaMaestrodeta.Numero);
                prm_Params[8] = new Parameter("@Fecha", objBETablaMaestrodeta.Fecha);
                prm_Params[9] = new Parameter("@Estado", objBETablaMaestrodeta.Estado);
                prm_Params[10] = new Parameter("@ExplicacionAdicional", objBETablaMaestrodeta.ExplicacionAdicional);
                prm_Params[11] = new Parameter("@Texto1", objBETablaMaestrodeta.Texto1);
                prm_Params[12] = new Parameter("@Texto2", objBETablaMaestrodeta.Texto2);
                prm_Params[13] = new Parameter("@UsuarioCreacion", objBETablaMaestrodeta.UltimoUsuario);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                return objBETablaMaestrodeta.ParametroClave;
            }
            else
            {
                return "";
            }

        }

        public string ActualizarParametro(WCO_ListarParametro_Result objBETablaMaestrodeta)
        {
            string valor = "0";
            WCO_ListarParametro_Result obj = new WCO_ListarParametro_Result()
            {
                CompaniaCodigo = "",
                AplicacionCodigo = ""
            };

            bool isExists = false;
            isExists = ListaParametro(obj).Exists(x => x.CompaniaCodigo == objBETablaMaestrodeta.CompaniaCodigo && x.AplicacionCodigo == objBETablaMaestrodeta.AplicacionCodigo
             && x.ParametroClave != objBETablaMaestrodeta.ParametroClave);

            if (!isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarParametro");
                Parameter[] prm_Params = new Parameter[14];
                prm_Params[0] = new Parameter("@CompaniaCodigo", objBETablaMaestrodeta.CompaniaCodigo);
                prm_Params[1] = new Parameter("@AplicacionCodigo", objBETablaMaestrodeta.AplicacionCodigo);
                prm_Params[2] = new Parameter("@ParametroClave", objBETablaMaestrodeta.ParametroClave);
                prm_Params[3] = new Parameter("@DescripcionParametro", objBETablaMaestrodeta.DescripcionParametro);
                prm_Params[4] = new Parameter("@Explicacion", objBETablaMaestrodeta.Explicacion);
                prm_Params[5] = new Parameter("@TipodeDatoFlag", objBETablaMaestrodeta.TipodeDatoFlag);
                prm_Params[6] = new Parameter("@Texto", objBETablaMaestrodeta.Texto);
                prm_Params[7] = new Parameter("@Numero", objBETablaMaestrodeta.Numero);
                prm_Params[8] = new Parameter("@Fecha", objBETablaMaestrodeta.Fecha);
                prm_Params[9] = new Parameter("@Estado", objBETablaMaestrodeta.Estado);
                prm_Params[10] = new Parameter("@ExplicacionAdicional", objBETablaMaestrodeta.ExplicacionAdicional);
                prm_Params[11] = new Parameter("@Texto1", objBETablaMaestrodeta.Texto1);
                prm_Params[12] = new Parameter("@Texto2", objBETablaMaestrodeta.Texto2);
                prm_Params[13] = new Parameter("@UsuarioModificacion", objBETablaMaestrodeta.UltimoUsuario);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = "-1";
            }
            return valor;
        }


        #endregion
    }
}