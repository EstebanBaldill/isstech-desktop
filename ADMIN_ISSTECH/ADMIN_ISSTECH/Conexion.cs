using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace ADMIN_ISSTECH
{
    class Conexion
    {
        public MySqlConnection _conexion;
        public MySqlCommand _comando;
        public Conexion()
        {
            _conexion = new MySqlConnection("server=localhost; database=buzon; uid=root; pwd=;");
        }
        public bool abrirconexion()
        {
            try
            {
                _conexion.Open();
                return true;
            }
            catch (MySqlException exeption)
            {
                return false;
                throw exeption;
              
              
            }
        }

        public bool cerrarconexion()
        {
            try
            {
                _conexion.Close();
                return true;
            }
            catch (MySqlException exeption)
            {
                return false;
                throw exeption;
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                _conexion.Open();
                _comando = new MySqlCommand(query, _conexion);

                if (_comando.ExecuteNonQuery() == 1)
                {
                     MessageBox.Show("Proceso Correcto", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                     MessageBox.Show("Proceso error");
                }

            }
            catch (MySqlException exeption)
            {
                MessageBox.Show(exeption.Message);
            }
            finally
            {
                _conexion.Close();
            }
        }
    }
}
