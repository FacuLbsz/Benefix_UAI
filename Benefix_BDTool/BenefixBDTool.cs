using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benefix_BDTool
{
    public partial class BenefixBDTool : Form
    {
        static String RSAPublicKey = "<RSAKeyValue><Modulus>tsBjrD7cndJc2qhIi0g889KsAy3w/YH+35+k7QsHA23nS8sMwfLzYPjVqYXe+xzJyGr5iaBT58XSoDDTVMViaC/x7XqXlAQyLuHcwrRX2XbLatKXLXfk7glaBGsR/YTUgqDEFlFn6qtMdb8ho3xbw2VC93si6hlpwoYdYqqTu5U=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public BenefixBDTool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0 && (checkBox1.Checked || textBox2.Text.Trim().Length > 0 && textBox3.Text.Trim().Length > 0))
            {
                var stringDeConexion = "";
                if (checkBox1.Checked)
                {
                    var stringDeConexionSeguridadW = "Data Source={0};Initial Catalog=Benefix;Integrated Security=True";
                    stringDeConexion = String.Format(stringDeConexionSeguridadW, textBox1.Text.Trim());
                }
                else
                {
                    var stringDeConexionSeguridadUP = "Persist Security Info=False;User ID={0};Password={1};Initial Catalog=Benefix;Server={2}";
                    stringDeConexion = String.Format(stringDeConexionSeguridadUP, textBox2.Text.Trim(), textBox3.Text, textBox1.Text.Trim());

                }
                RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(2028);
                rsaProvider.FromXmlString(RSAPublicKey);
                byte[] encryptedData = rsaProvider.Encrypt(Encoding.ASCII.GetBytes(stringDeConexion), false);

                richTextBox1.Text = Convert.ToBase64String(encryptedData);
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos requeridos.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = !checkBox1.Checked;
            textBox3.Enabled = !checkBox1.Checked;
        }
    }
}
