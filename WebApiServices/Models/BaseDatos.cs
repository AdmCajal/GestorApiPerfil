using RoyalSystems.Data;
using System;
using System.Data;
using System.IO;
using WebApiServices.Models.Entidades;

namespace WebApiServices.Models
{
    public class BaseDatos
    {
        public static void SaveLog(String documento, int tipoerror, String mensaje, String JsonSeguimiento, int lineaerror, String usuario, String Proceso)
        {
            //var sqlString = UtilsGlobal.ConvertLinesSqlXml("QueryMiscelaneos", "Miscelaneos.ControlErroresLOG");
            // List<SqlParameter> parametros = new List<SqlParameter>();
            // parametros.Add(new SqlParameter("@Documento", documento));
            // parametros.Add(new SqlParameter("@TipoError", tipoerror));
            // parametros.Add(new SqlParameter("@MensajeError", mensaje));
            // parametros.Add(new SqlParameter("@JsonSeguimiento", JsonSeguimiento));
            // parametros.Add(new SqlParameter("@LineaError", lineaerror));
            // parametros.Add(new SqlParameter("@Usuario", usuario));
            // parametros.Add(new SqlParameter("@Proceso", Proceso));
            // UtilsDAO.ExecuteQueryCRUD(sqlString, parametros);
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static int InsertarLog(string IdOrdenAtencion, string Lineas, string Trama, string Observacion)
        {
            try
            {
                DataOperation dop_Operacion = new DataOperation("WCO_InsertarPdfLog");
                Parameter[] prm_Params = new Parameter[5];
                prm_Params[0] = new Parameter("@Id", DbType.Int32);
                prm_Params[1] = new Parameter("@IdOrdenAtencion", IdOrdenAtencion);
                prm_Params[2] = new Parameter("@Lineas", Lineas);
                prm_Params[3] = new Parameter("@Trama", Trama);
                prm_Params[4] = new Parameter("@Observacion", Observacion);
                dop_Operacion.Parameters.AddRange(prm_Params);
                DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
                return int.Parse(dop_Operacion.GetParameterByName("@Id").Value.ToString());
            }
            catch (Exception ex)
            {
                string asunto = System.DateTime.Now + " | " + "Error Conexión con el SQl ";
                WriteLog(asunto + " | " + ex.ToString().Substring(25, 50));
                return 0;
            }
        }

        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = Path.GetFullPath("\\Logs\\");
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("dd-MM-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }


        public static DataTable GroupBy(string i_sGroupByColumn, string i_sAggregateColumn, DataTable i_dSourceTable)
        {
            DataView dv = new DataView(i_dSourceTable);
            //getting distinct values for group column
            //DataTable dtGroup = dv.ToTable(true, new string[] { "IdProvedor" });
            DataTable dtGroup = dv.ToTable(true, new string[] { i_sGroupByColumn });
            //adding column for the row count
            dtGroup.Columns.Add("Count", typeof(int));
            //looping thru distinct values for the group, counting
            foreach (DataRow dr in dtGroup.Rows)
            {
                dr["Count"] = i_dSourceTable.Compute("Count(" + i_sAggregateColumn + ")", i_sGroupByColumn + " = '" + dr[i_sGroupByColumn] + "'");
            }
            //returning grouped/counted result
            return dtGroup;
        }

        ///<summary>Actualizar el registro en la tabla PERSONAMAST.</summary>
        ///<param name="obj_pSA_Curriculo">Entidad de Negocio</param>
        ///<remarks><list type="bullet">
        ///<item><CreadoPor>Creado PorJordan Mateo Pizarro</CreadoPor></item>
        ///<item><FecCrea>17/10/2012</FecCrea></item></list></remarks>
        public static void InsertarUsuarioWeb(ADBE_PersonaMast BE_pPersona)
        {
            DataOperation dop_Operacion = new DataOperation("WCO_InsertarPersonaPassword");
            Parameter[] prm_Params = new Parameter[3];
            prm_Params[0] = new Parameter("@IdPersona", BE_pPersona.PK.IdPersona);
            prm_Params[1] = new Parameter("@PerNumeroDocumento", BE_pPersona.PerNumeroDocumento);
            prm_Params[2] = new Parameter("@ClasificadorMovimiento", BE_pPersona.SunatUbigeo);
            dop_Operacion.Parameters.AddRange(prm_Params);
            DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        }


    }
}