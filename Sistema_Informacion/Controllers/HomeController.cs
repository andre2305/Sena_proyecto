using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Informacion.Models;

namespace Sistema_Informacion.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            return View(ma.RecuperarTodos());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                usu_Documento = collection["usu_Documento"],
                usu_TipoDocumento = collection["usu_TipoDocumento"],
                usu_Nombre = collection["usu_Nombre"],
                usu_Celular = collection["usu_Celular"],
                usu_Email = collection["usu_Email"],
                usu_Genero = collection["usu_Genero"],
                usu_Aprendiz = int.Parse(collection["usu_Aprendiz"]),
                usu_Egresado = int.Parse(collection["usu_Egresado"]),
                usu_AreaFormacion = collection["usu_AreaFormacion"],
                usu_FechaEgresado = DateTime.Parse(collection["usu_FechaegResado"]),
                usu_Direccion = collection["usu_Direccion"],
                usu_Barrio = collection["usu_Barrio"],
                usu_Ciudad = collection["usu_Ciudad"],
                usu_Departamento = collection["usu_Departamento"],
               usu_FechaRegistro = DateTime.Parse(collection["usu_fecharegistro"])
            };
            ma.Alta(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = new Usuario
            {
                usu_ID = id,
                usu_Documento =collection["documento"].ToString(),
                usu_TipoDocumento = collection["tipodocumento"].ToString(),
                usu_Nombre = collection["nombre"].ToString(),
                usu_Celular = collection["celular"].ToString(),
                usu_Email = collection["email"].ToString(),
                usu_Genero = collection["genero"].ToString(),
                usu_Aprendiz = int.Parse(collection["aprendiz"].ToString()),
                usu_Egresado = int.Parse(collection["egresado"].ToString()),
                usu_AreaFormacion = collection["areaformacion"].ToString(),
                usu_FechaEgresado = DateTime.Parse(collection["fechaegresado"].ToString()),
                usu_Direccion = collection["direccion"].ToString(),
                usu_Barrio = collection["barrio"].ToString(),
                usu_Ciudad = collection["ciudad"].ToString(),
                usu_Departamento = collection["departamento"].ToString(),
                usu_FechaRegistro = DateTime.Parse(collection["fecharegistro"].ToString())
            };
            ma.Modificar(usu);
            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            Usuario usu = ma.Recuperar(id);
            return View(usu);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            MantenimientoUsuario ma = new MantenimientoUsuario();
            ma.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}