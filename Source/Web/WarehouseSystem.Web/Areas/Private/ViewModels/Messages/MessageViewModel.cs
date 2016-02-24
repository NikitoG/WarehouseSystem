namespace WarehouseSystem.Web.Areas.Private.ViewModels.Messages
{
    using System;
    using AutoMapper;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Web.Infrastructure.Mapping;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int? FromImgId { get; set; }

        public int? ToImgId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ForMember(m => m.From, opt => opt.MapFrom(t => t.From.Email))
                .ForMember(m => m.To, opt => opt.MapFrom(t => t.To.Email))
                .ForMember(m => m.FromImgId, opt => opt.MapFrom(t => t.From.ImageId))
                .ForMember(m => m.ToImgId, opt => opt.MapFrom(t => t.To.ImageId));
        }
    }
}
