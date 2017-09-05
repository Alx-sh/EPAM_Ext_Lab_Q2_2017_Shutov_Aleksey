namespace ForumApp.Controllers
{
    using DataAccessLayer;
    using DataAccessLayer.Models;
    using PagedList;
    using System.Configuration;
    using System.Web.Mvc;
    using System.Web.Security;

    public class AccountController : Controller
    {
        DAL dal = new DAL(ConfigurationManager.ConnectionStrings["Conection"].ConnectionString);
 
        [HttpGet]
        public ActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (dal.ValidateUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    ViewBag.Message = "Welcome, " + user.UserName + "!";
                }
                else
                {
                    ViewBag.ResultTitle = "Incorrect data input";
                    ViewBag.Message = !dal.ExistUser(user.UserName) ? "The user doesn't exist" : "Incorrect password!";
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect data input");
                ViewBag.ResultTitle = "Incorrect data input";
                ViewBag.Message = "<p>User Name has to be in the range 4-20.</p>" +
                                  "<p>Password has to be in the range 8-20.</p>";
            }

            return View("Result");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = "Good bye, " + User.Identity.Name + ".";
            return View("Result");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                if (!user.Password.Equals(user.Password_confirmation))
                {
                    ViewBag.ResultTitle = "Registration error";
                    ViewBag.Message = "Passwords don't coincide!";
                    return View("Result");
                }

                if (dal.CreateUser(user) > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    ViewBag.Message = "Registration is successfully complete!";
                }
                else
                {
                    ModelState.AddModelError("", "Registration error");
                    user.Password = user.Password_confirmation = string.Empty;
                    ViewBag.ResultTitle = "Registration error";
                    ViewBag.Message = "The user exists!";
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect data input!");
                ViewBag.ResultTitle = "Registration error";
                ViewBag.Message = "<p>User Name has to be in the range 4-20.</p>" +
                                  "<p>Password has to be in the range 8-20.</p>";
      
            }

            return View("Result");
        }

        [HttpGet]
        public ActionResult Information(string userName)
        {
            UserInformationViewModel ui = new UserInformationViewModel();
            ui.typeUsers = dal.ShowTypeUsers();
            ui.user = dal.ShowUserInfo(userName);
            return View(ui);
        }

        [HttpPost]
        public ActionResult Information(User user)
        {
            int typeUserID = dal.SelectTypeUserID(user.TypeUser);
            ViewBag.Message = dal.EditTypeUser(user.UserID, typeUserID) > 0 ? "Type user changed!" : "Error change type user!";
            return View("Result");
        }

        public ActionResult ViewMessages(int userID, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(dal.ShowMessagesByOneUser(userID).ToPagedList(pageNumber, pageSize));
        }
    }
}