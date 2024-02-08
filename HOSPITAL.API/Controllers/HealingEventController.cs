using BLL.Interfaces;
using DAL.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL.API.Controllers
{
    [ApiController]
    [Route("/api/healingevent")]
    public class HealingEventController(IHealingEventService healingEventService) : Controller
    {
        private readonly IHealingEventService _healingEventService = healingEventService;


        [HttpPost]
        [Route("/createrequest")]
        public async Task<IActionResult> CreateRequest(string phone, string name, string lastname) =>
            Ok(await _healingEventService.CreateRequestAsync(phone, name, lastname));
        [HttpPost]
        [Route("/visitcreate")]
        public async Task<IActionResult> CreateVisit(string phone, string name, string lastname, string rec, string notes) =>
            Ok(await _healingEventService.CreateVisitAsync(phone, name, lastname, rec, notes));
        [HttpPost]
        [Route("/createevent")]
        public async Task<IActionResult> CreateEvent([FromBody] HealingEventDTO healingEventDTO) =>
            Ok(await _healingEventService.CreateEventAsync(healingEventDTO));
    }
}
