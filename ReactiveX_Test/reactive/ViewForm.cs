﻿using ReactiveX_Test.tecnospeed;
using System;
using System.Windows.Forms;

namespace ReactiveX_Test.reactive
{
    public partial class ViewForm : Form
    {
        NFCe400 nfce400;

        public ViewForm()
        {
            this.nfce400 = new NFCe400();

            InitializeComponent();
        }

        private void setTextBox2Text(string text)
        {
            this.textBox2.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chave_consulta = this.textBox1.Text;

            this.setTextBox2Text(this.nfce400.consultarNFCe(chave_consulta));
        }
    }
}