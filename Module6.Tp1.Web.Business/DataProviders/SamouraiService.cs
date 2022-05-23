namespace Module6.Tp1.Web.Business.DataProviders
{
    using Microsoft.EntityFrameworkCore;
    using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;
    using Module6.Tp1.DataAccessLayer.Entities;
    using Module6.Tp1.Web.Business.DataProviders.Abstractions;
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class SamouraiService : ISamouraiService
    {
        private readonly ISamouraiAccessLayer accessLayer;

        public SamouraiService(ISamouraiAccessLayer accessLayer)
        {
            this.accessLayer = accessLayer;
        }

        public async Task AddAsync(SamouraiDto samourai)
        {
            var toAdd = new Samourai
            {
                Force = samourai.Force,
                Nom = samourai.Nom,
                ArmeId = samourai.ArmeId
                
            };

            await this.accessLayer.AddAsync(toAdd);
        }

        public async Task DeleteAsync(int id)
        {
            await this.accessLayer.RemoveAsync(id);
        }

        public async Task<List<SamouraiDto>> GetAllAsync()
             => await this.accessLayer.GetCollection()
                .Select(x => new SamouraiDto
                {
                    Id = x.Id,
                    Force = x.Force,
                    Nom = x.Nom,
                    ArmeId = x.ArmeId
                })
                .ToListAsync();

        public async Task<SamouraiDto> GetByIdAsync(int id)
        {
            var samourai = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id);

            return samourai is null
                 ? null
                 : new()
                 {
                     Id = samourai.Id,
                     Force = samourai.Force,
                     Nom = samourai.Nom,
                     ArmeId = samourai.ArmeId
                 };
        }

        public async Task UpdateAsync(int id, SamouraiDto samourai)
        {
            var toUpdate = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id, trackingEnabled: true);

            toUpdate.Nom = samourai.Nom;
            toUpdate.Force = samourai.Force;
            toUpdate.ArmeId = samourai.ArmeId;

            await this.accessLayer.UpdateAsync(toUpdate);
        }
    }
}
