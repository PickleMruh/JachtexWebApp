using JachtexWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JachtexWebApp.Data
{
    public interface IDB_Jachtex
    {
        Task<IEnumerable<Jachty>> GetJachty();
    }
}
