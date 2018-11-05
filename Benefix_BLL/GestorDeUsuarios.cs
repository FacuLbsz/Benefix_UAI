using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Net.Mail;

public class GestorDeUsuarios
{

    private static GestorDeUsuarios instancia;
    private GestorDeDigitoVerificador GestorDeDigitoVerificador;
    private GestorDeBitacora m_GestorDeBitacora;
    private GestorDeEncriptacion GestorDeEncriptacion;

    private GestorDeUsuarios()
    {
        GestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
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
        DataTable dataTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(consulta);

        List<Usuario> usuarios = new List<Usuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            Usuario usuario = new Usuario();

            usuario = PopularUsuarioDesdeBD(row);
            usuario.nombreUsuario = GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);

            usuarios.Add(usuario);
        }
        return usuarios;
    }

    public Usuario ObtenerUsuario(int idUsuario)
    {
        Usuario usuario = ObtenerUsuarioBD(idUsuario);
        usuario.nombreUsuario = GestorDeEncriptacion.DesencriptarAes(usuario.nombreUsuario);
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
        DataTable dataTable = BaseDeDatos.ObtenerInstancia().ConsultarBase("SELECT * FROM USUARIO WHERE idUsuario = " + idUsuario);
        Usuario usuario = new Usuario();
        foreach (DataRow row in dataTable.Rows)
        {
            usuario = PopularUsuarioDesdeBD(row);
        }
        return usuario;
    }

    public int CrearUsuario(Usuario usuario)
    {
        if(VerificarEmail(usuario.email) == 1){

            throw new EntidadDuplicadaExcepcion("email");
        }

        usuario.nombreUsuario = GestorDeEncriptacion.EncriptarAes(usuario.nombreUsuario);

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE nombreUsuario = '{0}'", usuario.nombreUsuario)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombreUsuario");
        }

        usuario.contrasena = GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuario);

        usuario.idioma = new Idioma() { identificador = 1 };

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("INSERT INTO USUARIO(nombreUsuario,contrasena,nombre,apellido,email,Idioma_idIdioma,habilitado,digitoVerificadorH) VALUES ('{0}','{1}','{2}','{3}','{4}',{5},1,'{6}')", usuario.nombreUsuario, usuario.contrasena, usuario.nombre, usuario.apellido, usuario.email, usuario.idioma.identificador, digitoVH));

        GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
    }

    public int EliminarUsuario(Usuario usuario)
    {
        return BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET habilitado = 0 WHERE idUsuario = {0}", usuario.identificador));
    }

    public int ModificarIdioma(Usuario usuario, Idioma idioma)
    {

        usuario = ObtenerUsuarioBD(usuario.identificador);
        usuario.idioma = idioma;

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuario);

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET Idioma_idIdioma = {0}, digitoVerificadorH = '{1}' WHERE idUsuario = {2}", usuario.idioma.identificador, digitoVH, usuario.identificador));
        GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
    }

    public int ModificarUsuario(Usuario usuario)
    {
        Usuario usuarioViejo = ObtenerUsuarioBD(usuario.identificador);

        String set = "";
        if (usuario.nombre != null && usuarioViejo.nombre != usuario.nombre)
        {
            usuarioViejo.nombre = usuario.nombre;
            set = String.Format(" nombre = '{0}' ", usuario.nombre);
        }
        if (usuario.apellido != null && usuarioViejo.apellido != usuario.apellido)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            usuarioViejo.apellido = usuario.apellido;
            set = set + String.Format(" apellido = '{0}' ", usuario.apellido);
        }

        if (usuario.email != null && usuarioViejo.email != usuario.email)
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
            var contrasenaEncriptada = GestorDeEncriptacion.EncriptarMD5(usuario.contrasena);
            usuarioViejo.contrasena = contrasenaEncriptada;
            set = set + String.Format(" contrasena = '{0}' ", contrasenaEncriptada);
        }

        var digitoVH = ObtenerDigitoVerificadorHDeUsuario(usuarioViejo);

        if (set.Length > 0)
        {
            set = set + " , ";
        }
        set = set + String.Format(" digitoVerificadorH = '{0}' ", digitoVH);

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE USUARIO SET {0} WHERE idUsuario = {1}", set, usuario.identificador));
        GestorDeDigitoVerificador.ModificarDigitoVV("USUARIO");

        return registros;
    }

    public Usuario RealizarLogIn(Usuario usuario)
    {

        return null;
    }

    public int RealizarLogOut(Usuario usuario)
    {

        return 0;
    }

    private int VerificarEmail(String email)
    {
        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM USUARIO WHERE email = '{0}'", email)).Rows.Count > 0)
        {
            return 1;
        }

        return 0;
    }

    private String ObtenerDigitoVerificadorHDeUsuario(Usuario usuario)
    {
        return GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { usuario.nombreUsuario, usuario.nombre, usuario.apellido, usuario.contrasena });
    }

}