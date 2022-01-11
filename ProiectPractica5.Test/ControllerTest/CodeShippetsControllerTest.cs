
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
    public class CodeShippetsControllerTest
    {
        CodeSnippetsController _controller;
        Mock<ILogger<CodeSnippetsController>> _logger = new Mock<ILogger<CodeSnippetsController>>();
        Mock<ICodeSnippetsServices> _services = new Mock< ICodeSnippetsServices >();

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
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);

            //Act
            var result = _controller.Get();
            //Assert
            Assert.IsType<StatusCodeResult>(result);
        }
        
        [Fact]
        public void GetTest_WhenDataAreReturned()
        {
            //Arrange
            _controller= new CodeSnippetsController(_logger.Object, _services.Object);
            var CodeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            var CodeSnippet2 = new CodeSnippets { Title = "Test2", ContentCode = "test2" };
            List<CodeSnippets> listSource = new List<CodeSnippets>();
            listSource.Add(CodeSnippet);
            listSource.Add(CodeSnippet2);
            var dbSet = GetQueryableMockDbSet(listSource);

            //Act
            var CodeSnippets = _services.Setup(m=>m.Get()).Returns(dbSet);
            var result = _controller.Get();
            
            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CodeSnippets>>(objectResult.Value);
            Assert.Equal(2, model.Count());
        }
        #endregion

        #region PostUnitTest

        [Fact]
        public void PostTest_WhenNoData()
        {
            //Arrange
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);

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
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);
            var codeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            var codeSnippet2 = new CodeSnippets { Title = "Test2", ContentCode = "test2" };
            var codeSnippedAdded = _services.Setup(m => m.Post(codeSnippet));
            //Act
            var result = _controller.Post(codeSnippet);

            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.CreateCodeSnippetMessage,objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Created);
        }

        #endregion

        #region PutUnitTest

        [Fact]
        public void PutTest_WhenNoData()
        {
            //Arrange
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);
            var codeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            _controller.Post(codeSnippet);

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
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);
            var codeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            _controller.Post(codeSnippet);
            codeSnippet.Title = "TestModify";
            var codeSnippedAdded = _services.Setup(m => m.Post(codeSnippet));

            //Act
            var result = _controller.Put(codeSnippet);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.UpdateCodeSnippetMessage, objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.Accepted);
        }

        #endregion

        #region DeleteUnitTest

        [Fact]
        public void DeleteTest_WhenNoData()
        {
            //Arrange
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);
            var codeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            _controller.Post(codeSnippet);

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
            _controller = new CodeSnippetsController(_logger.Object, _services.Object);
            var codeSnippet = new CodeSnippets { Title = "Test", ContentCode = "test" };
            var codeSnippedDeleted = _services.Setup(m => m.Delete(codeSnippet));

            //Act
            var result = _controller.Delete(codeSnippet);


            //Assert
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(Constants.DeleteCodeSnippetMessage, objectResult.Value);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.OK);
        }

        #endregion
    }
}
