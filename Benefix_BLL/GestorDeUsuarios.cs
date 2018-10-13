using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeUsuarios
{

    private GestorDeUsuarios instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    public GestorDeBitacora m_GestorDeBitacora;
    public GestorDeEncriptacion m_GestorDeEncriptacion;

    private GestorDeUsuarios()
    {

    }

    public GestorDeUsuarios ObtenerInstancia()
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

        return null;
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