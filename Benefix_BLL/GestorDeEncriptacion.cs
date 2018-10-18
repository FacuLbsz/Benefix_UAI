
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class GestorDeEncriptacion
{

    String salt = "EC91C6E167CEBA61";
    String AESKEY = "eckIEptpScebO7eOMmHlEcH7D8yOTz7GPFT7mrqSnY4=";
    String AESIV = "AK8p702PFr4eWbb6B1g82Q==";

    private static GestorDeEncriptacion instancia;

    private GestorDeEncriptacion()
    {

    }

    public static GestorDeEncriptacion ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEncriptacion();
        }

        return instancia;
    }

    //SDC Modificar List por String como argumentos y retorno
    public String DesencriptarAes(String informacionEncriptada)
    {
        string informacionDesencriptada = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(AESKEY);
            aesAlg.IV = Convert.FromBase64String(AESIV);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(informacionEncriptada)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        informacionDesencriptada = srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        return informacionDesencriptada;
    }


    //SDC Modificar List por String como argumentos y retorno
    public String EncriptarAes(String informacionAEncriptar)
    {
        byte[] informacionEncriptada;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Convert.FromBase64String(AESKEY);
            aesAlg.IV = Convert.FromBase64String(AESIV);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(informacionAEncriptar);
                    }
                    informacionEncriptada = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(informacionEncriptada);
    }

    //SDC Cambiar List por String
    public String EncriptarMD5(String informacion)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(informacion);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

}