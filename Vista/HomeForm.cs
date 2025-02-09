﻿using Controlador;
using Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{

    public partial class HomeForm : Form
    {
      
        private ProductoController controller = new ProductoController();
        private MarcaController mController = new MarcaController();
        private List<Articulo> articulos;
        private List<Marca> marcas;


       
        public HomeForm()
        {
            InitializeComponent();
            InicializarControles();
            InicializarEventos();
        }



        private void InicializarControles()
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            dgvList.BackgroundColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 32, 40);
            dgvList.DefaultCellStyle.ForeColor = Color.White;
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBoxBusqueda.Items.AddRange(new string[] { "Buscar por Código", "Buscar por Nombre" });
            comboBoxBusqueda.SelectedIndex = 0;

            ActualizarComboBoxMarca();
         
            PanelInfo.BackColor = Color.FromArgb(128, 26, 32, 40);

        }




        private void InicializarEventos()
        {
         
            btnEditar.Click += editar_Producto_btn;
            articuloToolStripMenuItem.Click += BtnNuevoProducto_Click;
            categoriaToolStripMenuItem.Click += menuStripNuevoCategoria_Click;
            marcaToolStripMenuItem.Click += menuStripNuevoMarca_Click;

        }




        private void Homeform_Load(object sender, EventArgs e)
        {
      
            articulos = controller.ListarArticulos();
            dgvList.DataSource = articulos;
            dgvList.ReadOnly = true;

            dgvList.Columns["Id"].Visible = false;
            dgvList.Columns["UrlImagen"].Visible = false;
            dgvList.Columns["Descripcion"].Visible = false;
        }




        private void ActualizarSeccionProductos(object sender, EventArgs e)
        {
            // Actualiza la sección de detalles del producto seleccionado
            try
            {
                DataGridViewRow fila = dgvList.CurrentRow;

                if (fila != null)
                {
                    try
                    {              

                        PictureBoxArticulo.LoadAsync((string)fila.Cells["UrlImagen"].Value);
                        
                        //  PictureBoxArticulo.Load((string)fila.Cells["UrlImagen"].Value);
                    }
                    catch
                    {
                        PictureBoxArticulo.Image = PictureBoxArticulo.ErrorImage;
                        
                    }

                    string codigoArt = fila.Cells["Codigo"].Value.ToString();
                    string nombreArt = fila.Cells["Nombre"].Value.ToString();
                    decimal precioArt = Convert.ToDecimal(fila.Cells["Precio"].Value);
                    string descripcionArt = fila.Cells["Descripcion"].Value.ToString();

                    Marca marca = (Marca)fila.Cells["Marca"].Value;
                    Categoria categoria = (Categoria)fila.Cells["Categoria"].Value;

                    lblPrecio.Text = "$ " + precioArt.ToString();
                    lblDescripcion.Text = descripcionArt;
                    lblMarca.Text = marca.Descripcion;
                    lblCategoria.Text = categoria.Descripcion;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la sección de productos: " + ex.Message, ex);
            }
        }






        private void BtnNuevoProducto_Click(object sender, EventArgs e)
        {
            // Abre el formulario para agregar un nuevo producto
            using (AddForm addfrm = new AddForm())
            {
                addfrm.ShowDialog();
            }
            ActualizarDatos();
        }




        private void EditarProducto(DataGridViewRow selectedRow)
        {
            // Abre el formulario para editar el producto seleccionado
            Categoria categoria = (Categoria)(selectedRow.Cells["Categoria"].Value);
            Marca marca = (Marca)(selectedRow.Cells["Marca"].Value);

            Articulo selectedArticulo = new Articulo
            {
                Id = Convert.ToInt32(selectedRow.Cells["Id"].Value),
                Codigo = selectedRow.Cells["Codigo"].Value.ToString(),
                Nombre = selectedRow.Cells["Nombre"].Value.ToString(),
                Precio = Convert.ToDecimal(selectedRow.Cells["Precio"].Value),
                Categoria = categoria,
                Marca = marca,
                Descripcion = selectedRow.Cells["Descripcion"].Value.ToString(),
                UrlImagen = selectedRow.Cells["UrlImagen"].Value.ToString()
            };

            using (EditForm editForm = new EditForm(selectedArticulo))
            {
                editForm.ShowDialog();
            }

            ActualizarDatos();
        }





        private void editar_Producto_btn(object sender, EventArgs e)
        {
            // Evento para editar un producto desde un botón
            if (dgvList.CurrentRow != null)
            {
                EditarProducto(dgvList.CurrentRow);
            }
        }




        private void DgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evento de doble clic en el DataGridView para editar un producto
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvList.Rows[e.RowIndex];
                if (selectedRow != null)
                {
                    EditarProducto(selectedRow);
                }
            }
        }



        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            // Elimina el artículo seleccionado
            using (DeleteForm frm = new DeleteForm())
            {
                DialogResult result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    try
                    {
                        if (dgvList.CurrentRow != null)
                        {
                            int id = (int)dgvList.CurrentRow.Cells["Id"].Value;
                            int filasAfectadas = controller.EliminarArticulo(id);

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Artículo eliminado con éxito.");
                                ActualizarDatos();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el artículo.");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo eliminar el artículo.");
                    }
                }
            }
        }



        private void ActualizarComboBoxMarca()
        {
            comboBoxFiltroMarca.Items.Clear();
            this.marcas = mController.ListarMarcas();       
            comboBoxFiltroMarca.Items.Add("Todas");

            foreach (Marca marca in marcas)
            {
                comboBoxFiltroMarca.Items.Add(marca.Descripcion);
            }
            comboBoxFiltroMarca.Refresh();
            comboBoxFiltroMarca.SelectedIndex = 0;

        }



        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            // aca se va el despliegue antes de mostrar lo filtrado . quitar si molesta
            ActualizarDatos();

            BusquedaFiltrada();
        }





        private void BusquedaFiltrada()
        {

            string criterioBusqueda = comboBoxBusqueda.SelectedItem.ToString();
            string valorBusca2 = richTextBoxBuscar.Text.Trim().ToLower();
            string marcaSeleccionada = comboBoxFiltroMarca.SelectedItem.ToString();

            // Filtra y busca los artículos
            List<Articulo> resultados = articulos;

            if (!string.IsNullOrEmpty(valorBusca2))
            {
                if (criterioBusqueda == "Buscar por Código")
                {
                    resultados = resultados.Where(art => art.Codigo.ToLower().Contains(valorBusca2)).ToList();
                }
                else if (criterioBusqueda == "Buscar por Nombre")
                {
                    resultados = resultados.Where(art => art.Nombre.ToLower().Contains(valorBusca2)).ToList();
                }
            }


            // segundo filtro

            if (marcaSeleccionada != "Todas")
            {
                resultados = resultados.Where(art => art.Marca.Descripcion == marcaSeleccionada).ToList();
            }

            dgvList.DataSource = resultados;
        }





        private void menuStripNuevoCategoria_Click(object sender, EventArgs e)
        {
        
            using(NewCategoryForm frm = new NewCategoryForm())
            {
                    if( frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Categoria agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ActualizarDatos();
                }

            }

        }



        private void menuStripNuevoMarca_Click(object sender, EventArgs e)
        {
            using (NewMarcaForm frm = new NewMarcaForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Marca agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    ActualizarComboBoxMarca();
                    ActualizarDatos();
                }
            }

        }
                



        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el color del botón al pasar el mouse sobre él
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.FromArgb(241, 90, 37);
            }
        }



        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el color original del botón al quitar el mouse
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.FromArgb(255, 163, 0);
            }
        }



        //  actualizar los datos en el dgv
        public void ActualizarDatos()
        {
            articulos = controller.ListarArticulos();
            
            dgvList.DataSource = articulos;
        

            dgvList.Refresh();
            comboBoxFiltroMarca.Refresh();
        }
    }
}
