namespace ForumApp.Controllers
{
    using DataAccessLayer;
    using DataAccessLayer.Models;
    using PagedList;
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
                ViewBag.Message = "You have been banned! The entrance isn't executed.";
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
                    ViewBag.Message = "Topic created!";
                }
                else
                {
                    ViewBag.ResultTitle = "Topic error";
                    ViewBag.Message = "Topic with such name already exists.";
                }
            }
            else
            {
                ModelState.AddModelError("", "Topic error");
                ViewBag.ResultTitle = "Topic error";
                ViewBag.Message = "<p>Topic name has to be in the range 4-20.</p>" +
                                   "<p>Text message has to be in the range 1-4000.</p>";
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
                    ViewBag.Message = "Topic edited!";
                }
                else
                {
                    ViewBag.ResultTitle = "Topic error";
                    ViewBag.Message = "The topic with such name already exists.";
                }
            }
            else
            {
                ModelState.AddModelError("", "Topic error");
                ViewBag.ResultTitle = "Topic error";
                ViewBag.Message = "The topic name has to be in the range 4-20.";
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
                    ViewBag.Message = "Message added!";
                    return View("Result");
                }
            }

            ModelState.AddModelError("", "Message error");
            ViewBag.ResultTitle = "Message error";
            ViewBag.Message = "Text message has to be in the range 1-4000.";

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
                    ViewBag.Message = "Message edited!";
                }
            }
            else
            {
                ModelState.AddModelError("", "Message error");
                ViewBag.ResultTitle = "Message error";
                ViewBag.Message = "Text message has to be in the range 1-4000.";
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
                    ViewBag.Message = "Message deleted!";
                }
            }
            else
            {
                ModelState.AddModelError("", "Message error");
                ViewBag.ResultTitle = "Message error";
                ViewBag.Message = "Error delete message!";
            }

            return View("Result");
        }
    }
}