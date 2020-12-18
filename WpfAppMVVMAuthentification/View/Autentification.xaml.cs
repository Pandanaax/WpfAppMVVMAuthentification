using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfAppMVVMAuthentification.Helper;

namespace WpfAppMVVMAuthentification.View
{
    /// <summary>
    /// Interaction logic for Autentification.xaml
    /// </summary>
    public partial class Autentification : Window
    {
        public Autentification()
        {
            InitializeComponent();
        }
        static int nbTentative = 3;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            if (chkWindowsBase.IsChecked == true)
            {
                AutentificationWindows();
            }
            else
            {
                AutentificationBase();
            }
        }

        private void AutentificationBase()
        {
            MessageBox.Show("Authentification en base de données");
        }

        private void AutentificationWindows()
        {
            MessageBox.Show("Authentification windows " + txtUserName.Text + " " + pwdPass.Password );
            // On vérifie si le compte user est valide 
            // Utiliser des fonctionalités pour cela
            // traitement
            // Single responsability
            bool ok = false;

            ok = WindowsAccessHelper.IsValidateCredentials(txtUserName.Text, pwdPass.Password, "");

            string _connected = (ok) ? "Connecté : #" : "Echec connexion";

            if (ok)
            {
             MessageBox.Show(_connected);
            // si connexion reussi alors loger l'évenement
            // par sécurité on peut aussi logger les echecs de connexion

            // Dans ce cas, on loggera dans tous les cas

            _connected += txtUserName.Text + " à partir de la session : # " + Environment.UserName + ": #  à : # " + DateTime.Now;

            // logger le string - après l'avoir crypté 

            // D'où le besoin d'une fonction de cryptage ==> ici on utilisera un encodege base64
            string _messageCrypte = EncryptHelper.Base64Encode(_connected);

            MessageBox.Show("message  en clair+ " + EncryptHelper.Base64Decode(_messageCrypte));

            MessageBox.Show("message crypté + " +_messageCrypte);

            var _log = new EventLog("Application");
            _log.Source = "Application";
            _log.WriteEntry(_connected, EventLogEntryType.Information, 1580);
            // log en base
            int i = GestionLog.Logger(_messageCrypte);
            string _s = (i > 0) ? "Enrengistré en base !" : "Echec d'enrengistrement";


            MessageBox.Show(_s);

                // se reconnecter sur la fenetre principale
                // methode 1 => masquer la fenetre courante et démasquer la fenetre principale
                // => inconveniant : la fenetre courant va rester en standby
                // dans ce cas on va la fermer comme une boîte de dialogue result => 
                this.DialogResult = true;

            }
            else
            {
                nbTentative--;
                if (nbTentative == 0)
                    this.DialogResult = false;
                
            }

           

        }

        private void AnnulerCnx_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }
    }
}
