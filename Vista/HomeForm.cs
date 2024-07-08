using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vista
{
    public partial class HomeForm : Form
    {

        public ProductoController controller = new ProductoController();


        public HomeForm()
        {
            InitializeComponent();


            /// home form
            /// 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


            /// dgvLists
            /// 
            dgvList.BackgroundColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.ForeColor = Color.White;
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            /// comboBoxes
            comboBoxBusqueda.Items.Clear();

            comboBoxBusqueda.Items.Add("Buscar por Código");
            comboBoxBusqueda.Items.Add("Buscar por Nombre");
            comboBoxBusqueda.Items.Add("Buscar por Marca");
            comboBoxBusqueda.Items.Add("Buscar por Categoría");
            comboBoxBusqueda.SelectedIndex = 0;



            ///
            PanelInfo.BackColor = Color.FromArgb(128, 26, 32, 40);


            /// btns
            /// 
            btnEditar.Click += new EventHandler(editar_Producto_btn);





            /// txtBox
            /// 



        }



        private void Homeform_Load(object sender, EventArgs e)
        {

            /// dgvList
            List<Articulo> listArticulos = controller.ListarArticulos();
            dgvList.DataSource = listArticulos;
            dgvList.ReadOnly = false;
            dgvList.Columns["IdMarca"].HeaderText = "ID Marca";
            //    dgvList.Columns["IdMarca"].Visible = false;
            //    dgvList.Columns["idCategoria"].Visible = false;
            dgvList.Columns["idCategoria"].HeaderText = "ID Categoria";
            dgvList.Columns["UrlImagen"].Visible = false;
            dgvList.Columns["Descripcion"].Visible = false;
          ///  PictureBoxArticulo.Load(listArticulos[0].UrlImagen);


        }


        // evento que cambia la img del articulo

        private void ActualizarSeccionProductos(object sender, EventArgs e)
        {
            DataGridViewRow fila = dgvList.CurrentRow;
            if (fila != null)
            {
                /// la url está en el indice 6

                PictureBoxArticulo.ImageLocation = (string)fila.Cells[6].Value;
                PictureBoxArticulo.Refresh();

                string PrecioArt = "$ " + fila.Cells[2].Value.ToString();
                string DescripcionArt = fila.Cells[5].Value.ToString();

                /// traer desde la db

                string MarcaArt = controller.getMarcaById((int)fila.Cells[3].Value);
                string CategoriaArt = controller.getCategoriaById((int)fila.Cells[4].Value);


                /// update de labels en la seccion
                /// 



                lblMarca.Text = MarcaArt;
                lblCategoria.Text = CategoriaArt;
                lblPrecio.Text = PrecioArt;
                lblDescripcion.Text = DescripcionArt;



            }

        }




        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            AddForm addfrm = new AddForm();
            addfrm.ShowDialog();

        }





        private void EditarProducto(DataGridViewRow selectedRow)
        {

            Articulo selectedArticulo = new Articulo
            {
                Codigo = selectedRow.Cells["Codigo"].Value.ToString(),
                Nombre = selectedRow.Cells["Nombre"].Value.ToString(),
                Precio = Convert.ToDecimal(selectedRow.Cells["Precio"].Value),
                IdCategoria = Convert.ToInt32(selectedRow.Cells["IdCategoria"].Value),
                IdMarca = Convert.ToInt32(selectedRow.Cells["IdMarca"].Value),
                Descripcion = selectedRow.Cells["Descripcion"].Value.ToString(),
                UrlImagen = selectedRow.Cells["UrlImagen"].Value.ToString()
            };




            EditForm editForm = new EditForm(selectedArticulo);

            editForm.ShowDialog();
        }

        private void editar_Producto_btn(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                EditarProducto(dgvList.CurrentRow);
            }
        }


        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvList.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    EditarProducto(selectedRow);
                }

            }
        }



        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {

                button.BackColor = Color.Red;
                //  button.ForeColor = Color.White;   
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {

                button.BackColor = Color.Orange;

            }
        }



    }






    /*
private void btnEnviar_Click(object sender, EventArgs e)
{


string nombre = txtBoxNombre.Text;
decimal precio = decimal.Parse(txtBoxPrecio.Text);
int stock = (int)nmrcStock.Value;

controller.AgregarProducto(nombre, precio, stock, comboBoxMarca.SelectedItem as Marca);
Actualizar();

}

private void Actualizar()
{

dgvList.DataSource = controller.ListarProductos();
dgvList.Refresh();

}
*/

}

