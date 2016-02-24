namespace WarehouseSystem.Web.Routes.Tests
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Moq;
    using MvcRouteTester;
    using NUnit.Framework;
    using WarehouseSystem.Web.Areas.Private;
    using WarehouseSystem.Web.Areas.Private.Controllers;

    [TestFixture]
    public class WarehouseSystemRouteTests
    {
        [Test]
        public void TestRouteMessagesById()
        {
            const string Url = "/message/222";
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new UserAreaRegistration();
            Assert.AreEqual("Private", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Private");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            routes.ShouldMap(Url).To<MessagesController>(c => c.ById(222));
        }

        [Test]
        public void TestRouteOrdersByPartners()
        {
            const string Url = "/orders/222";
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new UserAreaRegistration();
            Assert.AreEqual("Private", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Private");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            routes.ShouldMap(Url).To<OrdersController>(c => c.ByPartner(222));
        }

        [Test]
        public void TestRouteSuppliersGetById()
        {
            const string Url = "/suppliers/222";
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new UserAreaRegistration();
            Assert.AreEqual("Private", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Private");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            routes.ShouldMap(Url).To<SuppliersController>(c => c.GetById(222));
        }

        [Test]
        public void TestRouteSuppliersGetPartners()
        {
            const string Url = "/byCategories/222";
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new UserAreaRegistration();
            Assert.AreEqual("Private", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Private");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            routes.ShouldMap(Url).To<SuppliersController>(c => c.GetPartners(222));
        }

        [Test]
        public void TestRouteProductsUpdates()
        {
            const string Url = "/product/222";
            var routes = new RouteCollection();

            // Get my AreaRegistration class
            var areaRegistration = new UserAreaRegistration();
            Assert.AreEqual("Private", areaRegistration.AreaName);

            // Get an AreaRegistrationContext for my class. Give it an empty RouteCollection
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
            areaRegistration.RegisterArea(areaRegistrationContext);

            // Mock up an HttpContext object with my test path (using Moq)
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Private");

            // Get the RouteData based on the HttpContext
            var routeData = routes.GetRouteData(context.Object);

            routes.ShouldMap(Url).To<ProductsController>(c => c.Update(222));
        }
    }
}
