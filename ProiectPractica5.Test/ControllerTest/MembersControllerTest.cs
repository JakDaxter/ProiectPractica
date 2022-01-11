
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProiectPractica5.App_Data;
using ProiectPractica5.Controllers;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace ProiectPractica5.Test.ControllerTest
{
    public class MembersControllerTest
    {
        MembersController _controller;
        Mock<ILogger<MembersController>> _logger = new Mock<ILogger<MembersController>>();
        Mock<IMembersServices> _services = new Mock<IMembersServices>();

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
            _controller = new MembersController(_logger.Object, _services.Object);

            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<StatusCodeResult>(result);
        }

        [Fact]
        public void GetTest_WhenDataAreReturned()
        {
            //Arrange
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            var members2 = new Members { Name = "Name2", Title = "Title2" };
            List<Members> listSource = new List<Members>();
            listSource.Add(members);
            listSource.Add(members2);
            var dbSet = GetQueryableMockDbSet(listSource);

            //Act
            var CodeSnippets = _services.Setup(m => m.Get()).Returns(dbSet);
            var result = _controller.Get();

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Members>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region PostUnitTest

        [Fact]
        public void PostTest_WhenNoData()
        {
            //Arrange
            _controller = new MembersController(_logger.Object, _services.Object);

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
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            var members2 = new Members { Name = "Name2", Title = "Title2" };
            var codeSnippedAdded = _services.Setup(m => m.Post(members));
            //Act
            var result = _controller.Post(members);

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Member was added in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region PutUnitTest

        [Fact]
        public void PutTest_WhenNoData()
        {
            //Arrange
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            var codeSnippedAdded = _services.Setup(m => m.Post(members));

            //Act
            var result = _controller.Put(null);

            //Assert
            var resultStatusCode = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(resultStatusCode.StatusCode, (int)HttpStatusCode.InternalServerError);
        }

        [Fact]
        public void PutTest_WhenSendData()
        {
            //Arrange
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            var codeSnippedAdded = _services.Setup(m => m.Post(members));
            members.Title = "TestModify";
            var MembersAdded = _services.Setup(m => m.Post(members));

            //Act
            var result = _controller.Put(members);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Member was modify in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region DeleteUnitTest

        [Fact]
        public void DeleteTest_WhenNoData()
        {
            //Arrange
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            _controller.Post(members);

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
            _controller = new MembersController(_logger.Object, _services.Object);
            var members = new Members { Name = "Name", Title = "Title" };
            _controller.Post(members);
            _services.Setup(m => m.Post(members));
            var membersAdded = _services.Setup(m => m.Delete(members));

            //Act
            var result = _controller.Delete(members);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Member was delete in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion
    }
}
