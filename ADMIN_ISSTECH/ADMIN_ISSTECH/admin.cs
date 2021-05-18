using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MySql.Data.MySqlClient;

namespace ADMIN_ISSTECH
{
    public partial class admin : Form
    {

        /// <summary>--------------------------------------------------------------------------------------------------------------//
        /// Materia: Ingenieria de software I
        /// proyecto: ISSTECH (PAGINA ISSTECH Y APLICACION DESKTOP)
        /// iNTEGRANTES DE EQUIPO:
        /// -Alexandra Marianne Jimenez Lopez
        /// -Freddy Esteban Balcazar Padilla
        /// -Eduardo Perez Ruiz
        /// fecha: 18/05/2021
        /// -----------------------------------------------------------------------------------------------------------------------//
        public admin(string nombre)
        {
            InitializeComponent();
            lblname.Text = nombre;
            dgbconsulta();
        }
        int tipo = 0;
        #region consultas
        public void dgbconsulta()//Genera la visualizacion de mensajes
        {
            Conexion abrir = new Conexion();
            string selectQuery = "select id_queja_sugerencia_felicitacion,tipo,nombre_del_servidor_publico,cargo,area_de_servicio from queja__sugerencia__felicitacions";
            DataTable mensaje = new DataTable();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(selectQuery, abrir._conexion);
            adaptar.Fill(mensaje);
            dgbmensajes.DataSource = mensaje;
        }

        public void dgbconsulta2()//Genera el filtro de mensajes anonimo
        {
            Conexion abrir = new Conexion();
            string selectQuery = "select id_queja_sugerencia_felicitacion,tipo,nombre_del_servidor_publico,cargo,area_de_servicio from queja__sugerencia__felicitacions where anonimo='1'";
            DataTable mensaje = new DataTable();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(selectQuery, abrir._conexion);
            adaptar.Fill(mensaje);
            dgbmensajes.DataSource = mensaje;
        }
        public void dgbconsulta3()//Genera el filtro de mensajes noderechohabientes
        {
            Conexion abrir = new Conexion();
            string selectQuery = "select id_queja_sugerencia_felicitacion,tipo,nombre_del_servidor_publico,cargo,area_de_servicio from queja__sugerencia__felicitacions where anonimo='0' AND id_clips_fk IS NULL";
            DataTable mensaje = new DataTable();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(selectQuery, abrir._conexion);
            adaptar.Fill(mensaje);
            dgbmensajes.DataSource = mensaje;
        }
        public void dgbconsulta4()//Genera el filtro de mensajes derechohabientes
        {
            Conexion abrir = new Conexion();
            string selectQuery = "select id_queja_sugerencia_felicitacion,tipo,nombre_del_servidor_publico,cargo,area_de_servicio from queja__sugerencia__felicitacions where  id_clips_fk<>'NULL'";
            DataTable mensaje = new DataTable();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(selectQuery, abrir._conexion);
            adaptar.Fill(mensaje);
            dgbmensajes.DataSource = mensaje;
        }
        #endregion consultas 
        private void btntodo_Click(object sender, EventArgs e)
        {
            
        }
        #region pdf
        private void crearPdf()
        {
            PdfWriter pdfwriter = new PdfWriter("Reporte_Folio_"+lblid.Text+".pdf");
            PdfDocument pdf = new PdfDocument(pdfwriter);
            Document documento = new Document(pdf, PageSize.LETTER);
            documento.SetMargins(60, 20, 55, 20);
            PdfFont Fontcolumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontcontenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            string[] columnas = { "Informacion personal", "Dato" };

            float[] tamaños = { 2, 4 };
            Table tabla = new Table (UnitValue.CreatePercentArray(tamaños) );
            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach(string columna in columnas)
            {
               
                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(Fontcolumnas)));
               
            }
            //Estructura de la tabla, con tipo de dato y el dato.
            tabla.AddCell(new Cell().Add(new Paragraph("FOLIO:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblid.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Nombres:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblnombre.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Apellido paterno:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblpaterno.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Apellido materno:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblmaterno.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Telefono:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lbltelefono.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Correo:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblcorreo.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Direccion").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Codigo postal:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblpostal.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("calle:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblcalle.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Numero:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblnumero.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Colonia:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblcolonia.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Ciudad o municipio:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblciudad.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Detalles del mensaje").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(" ").SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Tipo de mensaje:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lbltipo_mensaje.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Servidor publico:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lbls_publico.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Cargo del servidor publico:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblcargo.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Descripcion del area de servicio:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblarea.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Fecha y hora:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(lblhora.Text).SetFont(fontcontenido)));

