using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WarehouseSystem.Data.Models;
using WarehouseSystem.Web.Infrastructure.Mapping;

namespace WarehouseSystem.Web.Areas.Private.ViewModels.Products
{
    public class SupplierProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [DisplayName("SKU")]
        public int Sku { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string Barcode { get; set; }

        [DisplayName("Heigth")]
        public double HeigthInCm { get; set; }

        [DisplayName("Width")]
        public double WidthInCm { get; set; }

        [DisplayName("Weight")]
        public int WeightInGr { get; set; }

        [DisplayName("Delivery Unit")]
        public double DeliveryUnit { get; set; }

        [DisplayName("Day of expires")]
        public int MinDayOfExpiryInDays { get; set; }

        [DisplayName("Blocked")]
        public bool IsBlocked { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string Category { get; set; }

        public int? ImageId { get; set; }

        public string Size => $"{this.HeigthInCm} cm. / {this.WidthInCm} cm. - {this.WeightInGr} gr.";

        public HttpPostedFileBase UploadedImage { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, SupplierProductViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name))
                .ReverseMap();
        }
    }
}