﻿using Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Principal
{
    /// <summary>
    /// Lógica de interacción para PantallaGestionVentas.xaml
    /// </summary>
    public partial class PantallaGestionVentas : Window
    {
        public PantallaGestionVentas()
        {
            InitializeComponent();
            CargarFormaPago();
            CargarProductos();
         
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            PantallaGestionVentas p = new PantallaGestionVentas();
            p.ShowDialog();
        }

        private void btnCuadratura_Click(object sender, RoutedEventArgs e)
        {
            PantallaCuadratura p = new PantallaCuadratura();
            p.ShowDialog();
        }

        private void btnHistorialV_Click(object sender, RoutedEventArgs e)
        {
            PantallaHistorialVenta p = new PantallaHistorialVenta();
            p.ShowDialog();
        }

        private void btnStock_Click(object sender, RoutedEventArgs e)
        {
            PantallaProductosVendidos p = new PantallaProductosVendidos();
            p.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            PantallaAdministracionUsuarios p = new PantallaAdministracionUsuarios();
            p.ShowDialog();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void CargarFormaPago()
        {
            ServiciosFormaPago servicio = new ServiciosFormaPago();
            List<FORMA_PAGO> tipos = servicio.GetEntities();
            cbxFormaPago.ItemsSource = tipos;
            cbxFormaPago.SelectedValuePath = "id";
            cbxFormaPago.DisplayMemberPath = "Nombre";
        }

        public void CargarProductos()
        {
            ServiciosProducto servicio = new ServiciosProducto();
            List<PRODUCTO> tipos = servicio.GetEntities();
            cbxNombreProducto.ItemsSource = tipos;
            cbxNombreProducto.SelectedValuePath = "idProducto";
            cbxNombreProducto.DisplayMemberPath = "Nombre";
        }

        public static int Numero()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ANDREEEEES\\SQLEXPRESS;Initial Catalog=LaTirana;Integrated Security=True"))
            {
                cn.Open();
                string sql = "SELECT MAX(idBoleta) FROM BOLETA";
                SqlCommand cmd = new SqlCommand(sql, cn);

                int MaxNumero = 0;
                int.TryParse(cmd.ExecuteScalar().ToString(), out MaxNumero);

                return MaxNumero + 10001;
            }
        }

        private void cbxNombreProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxNombreProducto.SelectedIndex == -1)
            {
                txtCodigoRegistro.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
            }
            else
            {
                int cod = (int)cbxNombreProducto.SelectedValue;
                PRODUCTO producto = new ServiciosProducto().GetEntity(cod);

                txtCodigoRegistro.Text = producto.idProducto.ToString();
                txtPrecio.Text = producto.Precio.ToString();
                txtStock.Text = producto.Stock.ToString();
            }
        }


        public void Cargar()
        {
            var cod = int.Parse(txtCodigoRegistro.Text);
            ServiciosProducto producto = new ServiciosProducto();
            var listadoproducto = from p in producto.GetEntities()
                                  where p.idProducto == cod
                                  select new
                                  {
                                      Codigo = p.idProducto,
                                      Descripcion = p.Nombre,
                                      cantidad = txtCantidad.Text,
                                      Precio = p.Precio,

                                  };

            dgListaProducto.ItemsSource = listadoproducto;
            dgListaProducto.Items.Refresh();
        }

        private void txtCantidad_LostFocus(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
    }
}
