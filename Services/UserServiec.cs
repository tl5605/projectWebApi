using Entities;
using Repositories;
using System.Text.Json;
using Zxcvbn;

namespace Services
{
    public class UserServiec : IUserServiec
    {
        private IUserRepository _userRepository;

        public UserServiec(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> Login(User user)
        {
            return await _userRepository.Login(user);
        }

        public int StrongPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);

            return result.Score;

        }
        public async Task<User> Register(User user)
        {
                return await _userRepository.Register(user);
        }

        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            if (StrongPassword(userToUpdate.Password) >= 2)
                return await _userRepository.UpdateUser(id, userToUpdate);
            else
                return null;
        }
    }
}
