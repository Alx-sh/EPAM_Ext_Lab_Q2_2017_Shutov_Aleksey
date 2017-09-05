namespace ForumApp.Controllers
{
    using DataAccessLayer;
    using DataAccessLayer.Models;
    using PagedList;
    using Properties;
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
                    ViewBag.Message = Resources.Welcome + user.UserName;
                }
                else
                {
                    ViewBag.ResultTitle = Resources.IncorrectData;
                    ViewBag.Message = !dal.ExistUser(user.UserName) ? Resources.UserNotEx : Resources.IncorrectPass;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.IncorrectData);
                ViewBag.ResultTitle = Resources.IncorrectData;
                ViewBag.Message = Resources.UserNameValid + Resources.PassValid;
            }

            return View("Result");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            ViewBag.Message = Resources.GoodBye + User.Identity.Name;

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
                    ViewBag.ResultTitle = Resources.RegistrationError;
                    ViewBag.Message = Resources.PassConfirmed;

                    return View("Result");
                }

                if (dal.CreateUser(user) > 0)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    ViewBag.Message = Resources.RegistrationComplete;
                }
                else
                {
                    ModelState.AddModelError("", Resources.RegistrationError);
                    user.Password = user.Password_confirmation = string.Empty;
                    ViewBag.ResultTitle = Resources.RegistrationError;
                    ViewBag.Message = Resources.UserEx;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.IncorrectData);
                ViewBag.ResultTitle = Resources.RegistrationError;
                ViewBag.Message = Resources.UserNameValid + Resources.PassValid;
      
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
            ViewBag.Message = dal.EditTypeUser(user.UserID, typeUserID) > 0 ? Resources.ChangeTypeUser : Resources.ChangeTypeUserError;

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