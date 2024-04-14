using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int Id)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
  
            var respuesta = _ContactoDatos.Eliminar(oContacto.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
