using DevExpress.Skins;
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
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.UserSkins.BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //Application.EnableVisualStyles();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-PE");
            Application.Run(new Modulos.Usuario.frmLogin());


        }
    }
}
