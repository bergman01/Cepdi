using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class UsuariosController : Controller
    {

        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _UsuarioDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(UsuarioModel oUsuario)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _UsuarioDatos.Guardar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oUsuario = _UsuarioDatos.Obtener(Id);
            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel oUsuario)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _UsuarioDatos.Editar(oUsuario);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oUsuario = _UsuarioDatos.Obtener(Id);
            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(UsuarioModel oUsuario)
        {
  
            var respuesta = _UsuarioDatos.Eliminar(oUsuario.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
