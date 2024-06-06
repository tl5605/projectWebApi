using Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace Tests
{
    public class UserRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly _326134715ShopContext _dbcontext;
        private readonly UserRepository _userRepository;

        public UserRepositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbcontext = databaseFixture.Context;
            _userRepository = new UserRepository(_dbcontext);
        }

        [Fact]

        public async Task Login_ValidCredentials_ReturnUser()
        {
            var email = "test@gmail.com";
            var password = "password";
            var userToCreateInDB = new User { Email = email, Password = password, FirstName = "test firstName", LastName = "test lastName" };
            await _dbcontext.Users.AddAsync(userToCreateInDB);
            await _dbcontext.SaveChangesAsync();


            var userToLoginWith = new User { Email = email, Password = password };

            var result = await _userRepository.Login(userToLoginWith);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnUser()
        {
            var email = "test@ggg.com";
            var password = "123";
            var userToCreateInDB = new User { Email = email, Password = password, FirstName = "tamar", LastName = "lavi" };
            await _dbcontext.Users.AddAsync(userToCreateInDB);
            await _dbcontext.SaveChangesAsync();


            var userLogin = new User { Email = "test@ggg.com", Password = "456", FirstName = "tamar", LastName = "lavi" };
            var result = await _userRepository.Login(userLogin);

            Assert.Null(result);
        }

        [Fact]

        public async Task Register_ValidCredentials_ReturnUser()
        {
            var email = "test@gmail.com";
            var password = "password";
            var userToCreateInDB = new User { Email = email, Password = password, FirstName = "test firstName", LastName = "test lastName" };
            //await _dbcontext.Users.AddAsync(userToCreateInDB);
           // await _dbcontext.SaveChangesAsync();

            var result = await _userRepository.Register(userToCreateInDB);

            Assert.NotNull(result);
        }


    }
}
