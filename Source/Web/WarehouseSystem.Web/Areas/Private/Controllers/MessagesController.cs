namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;
    using WarehouseSystem.Web.Controllers;

    [Authorize]
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
            this.TempData["users"] = this.Cache.Get(
                    "user",
                    () => this.Users.GetAll()
                                        .Select(c => new SelectListItem { Value = c.Id, Text = c.Email })
                                        .ToList(),
                    30 * 60);

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
                this.TempData["users"] = this.Cache.Get(
                        "user",
                        () => this.Users.GetAll()
                                            .Select(c => new SelectListItem { Value = c.Id, Text = c.Email })
                                            .ToList(),
                        30 * 60);

                return this.View(model);
            }

            var messagge = new Message()
            {
                Content = model.Content,
                Title = model.Title,
                ToId = model.To,
                FromId = this.UserProfile.Id
            };

            this.Messages.Add(messagge);

            return this.RedirectToAction("Sent");
        }
    }
}
