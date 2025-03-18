using Moq;
using NUnit.Framework;
using BusinessLayer.Interface;
using AddressBook.Controllers;
using ModelLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace NUnit.Test
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<IUserBL> _userServiceMock;
        private AuthController _authController;

        [SetUp]
        public void Setup()
        {
            _userServiceMock = new Mock<IUserBL>();
            _authController = new AuthController(_userServiceMock.Object);
        }

        [Test]
        public void Register_ValidUser_ReturnsSuccess()
        {
            var request = new UserRegister { Email = "test@example.com", Password = "Test@123" };
            _userServiceMock.Setup(u => u.RegisterUser(request)).Returns(true);

            var result = _authController.Register(request) as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void Login_ValidCredentials_ReturnsToken()
        {
            var request = new UserLogin { Email = "test@example.com", Password = "Test@123" };
            _userServiceMock.Setup(u => u.LoginUser(request)).Returns("ValidToken");

            var result = _authController.Login(request) as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(200));
            Assert.That(result?.Value, Is.EqualTo("ValidToken"));
        }

        [Test]
        public void ForgotPassword_ValidEmail_ReturnsSuccess()
        {
            _userServiceMock.Setup(u => u.ForgotPassword("test@example.com")).Returns(true);

            var result = _authController.ForgotPassword(new ForgotPassword { Email = "test@example.com" }) as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void ResetPassword_ValidToken_ReturnsSuccess()
        {
            _userServiceMock.Setup(u => u.ResetPassword("ValidToken", "NewPass@123")).Returns(true);

            var result = _authController.ResetPassword(new ResetPassword { Token = "ValidToken", NewPassword = "NewPass@123" }) as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result?.StatusCode, Is.EqualTo(200));
        }
    }
}
