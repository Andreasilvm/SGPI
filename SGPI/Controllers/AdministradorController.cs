using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class AdministradorController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();


        public IActionResult Login()
        {

            ///// create

            //TblUsuario usr = new TblUsuario();

            //usr.PrimerNombre = "Mauricio";
            //usr.SegundoNombre = string.Empty;
            //usr.PrimerApellido = "Amariles";
            //usr.SegundoApellido = "Camacho";
            //usr.Email = "mauricio.amariles@tdea.edu.co";
            //usr.Iddoc = 1;
            //usr.Idgenero = 1;
            //usr.Idrol = 1;
            //usr.Idprograma = 1;
            //usr.NumeroDocumento = "123456789";
            //usr.VcPassword = "123456789";

            //context.Add(usr);
            //context.SaveChanges();

            ///// QUERY
            //TblUsuario usuario = new TblUsuario();
            //usuario = context.TblUsuarios
            //.Single(b => b.NumeroDocumento == "123456789");

            //List<TblUsuario> usuarios = new List<TblUsuario>();
            //usuarios = context.TblUsuarios.ToList();

            /// UPDATE
            //var usr = context.TblUsuarios.Where(cursor => cursor.Idusuario == 1)
            //    .FirstOrDefault();
            //if (usr != null)
            //{
            //    usr.SegundoNombre = "Tronchatoro";
            //    context.TblUsuarios.Update(usr);
            //    context.SaveChanges();
            //}

            //    /// DELATE
            //    var usuarioEliminar = context.TblUsuarios.Where(cursor => cursor.Idusuario == 1)
            //        .FirstOrDefault();
            //    context.TblUsuarios.Remove(usuarioEliminar);
            return View();
        }
        [HttpPost]
        public IActionResult Login(TblUsuario user)
        {
            string numerodoc = user.NumeroDocumento;
            string password = user.VcPassword;

            var usuarioLogin = context.TblUsuarios
               .Where(consulta => consulta.NumeroDocumento == numerodoc && consulta.VcPassword == password).FirstOrDefault();
            if (usuarioLogin != null)
            {



                switch (usuarioLogin.Idrol)
                {
                    case 1:
                        CrearUsuario();
                        return View("CrearUsuario");
                       
                    case 2:
                        CoordinadorController Coordinador = new CoordinadorController();
                        Coordinador.BuscarCoordinador();
                        return Redirect("Coordinador/BuscarCoordinador");
                        

                    case 3:
                        EstudianteController Estudiante = new EstudianteController();
                        Estudiante.Actualizar();
                        return Redirect("Estudiante/Actualizar");
                       
                    default:
                        return View();
                       
                }
            }
            else
            {
                return ViewBag.mensaje = "Usuario no existe o usuario/contraseña no no valida";

            }
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
