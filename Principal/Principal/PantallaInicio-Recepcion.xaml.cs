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
    /// Lógica de interacción para PantallaInicio_Recepcion.xaml
    /// </summary>
    public partial class PantallaInicio_Recepcion : Window
    {
        public PantallaInicio_Recepcion()
        {
            InitializeComponent();
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
            PantallaRegistroUsuario p = new PantallaRegistroUsuario();
            p.ShowDialog();
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            PantallaGestionVentas p = new PantallaGestionVentas();
            p.ShowDialog();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        public static int NroOperacion()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ANDREEEEES\\SQLEXPRESS;Initial Catalog=LaTirana;Integrated Security=True"))
            {
                cn.Open();
                string sql = "SELECT MAX(NroOperacion) FROM BOLETA";
                SqlCommand cmd = new SqlCommand(sql, cn);

                int MaxNumero = 0;
                int.TryParse(cmd.ExecuteScalar().ToString(), out MaxNumero);

                return MaxNumero + 501;
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
           var mensaje = MessageBox.Show("DESEA CONTINUAR CON ESTA OPERACION", "mensaje", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
           if(mensaje == MessageBoxResult.Yes)
           {
                PantallaGestionVentas p = new PantallaGestionVentas();
                p.txtCódigoV.Text = "1001";
                p.txtNroBoleta.Text = NroBoleta().ToString();
                p.txtNroOperacion.Text = NroOperacion().ToString();
                p.ShowDialog();
           }
        }
    }
}
