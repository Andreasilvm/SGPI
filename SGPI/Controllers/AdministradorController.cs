using Microsoft.AspNetCore.Mvc;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();


        public IActionResult Login()
        {

            /// create

            TblUsuario usr = new TblUsuario();

            usr.PrimerNombre = "Mauricio";
            usr.SegundoNombre = string.Empty;
            usr.PrimerApellido = "Amariles";
            usr.SegundoApellido = "Camacho";
            usr.Email = "mauricio.amariles@tdea.edu.co";
            usr.Iddoc = 1;
            usr.Idgenero = 1;
            usr.Idrol = 1;
            usr.Idprograma = 1;
            usr.NumeroDocumento = "123456789";
            usr.VcPassword = "123456789";

            context.Add(usr);
            context.SaveChanges();

            /// QUERY
            /// UPDATE
            /// DALATE

            return View();
        }

        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            return View();
        }

        public IActionResult BuscarUsuario()
        {
            return View();
        }

        public IActionResult EliminarUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario()
        {
            return View();
        }

        public IActionResult Reporte()
        {
            return View();
        }

    }
}