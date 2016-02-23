namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;
    using WarehouseSystem.Web.Controllers;
    using WarehouseSystem.Data.Models;

    public class MessagesController : BaseController
    {
        [Inject]
        public IMessageServices Messages { get; set; }

        public ActionResult Inbox()
        {
            var model = this.Messages.GetReceivedMessage(this.UserProfile.Id)
                .Project()
                .To<MessageViewModel>()
                .ToList();

            return this.View(model);
        }

        public ActionResult Sent()
        {
            var model = this.Messages.GetSentMessage(this.UserProfile.Id)
                .Project()
                .To<MessageViewModel>()
                .ToList();

            return this.View("Inbox", model);
        }

        public ActionResult ById(int id)
        {
            var model = this.Messages.GetById(id);

            return this.Content(model.Content);
        }

        public ActionResult Create()
        {
            return this.View();
        }

        public JsonResult GetEmails()
        {
            var users = this.Users.GetAll()
                .Project()
                .To<UserViewModel>()
                .ToList();

            return this.Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SendMessageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            foreach (var reciever in model.RecieversId)
            {
                var to = this.Users.GetById(reciever);
                if (to != null)
                {
                    var newMessage = new Message()
                    {
                        Content = model.Content,
                        Title = model.Title,
                        FromId = this.UserProfile.Id,
                        ToId = to.Id
                    };

                    this.Messages.Add(newMessage);
                }
            }

            return this.RedirectToAction("Sent");
        }
    }
}