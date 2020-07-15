using Persistencia;
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

            var cod = int.Parse(txtNroBoleta.Text);
            ServiciosBoleta boleta = new ServiciosBoleta();
            ServiciosProducto producto = new ServiciosProducto();
            var listadoproducto = from b in boleta.GetEntities()
                                  join p in producto.GetEntities()
                                  on b.idProducto equals p.idProducto
                                  where b.NroBoleta == cod
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

        private void Registrar()
        {
            BOLETA b = new BOLETA()
            {

                NroBoleta = int.Parse(txtNroBoleta.Text),
                NroOperacion = int.Parse(txtNroOperacion.Text),
                MontoTotal = int.Parse(txtTotalFinal.Text),
                CantidadProducto = int.Parse(txtCantidad.Text),
                //Fecha = Convert.ToDateTime(dtFecha.SelectedDate),
                idFormaPago = (int)cbxFormaPago.SelectedValue,
                idVendedor = int.Parse(txtCódigoV.Text),
                idProducto = (int)cbxNombreProducto.SelectedValue,
                Precio = int.Parse(txtPrecio.Text)

            };
            ServiciosBoleta servicio = new ServiciosBoleta();
            servicio.AddEntity(b);
        }

        public static int NroBoleta()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ANDREEEEES\\SQLEXPRESS;Initial Catalog=LaTirana;Integrated Security=True"))
            {
                cn.Open();
                string sql = "SELECT MAX(NroBoleta) FROM BOLETA";
                SqlCommand cmd = new SqlCommand(sql, cn);

                int MaxNumero = 0;
                int.TryParse(cmd.ExecuteScalar().ToString(), out MaxNumero);

                return MaxNumero + 1;
            }
        }

        public int ValorTotal()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ANDREEEEES\\SQLEXPRESS;Initial Catalog=LaTirana;Integrated Security=True"))
            {
                
                cn.Open();
                string sql = "SELECT SUM(Precio) FROM BOLETA WHERE NroBoleta =" +  txtNroBoleta.Text;
                SqlCommand cmd = new SqlCommand(sql, cn);

                int Resultado = 0;
                int.TryParse(cmd.ExecuteScalar().ToString(), out Resultado);

                return Resultado;
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
            Registrar();
            txtTotalFinal.Text = ValorTotal().ToString();
            Cargar();

        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("VENTA REGISTRADA", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
            cbxFormaPago.SelectedIndex = -1;
            cbxNombreProducto.SelectedIndex = -1;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtTotalFinal.Text = string.Empty;
            txtNroBoleta.Text = NroBoleta().ToString();

        }
    }
}
