namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Profile;
    using WarehouseSystem.Web.Controllers;

    [Authorize]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var currentUser = Mapper.Map<ProfileViewModel>(this.UserProfile); ;

            return View(currentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }


            this.UpdateUserSettings(this.UserProfile, model);
            if (model.UploadedImage != null)
            {
                using (var memory = new MemoryStream())
                {
                    model.UploadedImage.InputStream.CopyTo(memory);
                    var content = memory.GetBuffer();

                    this.UserProfile.Image = new Image
                    {
                        Content = content,
                        FileExtension = model.UploadedImage.FileName.Split(new[] { '.' }).Last(),
                        CreatedOn = DateTime.Now
                    };
                }
            }

            this.Users.Update();
            return this.RedirectToAction("Index", "Organization", new {area = "Private"});
        }

        private void UpdateUserSettings(User model, ProfileViewModel viewModel)
        {
            model.UserName = viewModel.Email;
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            model.Email = viewModel.Email;
            model.Position = viewModel.Position;
        }
    }
}