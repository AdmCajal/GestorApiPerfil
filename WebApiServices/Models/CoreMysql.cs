using MySqlConnector;
using System;
using System.Configuration;
using System.Data;
using WebApiServices.Models.Entidades;

namespace WebApiServices.Models
{
    public class CoreMysql
    {
        //[Obsolete]
        //readonly static string strconexion = ConfigurationSettings.AppSettings["IpLocal"];

        //public static DataTable Listar(string _query, string _type = "insert")
        //{
        //    DataSet ds_Result = new DataSet();
        //    MySqlConnection cnx = new MySqlConnection(strconexion);
        //    cnx.Open();
        //    MySqlCommand cmd = new MySqlCommand(_query, cnx);
        //    if (_type == "select")
        //    {
        //        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //        da.Fill(ds_Result);
        //        if (ds_Result == null || ds_Result.Tables.Count == 0)
        //        {
        //            return null;
        //        }
        //        ds_Result.Tables[0].TableName = "Zero";
        //    }
        //    cnx.Close();
        //    return ds_Result.Tables[0];
        //}

        //public static int Ejecutar(string _query, string _type = "insert")
        //{
        //    using (MySqlConnection cnx = new MySqlConnection(strconexion))
        //    {
        //        cnx.Open();
        //        int retorno = 0;
        //        MySqlCommand cmd = new MySqlCommand(_query, cnx);
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        if (_type != "select")
        //        {
        //            retorno = cmd.ExecuteNonQuery();
        //        }
        //        cnx.Close();
        //        return retorno;
        //    }
        //}

        //public static DataTable ListaTabla(Nullable<Int32> Flat, string strQuery)
        //{
        //    DataTable dt_Result = null;
        //    try
        //    {
        //        if (Flat == 1)
        //        {
        //            dt_Result = CoreMysql.Listar(strQuery, "select");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string asunto = System.DateTime.Now + " " + ex.ToString().Substring(25, 50);
        //        //CoreSql.WriteLog(asunto + " | " + ex.ToString().Substring(25, 50));
        //    }
        //    return dt_Result;
        //}

        //public static DataTable DataRubConsultar(string _databaseNew, string Empresa, string Documento, string periodo)
        //{
        //    DataSet ds_Result = new DataSet();
        //    using (MySqlConnection con = new MySqlConnection(strconexion))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("SP_DataRubConsultar", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("?IN_Empresa", Empresa);
        //            cmd.Parameters["?IN_Empresa"].Direction = ParameterDirection.Input;
        //            cmd.Parameters.AddWithValue("?IN_Documento", Documento);
        //            cmd.Parameters["?IN_Documento"].Direction = ParameterDirection.Input;
        //            cmd.Parameters.AddWithValue("?IN_periodo", periodo);
        //            cmd.Parameters["?IN_periodo"].Direction = ParameterDirection.Input;
        //            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                if (ds_Result == null || ds_Result.Tables.Count == 0)
        //                {
        //                    return null;
        //                }
        //                ds_Result.Tables[0].TableName = "Zero";
        //            }
        //        }
        //        con.Close();
        //    }

        //    return ds_Result.Tables[0];
        //}

        //public static int InsertarDetPagina(DtoDetPagina dto)
        //{
        //    using (MySqlConnection cn = new MySqlConnection(strconexion))
        //    {
        //        int retorno = 0;
        //        string query = "INSERT INTO DetPagina " +
        //        "(IdDetpagina ,Idpagina ,Tipo ,Secuencia ,Descripcion_Uno ,Descripcion_Dos ,Descripcion_tres ,Descripcion_Cuatro ,Imagen_Name,Imagen_Type,Imagen_Size,usuario_Modificacion ,Fecha_Modificacion ,IdPadre,Imagen_Base )" +
        //        " VALUES (?IdDetpagina ,?Idpagina ,?Tipo ,?Secuencia ,?Descripcion_Uno ,?Descripcion_Dos ,?Descripcion_tres ,?Descripcion_Cuatro ,?Imagen_Name,?Imagen_Type,?Imagen_Size,?usuario_Modificacion ,?Fecha_Modificacion ,?IdPadre,?Imagen_Base);";
        //        cn.Open();
        //        using (MySqlCommand cmd = new MySqlCommand(query, cn))
        //        {
        //            DateTime MyDate = DateTime.Now;
        //            String MyString = MyDate.ToString("yyyy-MM-dd HH:MM");
        //            dto.Fecha_Modificacion = MyString;
        //            cmd.Parameters.Add("?IdDetpagina", MySqlDbType.Int32).Value = dto.IdDetpagina;
        //            cmd.Parameters.Add("?Idpagina", MySqlDbType.Int32).Value = dto.Idpagina;
        //            cmd.Parameters.Add("?Secuencia", MySqlDbType.Int32).Value = dto.Secuencia;
        //            cmd.Parameters.Add("?Tipo", MySqlDbType.VarChar).Value = dto.Tipo;
        //            cmd.Parameters.Add("?Descripcion_Uno", MySqlDbType.VarChar).Value = dto.Descripcion_Uno;
        //            cmd.Parameters.Add("?Descripcion_Dos", MySqlDbType.VarChar).Value = dto.Descripcion_Dos;
        //            cmd.Parameters.Add("?Descripcion_tres", MySqlDbType.VarChar).Value = dto.Descripcion_tres;
        //            cmd.Parameters.Add("?Descripcion_Cuatro", MySqlDbType.VarChar).Value = dto.Descripcion_Cuatro;
        //            cmd.Parameters.Add("?Imagen_Name", MySqlDbType.VarChar).Value = dto.Imagen_Name;
        //            cmd.Parameters.Add("?Imagen_Type", MySqlDbType.VarChar).Value = dto.Imagen_Type;
        //            cmd.Parameters.Add("?Imagen_Size", MySqlDbType.Int32).Value = dto.Imagen_Size;
        //            cmd.Parameters.Add("?usuario_Modificacion", MySqlDbType.VarChar).Value = dto.usuario_Modificacion;
        //            cmd.Parameters.Add("?Fecha_Modificacion", MySqlDbType.VarChar).Value = dto.Fecha_Modificacion;
        //            cmd.Parameters.Add("?IdPadre", MySqlDbType.Int32).Value = dto.IdPadre;
        //            cmd.Parameters.Add("?Imagen_Base", MySqlDbType.LongText).Value = dto.Imagen_Base;
        //            //cmd.Parameters.Add("?UsuarioCreacion", MySqlDbType.VarChar).Value = ASITramiteBandeja.UsuarioCreacion;
        //            //cmd.Parameters.Add("?FechaCreacion", MySqlDbType.VarChar).Value = MyString;
        //            //cmd.Parameters.Add("?IpCreacion", MySqlDbType.VarChar).Value = ASITramiteBandeja.IpCreacion;
        //            retorno = cmd.ExecuteNonQuery();
        //        }
        //        cn.Close();
        //        return retorno;
        //    }
        //}


    }
}