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

    internal class ArmeService : IArmeService
    {
        private readonly IArmeAccessLayer accessLayer;

        public ArmeService(IArmeAccessLayer accessLayer)
        {
            this.accessLayer = accessLayer;
        }

        public async Task AddAsync(ArmeDto arme)
        {
            var toAdd = new Arme
            {
                Degats = arme.Degats,
                Nom = arme.Nom,
                
            };

            await this.accessLayer.AddAsync(toAdd);
        }

        public async Task DeleteAsync(int id)
        {

            
            await this.accessLayer.RemoveAsync(id);
        }

        public async Task<List<ArmeDto>> GetAllAsync()
            => await this.accessLayer.GetCollection()
                .Select(x => new ArmeDto
                {
                    Id = x.Id,
                    Degats = x.Degats,
                    Nom = x.Nom
                })
                .ToListAsync();

        public async Task<ArmeDto> GetByIdAsync(int id)
        {
            var arme = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id);

           return arme is null 
                ? null 
                : new()
                {
                    Id = arme.Id,
                    Degats = arme.Degats,
                    Nom = arme.Nom
                };
        }

        public async Task UpdateAsync(int id, ArmeDto arme)
        {
            var toUpdate = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id, trackingEnabled: true);

            toUpdate.Nom = arme.Nom;
            toUpdate.Degats = arme.Degats;

            await this.accessLayer.UpdateAsync(toUpdate);
        }
    }
}
