using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using Ionic.Zip;
using Benefix_BLL;

public class GestorSistema
{

    private static GestorSistema instancia;
    public GestorDeUsuarios m_GestorDeUsuarios;
    public GestorDePatentes m_GestorDePatentes;
    public GestorIdioma m_GestorIdioma;

    //SDC Añadir relacion GestorDeEncriptacion 

    //SDC Relacion con gestor de digito verificador GestorDeDigitoVerificador

    private BaseDeDatos baseDeDatos;
    private Usuario usuarioEnSesion;

    public Usuario ObtenerUsuarioEnSesion()
    {
        return this.usuarioEnSesion;
    }

    private GestorSistema()
    {
        if (Benefix.Default.StringDeConexion.Length == 0)
        {
            throw new Exception("El string de conexion no se encuentra configurado.");
        }
        baseDeDatos = BaseDeDatos.ObtenerInstancia(GestorDeEncriptacion.DesencriptarRSA(Benefix.Default.StringDeConexion));
    }

    public static GestorSistema ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorSistema();
        }

        return instancia;
    }

    public int ConsultarIntegridadDeBaseDeDatos()
    {

        var map = new Dictionary<String, List<String>>();
        map.Add("BITACORA", new List<String>() { "criticidad", "descripcion", "fecha", "funcionalidad", "Usuario_idUsuario" });
        map.Add("USUARIO", new List<String>() { "nombreUsuario", "nombre", "apellido", "contrasena" });
        map.Add("PATENTEUSUARIO", new List<String>() { "esPermisiva", "Patente_idPatente", "Usuario_idUsuario" });
        map.Add("FAMILIAPATENTE", new List<String>() { "Patente_idPatente", "Familia_idFamilia" });
        map.Add("BENEFICIO", new List<String>() { "descripcion", "puntaje" });
        //SDC Modificar campos que contendran DVH en la tabla EVALUACION
        map.Add("EVALUACION", new List<String>() { "puntaje", "periodo" });


        foreach (String tabla in map.Keys)
        {
            if (ConsultaIntegridadDeUnaTabla(tabla, map[tabla]) == 0)
            {
                return 0;
            }
        }
        return 1;
    }

    private int ConsultaIntegridadDeUnaTabla(String tabla, List<String> atributos)
    {

        DataTable dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM {0}", tabla));

        String digitosVHBitacora = "";
        foreach (DataRow eventoBitacora in dataTable.Rows)
        {
            List<String> argumentos = new List<String>();
            foreach (String atributo in atributos)
            {
                argumentos.Add(Convert.ToString(eventoBitacora[atributo]));
            }

            var digitoVH = GestorDeDigitoVerificador.ObtenerDigitoVH(argumentos);

            if (!digitoVH.Equals(Convert.ToString(eventoBitacora["digitoVerificadorH"])))
            {
                return 0;
            }

            digitosVHBitacora = digitosVHBitacora + digitoVH;
        }

        if (digitosVHBitacora.Length > 0)
        {
            dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT digitoVerificador FROM digitoverificadorvertical WHERE tabla = '{0}'", tabla));

            if (dataTable.Rows.Count > 0)
            {
                if (!Convert.ToString(dataTable.Rows[0]["digitoVerificador"]).Equals(GestorDeEncriptacion.EncriptarMD5(digitosVHBitacora)))
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        return 1;
    }

    public int RealizarLogIn(Usuario usuario)
    {
        this.usuarioEnSesion = usuario;
        Usuario usuarioLogin = GestorDeUsuarios.ObtenerInstancia().RealizarLogIn(usuario);
        if (usuarioLogin == null)
        {
            return 0;
        }
        this.usuarioEnSesion = usuarioLogin;

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Login", criticidad = 3, funcionalidad = "LOGIN", usuario = ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return 1;
    }

    public static int ModificarStringDeConexion(String stringDeConexion)
    {

        Benefix.Default.StringDeConexion = stringDeConexion;
        Benefix.Default.Save();
        try
        {
            instancia = new GestorSistema();
            BaseDeDatos.ObtenerInstancia().ConsultarBase("SELECT 1");
        }
        catch (Exception e)
        {
            return 0;
        }
        //EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el String de conexión.", criticidad = 1, funcionalidad = "MODIFICAR STRING DE CONEXION", usuario = ObtenerUsuarioEnSesion()!=null? ObtenerUsuarioEnSesion(): 0 };
        //GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return 1;
    }

    public int RealizarBackup(String rutaDestino, int cantidadVolumenes)
    {
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                var backupPath = baseDeDatos.ObtenerBackup();
                var ruta = backupPath;
                var multiplesVolumenes = cantidadVolumenes > 1;
                var rutaDestinoTemp = rutaDestino + "\\Benefix-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".zip";

                zip.AddFile(ruta, "");
                zip.TempFileFolder = Path.GetTempPath();
                zip.Save(rutaDestinoTemp);

                if (cantidadVolumenes > 1)
                {
                    FileInfo fileInfo = new FileInfo(rutaDestinoTemp);
                    var tamañoDeVolumen = fileInfo.Length / cantidadVolumenes;

                    using (ZipFile zip2 = new ZipFile())
                    {
                        zip2.MaxOutputSegmentSize = (int)tamañoDeVolumen;
                        zip2.AddFile(rutaDestinoTemp, "");
                        zip2.TempFileFolder = Path.GetTempPath();
                        zip2.Save(rutaDestinoTemp);
                    }

                }
            }
        }
        catch (Exception e)
        {
            return 0;
        }
        return 1;
    }

    public int RealizarRestore(String rutaOrigen)
    {
        try
        {
            DataTable rutaBackupDataTable = baseDeDatos.ConsultarBase("EXEC xp_instance_regread  N'HKEY_LOCAL_MACHINE', N'Software\\Microsoft\\MSSQLServer\\MSSQLServer',N'BackupDirectory'");
            var rutaBackup = "";
            foreach (DataRow row in rutaBackupDataTable.Rows)
            {
                rutaBackup = row["Data"].ToString();
            }

            using (ZipFile zipFile = new ZipFile(rutaOrigen))
            {
                rutaBackup = rutaBackup + "\\Backup-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                zipFile.ExtractAll(rutaBackup);

                string[] zipFiles = Directory.GetFiles(rutaBackup, "*.zip*", SearchOption.AllDirectories);

                if (zipFiles.Length > 0)
                {
                    var zipFile2 = new ZipFile(zipFiles[0]);
                    zipFile2.ExtractAll(rutaBackup);
                }

                string[] backFiles = Directory.GetFiles(rutaBackup, "*.bak*", SearchOption.AllDirectories);

                if (backFiles.Length == 1)
                {
                    baseDeDatos.RealizarRestore(backFiles[0]);
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception e)
        {
            return 0;
        }
        return 1;
    }

    public bool ConsultarPatentePorUsuario(String patente)
    {
        if (baseDeDatos.ConsultarBase(String.Format("select * from patenteusuario inner join patente on patente.idPatente = patenteusuario.Patente_idPatente where patenteusuario.esPermisiva = 0 and patenteusuario.Usuario_idUsuario = {0} and patente.nombre = '{1}'", usuarioEnSesion.identificador, patente)).Rows.Count != 0)
        {
            return false;
        }
        return baseDeDatos.ConsultarBase(String.Format("select * from familiausuario inner join familiapatente on familiapatente.Familia_idFamilia = familiausuario.Familia_idFamilia inner join patente on patente.idPatente = familiapatente.Patente_idPatente where familiausuario.Usuario_idUsuario = {0} and patente.nombre = '{1}'", usuarioEnSesion.identificador, patente)).Rows.Count != 0;
    }
}