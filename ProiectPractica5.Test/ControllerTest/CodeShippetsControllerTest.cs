
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProiectPractica5.App_Data;
using ProiectPractica5.Controllers;
using ProiectPractica5.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProiectPractica5.Test.ControllerTest
{
    public class CodeShippetsControllerTest
    {
        CodeSnippetsControllers _controller;
        Mock<ILogger<CodeSnippetsControllers>> _logger;
        Mock<CodeSnippetsServices> _services;

        [Fact]
        public void GetTest_WhenContextIsNull()
        {
            /*
            //Arrage
            ILogger<CodeSnippetsControllers> _loggerTest = null;
            CodeSnippetsServices> _servicesTest;
            _controller = new CodeSnippetsControllers(_loggerTest, _services);
            //Act
            var result = _controller.Get();
            //Assert        
            Assert.IsType<ObjectResult>(result);
            */
        }
        [Fact]
        public void GetTest_WhenWehaveData()
        {
            //Arrage
            
        }
    }
}
