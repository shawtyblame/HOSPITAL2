using DAL.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHealingEventService
    {
        public Task<bool> CreateRequestAsync(string phone, string name, string lastname);
        public Task<bool> CreateVisitAsync(string phone, string name, string lastname, string rec, string notes);
        public Task<bool> CreateEventAsync(HealingEventDTO healingEventDTO);
    }
}
