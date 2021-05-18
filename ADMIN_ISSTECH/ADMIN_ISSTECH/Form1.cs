using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace ADMIN_ISSTECH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {




        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //  admin administrador = new admin();
            //  administrador.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=buzon; uid=root; pwd=;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            codigo.CommandText = ("select *from users where email='" + txtuser.Text + "'and contra_c='" + txtcontra.Text +"'");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
               txtuser.Text=leer["name"].ToString();

                MessageBox.Show("BIENVENIDO " + txtuser.Text);
                string nombre = txtuser.Text;
                admin abrir = new admin(nombre);
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("DATOS INCORRECTOS O FALTANTES", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conectar.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
