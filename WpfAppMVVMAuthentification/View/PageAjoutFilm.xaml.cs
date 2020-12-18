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

namespace WpfAppMVVMAuthentification.View
{
    /// <summary>
    /// Interaction logic for PageAjoutFilm.xaml
    /// </summary>
    public partial class PageAjoutFilm : Page
    {
        public PageAjoutFilm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    private void InitialiserListFilm()
    {
        dgFilms.ItemSource = GestionFilm.GetFilms();
    }

    private void EnregisterUnFilm_Click(Object sender, RoutedEventArgs e)
    {
        Film _f = new Film();
        _f.Titre = txtTitreFilm.Text;
        _f.Annee = int.Parse(txtAnneeFilm.Text);

    }
}
