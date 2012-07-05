using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plan1.Controllers;
using Plan1.Models;
using TestPlan1.Models;


namespace TestPlan1.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        Permission GetPermission()
        {
            return GetPermission(1);
        }

        Permission GetPermission(int id)
        {
            return new Permission
            {
                Id = id               
            };
        }
        [TestMethod]
            // Verifies that the Index method returns a view named Index
        public void T1_Index_Get_AsksForIndexView()
        {
            // Arrange
            var controller = GetHomeController(new InMemoryPermissionRepository());
            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
            // Adds the first two Permission records to the mock repository and then verifies 
            // that they are in the ViewData Model object in Index view
        public void T2_Index_Get_RetrievesAllPermissionsFromRepository()
        {          
            // Arrange
            Permission Permission1 = GetPermission(1);
            Permission Permission2 = GetPermission(2);
            InMemoryPermissionRepository repository = new InMemoryPermissionRepository();
            repository.Add(Permission1);
            repository.Add(Permission2);
            var controller = GetHomeController(repository);

            // Act
            var result = controller.Index();

            // Assert
            var model = (IEnumerable<Permission>)result.ViewData.Model;
            CollectionAssert.Contains(model.ToList(), Permission1);
            CollectionAssert.Contains(model.ToList(), Permission2);
        }

        [TestMethod]
        public void T3_Create_Post_ReturnsRedirectOnSuccess()
        {
            // Arrange
            HomeController controller = GetHomeController(new InMemoryPermissionRepository());
            Permission model = GetPermission(1);

            // Act
            var result = (RedirectToRouteResult)controller.Create(model);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
            // Test for creating a Permission
        public void T4_Create_Post_ReturnsViewIfModelStateIsNotValid()
        {
            // Arrange
            HomeController controller = GetHomeController(new InMemoryPermissionRepository());
            // Executing a method during a unit test does only that - no more. 
            controller.ModelState.AddModelError("", "mock error message");
            Permission model = GetPermission(1);

            // Act
            var result = (ViewResult)controller.Create(model);            

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
            // Verify that an HTTP POST to the Create method adds a valid Permission  to the repository
        public void T5_Create_Post_PutsValidPermissionIntoRepository()
        {
            // Arrange
            InMemoryPermissionRepository repository = new InMemoryPermissionRepository();
            HomeController controller = GetHomeController(repository);
            Permission Permission = GetPermission(1);

            // Act
            controller.Create(Permission);

            // Assert
            IEnumerable<Permission> Permissions = repository.GetAllPermissions();
            Assert.IsTrue(Permissions.Contains(Permission));
        }

        [TestMethod]
            // Verify that methods correctly handle exceptions
        public void T6_Create_Post_ReturnsViewIfRepositoryThrowsException()
        {
            // Arrange
            InMemoryPermissionRepository repository = new InMemoryPermissionRepository();
            Exception exception = new Exception();
            repository.ExceptionToThrow = exception;
            HomeController controller = GetHomeController(repository);
            Permission model = GetPermission(1);

            // Act
            var result = (ViewResult)controller.Create(model);

            // Assert
            Assert.AreEqual("Create", result.ViewName);
            ModelState modelState = result.ViewData.ModelState[""];
            Assert.IsNotNull(modelState);
            Assert.IsTrue(modelState.Errors.Any());
            Assert.AreEqual(exception, modelState.Errors[0].Exception);
        }


        private static HomeController GetHomeController(IPermissionRepository repository)
        {
            HomeController controller = new HomeController(repository);

            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }


        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(
                     new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }
    }

}