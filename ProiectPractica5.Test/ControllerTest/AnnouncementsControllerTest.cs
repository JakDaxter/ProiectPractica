
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProiectPractica5.Controllers;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace ProiectPractica5.Test.ControllerTest
{
    public class AnnouncementsControllerTest
    {
        AnnouncementsController _controller;
        Mock<ILogger<AnnouncementsController>> _logger = new Mock<ILogger<AnnouncementsController>>();
        Mock<IAnnouncementsServices> _services = new Mock<IAnnouncementsServices>();

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }


        #region GetUnitTests
        [Fact]
        public void GetTest_WhenNoDataAreReturned()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);

            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<StatusCodeResult>(result);
        }

        [Fact]
        public void GetTest_WhenDataAreReturned()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            var announcements2 = new Announcements { Title = "Test2", Text = "Text2" };
            List<Announcements> listSource = new List<Announcements>();
            listSource.Add(announcements);
            listSource.Add(announcements2);
            var dbSet = GetQueryableMockDbSet(listSource);

            //Act
            var CodeSnippets = _services.Setup(m => m.Get()).Returns(dbSet);
            var result = _controller.Get();

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Announcements>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region PostUnitTest

        [Fact]
        public void PostTest_WhenNoData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);

            //Act
            var result = _controller.Post(null);

            //Assert
            var resultStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(resultStatusCode.StatusCode, (int)HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void PostTest_WhenSendData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            var announcements2 = new Announcements { Title = "Test2", Text = "Text2" };
            var codeSnippedAdded = _services.Setup(m => m.Post(announcements));
            //Act
            var result = _controller.Post(announcements);

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.CreateAnnouncementsMessage, objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region PutUnitTest

        [Fact]
        public void PutTest_WhenNoData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            _controller.Post(announcements);

            //Act
            var result = _controller.Put(null);

            //Assert
            var resultStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(resultStatusCode.StatusCode, (int)HttpStatusCode.NotFound);
        }

        [Fact]
        public void PutTest_WhenSendData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            _controller.Post(announcements);
            announcements.Title = "TestModify";
            var codeSnippedAdded = _services.Setup(m => m.Post(announcements));

            //Act
            var result = _controller.Put(announcements);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.UpdateAnnouncementsMessage, objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Accepted);
        }

        #endregion

        #region DeleteUnitTest

        [Fact]
        public void DeleteTest_WhenNoData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            _controller.Post(announcements);

            //Act
            var result = _controller.Delete(null);

            //Assert
            var resultStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(resultStatusCode.StatusCode, (int)HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void DeleteTest_WhenSendData()
        {
            //Arrange
            _controller = new AnnouncementsController(_logger.Object, _services.Object);
            var announcements = new Announcements { Title = "Test", Text = "Text" };
            _controller.Post(announcements);
            _services.Setup(m => m.Post(announcements));
            var codeSnippedAdded = _services.Setup(m => m.Delete(announcements));

            //Act
            var result = _controller.Delete(announcements);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.DeleteAnnouncementsMessage, objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.OK);
        }

        #endregion
    }
}
