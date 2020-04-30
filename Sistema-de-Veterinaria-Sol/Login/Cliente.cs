using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SQLite;

namespace Login
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void Cliente_Load(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seguro desea guardar registro ?", "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string txtQuery = "update clientes Set Apellido = '" + txtApellido.Text + "', Direccion = '" + txtDireccion.Text + "', Localidad = '" + txtLocalidad.Text + "', Telefono = '" + txtTelefono.Text + "', Animal = '" + txtAnimal.Text + "', Especie = '" + txtEspecie.Text + "', Sexo = '" + txtSexo.Text + "', Raza = '" + txtRaza.Text + "', Nacio = '" + txtNacio.Text + "', Pelaje = '" + txtPelaje.Text + "', Ult_Año = '" + txtUltAño.Text + "', Tamaño = '" + txtTamaño.Text + "', Quint = '" + txtQuintuple.Text + "', Sept = '" + txtSeptuple.Text + "', Tripfel = '" + txtTriplefelina.Text + "', Antirrab = '" + txtAntirrabica.Text + "', Antic = '" + txtAnticonceptiva.Text + "'  where Apellido = '" + txtApellido.Text + "' ";
                    ExecuteQuery(txtQuery);
                    LoadData();
                    MessageBox.Show("Registro actualizado correctamente !!");
                }
                else { }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Seguro desea agregar cliente ?", "Agregar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string txtQuery = "insert into clientes (Apellido, Direccion, Localidad, Telefono, Animal, Especie, Sexo, Raza, Nacio, Pelaje, Ult_Año, Tamaño, Quint, Sept, Tripfel, Antirrab, Antic) values('" + txtApellido.Text + "', '" + txtDireccion.Text + "', '" + txtLocalidad.Text + "', '" + txtTelefono.Text + "', '" + txtAnimal.Text + "', '" + txtEspecie.Text + "', '" + txtSexo.Text + "', '" + txtRaza.Text + "', '" + txtNacio.Text + "', '" + txtPelaje.Text + "', '" + txtUltAño.Text + "', '" + txtTamaño.Text + "', '" + txtQuintuple.Text + "', '" + txtSeptuple.Text + "', '" + txtTriplefelina.Text + "', '" + txtAntirrabica.Text + "', '" + txtAnticonceptiva.Text + "') ";
                    ExecuteQuery(txtQuery);
                    LoadData();
                    MessageBox.Show("Cliente agregado correctamente !!");
                }
                else { }

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
                if (MessageBox.Show("Seguro desea eliminar cliente ?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string txtQuery = "delete from clientes where Apellido = '" + txtApellido.Text + "' ";
                    ExecuteQuery(txtQuery);
                    LoadData();
                    MessageBox.Show("Cliente eliminado correctamente !!");
                }
                else { }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();
            CertificadoVacunacion c = new CertificadoVacunacion();
            datos.Apelido = txtApellido.Text;
            datos.Direccion = txtDireccion.Text;
            datos.Localidad = txtLocalidad.Text;
            datos.Animal = txtAnimal.Text;
            datos.Raza = txtRaza.Text;
            datos.Tamaño = txtTamaño.Text;
            datos.Nacio = txtNacio.Text;
            datos.Especie = txtEspecie.Text;
            datos.Pelaje = txtPelaje.Text;
            datos.Sexo = txtSexo.Text;
            c.datos.Add(datos);
            c.Show();
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtLocalidad.Focus();
            }
        }

        private void txtLocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAnimal.Focus();
            }
        }

        private void txtAnimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtEspecie.Focus();
            }
        }

        private void txtEspecie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtSexo.Focus();
            }
        }

        private void txtSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtRaza.Focus();
            }
        }

        private void txtRaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNacio.Focus();
            }
        }

        private void txtNacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPelaje.Focus();
            }
        }

        private void txtPelaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtUltAño.Focus();
            }
        }

        private void txtUltAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtTamaño.Focus();
            }
        }

        private void txtTamaño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtQuintuple.Focus();
            }
        }

        private void txtQuintuple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtSeptuple.Focus();
            }
        }

        private void txtSeptuple_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtTriplefelina.Focus();
            }
        }

        private void txtTriplefelina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAntirrabica.Focus();
            }
        }

        private void txtAntirrabica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAnticonceptiva.Focus();
            }
        }

        private void txtAnticonceptiva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnGuardar.Focus();
            }

        }

    }
}
