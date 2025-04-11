using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_TablaMaestroArchivo
    {
        public List<WCO_ListarTablaMaestroArchivo_Result> Listar(WCO_ListarTablaMaestroArchivo_Result ObjEntidad)
        {
            List<WCO_ListarTablaMaestroArchivo_Result> lst = new List<WCO_ListarTablaMaestroArchivo_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarTablaMaestroArchivo(ObjEntidad.Id, ObjEntidad.Tabla, ObjEntidad.IdTabla,
                    ObjEntidad.Linea, ObjEntidad.Estado).ToList();
            }
            return lst;
        }
        public int Insertar(WCO_ListarTablaMaestroArchivo_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_InsertarTablaMaestroArchivo");
            try
            {
                Parameter[] prm_Params = new Parameter[8];
                prm_Params[0] = new Parameter("@Id", obj_pBEUsuario.Id);
                prm_Params[1] = new Parameter("@Tabla", obj_pBEUsuario.Tabla);
                prm_Params[2] = new Parameter("@IdTabla", obj_pBEUsuario.IdTabla);
                prm_Params[3] = new Parameter("@Linea", obj_pBEUsuario.Linea);
                prm_Params[4] = new Parameter("@NombrePDF", obj_pBEUsuario.NombrePDF);
                prm_Params[5] = new Parameter("@Contenido", obj_pBEUsuario.Contenido);
                prm_Params[6] = new Parameter("@Estado", obj_pBEUsuario.Estado);
                prm_Params[7] = new Parameter("@UsuarioCreacion", obj_pBEUsuario.UsuarioCreacion);
                dop_DataOperation.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
                return 1;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int Actualizar(WCO_ListarTablaMaestroArchivo_Result obj_pBEUsuario)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_ActualizarTablaMaestroArchivo");
            try
            {
                Parameter[] prm_Params = new Parameter[8];
                prm_Params[0] = new Parameter("@Id", obj_pBEUsuario.Id);
                prm_Params[1] = new Parameter("@Tabla", obj_pBEUsuario.Tabla);
                prm_Params[2] = new Parameter("@IdTabla", obj_pBEUsuario.IdTabla);
                prm_Params[3] = new Parameter("@Linea", obj_pBEUsuario.Linea);
                prm_Params[4] = new Parameter("@NombrePDF", obj_pBEUsuario.NombrePDF);
                prm_Params[5] = new Parameter("@Contenido", obj_pBEUsuario.Contenido);
                prm_Params[6] = new Parameter("@Estado", obj_pBEUsuario.Estado);
                prm_Params[7] = new Parameter("@UsuarioModificacion", obj_pBEUsuario.UsuarioModificacion);
                dop_DataOperation.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
                return obj_pBEUsuario.Id;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //throw ex;
                return 0;
            }
            catch (Exception ex)
            {
                //throw ex;
                return 0;
            }
        }

        public int Eliminar(WCO_ListarTablaMaestroArchivo_Result obj_pBEUsuario)
        {
            DataOperation dop_Operacion = new DataOperation("WCO_EliminarTablaMaestroArchivo");
            try
            {
                Parameter[] prm_Params = new Parameter[8];
                prm_Params[0] = new Parameter("@Id", obj_pBEUsuario.Id);
                prm_Params[1] = new Parameter("@Tabla", obj_pBEUsuario.Tabla);
                prm_Params[2] = new Parameter("@IdTabla", obj_pBEUsuario.IdTabla);
                prm_Params[3] = new Parameter("@Linea", obj_pBEUsuario.Linea);
                prm_Params[4] = new Parameter("@NombrePDF", obj_pBEUsuario.NombrePDF);
                prm_Params[5] = new Parameter("@Contenido", obj_pBEUsuario.Contenido);
                prm_Params[6] = new Parameter("@Estado", obj_pBEUsuario.Estado);
                prm_Params[7] = new Parameter("@UsuarioModificacion", obj_pBEUsuario.UsuarioModificacion);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                return obj_pBEUsuario.Id;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                //throw ex;
                return 0;
            }
            catch (Exception ex)
            {
                //throw ex;
                return 0;
            }
        }
    }
}