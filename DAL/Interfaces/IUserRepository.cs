﻿using DAL.DTOS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> RegistrationUserAsync(UserDTO userDTO);
        public Task<UserDTO> GetInfoMyMedicalCardNumberAsync(long number);
        public Task<UserCredential> ValidateUserAsync(ValidateDTO validateDTO);
        public Task<UserDTO> GetUserInfo(string phone);
    }
}
