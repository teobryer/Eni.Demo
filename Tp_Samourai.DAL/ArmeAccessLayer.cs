using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
    public class ArmeAccessLayer
    {
        private readonly SamouraiDbContext context;

        public ArmeAccessLayer(SamouraiDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Arme>> GetArmesAsync()
            => await this.context.Armes.ToListAsync();
    }
}
