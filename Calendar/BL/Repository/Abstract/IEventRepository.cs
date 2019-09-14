using Calendar.Data.Domain;
using Calendar.Data.Repository.Abstract.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Bl.Repository.Abstract
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetEventsByDate(DateTime date);
    }
}
