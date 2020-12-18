using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppMVVMAuthentification.Model
{
    public class Trace
    {
        // table des logs
        [Key]

        public int Id { get; set; }
        
        // texte en vrac
        public string Info { get; set; }


        

    }
}
