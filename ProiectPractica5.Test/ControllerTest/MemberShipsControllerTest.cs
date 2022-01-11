
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
    public class MemberShipsControllerTest
    {
        MemberShipsController _controller;
        Mock<ILogger<MemberShipsController>> _logger = new Mock<ILogger<MemberShipsController>>();
        Mock<IMemberShipsServices> _services = new Mock<IMemberShipsServices>();

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
            _controller = new MemberShipsController(_logger.Object, _services.Object);

            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<StatusCodeResult>(result);
        }

        [Fact]
        public void GetTest_WhenDataAreReturned()
        {
            //Arrange
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl= 10, StartData= System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            var memberShips2 = new MemberShips { Lvl = 8, StartData = System.DateTime.Parse("2/14/2008 13:15:12 PM") };
            List<MemberShips> listSource = new List<MemberShips>();
            listSource.Add(memberShips);
            listSource.Add(memberShips2);
            var dbSet = GetQueryableMockDbSet(listSource);

            //Act
            var CodeSnippets = _services.Setup(m => m.Get()).Returns(dbSet);
            var result = _controller.Get();

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MemberShips>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region PostUnitTest

        [Fact]
        public void PostTest_WhenNoData()
        {
            //Arrange
            _controller = new MemberShipsController(_logger.Object, _services.Object);

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
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl = 10, StartData = System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            var memberShips2 = new MemberShips { Lvl = 8, StartData = System.DateTime.Parse("2/14/2008 13:15:12 PM") };
            var memberShipTypesAdded = _services.Setup(m => m.Post(memberShips));
            //Act
            var result = _controller.Post(memberShips);

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("MemberShip was added in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region PutUnitTest

        [Fact]
        public void PutTest_WhenNoData()
        {
            //Arrange
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl = 10, StartData = System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            var codeSnippedAdded = _services.Setup(m => m.Post(memberShips));

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
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl = 10, StartData = System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            var codeSnippedAdded = _services.Setup(m => m.Post(memberShips));
            memberShips.Lvl = 11;
            var MembersAdded = _services.Setup(m => m.Post(memberShips));

            //Act
            var result = _controller.Put(memberShips);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("MemberShip was modify in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region DeleteUnitTest

        [Fact]
        public void DeleteTest_WhenNoData()
        {
            //Arrange
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl = 10, StartData = System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            _controller.Post(memberShips);

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
            _controller = new MemberShipsController(_logger.Object, _services.Object);
            var memberShips = new MemberShips { Lvl = 10, StartData = System.DateTime.Parse("2/16/2008 12:15:12 PM") };
            _controller.Post(memberShips);
            _services.Setup(m => m.Post(memberShips));
            var membersAdded = _services.Setup(m => m.Delete(memberShips));

            //Act
            var result = _controller.Delete(memberShips);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("MemberShip was delete in database", objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion
    }
}
