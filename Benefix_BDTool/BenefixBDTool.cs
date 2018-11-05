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
            if(textBox1.Text.Trim().Length > 0)
            {
                    RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider(1024);
                    rsaProvider.FromXmlString(RSAPublicKey);
                    byte[] encryptedData = rsaProvider.Encrypt(Encoding.ASCII.GetBytes(textBox1.Text), false);

                    richTextBox1.Text = Convert.ToBase64String(encryptedData);
            }
        }
    }
}
