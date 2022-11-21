using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using IIParcialMySQL.Models;
using IIParcialMySQL.DatabaseHelper;


namespace IIParcialMySQL.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveUser(
                            string txtCedula,
                            string txtNombre,
                            string txtApellido,
                            string txtTelefono,
                            string txtEmail,
                            string txtPassword)
        {
            try
            {
                DatabaseHelper.DatabaseHelper.InsertUser(new Models.Usuarios()
                {
                    Cedula = txtCedula,
                    Nombre = txtNombre,
                    Apellido = txtApellido,
                    Telefono = Convert.ToInt32(txtTelefono),
                    Email = txtEmail,
                    Password = txtPassword

                });

                return RedirectToAction("Index", "Login");
            }
            catch (Exception exemail)
            {
                ViewBag.Error = new ErrorHandler()
                {
                    Title = "¡ERROR!",
                    ErrorMessage = "El Email ingresado ya existe en la Base de Datos",
                    Path = "/Login/Registro"
                };

                return View("ErrorHandler");
            }

        }

        [HttpPost]
        public IActionResult ResetPasswordUser(
                    string txtEmail,
                    string txtPassword)
        {
            try 
            {
                DatabaseHelper.DatabaseHelper.ResetPassword(new Models.Usuarios()
                {
                    Email = txtEmail,
                    Password = txtPassword

                });

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorHandler()
                {
                    Title = "¡ERROR!",
                    ErrorMessage = "El Email ingresado NO existe en la Base de Datos",
                    Path = "/Login/ResetPassword"
                };

                return View("ErrorHandler");
            }

        }


        [HttpPost]
        public ActionResult ValidateLogin(string txtEmail, string txtPassword)
        {
            Usuarios? usuarios = GetUser(txtEmail, txtPassword);

            if (usuarios != null)
            {
                string strUser = JsonConvert.SerializeObject(usuarios);

                HttpContext.Session.SetString("userSession", strUser);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = new ErrorHandler()
                {
                    Title = "¡ERROR Login Inválido!",
                    ErrorMessage = "Email o Password Incorrectos",
                    Path = "/Login"
                };

                return View("ErrorHandler");
            }
        }

        private Usuarios? GetUser(string txtEmail, string txtPassword)
        {
            DataTable ds = DatabaseHelper.DatabaseHelper.ExecuteStoreProcedure("spValidarUsuario", new List<MySqlParameter>()
            {
                new MySqlParameter("pEmail", txtEmail),
                new MySqlParameter("pPassword", txtPassword)
            });

            if (ds.Rows.Count > 0)
            {
                Usuarios usuario = new Usuarios
                {
                    Cedula = ds.Rows[0]["Cedula"].ToString(),
                    Nombre = ds.Rows[0]["Nombre"].ToString(),
                    Apellido = ds.Rows[0]["Apellido"].ToString(),
                    Telefono = Convert.ToInt32(ds.Rows[0]["Telefono"]),
                    Email = ds.Rows[0]["Email"].ToString(),
                    Password = ds.Rows[0]["Password"].ToString(),
                };

                return usuario;
            }
            else
            {
                return null;
            }
        }

        private Usuarios? GetEmailUser(string txtEmail)
        {
            DataTable ds = DatabaseHelper.DatabaseHelper.ExecuteStoreProcedure("spEmail", new List<MySqlParameter>()
            {
                new MySqlParameter("pEmail", txtEmail)
            });

            if (ds.Rows.Count > 0)
            {
                Usuarios emailusuario = new Usuarios
                {
                    Cedula = ds.Rows[0]["Cedula"].ToString(),
                    Nombre = ds.Rows[0]["Nombre"].ToString(),
                    Apellido = ds.Rows[0]["Apellido"].ToString(),
                    Telefono = Convert.ToInt32(ds.Rows[0]["Telefono"]),
                    Email = ds.Rows[0]["Email"].ToString(),
                    Password = ds.Rows[0]["Password"].ToString(),
                };

                return emailusuario;
            }
            else
            {
                return null;
            }
        }





        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
