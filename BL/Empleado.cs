using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenZDamianEntities context = new DL.ExamenZDamianEntities())
                {
                    var empleados = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Genero = obj.Genero;
                            empleado.Estatus = obj.Estatus.Value;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenZDamianEntities context = new DL.ExamenZDamianEntities())
                {
                    var empleados = context.EmpleadoAdd(empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Genero, empleado.Estatus);

                    if (empleados >= 1)
                    {
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al insertar";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenZDamianEntities context = new DL.ExamenZDamianEntities())
                {
                    var empleados = context.EmpleadoUpdate(empleado.IdEmpleado,empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Genero, empleado.Estatus);

                    if (empleados >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al actualizar";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenZDamianEntities context = new DL.ExamenZDamianEntities())
                {
                    var empleados = context.EmpleadoDelete(empleado.IdEmpleado);

                    if (empleados >= 1)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al eliminar";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenZDamianEntities context = new DL.ExamenZDamianEntities())
                {
                    ML.Empleado empleado = new ML.Empleado();
                    var empleados = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();


                    empleado.IdEmpleado = empleados.IdEmpleado;
                    empleado.Nombre = empleados.Nombre;
                    empleado.ApellidoPaterno = empleados.ApellidoPaterno;
                    empleado.ApellidoMaterno = empleados.ApellidoMaterno;
                    empleado.Genero = empleados.Genero;
                    empleado.Estatus = empleados.Estatus.Value;

                    result.Object = empleado;

                    if (empleados != null)
                    {
                    
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraro el Id";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        
    }
}
