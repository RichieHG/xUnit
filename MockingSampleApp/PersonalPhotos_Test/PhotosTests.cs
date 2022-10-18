using Core.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalPhotos.Controllers;
using PersonalPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPhotos_Test
{
    public class PhotosTests
    {
        private readonly Mock<IFileStorage> _fileStorage;
        private readonly Mock<IKeyGenerator> _keyGenerator;
        private readonly Mock<IPhotoMetaData> _photoMetaData;

        public PhotosTests()
        {
            _fileStorage = new Mock<IFileStorage>();
            _keyGenerator = new Mock<IKeyGenerator>();
            _photoMetaData = new Mock<IPhotoMetaData>();
        }

        [Fact]
        public async Task Upload_GivenFileName_ReturnsDisplayAction()
        {
            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("User", "qaqwq");


            // Arrange
            // We put session and accesor inside Method to isolate other Tests and
            // not mix them.
            var session = new Mock<ISession>();
            byte[]? a = Encoding.UTF8.GetBytes("ricardo@mail.com");
            session.Setup(x => x.TryGetValue("User",out a));
            
            var httpContext = Mock.Of<HttpContext>(x => x.Session == session.Object);

            var _accesor = Mock.Of<IHttpContextAccessor>(x => x.HttpContext == httpContext);
            
            var _photosController = new PhotosController(_keyGenerator.Object, _accesor, _photoMetaData.Object, _fileStorage.Object);
            var formFile = Mock.Of<IFormFile>();
            var model = Mock.Of<PhotoUploadViewModel>(x => x.Description == "Test Description" && x.File == formFile);

            //Act

            var result = await _photosController.Upload(model) as RedirectToActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Display", result.ActionName, ignoreCase: true);
        }

        [Fact]
        public void Display_WithSession()
        {
            // Arrange
            // We put session and accesor inside Method to isolate other Tests and
            // not mix them.
            var session = new Mock<ISession>();
            byte[]? a = Encoding.UTF8.GetBytes("ricardo@mail.com");
            session.Setup(x => x.TryGetValue("User", out a));

            var httpContext = Mock.Of<HttpContext>(x => x.Session == session.Object);

            var _accesor = new Mock<IHttpContextAccessor>();
            _accesor.Setup(x => x.HttpContext).Returns(httpContext);

            var _photosController = new PhotosController(_keyGenerator.Object, _accesor.Object, _photoMetaData.Object, _fileStorage.Object);

            var result = _photosController.Display() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Display", result.ViewName, ignoreCase: true);

        }

        [Fact]
        public void Display_WithoutSession()
        {
            // Arrange
            // We put session and accesor inside Method to isolate other Tests and
            // not mix them.
            var session = Mock.Of<ISession>();
            var httpContext = Mock.Of<HttpContext>(x => x.Session == session);

            var _accesor = new Mock<IHttpContextAccessor>();
            _accesor.Setup(x => x.HttpContext).Returns(httpContext);

            var _photosController = new PhotosController(_keyGenerator.Object, _accesor.Object, _photoMetaData.Object, _fileStorage.Object);

            var result = _photosController.Display() as ViewResult;

            Assert.NotNull(result);
            Assert.Equal("Display", result.ViewName, ignoreCase: true);

        }
    }
}
