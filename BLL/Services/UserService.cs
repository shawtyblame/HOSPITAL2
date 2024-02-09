using BLL.Interfaces;
using DAL.DTOS;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> GetInfoMyMedicalCardNumberAsync(long number)
        {
            return await _userRepository.GetInfoMyMedicalCardNumberAsync(number);
        }

        public async Task<UserDTO> GetUserInfo(string phone)
        {
            return await _userRepository.GetUserInfo(phone);
        }

        public async Task<bool> RegistrationUserAsync(UserDTO userDTO)
        {
            return await _userRepository.RegistrationUserAsync(userDTO);
        }

        public async Task<UserCredential> ValidateUserAsync(ValidateDTO validateDTO)
        {
            return await _userRepository.ValidateUserAsync(validateDTO);
        }
    }
}
