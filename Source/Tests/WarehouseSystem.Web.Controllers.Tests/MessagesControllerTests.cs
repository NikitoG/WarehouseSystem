using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WarehouseSystem.Web.Controllers.Tests
{
    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;
    using WarehouseSystem.Data.Models;
    using WarehouseSystem.Services.Data.Contract;
    using WarehouseSystem.Web.App_Start;
    using WarehouseSystem.Web.Areas.Private.Controllers;

    [TestFixture]
    public class MessagesControllerTests
    {
        [Test]
        public void ByIdShouldWorkCorrectly()
        {
            var organizationServiceMock = new Mock<IOrganizationServices>();
            organizationServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Organization>() { new Organization { Name = "Organization", Id = 12 } }.AsQueryable());
            var publicMessageServiceMock = new Mock<IPublicMessageServices>();
            publicMessageServiceMock.Setup(x => x.Add(It.IsAny<PublicMessage>()))
                .Returns(new PublicMessage { Content = "Test", Email = "test@site.com", FullName = "Test" });
            var controller = new HomeController();
            var expected = "Index";
            var actual = ((ViewResult)controller.Index()).ViewName;
            Assert.AreEqual(expected, actual);
        }
    }
}
