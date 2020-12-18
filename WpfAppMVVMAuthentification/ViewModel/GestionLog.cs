using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppMVVMAuthentification.Model;

namespace WpfAppMVVMAuthentification.ViewModel
{
   public class GestionLog : IDisposable
    {
        //dbcontext (généralement noté dbc ou db )
        private  static EFFilms db = new EFFilms();

        public static int Logger (string info)
        {
            db.Trace.Add(new Trace { Info=info });
           return  db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
