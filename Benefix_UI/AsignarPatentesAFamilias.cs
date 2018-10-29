using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesis
{
    public partial class AsignarPatentesAFamilias : Form
    {
        private Familia familia;
        private GestorDePatentes gestorDePatentes;
        public AsignarPatentesAFamilias(Familia familia)
        {
            this.familia = familia;
            gestorDePatentes = GestorDePatentes.ObtenerInstancia();
            InitializeComponent();
        }
    }
}
