using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Sistema;
using Logica;
using Logica.Sistema;

namespace Presentacion.Formularios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToParent();
        }
        Usuario usuario = new Usuario();
        UsuarioLN usuarioLN = new UsuarioLN();
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                label8.Visible = true;
            }
            if (textBox2.Text.Equals(""))
            {
                label8.Visible = true;
            }
            for (int i = 0; i < usuarioLN.MostrarUsuarioFitro("").Count; i++)
            {
                if (usuarioLN.MostrarUsuarioFitro("")[i].NombreUsuario.Equals(textBox1.Text))
                {
                    if (usuarioLN.MostrarUsuarioFitro("")[i].Contrasena.Equals(textBox2.Text))
                    {
                        Principal p = new Principal();
                        p.Show();
                        this.Hide();
                    }                    
                    else
                    {
                        label8.Visible = true;
                    }
                }
                else
                {                    
                    label8.Visible = true;
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }
    }
}
