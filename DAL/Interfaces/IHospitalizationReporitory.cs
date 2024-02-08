using DAL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHospitalizationReporitory
    {
        public Task<bool> SendToHospitalization(HospitalizationDTO hospitalizationDTO);
        public Task<bool> RejectAsync(string phone);
    }
}
