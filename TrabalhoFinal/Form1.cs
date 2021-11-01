using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrabalhoFinal
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
            conectarToolStripMenuItem.Enabled = true;
            desconectarToolStripMenuItem.Enabled = false;
            cadastroToolStripMenuItem.Enabled = false;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cadastro_Cliente cliente = new Frm_Cadastro_Cliente();
            cliente.Show();
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Login L = new Frm_Login();
            L.ShowDialog();
            if (L.DialogResult == DialogResult.OK)
            {

                string senha = L.senha;
                string login = L.login;

                if (Fcs_Complementares.validaSenhaLogin(senha) == true)
                {
                    conectarToolStripMenuItem.Enabled = false;
                    desconectarToolStripMenuItem.Enabled = true;
                    cadastroToolStripMenuItem.Enabled = true;


                    MessageBox.Show("Bem vindo " + login + " !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Senha inválida !", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void desconectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conectarToolStripMenuItem.Enabled = true;
            desconectarToolStripMenuItem.Enabled = false;
            cadastroToolStripMenuItem.Enabled = false;

            MessageBox.Show("Desconectado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
