using RoyalSystems.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace WebApiServices.Models.Datos
{
    public class ADDAT_TablaMaestroDetalle
    {
        #region MaestroTabla
        public List<WCO_ListarTablasMaestras_Result> ListaTablasMaestras(WCO_ListarTablasMaestras_Result ObjMaestras)
        {
            List<WCO_ListarTablasMaestras_Result> lst = new List<WCO_ListarTablasMaestras_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                Nullable<int> iReturnValue = null;
                if (ObjMaestras.IdTablaMaestro > 0)
                {
                    iReturnValue = ObjMaestras.IdTablaMaestro;
                }
                lst = context.WCO_ListarTablasMaestras(iReturnValue, ObjMaestras.Nombre, ObjMaestras.Estado, ObjMaestras.CodigoTabla).ToList();
            }
            return lst;
        }

        public int InsertarTablaMaestro(WCO_ListarTablasMaestras_Result objBETablaMaestro)
        {
            int valor = 0;
            WCO_ListarTablasMaestras_Result obj = new WCO_ListarTablasMaestras_Result()
            {
                IdTablaMaestro = 0,
                CodigoTabla = "",
                Nombre = ""
            };

            bool isExists = false;
            isExists = ListaTablasMaestras(obj).Exists(x => x.CodigoTabla == objBETablaMaestro.CodigoTabla || x.Nombre == objBETablaMaestro.Nombre);

            if (!isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarTablaMaestro");
                Parameter[] prm_Params = new Parameter[6];
                prm_Params[0] = new Parameter("@Nombre", objBETablaMaestro.Nombre);
                prm_Params[1] = new Parameter("@Descripcion", objBETablaMaestro.Descripcion);
                prm_Params[2] = new Parameter("@Codigo", objBETablaMaestro.CodigoTabla);
                prm_Params[3] = new Parameter("@Estado", objBETablaMaestro.Estado);
                prm_Params[4] = new Parameter("@UsuarioCreacion", objBETablaMaestro.UsuarioCreacion);
                prm_Params[5] = new Parameter("@IdTablaMaestro", DbType.Int32);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                valor = int.Parse(dop_Operacion.GetParameterByName("@IdTablaMaestro").Value.ToString());
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        public int ActualizarTablaMaestro(WCO_ListarTablasMaestras_Result objBETablaMaestro)
        {
            int valor = 0;
            WCO_ListarTablasMaestras_Result obj = new WCO_ListarTablasMaestras_Result()
            {
                IdTablaMaestro = 0,
                CodigoTabla = "",
                Nombre = ""
            };

            bool isExists = false;
            isExists = ListaTablasMaestras(obj).Exists(x => x.CodigoTabla == objBETablaMaestro.CodigoTabla || x.Nombre == objBETablaMaestro.Nombre);

            if (!isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarTablaMaestro");
                Parameter[] prm_Params = new Parameter[7];
                prm_Params[0] = new Parameter("@Nombre", objBETablaMaestro.Nombre);
                prm_Params[1] = new Parameter("@Descripcion", objBETablaMaestro.Descripcion);
                prm_Params[2] = new Parameter("@Codigo", objBETablaMaestro.CodigoTabla);
                prm_Params[3] = new Parameter("@Estado", objBETablaMaestro.Estado);
                prm_Params[4] = new Parameter("@UsuarioModificacion", objBETablaMaestro.UsuarioModificacion);
                prm_Params[5] = new Parameter("@IdTablaMaestro", objBETablaMaestro.IdTablaMaestro);
                prm_Params[6] = new Parameter("@version", objBETablaMaestro.Version);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                valor = int.Parse(dop_Operacion.GetParameterByName("@IdTablaMaestro").Value.ToString());
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        public void InactivarTablaMaestro(WCO_ListarTablasMaestras_Result objBETablaMaestro)
        {
            DataOperation dop_Operacion = new DataOperation("WCO_InactivarTablaMaestro");
            Parameter[] prm_Params = new Parameter[2];
            prm_Params[0] = new Parameter("@UsuarioModificacion", objBETablaMaestro.UsuarioModificacion);
            prm_Params[1] = new Parameter("@IdTablaMaestro", objBETablaMaestro.IdTablaMaestro);
            dop_Operacion.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        }

        #endregion

        #region MaestroDetalleTabla

        public List<WCO_ListarTablaMaestroDetalle_Result> ListaTablaMaestroDetalle(WCO_ListarTablaMaestroDetalle_Result ObjUsuario)
        {
            List<WCO_ListarTablaMaestroDetalle_Result> lst = new List<WCO_ListarTablaMaestroDetalle_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarTablaMaestroDetalle(ObjUsuario.Codigo).ToList();
            }
            return lst;
        }

        public List<WCO_ListarTMAestroDetalles_Result> ListaMaestroDetalle(WCO_ListarTMAestroDetalles_Result ObjDetalle)
        {
            List<WCO_ListarTMAestroDetalles_Result> lst = new List<WCO_ListarTMAestroDetalles_Result>();
            using (var context = new BDInmobiliariaEntities())
            {
                lst = context.WCO_ListarTMAestroDetalles(ObjDetalle.IdTablaMaestro, ObjDetalle.IdCodigo, ObjDetalle.Nombre, ObjDetalle.Estado).ToList();
            }
            return lst;
        }

        public int InsertarMaestroDetalle(WCO_ListarTMAestroDetalles_Result objBETablaMaestrodeta)
        {
            int valor = 0;
            //WCO_ListarTMAestroDetalles_Result obj = new WCO_ListarTMAestroDetalles_Result()
            //{
            //    IdTablaMaestro = 0,
            //    IdCodigo = 0,
            //    Nombre = ""
            //};

            bool isExists = false;
            //isExists = ListaMaestroDetalle(obj).Exists(x => x.IdTablaMaestro == objBETablaMaestrodeta.IdTablaMaestro && x.IdCodigo == objBETablaMaestrodeta.IdCodigo
            //|| x.IdTablaMaestro == objBETablaMaestrodeta.IdTablaMaestro && x.Nombre == objBETablaMaestrodeta.Nombre);
            isExists = ExisteMaestroDetalle(objBETablaMaestrodeta);
            if (isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarTablaMaestroDetalle");
                Parameter[] prm_Params = new Parameter[7];
                prm_Params[0] = new Parameter("@Nombre", objBETablaMaestrodeta.Nombre);
                prm_Params[1] = new Parameter("@Descripcion", objBETablaMaestrodeta.Descripcion);
                prm_Params[2] = new Parameter("@Codigo", objBETablaMaestrodeta.Codigo);
                prm_Params[3] = new Parameter("@Estado", objBETablaMaestrodeta.Estado);
                prm_Params[4] = new Parameter("@UsuarioCreacion", objBETablaMaestrodeta.UsuarioCreacion);
                prm_Params[5] = new Parameter("@IdTablaMaestro", objBETablaMaestrodeta.IdTablaMaestro);
                prm_Params[6] = new Parameter("@IdCodigo", DbType.Int32);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                valor = int.Parse(dop_Operacion.GetParameterByName("@IdCodigo").Value.ToString());
            }
            else
            {
                valor = -1;
            }
            return valor;
        }

        public int ActualizarMaestroDetalle(WCO_ListarTMAestroDetalles_Result objBETablaMaestrodeta)
        {
            int valor = 0;
            bool isExists = false;
            valor = ListaMaestroDetalle(objBETablaMaestrodeta).Count();
            if (valor == 0)
            {
                isExists = true;
            }
            valor = 0;
            if (isExists)
            {
                DataOperation dop_Operacion = new DataOperation("WCO_ActualizarDetalleMaestro");
                Parameter[] prm_Params = new Parameter[7];
                prm_Params[0] = new Parameter("@Nombre", objBETablaMaestrodeta.Nombre);
                prm_Params[1] = new Parameter("@Descripcion", objBETablaMaestrodeta.Descripcion);
                prm_Params[2] = new Parameter("@Codigo", objBETablaMaestrodeta.Codigo);
                prm_Params[3] = new Parameter("@Estado", objBETablaMaestrodeta.Estado);
                prm_Params[4] = new Parameter("@UsuarioModificacion", objBETablaMaestrodeta.UsuarioModificacion);
                prm_Params[5] = new Parameter("@IdTablaMaestro", objBETablaMaestrodeta.IdTablaMaestro);
                prm_Params[6] = new Parameter("@IdCodigo", objBETablaMaestrodeta.IdCodigo);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            }
            else
            {
                valor = -1;
            }



            return valor;
        }

        public void InactivarMaestroDetalle(WCO_ListarTMAestroDetalles_Result objBETablaMaestrodeta)
        {          //try
            //{
            DataOperation dop_Operacion = new DataOperation("WCO_InactivarTablaDetalles");
            Parameter[] prm_Params = new Parameter[3];
            prm_Params[0] = new Parameter("@UsuarioModificacion", objBETablaMaestrodeta.UsuarioModificacion);
            prm_Params[1] = new Parameter("@IdTablaMaestro", objBETablaMaestrodeta.IdTablaMaestro);
            prm_Params[2] = new Parameter("@idcodigo", objBETablaMaestrodeta.IdCodigo);

            dop_Operacion.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
            //}
            //catch (System.Data.SqlClient.SqlException ex)
            //{
            //    throw ex;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public bool ExisteMaestroDetalle(WCO_ListarTMAestroDetalles_Result objBETablaMaestrodeta)
        {
            DataOperation dop_DataOperation = new DataOperation("WCO_ExisteDetalleMaestro");
            Parameter[] prm_Params = new Parameter[4];
            prm_Params[0] = new Parameter("@IdTablaMaestro", objBETablaMaestrodeta.IdTablaMaestro);
            prm_Params[1] = new Parameter("@Codigo", objBETablaMaestrodeta.Codigo);
            prm_Params[2] = new Parameter("@flagSalida", DbType.Int32);
            prm_Params[3] = new Parameter("@IdCodigo", objBETablaMaestrodeta.IdCodigo);
            dop_DataOperation.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_DataOperation);
            if (Convert.ToInt32(dop_DataOperation.GetParameterByName("flagSalida").Value) >= 1)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}