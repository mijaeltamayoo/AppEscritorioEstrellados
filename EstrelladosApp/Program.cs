using EstrelladosApp.Servicios;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstrelladosApp
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            UsuarioService usuarioService = new UsuarioService();
            var usuarios = await usuarioService.ObtenerUsuariosAsync();

            Console.WriteLine($"Usuarios obtenidos: {usuarios.Count}");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
