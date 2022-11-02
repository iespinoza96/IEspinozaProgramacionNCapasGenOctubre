using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using BL;
//using ML;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno

        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
        //[HttpPatch]
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAllEF();
            ML.Alumno alumno = new ML.Alumno(); 
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
                //reusltado = a + b;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(alumno);
        }
    }
}