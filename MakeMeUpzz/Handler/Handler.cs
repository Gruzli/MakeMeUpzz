using MakeMeUpzz.Model;
using MakeMeUpzz.Reposiitory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeMeUpzz.Handlers
{
    public class UserHandler
    {
        private readonly UserRepository _userRepository;

        public UserHandler()
        {
            _userRepository = new UserRepository();
        }

        public int GenerateUserId()
        {
            return _userRepository.generateId();
        }

        public void RegisterUser(User user)
        {
            _userRepository.InputRegisterUser(user);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return _userRepository.Authentication(username, password);
        }
    }
}
