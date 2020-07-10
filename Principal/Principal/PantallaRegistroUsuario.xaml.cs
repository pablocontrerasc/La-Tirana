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
    /// Lógica de interacción para PantallaRegistroUsuario.xaml
    /// </summary>
    public partial class PantallaRegistroUsuario : Window
    {
        public PantallaRegistroUsuario()
        {
            InitializeComponent();
            CargarTipoCargo();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            RegistrarEmpleado();
            
        }

        private void RegistrarEmpleado()
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("DEBES LLENAR TODOS LOS CAMPOS SOLICITADOS", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
               
                if (rbnConfirmacion.IsChecked == false)
                {
                    MessageBox.Show("DEBE CONFIRMAR LA INFORMACION", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
                else
                {

                    EMPLEADO empleado = new EMPLEADO();
                    {
                        empleado.Nombre = txtNombre.Text;
                        empleado.Apellido = txtApellido.Text;
                        empleado.Usuario = txtUsuario.Text;
                        empleado.Contraseña = txtContraseña.Text;
                        empleado.idCargo = (int)cbxTipoUsuario.SelectedValue;
                        empleado.CodVendedor = Numero();
                    };
                    ServiciosEmpleado servicio = new ServiciosEmpleado();
                    servicio.AddEntity(empleado);

                    MessageBox.Show("EMPLEADO REGISTRADO EXITOSAMENTE", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
            }
        }

        private void CargarTipoCargo()
        {
            ServiciosCargo servicio = new ServiciosCargo();
            List<CARGO> tipos = servicio.GetEntities();
            cbxTipoUsuario.ItemsSource = tipos;
            cbxTipoUsuario.SelectedValuePath = "id";
            cbxTipoUsuario.DisplayMemberPath = "Nombre";
        }

        public static int Numero()
        {
            using (SqlConnection cn = new SqlConnection("Data Source=ANDREEEEES\\SQLEXPRESS;Initial Catalog=LaTirana;Integrated Security=True"))
            {
                cn.Open();
                string sql = "SELECT MAX(CodVendedor) FROM EMPLEADO";
                SqlCommand cmd = new SqlCommand(sql, cn);

                int MaxNumero = 0;
                int.TryParse(cmd.ExecuteScalar().ToString(), out MaxNumero);

                return MaxNumero + 1001;
            }
        }
    }
}
