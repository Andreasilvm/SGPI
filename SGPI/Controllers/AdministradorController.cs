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
                        return Redirect("/Administrador/CrearUsuario");

                    case 2:
                        CoordinadorController Coordinador = new CoordinadorController();
                        Coordinador.BuscarCoordinador();
                        return Redirect("/Coordinador/BuscarCoordinador");


                    case 3:
                        EstudianteController Estudiante = new EstudianteController();
                        Estudiante.Actualizar();
                        return Redirect("/Estudiante/Actualizar");

                    default:
                        return View();
                }
            }
            else
            {
                ViewBag.mensaje = "Usuario no existe o usuario/contraseña no es valida";

            }
            return View();
        }


        public IActionResult OlvidarContrasena()
        {
            return View();
        }
        public IActionResult CrearUsuario()
        {
            ViewBag.TblPrograma = context.TblProgramas.ToList();
            ViewBag.TblGenero = context.TblGeneros.ToList();
            ViewBag.TblRol = context.TblRols.ToList();
            ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();


            return View();
        }

        /// modificando 27/10/2022
        [HttpPost]
        public IActionResult CrearUsuario(TblUsuario Usuario)
        {
            context.TblUsuarios.Add(Usuario);
            context.SaveChanges();

            ViewBag.mensaje = "usuario creado Exitosamente";
            ViewBag.TblPrograma = context.TblProgramas.ToList();
            ViewBag.TblGenero = context.TblGeneros.ToList();
            ViewBag.TblRol = context.TblRols.ToList();
            ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();


            return View();
        }


        public IActionResult BuscarUsuario()
        {
            TblUsuario usuario = new TblUsuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult BuscarUsuario(TblUsuario usuario)
        {
            String numeroDoc = usuario.NumeroDocumento;
            var user = context.TblUsuarios.
                Where(consulta => consulta.NumeroDocumento == numeroDoc).FirstOrDefault();
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return View();
            }

        }

        public IActionResult EliminarUsuario(int? Idusuario)
        {
            TblUsuario user = context.TblUsuarios.Find(Idusuario);

            if (user != null)
            {
                context.Remove(user);
                context.SaveChanges();

            }
            return View();
        }

        [HttpPost]
        public IActionResult EditarUsuario(TblUsuario usuario)
        {
            context.Update(usuario);
            context.SaveChanges();
            return Redirect("/Administrador/BuscarUsuario");
        }

        public IActionResult EditarUsuario(int? Idusuario)
        {
            TblUsuario usuarios = context.TblUsuarios.Find(Idusuario);

            if (usuarios != null)
            {
                ViewBag.TblPrograma = context.TblProgramas.ToList();
                ViewBag.TblGenero = context.TblGeneros.ToList();
                ViewBag.TblRol = context.TblRols.ToList();
                ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
                return View(usuarios);
            }
            else
            {
                return Redirect("/Administrador/BuscarUsuario");
            }
          
        }


        public IActionResult Reporte()
        {

            return View();
        }

    }


}
