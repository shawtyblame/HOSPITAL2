using BLL.Interfaces;
using BLL.Services;
using DAL.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Runtime.CompilerServices;

namespace HOSPITAL.API.Controllers
{
    [ApiController]
    [Route("/api/hospitalization")]
    public class HospitalizationContreoller : Controller
    {
        private readonly IHospitalizationService _hospitalizationService;
        public HospitalizationContreoller(IHospitalizationService hospitalizationService)
        {
            _hospitalizationService = hospitalizationService;
        }

        [HttpPost]
        [Route("/reject")]
        public async Task<IActionResult> Reject(string phone)
        {
            return Ok(await _hospitalizationService.RejectAsync(phone));
        }

        [HttpPost]
        [Route("/sendto")]
        public async Task<IActionResult> SendTo(HospitalizationDTO hospitalizationDTO)
        {
            return Ok(await _hospitalizationService.SendToHospitalization(hospitalizationDTO));
        }
    }
}
