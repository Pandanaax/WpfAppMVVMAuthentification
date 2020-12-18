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
using WpfAppMVVMAuthentification.Helpers;
using WpfAppMVVMAuthentification.ViewModel;

namespace WpfAppMVVMAuthentification.View
{
    /// <summary>
    /// Logique d'interaction pour Authentification.xaml
    /// </summary>
    public partial class Authentification : Window
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void Connection_Click(object sender, RoutedEventArgs e)
        {
            if (chkWindowsBase.IsChecked == true)
            {
                AuthentificationWindows();
            }
            else
            {
                AuthentificationBase();
            }

        }

        private void AuthentificationBase()
        {
            MessageBox.Show("Authentification en base de données");
        }

        static int  nbTentative = 3;
        private void AuthentificationWindows()
        {
           MessageBox.Show("Authentification windows, a vérifier "+txtUserName.Text+" "+pwdPass.Password);
            // On verifie si le compte user est valide
            // Utiliser des fonctionaités pour cela
            // traitement
            // Single responsability 

            
            bool ok = false;

            ok = WindowsAccessHelper.IsValidateCredentials(txtUserName.Text, pwdPass.Password,"");

           string _connected = (ok) ? "Connecté : #" : "Echec connexion : #";

            if (ok)
            {

                MessageBox.Show(_connected);
                // si connexion reussi alors logger l'évènement 
                // Par sécurité on peut aussi logger les echecs de connexion

                // dans ce cas, on loggera dans tous les cas 

                _connected += txtUserName.Text + "# à partir de la session #" + Environment.UserName + "# à #" + DateTime.Now;

                // logger le string - apres l'avoir crypté

                // d'ou le besoin d'une fonction de cryptage --> ici on utilisera une encodage base64

                string _messageCrypte = EncryptHelper.Base64Encode(_connected);

                MessageBox.Show("message en clair =" + EncryptHelper.Base64Decode(_messageCrypte));
                MessageBox.Show("Message crypté =" + _messageCrypte);

                // logger dans les journaux d'évènements

                var _log = new EventLog("Application");
                _log.Source = "Application";
                _log.WriteEntry(_connected, EventLogEntryType.Information, 1580);
                // log en base
                int i = GestionLog.Logger(_messageCrypte);
                string _s = (i > 0) ? "Enregistré en base !" : "Echec d'enregistrement ";
                MessageBox.Show(_s);
                //

                // se reconnecter sur la fenetre principale
                // Méthode 1 -> masquer la fenetre courante et démasquer la fenetre principale
                // => inconveniant : la fentre courant va rester en standby
                // dans ce vas la fermer comme un dialog result => 
                this.DialogResult = true;

            }
            else // eche

            {
                nbTentative--;
                if (nbTentative == 0)
                    this.DialogResult = false;

            }
            }

        private void AnnulerCnx_Click(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
