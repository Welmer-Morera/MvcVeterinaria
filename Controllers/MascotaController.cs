using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MvcVeterinaria.Models;

namespace MvcVeterinaria.Controllers
{
    public class MascotaController : Controller
    {
        static List<Mascota> ListaMascotas = new List<Mascota>();

        public static int Identificador = 1;
        Mascota mascota = new Mascota();

        public IActionResult Index()
        {
            List<Mascota> listaOrdenada = ListaMascotas.OrderBy(p => p.Id).ToList();

            var model = listaOrdenada;
            return View("Index", model);
        }

        public IActionResult Create()
        {
            ViewBag.Iden = Identificador;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Mascota mascota)
        {
            if (ModelState.IsValid)
            {

                ListaMascotas.Add(mascota);
                Identificador++;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Iden = Identificador;
            return View();
        }

        public void ObtenerDatos(int Id)
        {
            int pos = ListaMascotas.FindIndex(p => p.Id == Id);
            mascota.Id = ListaMascotas[pos].Id;
            mascota.Nombre = ListaMascotas[pos].Nombre;
            mascota.Edad = ListaMascotas[pos].Edad;
            mascota.Dueño = ListaMascotas[pos].Dueño;

        }
        public List<string> obtenerNombres(){
             List<string> nom =new List<string>();
             string name="no hay nada";

             for (var i = 0; i < ListaMascotas.Count(); i++)
             { 

                 name = ListaMascotas[i].Nombre.ToString();
                 nom.Add(name);
                 
             }

             
             return nom;
        }


        public IActionResult Details(int Id)
        {


            ObtenerDatos(Id);
            return View(mascota);


        }

        public IActionResult Edit(int Id)
        {

            ObtenerDatos(Id);
            return View(mascota);

        }

        [HttpPost]
        public IActionResult Edit(int Id, Models.Mascota mascota)
        {

            if (ModelState.IsValid)
            {
                ObtenerDatos(Id);
                int pos = ListaMascotas.FindIndex(p => p.Id == Id);
                ListaMascotas.RemoveAt(pos);
                ListaMascotas.Add(mascota);
                return RedirectToAction(nameof(Index));
            }
            return View(mascota);
 
        } 

        public IActionResult Delete(int Id)
        {


            ObtenerDatos(Id);
            return View(mascota);

        }

        [HttpPost]
        public IActionResult Delete(int Id, Models.Mascota mascota)
        {
            ObtenerDatos(Id);
            int pos = ListaMascotas.FindIndex(p => p.Id == Id);
            ListaMascotas.RemoveAt(pos);
            return RedirectToAction(nameof(Index));

        }
    }
}