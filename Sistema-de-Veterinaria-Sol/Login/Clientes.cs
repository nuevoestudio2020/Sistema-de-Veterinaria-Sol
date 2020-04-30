using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Login
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void Clientes_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        //conexion a la bd
        private void SetConnection()
        {
            try
            {
                sql_con = new SQLiteConnection
                    ("Data Source = veterinaria.db; version = 3; New = False; Compress = True;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //ejecutar consulta
        private void ExecuteQuery(string txtQuery)
        {
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = txtQuery;
                sql_cmd.ExecuteNonQuery();
                sql_con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        //cargar bd
        private void LoadData()
        {
            try
            {

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    c.txtApellido.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    c.txtDireccion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    c.txtLocalidad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    c.txtTelefono.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    c.txtAnimal.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    c.txtEspecie.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    c.txtSexo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    c.txtRaza.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    c.txtNacio.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    c.txtPelaje.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    c.txtUltAño.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    c.txtTamaño.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    c.txtQuintuple.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    c.txtSeptuple.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    c.txtTriplefelina.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                    c.txtAntirrabica.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                    c.txtAnticonceptiva.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();;
                    c.txtFicha.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                    c.ShowDialog();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();              
                c.ShowDialog();
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                Bitmap objBmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
                dataGridView1.DrawToBitmap(objBmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
                e.Graphics.DrawImage(objBmp, 10, 100);
                e.Graphics.DrawString(label1.Text, new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Black, new Point(300, 30));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select Apellido, Direccion, Localidad, Telefono, Animal, Especie, Sexo, Raza, Nacio, Pelaje, Ult_Año, Tamaño, Quint, Sept, Tripfel, Antirrab, Antic, Ficha from clientes where Apellido like '" + txtBusqueda.Text + "%' or Direccion like '" + txtBusqueda.Text + "%' or Telefono like '" + txtBusqueda.Text + "%' or Animal like '" + txtBusqueda.Text + "%' or Sexo like '" + txtBusqueda.Text + "%' or Raza like '" + txtBusqueda.Text + "%' or Nacio like '" + txtBusqueda.Text + "%' or Ult_Año like '" + txtBusqueda.Text + "%' or Quint like '" + txtBusqueda.Text + "%' or Sept like '" + txtBusqueda.Text + "%' or Tripfel like '" + txtBusqueda.Text + "%' or Antirrab like '" + txtBusqueda + "' or Antic like '" + txtBusqueda.Text + "%' or Ficha like '" + txtBusqueda.Text + "%' ";
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                dataGridView1.DataSource = DT;
                sql_con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

