using JachtexWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JachtexWebApp.Data
{
    public class DB_JachtexSql : IDB_Jachtex
    {
        private DB_JachtexContext DB_JachtexContext { get; }
        public DB_JachtexSql(DB_JachtexContext _dB_JachtexContext)
        {
            DB_JachtexContext = _dB_JachtexContext;
        }

        public async Task<IEnumerable<Jachty>> GetJachty()
        {
            return await DB_JachtexContext.Jachties.ToListAsync();
        }
    }
}
