namespace ForumApp.Controllers
{
    using DataAccessLayer;
    using DataAccessLayer.Models;
    using PagedList;
    using Properties;
    using System.Configuration;
    using System.Web.Mvc;
    using System.Web.Security;

    public class HomeController : Controller
    {
        DAL dal = new DAL(ConfigurationManager.ConnectionStrings["Conection"].ConnectionString);

        public ActionResult Index(int? page)
        {
            if (User.IsInRole("Banned"))
            {
                ViewBag.Message = Resources.MessageForBanned;
                FormsAuthentication.SignOut();

                return View("Result");
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(dal.ShowTopics().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ViewTopic(int topicID, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(dal.ShowMessages(topicID).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult ShowUsers()
        {
            return View(dal.ShowUsers());
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateTopic()
        {
            return PartialView();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTopic(Topic topic)
        {
            if (ModelState.IsValid && !topic.TopicMessage.Equals(string.Empty))
            {
                topic.mes.MessageAuthor = User.Identity.Name;

                if (dal.CreateTopic(topic) > 0)
                {
                    ViewBag.Message = Resources.CreateTopic;
                }
                else
                {
                    ViewBag.ResultTitle = Resources.ErrorTopic;
                    ViewBag.Message = Resources.ErrorTopicName;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.ErrorTopic);
                ViewBag.ResultTitle = Resources.ErrorTopic;
                ViewBag.Message = Resources.TopicNameValid + Resources.TextMessageValid;
            }

            return View("Result");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditTopic(int topicID)
        {
            Topic topic = new Topic();
            topic.TopicID = topicID;
            topic.TopicName = dal.SelectTopicName(topicID);

            return View(topic);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditTopic(Topic topic)
        {
            if (ModelState.IsValid)
            {
                if (dal.EditTopic(topic) > 0)
                {
                    ViewBag.Message = Resources.EditTopic;
                }
                else
                {
                    ViewBag.ResultTitle = Resources.ErrorTopic;
                    ViewBag.Message = Resources.ErrorTopicName;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.ErrorTopic);
                ViewBag.ResultTitle = Resources.ErrorTopic;
                ViewBag.Message = Resources.TopicNameValid;
            }

            return View("Result");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMessage(int topicID, string text)
        {
            if (ModelState.IsValid && !text.Equals(string.Empty))
            {
                Message mes = new Message();
                mes.MessageAuthor = User.Identity.Name;
                mes.TextMessage = text;
                mes.TopicID = topicID;

                if (dal.CreateMessage(mes) > 0)
                {
                    ViewBag.Message = Resources.AddMessage;

                    return View("Result");
                }
            }

            ModelState.AddModelError("", Resources.ErrorMessage);
            ViewBag.ResultTitle = Resources.ErrorMessage;
            ViewBag.Message = Resources.TextMessageValid;

            return View("Result");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EditMessage(int messageID)
        {
            Message mes = new Message();
            mes.MessageID = messageID;
            mes.TextMessage = dal.SelectTextMessage(messageID);

            return View(mes);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditMessage(Message mes)
        {
            if (ModelState.IsValid)
            {
                if (dal.EditMessage(mes) > 0)
                {
                    ViewBag.Message = Resources.EditMessage;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.ErrorMessage);
                ViewBag.ResultTitle = Resources.ErrorMessage;
                ViewBag.Message = Resources.TextMessageValid;
            }

            return View("Result");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DeleteMessage(Message mes)
        {
            mes.TextMessage = dal.SelectTextMessage(mes.MessageID);

            return View(mes);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteMessage(int messageID)
        {
            if (ModelState.IsValid)
            {
                if (dal.DeleteMessage(messageID) > 0)
                {
                    ViewBag.Message = Resources.DeleteMessage;
                }
            }
            else
            {
                ModelState.AddModelError("", Resources.ErrorMessage);
                ViewBag.ResultTitle = Resources.ErrorMessage;
                ViewBag.Message = Resources.DeleteMessageError;
            }

            return View("Result");
        }
    }
}