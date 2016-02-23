using System.Linq;
using AutoMapper.QueryableExtensions;
using WebGrease.Css.ImageAssemblyAnalysis;

namespace WarehouseSystem.Web.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Ninject;
    using WarehouseSystem.Web.Areas.Private.ViewModels.PartialModels;
    using WarehouseSystem.Web.Controllers;
    using WarehouseSystem.Services.Data.Contract;

    [Authorize]
    public class PartialController : BaseController
    {
        [Inject]
        public IImageServices Images { get; set; }

        [Inject]
        public ICategoryServices Categories { get; set; }

        [Inject]
        public IMessageServices Messages { get; set; }

        [Inject]
        public IPurchaseOrderService Orders { get; set; }

        [Inject]
        public IProductServices Products { get; set; }

        [Inject]
        public IOrganizationServices Organizations { get; set; }

        public ActionResult Header()
        {
            var viewModel = Mapper.Map<UserViewModel>(this.UserProfile);
            return this.PartialView("_HeaderPartial", viewModel);
        }

        public ActionResult SideMenu()
        {
            var user = Mapper.Map<UserViewModel>(this.UserProfile);
            var partners = this.Organizations.GetPartners(this.UserProfile.OrganizationId ?? 0)
                .Project()
                .To<PartnersViewModel>()
                .ToList();

            var categories = this.Categories.GetAll()
                .Project()
                .To<CategoryViewModel>()
                .ToList();

            var model = new SideMenuViewModel
            {
                Partners = partners,
                UserViewModel = user,
                Categories = categories
            };

            return this.PartialView("_SideMenuPartial", model);
        }

        public ActionResult Image(int id)
        {
            var image = this.Images.GetById(id);
            if (image == null)
            {
                throw new HttpException(404, "Image not found");
            }

            return this.File(image.Content, "image/" + image.FileExtension);
        }
    }
}