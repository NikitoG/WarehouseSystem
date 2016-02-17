

using System.Web;
using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
using WarehouseSystem.Web.Controllers;

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using AutoMapper.QueryableExtensions;
    using Ninject;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.ViewModels.Home;

    public class PartialController : BaseController
    {
        [Inject]
        public IImageServices Images { get; set; }

        public ActionResult Header()
        {
            var viewModel = Mapper.Map<UserViewModel>(this.UserProfile);
            return this.PartialView("_HeaderPartial", viewModel);
        }

        public ActionResult Image(int id)
        {
            var image = this.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return File(image.Content, "image/" + image.FileExtension);
        }
    }
}