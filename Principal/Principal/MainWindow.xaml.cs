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
                if (txtUsuario.Text == "Pabcontreras" && txtContraseña.Password == "123")
                {
                    PantallaInicio_Recepcion p = new PantallaInicio_Recepcion();
                    p.txtNombreVendedor.Text = "Pablo Adrian Contreras";
                    p.txtCodigoRegistro.Text = "1002";
                    p.txtCódigoV.Text = "01"; 
                    p.ShowDialog();
                    
                    Limpiar();
                }
                else if(txtUsuario.Text == "Elivasquez" && txtContraseña.Password == "123")
                {
                    PantallaInicio_Recepcion p = new PantallaInicio_Recepcion();
                    p.txtNombreVendedor.Text = "José Elias Vasquez";
                    p.txtCodigoRegistro.Text = "1003";
                    p.txtCódigoV.Text = "02";
                    Limpiar();
                }
                else if (txtUsuario.Text == "Andfuentes" && txtContraseña.Password == "123")
                {
                    PantallaInicio_Recepcion p = new PantallaInicio_Recepcion();
                    p.txtNombreVendedor.Text = "José Elias Vasquez";
                    p.txtCodigoRegistro.Text = "1004";
                    p.txtCódigoV.Text = "04";
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
