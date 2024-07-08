using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class AddForm : Form
    {
        public ProductoController controller;
        private System.Windows.Forms.Timer timer;


        private int contadorParpadeo;
        public AddForm()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;

            controller = new ProductoController();


            btnAceptar.MouseEnter += new EventHandler(btn_MouseEnter);
            btnAceptar.MouseLeave += new EventHandler(btn_MouseLeave);
            btnCancelar.MouseEnter += new EventHandler(btn_MouseEnter);
            btnCancelar.MouseLeave += new EventHandler(btn_MouseLeave);
            btnAceptar.Click += new EventHandler(btnAceptar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);


        }


        private void AddForm_Load(object sender, EventArgs e)
        {
            List<Marca> listaMarcas = controller.ListarMarcas();
            List<Categoria> listaCategorias = controller.ListarCategorias();

            /// comboBoxes
            comboBoxMarca.DisplayMember = "Descripcion";
            comboBoxMarca.ValueMember = "Id";

            comboBoxMarca.DataSource = listaMarcas;

            comboBoxCategoria.DisplayMember = "Descripcion";
            comboBoxCategoria.ValueMember = "Id";

            comboBoxCategoria.DataSource = listaCategorias;



            if (comboBoxMarca.Items.Count > 0)
            {
                comboBoxMarca.SelectedIndex = 0;
            }

            if (comboBoxCategoria.Items.Count > 0)
            {
                comboBoxCategoria.SelectedIndex = 0;
            }


            /// TextBoxes
            /// 



        }




        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos(out string mensajeError))
                {


                    string codigo = txtBoxCodigo.Text;
                    string nombre = txtNombre.Text;
                    string descripcion = txtBoxDescripcion.Text;
                    string urlImagen = string.Empty;
                    int idMarca = (int)comboBoxMarca.SelectedValue;
                    int idCategoria = (int)comboBoxCategoria.SelectedValue;



                    if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                    {
                        MessageBox.Show("Por favor, ingrese un precio válido mayor a 0.");
                        return;
                    }

                    // Si está validado, añadir a la db
                    int rowsAfectadas = controller.InsertarArticulo(new Articulo(codigo, nombre, precio, idMarca, idCategoria, descripcion, urlImagen));

                    if (rowsAfectadas > 0)
                    {
                        MessageBox.Show("Artículo añadido con éxito.");
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {

                        throw new Exception("no se pudo agregar");
                    }
                }

                else
                {
                    // Mostrar mensaje de error y activar el Timer y el sonido de error .{ revisar en casos especiales
                    ReproducirSonidoError();
                    MessageBox.Show(mensajeError);
                    timer.Start();
                    this.DialogResult = DialogResult.None; // No cerrar el formulario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar Producto: " + ex.Message);
            }
        }




        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Gray;
            }
        }

        protected void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = System.Drawing.Color.MediumSeaGreen;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            contadorParpadeo++;

            // Alternar el color de fondo de los TextBox vacíos
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && control.BackColor == Color.Red)
                {
                    control.BackColor = SystemColors.Window;
                }
                else if (control is TextBox && control.BackColor == SystemColors.Window)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        control.BackColor = Color.Red;
                    }
                }
            }


            // Detener el Timer después de dos parpadeos
            if (contadorParpadeo >= 4)
            {
                timer.Stop();
                contadorParpadeo = 0;

                txtBoxCodigo.BackColor = SystemColors.Window;
                txtBoxDescripcion.BackColor = SystemColors.Window;
                txtNombre.BackColor = SystemColors.Window;
                txtPrecio.BackColor = SystemColors.Window;
            }
        }

        private void ReproducirSonidoError()
        {
            System.Media.SystemSounds.Beep.Play();
        }





        private bool ValidarDatos(out string mensajeError)
        {
            bool valido = true;
            mensajeError = string.Empty;

            if (string.IsNullOrWhiteSpace(txtBoxCodigo.Text))
            {
                mensajeError = "El código no puede estar vacío.";
                txtBoxCodigo.BackColor = Color.Red;
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mensajeError += "\nEl nombre no puede estar vacío.";
                txtNombre.BackColor = Color.Red;
                valido = false;
            }

            /*
            if (string.IsNullOrWhiteSpace(txtBoxDescripcion.Text))
            {
                mensajeError += "\nLa descripción no puede estar vacía.";
                txtBoxDescripcion.BackColor = Color.Red;
                valido = false;
            }
            */

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                mensajeError += "\nIngrese un precio válido mayor a 0.";
                txtPrecio.BackColor = Color.Red;
                valido = false;
            }

            return valido;
        }

    }

}

