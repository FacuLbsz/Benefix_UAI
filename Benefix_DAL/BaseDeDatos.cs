using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data;

public class BaseDeDatos
{

    private String sqlString = "Persist Security Info=False;User ID=sa;Password=qwer1234;Initial Catalog=Benefix;Server=DESKTOP-VA9KCI4\\SQLEXPRESS";
    private SqlConnection sqlConnection;
    private static BaseDeDatos instancia;

    private BaseDeDatos()
    {
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }

    private BaseDeDatos(String sqlString)
    {
        this.sqlString = sqlString;
        sqlConnection = new SqlConnection(sqlString);
        Console.WriteLine("Conexion realizada!");
    }

    public static void ReiniciarInstancia(String sqlString)
    {
        instancia = new BaseDeDatos();
    }

    public static BaseDeDatos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new BaseDeDatos();
        }
        return instancia;
    }

    public DataTable ConsultarBase(String query)
    {
        AbrirConexion();
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(CrearComandoSQL(query));
        DataTable dataTable = new DataTable();

        sqlDataAdapter.Fill(dataTable);
        CerrarConexion();

        return dataTable;
    }

    public int ModificarBase(String query)
    {

        return 0;
    }

    private void AbrirConexion()
    {
        sqlConnection.Open();
    }

    private void CerrarConexion()
    {
        sqlConnection.Close();
    }

    private SqlCommand CrearComandoSQL(String comandoSQL)
    {
        return new SqlCommand(comandoSQL, sqlConnection);
    }

}