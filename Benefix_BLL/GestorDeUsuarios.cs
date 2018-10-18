using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Net.Mail;

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
        return ConsultarUsuarios("SELECT * FROM USUARIO WHERE habilitado = 1");
    }


    public List<Usuario> ConsultarUsuariosTodos()
    {
        return ConsultarUsuarios("SELECT * FROM USUARIO");
    }

    private List<Usuario> ConsultarUsuarios(String consulta)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase(consulta);

        List<Usuario> usuarios = new List<Usuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            Usuario usuario = new Usuario();

            usuario = PopularUsuarioDesdeBD(row);
            //usuario.nombreUsuario = m_GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);

            usuarios.Add(usuario);
        }
        return usuarios;
    }

    public Usuario ObtenerUsuario(int idUsuario)
    {
        Usuario usuario = ObtenerUsuarioBD(idUsuario);
        //usuario.nombreUsuario = m_GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);
        return usuario;
    }

    private Usuario PopularUsuarioDesdeBD(DataRow usuarioRow)
    {
        Usuario usuario = new Usuario();
        usuario.identificador = Convert.ToInt32(usuarioRow["idUsuario"]);
        usuario.nombreUsuario = Convert.ToString(usuarioRow["nombreUsuario"]);
        usuario.contrasena = Convert.ToString(usuarioRow["contrasena"]);
        usuario.nombre = Convert.ToString(usuarioRow["nombre"]);
        usuario.apellido = Convert.ToString(usuarioRow["apellido"]);
        usuario.email = Convert.ToString(usuarioRow["email"]);
        usuario.idioma = new Idioma() { identificador = Convert.ToInt32(usuarioRow["Idioma_idIdioma"]) };
        usuario.habilitado = Convert.ToBoolean(usuarioRow["habilitado"]);
        return usuario;
    }

    private Usuario ObtenerUsuarioBD(int idUsuario)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("SELECT * FROM USUARIO WHERE idUsuario = " + idUsuario);
        Usuario usuario = new Usuario();
        foreach (DataRow row in dataTable.Rows)
        {
            usuario = PopularUsuarioDesdeBD(row);
        }
        return usuario;
    }

    public int CrearUsuario(Usuario usuario)
    {
        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE email = '{0}')", usuario.email)).Rows.Count > 0)
        {
            //TODO Throw exception de entidad repetida
        }

        usuario.nombreUsuario = m_GestorDeEncriptacion.EncriptarAes(usuario.nombreUsuario);

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE nombreUsuario = '{0}')", usuario.nombreUsuario)).Rows.Count > 0)
        {
            //TODO Throw exception de entidad repetida
        }

        usuario.contrasena = m_GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuario);

        var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO USUARIO(nombreUsuario,contrasena,nombre,apellido,email,Idioma_idIdioma,habilitado,digitoVerificadorH) VALUES ('{0}','{1}','{2}','{3}','{4}',{5},1,'{6}')", usuario.nombreUsuario, usuario.contrasena, usuario.nombre, usuario.apellido, usuario.email, usuario.idioma.identificador, digitoVH));

        m_GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
    }

    public int EliminarUsuario(Usuario usuario)
    {
        return baseDeDatos.ModificarBase(String.Format("UPDATE USUARIO SET habilitado = 0 WHERE idUsuario = {0}", usuario.identificador));
    }

    public int ModificarIdioma(Usuario usuario, Idioma idioma)
    {

        usuario = ObtenerUsuarioBD(usuario.identificador);
        usuario.idioma = idioma;

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuario);

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE USUARIO SET Idioma_idIdioma = {0}, digitoVerificadorH = {1} WHERE idUsuario = {2}", usuario.idioma.identificador, digitoVH, usuario.identificador));
        m_GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
    }

    public int ModificarUsuario(Usuario usuario)
    {
        Usuario usuarioViejo = ObtenerUsuarioBD(usuario.identificador);

        String set = "";
        if (usuario.nombre != null)
        {
            usuarioViejo.nombre = usuario.nombre;
            set = String.Format(" nombre = '{0}' ", usuario.nombre);
        }
        if (usuario.apellido != null)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            usuarioViejo.apellido = usuario.apellido;
            set = set + String.Format(" apellido = '{0}' ", usuario.apellido);
        }

        if (usuario.email != null)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            usuarioViejo.email = usuario.email;
            set = set + String.Format(" email = '{0}' ", usuario.email);
        }

        if (usuario.contrasena != null)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            var contrasenaEncriptada = m_GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);
            usuarioViejo.contrasena = contrasenaEncriptada;
            set = set + String.Format(" contrasena = '{0}' ", contrasenaEncriptada);
        }

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuarioViejo);

        if (set.Length > 0)
        {
            set = set + " , ";
        }
        set = set + String.Format(" digitoVerificadorH = '{0}' ", digitoVH);

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE USUARIO SET {0} WHERE idUsuario = {1}", set, usuario.identificador));
        m_GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
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
        try
        {
            MailAddress m = new MailAddress(email);
            return 1;
        }
        catch (FormatException)
        {
            return 0;
        }
    }

    private String ObtenerDigitoVerificadorHDeUsuario(Usuario usuario)
    {
        return m_GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { usuario.nombreUsuario, usuario.nombre, usuario.apellido, usuario.contrasena });
    }

}