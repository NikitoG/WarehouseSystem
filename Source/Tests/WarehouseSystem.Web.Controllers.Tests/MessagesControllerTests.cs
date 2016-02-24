namespace MvcTemplate.Web.Controllers.Tests
{
    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.App_Start;
    using WarehouseSystem.Web.Areas.Private.Controllers;
    using WarehouseSystem.Web.Areas.Private.ViewModels.Messages;

    [TestFixture]
    public class MessagesControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {

            AutoMapperConfig.Execute();
            const string MessageContent = "SomeContent";
            const string MessageTitle = "SomeTitle";
            var messagesServiceMock = new Mock<IMessageServices>();
            messagesServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Message { Content = MessageContent, Title = MessageTitle, ToId = "user1", FromId = "user2"});
            var controller = new MessagesController();
            controller.WithCallTo(x => x.ById(444))
                .ShouldReturnContent();
        }
    }
}
