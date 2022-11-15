using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SGPI.Models;

namespace SGPI.Controllers
{
    public class EstudianteController : Controller
    {
        SGPI_BDContext BDContext = new SGPI_BDContext();



        public IActionResult Actualizar(int? Idusuario)
        {
            TblUsuario usuario = BDContext.TblUsuarios.Find(Idusuario);
            if (usuario != null)
            {
                ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
                ViewBag.TblGenero = BDContext.TblGeneros.ToList();
                ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
                return View(usuario);
            }
            else
            {
                return Redirect("/Estudiante/Actualizar/?Idusuario=");
            }
        }

        [HttpPost]
        public IActionResult Actualizar(TblUsuario usuarios)
        {
            usuarios.Idrol = 3;
            ViewBag.Mensaje = "Se Actualizo con exito";
            ViewBag.idusuario = usuarios.Idusuario;
            BDContext.Update(usuarios);
            BDContext.SaveChanges();
            ViewBag.TblPrograma = BDContext.TblProgramas.ToList();
            ViewBag.TblGenero = BDContext.TblGeneros.ToList();
            ViewBag.TblTipoDocumento = BDContext.TblTipoDocumentos.ToList();
            return Redirect("/Estudiante/Actualizar/?Idusuario=" + usuarios.Idusuario);
        }

        public IActionResult Pagos(int? Idusuario)
        {
            TblUsuario usuario = new TblUsuario();
            var usr = BDContext.TblUsuarios.Where(consulta => consulta.Idusuario == Idusuario).FirstOrDefault();
            ViewBag.Idusuario = usr.Idusuario;

            return View();
        }

        [HttpPost]
        public IActionResult Pagos(int? Idusuario, TblPago usuario)
        {
            TblUsuario usr = BDContext.TblUsuarios.Find(Idusuario);

            usuario.Estado = true;
            ViewBag.mensaje = "Pago Enviado";
            BDContext.TblPagos.Add(usuario);
            BDContext.SaveChanges();

            TblEstudiante estudiante = new TblEstudiante();
            estudiante.Archivo = "";
            estudiante.Idusuario = usr.Idusuario;
            estudiante.Idpago = usuario.IdPagos;
            estudiante.Egresado = false;

            BDContext.TblEstudiantes.Add(estudiante);
            BDContext.SaveChanges();

            return View();
        }
    }
}