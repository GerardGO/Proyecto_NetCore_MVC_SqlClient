using System;
using System.Collections.Generic;
using System.Linq;

using System.Data;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;

public class DBHelper
{
    // recuperando la cadena de conexión desde el appsettings.json
    private string cad_cn = "";

    public DBHelper(IConfiguration _config)
    {
        cad_cn = _config.GetConnectionString("cn1");
    }

    void LlenarParametros(SqlCommand cmd, params object[] prms)
    {
        int indice = 0;
        // descubre los parámetros del proced. almacenado que el
        // sqlcommand va a ejecutar
        SqlCommandBuilder.DeriveParameters(cmd);
        // recorrer la lista de parametros del proced. alm. del sqlcommand
        foreach (SqlParameter item in cmd.Parameters)
        {
            // si el nombre del parámetro encontrado es diferente de
            // @RETURN_VALUE el cual es del SQL, entonces estamos frente
            // a un parámetro de usuario
            if (item.ParameterName != "@RETURN_VALUE")
            {
                item.Value = prms[indice];
                indice++;
            }
        }
    }

    public void EjecutarSP_TRX(string NombreSP, params object[] Parametros)
    {
        SqlConnection cnx = new SqlConnection(cad_cn);
        cnx.Open();
        // definimos un objeto SqlTransaction que trabaje con el 
        // SqlConnection
        SqlTransaction TRX = cnx.BeginTransaction();
        // definir un bloque Try - Catch
        try
        {
            // El SqlCommand trabaja dentro de la Transacción
            SqlCommand comando = new SqlCommand(NombreSP, cnx, TRX);
            comando.CommandType = CommandType.StoredProcedure;
            // Si hay Parametros
            if (Parametros.Length > 0)
                LlenarParametros(comando, Parametros);
            //
            comando.ExecuteNonQuery();
            // SI NO EXISTE NINGÚN ERROR, ENTONCES CONFIRMAMOS LA
            // TRANSACCION
            TRX.Commit();
        }
        catch (Exception ex)
        {
            // SI HUBIERA UN ERROR, ENTONCES CANCELAMOS LA TRANSACCION
            TRX.Rollback();
            throw new Exception(ex.Message);
        }
        finally {
            //
            cnx.Close();
        }
    }


    public void EjecutarSP(string NombreSP, params object[] Parametros)
    {
        SqlConnection cnx = new SqlConnection(cad_cn);
        cnx.Open();
        // definir un bloque Try - Catch
        try
        {
            SqlCommand comando = new SqlCommand(NombreSP, cnx);
            comando.CommandType = CommandType.StoredProcedure;
            // Si hay Parametros
            if (Parametros.Length > 0)
                LlenarParametros(comando, Parametros);
            //
            comando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            //
            cnx.Close();
        }
    }


    // método que ejecutará cualquier procedimiento almacenado
    // con "n" parámetros y devolverá un SqlDataReader
    public SqlDataReader EjecutarSPDataReader(string NombreSP, params object[] Parametros)
    {
        SqlConnection cnx = new SqlConnection(cad_cn);
        cnx.Open();
        //
        SqlCommand comando = new SqlCommand(NombreSP, cnx);
        comando.CommandType = CommandType.StoredProcedure;

        // Si hay Parametros
        if (Parametros.Length > 0)
            LlenarParametros(comando, Parametros);
        //
        SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
        //
        return dr;
    }

    // método que retorne un valor de tipo object proveniente (ExecuteScalar)
    // de un "X" proced. almacenado hasta con "n" parámetros
    public object EjecutarSPRetornaObject(string NombreSP, params object[] Parametros)
    {
        object rpta = null;
        SqlConnection cnx = new SqlConnection(cad_cn);
        cnx.Open();
        //
        SqlCommand comando = new SqlCommand(NombreSP, cnx);
        comando.CommandType = CommandType.StoredProcedure;
        // Si hay Parametros
        if (Parametros.Length > 0)
            LlenarParametros(comando, Parametros);
        //
        rpta = comando.ExecuteScalar();
        //
        cnx.Close();
        //
        return rpta;
    }
}

