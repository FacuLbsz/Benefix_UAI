﻿using System;
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
    public partial class AsignarDesasignarPatente : Form
    {
        private Action<Boolean> action;
        public AsignarDesasignarPatente()
        {
            InitializeComponent();
        }

        public AsignarDesasignarPatente(Action<Boolean> action)
        {
            this.action = action;
            InitializeComponent();
        }


        private void permisivaButton_Click(object sender, EventArgs e)
        {
            action(true);
            Close();
        }

        private void restrictivaButton_Click(object sender, EventArgs e)
        {
            action(false);
            Close();
        }
    }
}
