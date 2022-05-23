using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
    public class SamouraiAccessLayer
    {
        private readonly SamouraiDbContext context;

        public SamouraiAccessLayer(SamouraiDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Samourai>> GetSamouraisList()
            => await this.context.Samourai.ToListAsync();

    }
}
