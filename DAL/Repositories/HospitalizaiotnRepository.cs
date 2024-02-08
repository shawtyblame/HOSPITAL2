using DAL.Data;
using DAL.DTOS;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class HospitalizaiotnRepository(AppDbContext appDbContext) : IHospitalizationReporitory
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task<bool> SendToHospitalization(HospitalizationDTO hospitalizationDTO)
        {
            var condition = await _context.HospitalizationConditions.FirstOrDefaultAsync(u => u.Name.ToLower().Equals(hospitalizationDTO.Condition.ToLower()));
            var departament = await _context.Departaments.FirstOrDefaultAsync(d => d.Name.ToLower().Equals(hospitalizationDTO.Departament.ToLower()));
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == hospitalizationDTO.PhoneNumber);
            var hospitalizationModel = new Hospitalization()
            {
                HospitalizationTime = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(10),
                UserInfoId = user.Id,
                Diagnosis = hospitalizationDTO.Diagnosis,
                Target = hospitalizationDTO.Target,
                HospitalizationConditionId = condition.Id,
                DepartmentId = departament.Id,
                HospitalizationStatusId = 1
            };
            _context.Hospitalizations.Add(hospitalizationModel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectAsync(string phone)
        {
            var user = await _context.UserMainInfos.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            var userHosp = await _context.Hospitalizations.FirstOrDefaultAsync(u => u.UserInfoId == user.Id);
            userHosp.HospitalizationStatusId = 2;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
