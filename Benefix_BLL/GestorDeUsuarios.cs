using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeUsuarios
{

    private static GestorDeUsuarios instancia;
    private GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    private GestorDeBitacora m_GestorDeBitacora;
    private GestorDeEncriptacion m_GestorDeEncriptacion;
    private BaseDeDatos baseDeDatos;

    private GestorDeUsuarios()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
        m_GestorDeEncriptacion = GestorDeEncriptacion.ObtenerInstancia();
    }

    public static GestorDeUsuarios ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeUsuarios();
        }

        return instancia;
    }

    public List<Usuario> ConsultarUsuarios()
    {

        return null;
    }

    public List<Usuario> ConsultarUsuariosTodos()
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("SELECT * FROM USUARIO");

        List<Usuario> usuarios = new List<Usuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            Usuario usuario = new Usuario();

            usuario.nombreUsuario = m_GestorDeEncriptacion.DesencriptarAes(Convert.ToString(row["nombreUsuario"]));
            usuario.identificador = Convert.ToInt32(row["idUsuario"]);

            usuarios.Add(usuario);
        }
        return usuarios;
    }

    public Usuario ObtenerUsuario(int idUsuario)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("SELECT * FROM USUARIO WHERE idUsuario = " + idUsuario);
        List<Usuario> usuarios = new List<Usuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            Usuario usuario = new Usuario();


            usuario.nombreUsuario = m_GestorDeEncriptacion.DesencriptarAes(Convert.ToString(row["nombreUsuario"]));
            usuario.identificador = Convert.ToInt32(row["idUsuario"]);

            usuarios.Add(usuario);
        }
        return usuarios[0];
    }

    public int CrearUsuario(Usuario usuario)
    {

        return 0;
    }

    public int EliminarUsuario(Usuario usuario)
    {

        return 0;
    }

    public int ModificarIdioma(Usuario usuario, Idioma idioma)
    {

        return 0;
    }

    public int ModificarUsuario(Usuario usuario)
    {

        return 0;
    }

    public int RealizarLogIn(Usuario usuario)
    {

        return 0;
    }

    public int RealizarLogOut(Usuario usuario)
    {

        return 0;
    }

    private int VerificarEmail(String email)
    {

        return 0;
    }

}