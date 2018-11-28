using Data.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //new FrmCompetitions(new RhDataService(new RhDataBase()))
            var db = new RhDataBase();
            
            Application.Run(new Login(new RhDataService(db)));
        }
    }
}
