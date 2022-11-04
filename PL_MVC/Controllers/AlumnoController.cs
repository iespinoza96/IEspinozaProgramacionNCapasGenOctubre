using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Result resultSemestre = BL.Semestre.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();
            if (IdAlumno == null)
            {
                alumno.Semestre.Semestres = resultSemestre.Objects;
                return View(alumno);
            }
            else
            {
                
                //GetbyId
                ML.Result result = BL.Alumno.GetByIdEF(IdAlumno.Value);
                
                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el alummno seleccionado";
                }
                return View(alumno);
            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if (alumno.IdAlumno == 0)
            {
                //add
                //ml.result = agergar
                ML.Result result = BL.Alumno.AddEF(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                ML.Result result = BL.Alumno.AddEF(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }

            return PartialView("Modal");
        }

        //DELETE
    }
}