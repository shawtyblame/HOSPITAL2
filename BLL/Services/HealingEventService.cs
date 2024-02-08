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
    public class HealingEventService(IHealingEventRepository healingEventRepository) : IHealingEventService
    {
        private readonly IHealingEventRepository _healingEventRepository = healingEventRepository;
        public async Task<bool> CreateEventAsync(HealingEventDTO healingEventDTO)
        {
            return await _healingEventRepository.CreateEventAsync(healingEventDTO);
        }

        public async Task<bool> CreateRequestAsync(string phone, string name, string lastname)
        {
            return await _healingEventRepository.CreateRequestAsync(phone, name, lastname);
        }

        public async Task<bool> CreateVisitAsync(string phone, string name, string lastname, string rec, string notes)
        {
            return await _healingEventRepository.CreateVisitAsync(phone, name, lastname, rec, notes);
        }
    }
}
