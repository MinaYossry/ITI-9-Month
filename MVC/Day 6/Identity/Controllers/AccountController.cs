using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User NewUser)
        {
            if (ModelState.IsValid)
            {
                MainDbContext db = new MainDbContext();

                db.Users.Add(NewUser);

                db.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, NewUser.Name),
                    new Claim(ClaimTypes.Email, NewUser.Email),
                    new Claim(ClaimTypes.MobilePhone, NewUser.PhoneNumber),
                    new Claim("Password", NewUser.Password)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            MainDbContext db = new MainDbContext();

            var loggedUser = db.Users.FirstOrDefault(u => u.Email == User.Email && u.Password == User.Password);

            if (loggedUser != null)
            {
                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, loggedUser.Email),
                    new Claim("Password", loggedUser.Password)
                }, "AppCookie");

                Request.GetOwinContext().Authentication.SignIn(userIdentity);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");

            return RedirectToAction("Login");
        }
    }
}