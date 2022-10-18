using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalPhotos.Controllers;
using PersonalPhotos.Models;

namespace PersonalPhotos_Test
{
    public class LoginsTests 
    {
        private readonly LoginsController _loginsController;
        private readonly Mock<ILogins> _logins;
        private readonly Mock<IHttpContextAccessor> _accesor;

        public LoginsTests( )
        {
            _logins = new Mock<ILogins>();
            var session = Mock.Of<ISession>();
            var httpContext = Mock.Of<HttpContext>(x => x.Session == session);

            _accesor = new Mock<IHttpContextAccessor>();
            _accesor.Setup(x => x.HttpContext).Returns(httpContext);
            
            _loginsController = new LoginsController(_logins.Object, _accesor.Object);
        }

        [Fact]
        public void Index_GivenNoReturnUrl_ReturnLoginView()
        {
            var result = _loginsController.Index();
            //Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsType<ViewResult>(result);

            var anotheTypeResult = (_loginsController.Index()) as ViewResult;
            Assert.NotNull(anotheTypeResult);
            Assert.Equal("Login", anotheTypeResult.ViewName, ignoreCase: true);

        }

        [Fact]
        public async Task Login_GivenModelStateInvalid()
        {
            _loginsController.ModelState.AddModelError("Test", "Test");

            //var model = new Mock<LoginViewModel>();
            //var result = _loginsController.Login(model.Object);

            var result = await _loginsController.Login(Mock.Of<LoginViewModel>()) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Login", result.ViewName, ignoreCase: true);
        }

        [Fact]
        public async Task Login_GivenCorrectPassword_RedirectToDisplayAction()
        {
            const string password = "1212";
            var modelView = Mock.Of<LoginViewModel>(x => x.Email == "ricardo@mail.com" && x.Password == password);

            var modelUser = Mock.Of<User>(x => x.Password == password);
            //_logins.Setup(x => x.GetUser(modelView.Email)).ReturnsAsync(modelUser);
            _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(modelUser);

            var result = await _loginsController.Login(modelView);

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Login_GivenIncorrectPassword()
        {
            const string password = "1212";
            var modelView = Mock.Of<LoginViewModel>(x => x.Email == "ricardo@mail.com" && x.Password == "hola");

            var modelUser = Mock.Of<User>(x => x.Password == password);
            _logins.Setup(x => x.GetUser(modelView.Email)).ReturnsAsync(modelUser);

            var result = await _loginsController.Login(modelView) as ViewResult;

            Assert.IsType<ViewResult>(result);
            Assert.Equal("Login", result.ViewName);
        }
    }
}