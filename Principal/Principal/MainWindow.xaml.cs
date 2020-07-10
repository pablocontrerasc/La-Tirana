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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Principal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtUsuario.Text = "";
            txtContraseña.Password = "";
        }
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

            if (txtUsuario.Text == "" || txtContraseña.Password == "")
            {
                MessageBox.Show("DEBE INGRESAR LOS DATOS", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
            else
            {
                if (txtUsuario.Text == "and" && txtContraseña.Password == "123")
                {
                    PantallaGestionVentas p = new PantallaGestionVentas();
                    p.ShowDialog();
                    p.txtCódigoV.Text = "001";
                    p.dtFecha.SelectedDate = DateTime.Now;
                    Limpiar();
                }
                else if(txtUsuario.Text == "res" && txtContraseña.Password == "456")
                {
                    PantallaGestionVentas p = new PantallaGestionVentas();
                    p.ShowDialog();
                    p.txtCódigoV.Text = "002";
                    p.dtFecha.SelectedDate = DateTime.Now;
                    Limpiar();
                }
                else if (txtUsuario.Text == "shot" && txtContraseña.Password == "789")
                {
                    PantallaGestionVentas p = new PantallaGestionVentas();
                    p.ShowDialog();
                    p.txtCódigoV.Text = "003";
                    p.dtFecha.SelectedDate = DateTime.Now;
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("USUARIO O CONTRASEÑA INCORRECTOS", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    Limpiar();
                }
            }

        }
    }
}
