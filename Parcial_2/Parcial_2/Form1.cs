using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///Steven Alexander Campos Martínez y Walter Ernesto Cababezas Benavides
namespace Parcial_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            public partial class frm_usuario : Form
        {
            Conexion objConexion = new Conexion();
            DataSet ds = new DataSet();
            DataTable miTabla = new DataTable();

            public int posicion = 0;
            String accion = "nuevo";
            public frm_usuario()
            {
                InitializeComponent();
            }

            private void label2_Click(object sender, EventArgs e)
            {

            }

            private void btnNuevoUsuario_Click(object sender, EventArgs e)
            {
                if (btnNuevoUsuario.Text == "Nuevo")
                {
                    btnNuevoUsuario.Text = "Guardar";
                    btnModificarUsuario.Text = "Cancelar";
                    accion = "nuevo";
                    estadoControles(true); // Habilitar las cajas de texto
                    limpiarCajas(); // Limpiar las cajas de texto
                }
                else
                { // Guardar
                  // Validar que el usuario tenga entre 6 y 16 caracteres
                    if (txtUsuario.Text.Length < 6 || txtUsuario.Text.Length > 16)
                    {
                        MessageBox.Show("El usuario debe tener entre 6 y 16 caracteres.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validar que la contraseña contenga letras y números
                    if (!txtClaveUsuario.Text.Any(char.IsLetter) || !txtClaveUsuario.Text.Any(char.IsDigit))
                    {
                        MessageBox.Show("La contraseña debe contener letras y números.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Confirmar que ambas contraseñas coincidan
                    if (txtClaveUsuario.Text != txtValidacionUsuario.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Crear arreglo con los datos del usuario
                    String[] usuario = {
            accion, // "nuevo"
            "", // idUsuario vacío porque es autoincremental
            txtUsuario.Text,
            txtClaveUsuario.Text,
            txtValidacionUsuario.Text,
            txtNombreUsuario.Text,
            txtDireccionUsuario.Text,
            txtTelefonoUsuario.Text
        };

                    // Enviar los datos a la base de datos
                    String respuesta = objConexion.administrarUsuarios(usuario);
                    if (respuesta != "1")
                    {
                        MessageBox.Show(respuesta, "Error en el registro de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        btnNuevoUsuario.Text = "Nuevo";
                        btnModificarUsuario.Text = "Modificar";
                        estadoControles(false); // Deshabilitar controles después de guardar
                        actualizarDs(); // Actualizar el dataset
                    }
                }
            }
            void limpiarCajas()
            {
                txtUsuario.Text = "";
                txtClaveUsuario.Text = "";
                txtValidacionUsuario.Text = "";
                txtNombreUsuario.Text = "";
                txtDireccionUsuario.Text = "";
                txtTelefonoUsuario.Text = "";

            }


            private void frm_usuario_Load(object sender, EventArgs e)
            {
                actualizarDs();
            }
            private void actualizarDs()
            {
                ds.Clear();
                ds = objConexion.obtenerDatos();
                miTabla = ds.Tables["usuarios"];
                miTabla.PrimaryKey = new DataColumn[] { miTabla.Columns["idUsuario"] };
                grdDatosUsuario.DataSource = miTabla;
                mostrarDatosUsuario();
            }
            private void mostrarDatosUsuario()
            {
                if (miTabla.Rows.Count > 0)
                {
                    txtUsuario.Text = miTabla.Rows[posicion].ItemArray[1].ToString();
                    txtClaveUsuario.Text = miTabla.Rows[posicion].ItemArray[2].ToString();
                    txtNombreUsuario.Text = miTabla.Rows[posicion].ItemArray[3].ToString();
                    txtDireccionUsuario.Text = miTabla.Rows[posicion].ItemArray[4].ToString();
                    txtTelefonoUsuario.Text = miTabla.Rows[posicion].ItemArray[5].ToString();


                    lblRegistrosUsuario.Text = (posicion + 1) + " de " + miTabla.Rows.Count;
                }
            }

            private void btnSiguienteUsuario_Click(object sender, EventArgs e)
            {
                if (posicion < miTabla.Rows.Count - 1)
                {
                    posicion++;
                    mostrarDatosUsuario();
                }
                else
                {
                    MessageBox.Show("Esta en el ultimo registro", "Navegacion de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void btnAnteriorUsuario_Click(object sender, EventArgs e)
            {
                if (posicion > 0)
                {
                    posicion--;
                    mostrarDatosUsuario();
                }
                else
                {
                    MessageBox.Show("Esta en el primer registro", "Navegacion de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            private void btnUltimoUsuario_Click(object sender, EventArgs e)
            {
                posicion = miTabla.Rows.Count - 1;
                mostrarDatosUsuario();
            }

            private void btnPrimeroUsuario_Click(object sender, EventArgs e)
            {
                posicion = 0;
                mostrarDatosUsuario();
            }
            private void estadoControles(Boolean estado)
            {
                grbDatosUsuario.Enabled = estado;
                grbNavegacionUsuario.Enabled = !estado;
                btnEliminarUsuario.Enabled = !estado;
            }

            private void btnModificarUsuario_Click(object sender, EventArgs e)
            {
                if (btnModificarUsuario.Text == "Modificar")
                {
                    btnNuevoUsuario.Text = "Guardar";
                    btnModificarUsuario.Text = "Cancelar";
                    accion = "modificar";
                    estadoControles(true);

                }
                else
                {//Cancelar
                    mostrarDatosUsuario();
                    btnNuevoUsuario.Text = "Nuevo";
                    btnModificarUsuario.Text = "Modificar";
                    estadoControles(false);
                }
            }

            private void btnEliminarUsuario_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Esta seguro de eliminar a " + txtNombreUsuario.Text.Trim() + "?", "Eliminar alumnos", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    String[] alumnos = {
                    "eliminar", miTabla.Rows[posicion].ItemArray[0].ToString()
                };
                    String respuesta = objConexion.administrarAlumnos(alumnos);
                    if (respuesta != "1")
                    {
                        MessageBox.Show(respuesta, "Error en el registro de usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        posicion = 0;
                        actualizarDs();
                        mostrarDatosUsuario();
                    }
                }
            } } } }
