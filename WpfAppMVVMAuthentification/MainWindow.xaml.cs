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
using WpfAppMVVMAuthentification.View;

namespace WpfAppMVVMAuthentification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // s'authentifier
            Authentifier();
        }

        private void Authentifier()
        {
            // se diriger vers l'authentification
            // Masque celle-ci et affiche l'authentification
            // qui retrourne true si l'authentification s'est bien passé

            this.Hide();
            Autentification auth = new Autentification();
            //auth.Show();
            if (auth.ShowDialog() == true)
            {
                this.Show();
            }
            else
            {
                // femer l'application
                this.Close();
            }
        }

        
        private void txtAjoutHide(object sender, MouseEventArgs e)
        {
            txtAjout.Visibility = Visibility.Hidden;
        }
        private void txtAjoutVisible(object sender, MouseEventArgs e)
        {
           txtAjout.Visibility = Visibility.Visible;
        }

        private void txtRechercheVisible(object sender, MouseEventArgs e)
        {
            txtRecherche.Visibility = Visibility.Visible;
        }

        private void txtRechercheHide(object sender, MouseEventArgs e)
        {
            txtRecherche.Visibility = Visibility.Hidden;
        }

    
        private void btnAdminAvecRelief(object sender, MouseEventArgs e)
        {
            btnAdmin.BorderThickness = new Thickness(4);
            
        }

        private void btnAdminAvecSansRelief(object sender, MouseEventArgs e)
        {
            btnAdmin.BorderThickness = new Thickness(1);
        }
        private void btnAutreAvecRelief(object sender, MouseEventArgs e)
        {
            btnAutres.BorderThickness = new Thickness(4);
            btnAutres.BorderBrush = Brushes.Transparent;

        }
        private void btnAutreAvecSansRelief(object sender, MouseEventArgs e)
        {
            btnAutres.BorderThickness = new Thickness(1);
        }
    }
}
