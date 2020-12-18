using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMAuthentification.Model
{
    public class Utilisateur
    { 
        [Key]

        public int id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }
        public string Email { get; set; }


    }
}
