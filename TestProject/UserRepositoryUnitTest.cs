using Entities;
using Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TestProject
{
    public class UserRepositoryUnitTest
    {
        [Fact]
        public async Task Login_VaildCredentials_ReturnsUser()
        {
            var user = new User { Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi"};

            var mockContext = new Mock<_326134715ShopContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.Login(user);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Login_InvaildCredentials_ReturnsNull()
        {
            var user = new User { Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };

            var mockContext = new Mock<_326134715ShopContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var userLogin = new User { Email = "test@ggg.com", Password = "456", FirstName = "tamar", LastName = "lavi" };
            var result = await userRepository.Login(userLogin);

            Assert.Null(result);
        }

        [Fact]
        public async Task Register_VaildCredentials_ReturnsUser()
        {
            var user = new User { Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };

            var mockContext = new Mock<_326134715ShopContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.Register(user);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Register_InvaildCredentials_ReturnsNull()
        {
            var user = new User { Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };

            var mockContext = new Mock<_326134715ShopContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var userRegister = new User  { Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };
            var result = await userRepository.Register(userRegister);

            Assert.Null(result);
        }

        [Fact]
        public async Task Update_InvaildCredentials_ReturnsNull()
        {
            var user = new User { UserId = 1 , Email = "test@ttt.com", Password = "123", FirstName = "tamar", LastName = "lavi" };
            var user2 = new User { UserId = 2, Email = "test@ggg.com", Password = "123", FirstName = "tamar", LastName = "lavi" };

            var mockContext = new Mock<_326134715ShopContext>();
            var users = new List<User>() { user, user2 };
            
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var userUpdate = new User { Email = "test@ggg.com", Password = "123", FirstName = "tamar", LastName = "lavi" };
            var result = await userRepository.UpdateUser(user.UserId, userUpdate);

            Assert.Null(result);
        }
    }
}

        

