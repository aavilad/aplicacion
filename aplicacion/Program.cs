using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace xtraForm
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-PE");
            //Application.Run(new frmPrincipal());
            Application.Run(new Modulos.Usuario.frmLogin());

        }
    }
}
