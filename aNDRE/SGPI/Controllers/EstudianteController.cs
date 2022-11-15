using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGPI.Controllers;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPI_BDContext context = new SGPI_BDContext();


        public IActionResult Actualizar(int? Idusuario)
        {
            TblUsuario usuarios = context.TblUsuarios.Find(Idusuario);
            if (usuarios != null)
            {

                ViewBag.TblPrograma = context.TblProgramas.ToList();
                ViewBag.TblGenero = context.TblGeneros.ToList();
                ViewBag.TblTipoDocumento = context.TblTipoDocumentos.ToList();
                return View(usuarios);
            }
            else
            {
                return Redirect("/Estudiante/Actualizar/?Idusuario");
            }
        }
        [HttpPost]
        public IActionResult Actualizar(TblUsuario usuarios)
        {
            int numeroDoc = usuarios.Idusuario;
            var usuarioActualizar = context.TblUsuarios.
                Where(consulta => consulta.Idusuario == numeroDoc).FirstOrDefault();

            usuarioActualizar.NumeroDocumento = usuarios.NumeroDocumento;
            usuarioActualizar.Iddoc = usuarios.Iddoc;
            usuarioActualizar.PrimerNombre = usuarios.PrimerNombre;
            usuarioActualizar.SegundoNombre = usuarios.SegundoNombre;
            usuarioActualizar.PrimerApellido = usuarios.PrimerApellido;
            usuarioActualizar.SegundoApellido = usuarios.SegundoApellido;
            usuarioActualizar.Idgenero = usuarios.Idgenero;
            usuarioActualizar.Idprograma = usuarios.Idprograma;
            usuarioActualizar.Email = usuarios.Email;


            context.Update(usuarioActualizar);
            context.SaveChanges();
            ViewBag.Estudiante = "Se ha actualizado con exito";

            return Redirect("/Estudiante/Actualizar/?Idusuario= " + usuarioActualizar.Idusuario);
        }



        public IActionResult Pagos()
        {
            ViewBag.TblPago = context.TblPagos.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Pagos(TblPago usuario)
        {
            usuario.Estado = true;
            context.TblPagos.Add(usuario);
            context.SaveChanges();
            ViewBag.Pagos = "Pago Enviado";
            return View();
        }
    }
}