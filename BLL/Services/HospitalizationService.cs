using BLL.Interfaces;
using DAL.DTOS;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HospitalizationService(IHospitalizationReporitory hospitalizationRepository) : IHospitalizationService
    {
        private readonly IHospitalizationReporitory _hospitalziationRepository = hospitalizationRepository;
        public async Task<bool> RejectAsync(string phone)
        {
            return await _hospitalziationRepository.RejectAsync(phone);
        }

        public async Task<bool> SendToHospitalization(HospitalizationDTO hospitalizationDTO)
        {
            return await _hospitalziationRepository.SendToHospitalization(hospitalizationDTO);
        }
    }
}