            tabla.AddCell(new Cell().Add(new Paragraph("Descripcion del mensaje:").SetFont(fontcontenido)));
            tabla.AddCell(new Cell().Add(new Paragraph(txtdescrip.Text).SetFont(fontcontenido)));
            var titulo = new Paragraph("Instituto de Seguridad Social de los Trabajadores del Estado de Chiapas");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            //PdfDocument pdfdoc = new PdfDocument(new PdfReader("Reporte.pdf"),new pdfWriter
             //   ("Reporte_id_" + lblid.Text + ".pdf"));
           // Document doc = new Document(pdfdoc);
            //doc.ShowTextAligned(titulo, 150, 15,1, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
            documento.Add(tabla);
            documento.Close();
        }
        #endregion pdf  
        private void dgbmensajes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnseguimiento.Visible = true;
            btnpdf.Visible = true;
            Datos.Visible = true;
           lblid.Text = dgbmensajes.Rows[e.RowIndex].Cells["id_queja_sugerencia_felicitacion"].Value.ToString();
            //Consulta de datos con nueva conexion.
            consultardatos();
           if (tipo==1)
            {
                consultardatos();
                btnseguimiento.Visible = true;
            }
            if(tipo==2)
            {
                consulta_noderechohabiente();
                btnseguimiento.Visible = true;
            }
           if(tipo==3)
            {
                consulta_anonimo();
                btnseguimiento.Visible = false;
            }
           if(tipo==0)
            {
                consultardatos();
                consulta_noderechohabiente();
                consulta_anonimo();
            }

        }
        #region consultas_datos
        private void consultardatos()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=buzon; uid=root; pwd=;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            //Obtencion de datos basicos del emisor del mensaje
            codigo.CommandText = ("SELECT * FROM queja__sugerencia__felicitacions,direccions where id_clips_fk<>'NULL' and id_queja_sugerencia_felicitacion="+lblid.Text+" and id_direccion_fk=id_direccion;");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                lblnombre.Text = "";
                lblpaterno.Text = "";
                lblmaterno.Text = "";
                lblcorreo.Text = "";
                lbltelefono.Text = "";
                lblpostal.Text = leer["codigo_postal"].ToString();
                lblcalle.Text = leer["calle"].ToString();
                lblciudad.Text = leer["ciudad_municipio"].ToString();
                lblnumero.Text = leer["numero"].ToString();
                lblcolonia.Text = leer["colonia"].ToString();
                lbltipo_mensaje.Text = leer["tipo"].ToString();
                lbls_publico.Text = leer["nombre_del_servidor_publico"].ToString();
                lblcargo.Text = leer["cargo"].ToString();
                lblarea.Text = leer["area_de_servicio"].ToString();
                txtdescrip.Text = leer["descripcion"].ToString();
                lblhora.Text = leer["fecha_hora"].ToString();


            }
            else
            {
                //MessageBox.Show("Falta informacion de clip.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conectar.Close();
        }

    private void consulta_noderechohabiente()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=buzon; uid=root; pwd=;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            //Obtencion de datos basicos del emisor del mensaje
            codigo.CommandText = ("SELECT * FROM queja__sugerencia__felicitacions,direccions join(no_derechohabientes) where id_nodhabientes_fk=id and id_queja_sugerencia_felicitacion="+lblid.Text+" and id_direccion=id_direccion_fk;");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                lblnombre.Text = leer["nombre"].ToString();
                lblpaterno.Text = leer["apellido_paterno"].ToString();
                lblmaterno.Text = leer["apellido_materno"].ToString();
                lblcorreo.Text = leer["correo"].ToString();
                lbltelefono.Text = leer["telefono_celular"].ToString();
                lblpostal.Text = leer["codigo_postal"].ToString();
                lblcalle.Text = leer["calle"].ToString();
                lblciudad.Text = leer["ciudad_municipio"].ToString();
                lblnumero.Text = leer["numero"].ToString();
                lblcolonia.Text = leer["colonia"].ToString();
                lbltipo_mensaje.Text = leer["tipo"].ToString();
                lbls_publico.Text = leer["nombre_del_servidor_publico"].ToString();
                lblcargo.Text = leer["cargo"].ToString();
                lblarea.Text = leer["area_de_servicio"].ToString();
                txtdescrip.Text = leer["descripcion"].ToString();
                lblhora.Text = leer["fecha_hora"].ToString();


            }
            else
            {
                //MessageBox.Show("Usuario Sin informacion.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conectar.Close();
        }

        private void consulta_anonimo()
        {
            MySqlConnection conectar = new MySqlConnection("server=localhost; database=buzon; uid=root; pwd=;");
            conectar.Open();
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conectanos = new MySqlConnection();
            codigo.Connection = conectar;
            //Obtencion de datos basicos del emisor del mensaje
            codigo.CommandText = ("select * from queja__sugerencia__felicitacions where anonimo='1' and id_queja_sugerencia_felicitacion="+lblid.Text+"");
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                lbltipo_mensaje.Text = leer["tipo"].ToString();
                lbls_publico.Text = leer["nombre_del_servidor_publico"].ToString();
                lblcargo.Text = leer["cargo"].ToString();
                lblarea.Text = leer["area_de_servicio"].ToString();
                txtdescrip.Text = leer["descripcion"].ToString();
                lblhora.Text = leer["fecha_hora"].ToString();
                lblnombre.Text = "";
                lblmaterno.Text = "";
                lblpaterno.Text = "";
                lblcorreo.Text = "";
                lbltelefono.Text = "";
                lblpostal.Text = "";
                lblcalle.Text = "";
                lblciudad.Text = "";
                lblnumero.Text = "";
                lblcolonia.Text = "";
            }
            else
            {
                //MessageBox.Show(").", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            conectar.Close();
        }
        #endregion consulta_dedatos
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 regreso = new Form1();
            regreso.Show();
            this.Hide();
        }

        private void btnderecho_Click(object sender, EventArgs e)
        {
             tipo = 1;
            btnseguimiento.Visible = false;
            btnpdf.Visible = false;
            Datos.Visible = false;
            lblnombre.Text = "";
            lblmaterno.Text = "";
            lblpaterno.Text = "";
            lblcorreo.Text = "";
            lbltelefono.Text = "";
            lblpostal.Text = "";
            lblcalle.Text = "";
            lblciudad.Text = "";
            lblnumero.Text = "";
            lblcolonia.Text = "";
            lblarea.Text = "";
            txtdescrip.Text = "";
            lblhora.Text = "";
            dgbconsulta4();
            lbltipo.Text = "Derechohabiente";
        }

        private void btnanonimo_Click(object sender, EventArgs e)
        {
             tipo = 3;
            btnseguimiento.Visible = false;
            btnpdf.Visible = false;
            Datos.Visible = false;
            lblnombre.Text = "";
            lblmaterno.Text = "";
            lblpaterno.Text = "";
            lblcorreo.Text = "";
            lbltelefono.Text = "";
            lblpostal.Text = "";
            lblcalle.Text = "";
            lblciudad.Text = "";
            lblnumero.Text = "";
            lblcolonia.Text = "";
            lblarea.Text = "";
            txtdescrip.Text = "";
            lblhora.Text = "";
            dgbconsulta2();
            lbltipo.Text = "Anónimo";
        }

        private void btnno_derecho_Click(object sender, EventArgs e)
        {
             tipo = 2;
            btnseguimiento.Visible = false;
            btnpdf.Visible = false;
            Datos.Visible = false;
            lblnombre.Text = "";
            lblmaterno.Text = "";
            lblpaterno.Text = "";
            lblcorreo.Text = "";
            lbltelefono.Text = "";
            lblpostal.Text = "";
            lblcalle.Text = "";
            lblciudad.Text = "";
            lblnumero.Text = "";
            lblcolonia.Text = "";
            lblarea.Text = "";
            txtdescrip.Text = "";
            lblhora.Text = "";
            dgbconsulta3();
            lbltipo.Text = "NO DERECHOHABIENTE";
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            btnseguimiento.Visible = false;
            btnpdf.Visible = false;
            Datos.Visible = false;
            lblnombre.Text = "";
            lblmaterno.Text = "";
            lblpaterno.Text = "";
            lblcorreo.Text = "";
            lbltelefono.Text = "";
            lblpostal.Text = "";
            lblcalle.Text = "";
            lblciudad.Text = "";
            lblnumero.Text = "";
            lblcolonia.Text = "";
            lblarea.Text = "";
            txtdescrip.Text = "";
            lblhora.Text = "";
            dgbconsulta();
            lbltipo.Text = "Derechohabiente, No derechohabiente y Anónimo";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_panel_Click(object sender, EventArgs e)
        {
            btnseguimiento.Visible = false;
            btnpdf.Visible = false;
            Datos.Visible = false;
            lblnombre.Text = "";
            lblmaterno.Text = "";
            lblpaterno.Text = "";
            lblcorreo.Text = "";
            lbltelefono.Text = "";
            lblpostal.Text = "";
            lblcalle.Text = "";
            lblciudad.Text = "";
            lblnumero.Text = "";
            lblcolonia.Text = "";
            lblarea.Text = "";
            txtdescrip.Text = "";
            lblhora.Text = "";
         
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string correo = lblcorreo.Text;
            string nombre = lblnombre.Text;
            Seguimiento enviar = new Seguimiento(correo,nombre);
           
            enviar.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            crearPdf();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
