using RoyalSystems.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace WebApiServices.Models.Datos
{
    public class ADDAT_Horario
    {
        //public List<WCO_ListarHorario_Result> ListarHorario(WCO_ListarHorario_Result ObjEntidad)
        //{
        //    List<WCO_ListarHorario_Result> lst = new List<WCO_ListarHorario_Result>();
        //    using (var context = new BDInmobiliariaEntities())
        //    {
        //        lst = context.WCO_ListarHorario(ObjEntidad.IdHorario, ObjEntidad.Nombre, ObjEntidad.Estado).ToList();
        //    }
        //    return lst;
        //}

        //public int Insertar(WCO_ListarHorario_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    bool isExists = false;
        //    DataSet ds_Result = null;
        //    //isExists = ValidarExiste(ObjEntidad);
        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_InsertarHorario");
        //        Parameter[] prm_Params = new Parameter[13];
        //        prm_Params[0] = new Parameter("@IdHorario", DbType.Int32);
        //        prm_Params[1] = new Parameter("@Nombre", ObjEntidad.Nombre);
        //        prm_Params[2] = new Parameter("@IdHorario", DbType.Int32);
        //        prm_Params[3] = new Parameter("@Flat", ObjEntidad.Flat);
        //        prm_Params[4] = new Parameter("@HoraInicio", ObjEntidad.HoraInicio);
        //        prm_Params[5] = new Parameter("@HoraFinal", ObjEntidad.HoraFinal);
        //        prm_Params[6] = new Parameter("@Flatoler", ObjEntidad.Flatoler);
        //        prm_Params[7] = new Parameter("@Tiempotoler", ObjEntidad.Tiempotoler);
        //        prm_Params[8] = new Parameter("@FlaExt", ObjEntidad.FlaExt);
        //        prm_Params[9] = new Parameter("@TiempoExt", ObjEntidad.TiempoExt);
        //        prm_Params[10] = new Parameter("@Estado", ObjEntidad.Estado);
        //        prm_Params[11] = new Parameter("@UsuarioCreacion", ObjEntidad.UsuarioCreacion);
        //        prm_Params[12] = new Parameter("@IpCreacion", ObjEntidad.IpCreacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        ds_Result = DataManager.ExecuteDataSet(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //        valor = int.Parse(dop_Operacion.GetParameterByName("@IdHorario").Value.ToString());
        //        ObjEntidad.IdHorario = valor;
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public int Actualizar(WCO_ListarHorario_Result ObjEntidad)
        //{
        //    int valor = 0;
        //    bool isExists = false;
        //    if (!isExists)
        //    {
        //        DataOperation dop_Operacion = new DataOperation("WCO_ActualizarHorario");
        //        Parameter[] prm_Params = new Parameter[13];
        //        prm_Params[0] = new Parameter("@IdHorario", ObjEntidad.IdHorario);
        //        prm_Params[1] = new Parameter("@Nombre", ObjEntidad.Nombre);
        //        prm_Params[2] = new Parameter("@IdHorario", DbType.Int32);
        //        prm_Params[3] = new Parameter("@Flat", ObjEntidad.Flat);
        //        prm_Params[4] = new Parameter("@HoraInicio", ObjEntidad.HoraInicio);
        //        prm_Params[5] = new Parameter("@HoraFinal", ObjEntidad.HoraFinal);
        //        prm_Params[6] = new Parameter("@Flatoler", ObjEntidad.Flatoler);
        //        prm_Params[7] = new Parameter("@Tiempotoler", ObjEntidad.Tiempotoler);
        //        prm_Params[8] = new Parameter("@FlaExt", ObjEntidad.FlaExt);
        //        prm_Params[9] = new Parameter("@TiempoExt", ObjEntidad.TiempoExt);
        //        prm_Params[10] = new Parameter("@Estado", ObjEntidad.Estado);
        //        prm_Params[11] = new Parameter("@UsuarioModificacion", ObjEntidad.UsuarioModificacion);
        //        prm_Params[12] = new Parameter("@IpModificacion", ObjEntidad.IpModificacion);
        //        dop_Operacion.Parameters.AddRange(prm_Params);
        //        DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //    }
        //    else
        //    {
        //        valor = -1;
        //    }
        //    return valor;
        //}

        //public void Inactivar(WCO_ListarHorario_Result ObjEntidad)
        //{
        //    DataOperation dop_Operacion = new DataOperation("WCO_InactivarHorario");
        //    Parameter[] prm_Params = new Parameter[3];
        //    prm_Params[0] = new Parameter("@IdHorario", ObjEntidad.IdHorario);
        //    prm_Params[1] = new Parameter("@Estado", ObjEntidad.Estado);
        //    prm_Params[2] = new Parameter("@UsuarioModificacion", ObjEntidad.UsuarioModificacion);
        //    dop_Operacion.Parameters.AddRange(prm_Params);
        //    DataManager.ExecuteNonQuery(DAT_Conexion.Co_ConnecPrecisa, dop_Operacion);
        //}
    }
}