using RoyalSystems.Data;
using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_CorrelativosMast
    {
        public List<WCO_ListarCorrelativosMast_Result> ListarCorrelativosMast(WCO_ListarCorrelativosMast_Result ObjEntidad)
        {
            List<WCO_ListarCorrelativosMast_Result> lst = new List<WCO_ListarCorrelativosMast_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarCorrelativosMast(ObjEntidad.CompaniaCodigo, ObjEntidad.TipoComprobante, ObjEntidad.Serie, ObjEntidad.Descripcion,
                    ObjEntidad.IdSede, ObjEntidad.Estado).ToList();
            }
            return lst;
        }

        public int Insertar(WCO_ListarCorrelativosMast_Result ObjEntidad)
        {
            int valor = 0;
            var lst = ListarCorrelativosMast(ObjEntidad);
            valor = lst.Count;
            if (valor == 0)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarCorrelativosMast");
                Parameter[] prm_Params = new Parameter[11];
                prm_Params[0] = new Parameter("@CompaniaCodigo", ObjEntidad.CompaniaCodigo);
                prm_Params[1] = new Parameter("@TipoComprobante", ObjEntidad.TipoComprobante);
                prm_Params[2] = new Parameter("@Serie", ObjEntidad.Serie);
                prm_Params[3] = new Parameter("@SedCodigo", ObjEntidad.Sucursal);
                prm_Params[4] = new Parameter("@IdEstablecimiento", ObjEntidad.IdEstablecimiento);
                prm_Params[5] = new Parameter("@Descripcion", ObjEntidad.Descripcion);
                prm_Params[6] = new Parameter("@CorrelativoNumero", ObjEntidad.CorrelativoNumero);
                prm_Params[7] = new Parameter("@CorrelativoDesde", ObjEntidad.CorrelativoDesde);
                prm_Params[8] = new Parameter("@CorrelativoHasta", ObjEntidad.CorrelativoHasta);
                prm_Params[9] = new Parameter("@Estado", ObjEntidad.Estado);
                prm_Params[10] = new Parameter("@UsuarioCreacion", ObjEntidad.UsuarioCreacion);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        public int Actualizar(WCO_ListarCorrelativosMast_Result ObjEntidad)
        {
            int valor = 0;
            bool isExists = false;
            //isExists = ValidarExiste(ObjEntidad);
            if (!isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarCorrelativosMast");
                Parameter[] prm_Params = new Parameter[11];
                prm_Params[0] = new Parameter("@CompaniaCodigo", ObjEntidad.CompaniaCodigo);
                prm_Params[1] = new Parameter("@TipoComprobante", ObjEntidad.TipoComprobante);
                prm_Params[2] = new Parameter("@Serie", ObjEntidad.Serie);
                prm_Params[3] = new Parameter("@SedCodigo", ObjEntidad.Sucursal);
                prm_Params[4] = new Parameter("@IdEstablecimiento", ObjEntidad.IdEstablecimiento);
                prm_Params[5] = new Parameter("@Descripcion", ObjEntidad.Descripcion);
                prm_Params[6] = new Parameter("@CorrelativoNumero", ObjEntidad.CorrelativoNumero);
                prm_Params[7] = new Parameter("@CorrelativoDesde", ObjEntidad.CorrelativoDesde);
                prm_Params[8] = new Parameter("@CorrelativoHasta", ObjEntidad.CorrelativoHasta);
                prm_Params[9] = new Parameter("@Estado", ObjEntidad.Estado);
                prm_Params[10] = new Parameter("@UsuarioModificacion", ObjEntidad.UltimoUsuario);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        public void Inactivar(WCO_ListarCorrelativosMast_Result ObjEntidad)
        {
            DataOperation dop_Operacion = new DataOperation("WCO_InactivarCorrelativosMast");
            Parameter[] prm_Params = new Parameter[5];
            prm_Params[0] = new Parameter("@CompaniaCodigo", ObjEntidad.CompaniaCodigo);
            prm_Params[1] = new Parameter("@TipoComprobante", ObjEntidad.TipoComprobante);
            prm_Params[2] = new Parameter("@Serie", ObjEntidad.Serie);
            prm_Params[3] = new Parameter("@Estado", ObjEntidad.Estado);
            prm_Params[4] = new Parameter("@UsuarioModificacion", ObjEntidad.UltimoUsuario);
            dop_Operacion.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        }

    }
}