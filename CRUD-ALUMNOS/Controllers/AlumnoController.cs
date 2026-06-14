using CRUD_ALUMNOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ALUMNOS.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index()
        {

            try
            {

                string sql = @"
                                select a.Id as CodAlumno, a.Nombres, a.Apellidos, a.Edad, a.Sexo, a.FechaRegistro
                                c.Nombre as Ciudad from Alumno a 
                                inner join Ciudad c on a.CodCiudad = c.ID
                                where a.Edad > 18
                                ";

                using (var db = new AlumnosContext())
                {

                    /*var data = from a in db.Alumno
                               join c in db.Ciudad on a.CodCiudad equals c.Id
                               select new AlumnoCE()
                               {

                                   Id = a.Id,
                                   Nombres = a.Nomrbes,
                                   Apellidos = a.Apellidos,
                                   Sexo = a.Sexo,
                                   NombreCiudad = c.Nombre,
                                   FechaRegistro = a.FechaRegistro,

                               }
                    
                    return View(db.Alumno.ToList());*/

                    return View(db.Database.SqlQuery<AlumnoCE>(sql).ToList());
                    
                }

            }
            catch (Exception)
            {

                throw;

            }
        }

        public ActionResult Agregar()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Alumno a)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {

                using (var db = new AlumnosContext())
                {

                    a.FechaRegistro = DateTime.Now;

                    db.Alumno.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error al registrar Alumno" + ex.Message);
                return View();

            }

        }

        public ActionResult Editar(int id)
        {

            try
            {

                using (var db = new AlumnosContext()) 
                {

                    Alumno alu = db.Alumno.Find(id);
                    return View(alu);

                
                }

            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Editar(Alumno a)
        {

            try
            {
                using (var db = new AlumnosContext())
                {

                    Alumno al = db.Alumno.Find(a.Id);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    db.SaveChanges();

                    return RedirectToAction("index");

                }
                

            }
            catch (Exception ex) 
            {

                throw;
            
            } 


        }

        public ActionResult Detallesalumno(int id) 
        {
            
            using (var db = new AlumnosContext()) 
            {

                Alumno alu = db.Alumno.Find(id);
                return View(alu);
            
            }
        
        }

        public ActionResult EliminarAlumno()
        {

            using (var db = new AlumnosContext) 
            {

                Alumno alu = db.Alumno.Find(id);
                db.Alumno.Remove(alu);
                db.SaveChanges();
                return RedirectToAction("Index");
            
            }

        }

        public static string NombreCiudad(int CodCiudad)
        {

            using(var db = new AlumnosContext())
            {

                return db.Ciudad.Find(CodCiudad).Nombre;

            }

        }

    }

}
