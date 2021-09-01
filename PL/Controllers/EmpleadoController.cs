using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();
            ML.Empleado empleado = new ML.Empleado();

            empleado.Empleados = result.Objects;
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            if (IdEmpleado == null)
            {
                empleado.Estatus = true;
                return View(empleado);
            }
            else
            {
                ML.Result result = BL.Empleado.GetById(IdEmpleado.Value);

                if (result.Correct)
                {
                    empleado.IdEmpleado = ((ML.Empleado)result.Object).IdEmpleado;
                    empleado.Nombre = ((ML.Empleado)result.Object).Nombre;
                    empleado.ApellidoPaterno = ((ML.Empleado)result.Object).ApellidoPaterno;
                    empleado.ApellidoMaterno = ((ML.Empleado)result.Object).ApellidoMaterno;
                    empleado.Genero = ((ML.Empleado)result.Object).Genero;
                    empleado.Estatus = ((ML.Empleado)result.Object).Estatus;
                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {
                if (empleado.IdEmpleado == 0)
                {
                    result = BL.Empleado.Add(empleado);
                    ViewBag.Message = "El empleado se agregó correctamente";
                }
                else
                {
                    result = BL.Empleado.Update(empleado);
                    ViewBag.Message = "El empleado se actualizó correctamente ";
                }
                if (!result.Correct)
                {
                    ViewBag.Message = "No se pudo agregar correctamente el empleado" + result.ErrorMessage;
                }
            }
            else
            {
                return View(empleado);
            }
            
            return PartialView("Modal");
        }

        public ActionResult UpdateEstatus(int IdEmpleado)
        {

            ML.Result result = new ML.Result();
            result = BL.Empleado.GetById(IdEmpleado);
            ML.Empleado empleado = new ML.Empleado();

            if (result.Correct)
            {
                empleado = ((ML.Empleado)result.Object);

                empleado.IdEmpleado = ((ML.Empleado)result.Object).IdEmpleado;
                empleado.Nombre = ((ML.Empleado)result.Object).Nombre;
                empleado.ApellidoPaterno = ((ML.Empleado)result.Object).ApellidoPaterno;
                empleado.ApellidoMaterno = ((ML.Empleado)result.Object).ApellidoMaterno;
                empleado.Genero = ((ML.Empleado)result.Object).Genero;
                empleado.Estatus = ((ML.Empleado)result.Object).Estatus;

                if (empleado.Estatus == true)
                {
                    empleado.Estatus = false;
                }
                else
                {
                    empleado.Estatus = true;
                }
                result = BL.Empleado.Update(empleado);
                if (result.Correct)
                {
                    ViewBag.Message = "Estatus del empleado actualizado correctamente";
                    
                }
                else
                {
                    ViewBag.Message = "No se pudo cambiar el estatus del Empleado " + result.ErrorMessage;
                }
            }
            else
            {
                result.Correct = false;
                ViewBag.Message = "No se pudo cambiar el estatus del Empleado " + result.ErrorMessage;
            } 
            return PartialView("Modal");
           // return RedirectToAction("GetAll");
        }
	}
}