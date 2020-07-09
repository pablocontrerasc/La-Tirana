using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para PantallaCuadratura.xaml
    /// </summary>
    public partial class PantallaCuadratura : Window
    {
        public PantallaCuadratura()
        {
            InitializeComponent();
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

        private void btnCuadratura_Click(object sender, RoutedEventArgs e)
        {
            PantallaCuadratura p = new PantallaCuadratura();
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
    }
}
