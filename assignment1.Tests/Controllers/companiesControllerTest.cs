using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment1.Controllers;
using System.Web.Mvc;
using assignment1.Models;
using Moq;
using System.Linq;

namespace assignment1.Tests.Controllers
{

    [TestClass]
    public class companiesControllerTest
    {
        companiesController controller;
        List<company> company;
        Mock<IMockCompaniesRepository> mock;

        //set up mock data for all unit tests
        [TestInitialize]
        public void TestInitialize()
        {
            // instanciate new mock
            mock = new Mock<IMockCompaniesRepository>();

            //mock company data
            company = new List<company>
            {
                new company {companyID = 1 },
                new company {companyID = 2 },
                new company {companyID = 3 }
            };

            //populate mock with mock data
            mock.Setup(c => c.companies).Returns(company.AsQueryable());

            //insert mock dependency when calling the controller's contructor
            controller = new companiesController(mock.Object);

        }
        
       [TestMethod]
       public void IndexViewLoads()
        {
            //arrange 
            // companiesController controller = new companiesController();
            //act
            ViewResult result = controller.Index() as ViewResult; 
            //assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void IndexLoadsCompanies()
        //{
        //    // act - cast ActionResult returntype to ViewResult to access the model
        //    var actual = (List<company)((ViewResult)controller.Index()).Model;

        //    // assert
        //    CollectionAssert.AreEqual(company, actual);
        //}

        [TestMethod]
        public void DetailsValidId()
        {
            // act
            var actual = ((ViewResult)controller.Details(1)).Model;

            // assert
            Assert.AreEqual(company[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            var actual = (ViewResult)controller.Details(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNoId()
        {
            // act
            var actual = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // GET: Edit
        [TestMethod]
        public void EditGetValidId()
        {
            // act
            var actual = ((ViewResult)controller.Edit(1)).Model;

            // assert
            Assert.AreEqual(company[0], actual);
        }

        [TestMethod]
        public void EditGetInvalidId()
        {
            // act
            var actual = (ViewResult)controller.Edit(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditGetNoId()
        {
            // assert - must pass an int so the overload calls GET not POST
            int? id = null;

            // act
            var actual = (ViewResult)controller.Edit(id);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Edit
        [TestMethod]
        public void EditPostValid()
        {
            // act - pass in the first mock order object
            var actual = (RedirectToRouteResult)controller.Edit(company[0]);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostInvalid()
        {
            // arrange - manually set the model state to invalid
            controller.ModelState.AddModelError("key", "unit test error");

            // act - pass in the first mock order object
            var actual = (ViewResult)controller.Edit(company[0]);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);
        }

        // GET: Create
        [TestMethod]
        public void CreateViewLoads()
        {
            // act
            var actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }


        // POST: Create
        [TestMethod]
        public void CreatePostValid()
        {
            // arrange
            company c = new company
            {
                CEO = "CEO name",
                Name = "Camera Comany"
            };

            // act
            var actual = (RedirectToRouteResult)controller.Create(c);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostInvalid()
        {
            // arrange
            company c = new company
            {
                CEO = "CEO name",
                Name = "Camera Comanpy"
            };

            controller.ModelState.AddModelError("key", "cannot add order");

            // act
            var actual = (ViewResult)controller.Create(c);

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        // GET: Delete
        [TestMethod]
        public void DeleteValidId()
        {
            // act
            var actual = ((ViewResult)controller.Delete(1)).Model;

            // assert
            Assert.AreEqual(company[0], actual);
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            // act
            var actual = (ViewResult)controller.Delete(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteNoId()
        {
            // act
            var actual = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Delete
        [TestMethod]
        public void DeletePostValid()
        {
            // act
            var actual = (RedirectToRouteResult)controller.DeleteConfirmed(34);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
    }
}

