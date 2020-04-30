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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
  
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
   

        private void Stock_Load(object sender, EventArgs e)
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
            catch(Exception ex)
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
            catch(Exception ex)
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
        

        //buscar
        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {


                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select Codigo, Descripcion, Laboratorio, Precio_costo, Precio_venta, Stock_actual, Stock_minimo from productos where Descripcion like ('" + txtBusqueda.Text + "%')";
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

        private void btnImprimir_Click(object sender, EventArgs e)
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


        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            }

            catch (Exception)
            {

                MessageBox.Show("Fila incorrecta");

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Stock_minimo")
                {
                    if (Convert.ToInt32(e.Value) <= 5)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
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
                Stock s = new Stock();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    s.txtCodigo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    s.txtDescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    s.txtLaboratorio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    s.txtCosto.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    s.txtVenta.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    s.txtActual.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    s.minimo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    s.ShowDialog();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Stock s = new Stock();
                s.ShowDialog();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string txtQuery = "delete from productos where Codigo = '" + textBox1.Text + "'";
                ExecuteQuery(txtQuery);
                LoadData();
                MessageBox.Show("Registro eliminado correctamente !!");
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
    
}

