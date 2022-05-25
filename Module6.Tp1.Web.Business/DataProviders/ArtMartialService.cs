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

    internal class ArtMartialService : IArtMartialService
    {
        private readonly IArtMartialAccessLayer accessLayer;

        public ArtMartialService(IArtMartialAccessLayer accessLayer)
        {
            this.accessLayer = accessLayer;
        }

        public async Task AddAsync(ArtMartialDto artMartial)
        {
            var toAdd = new ArtMartial
            {
                Nom = artMartial.Nom
                
            };

            await this.accessLayer.AddAsync(toAdd);
        }

        public async Task DeleteAsync(int id)
        {

            
            await this.accessLayer.RemoveAsync(id);
        }

        public async Task<List<ArtMartialDto>> GetAllAsync()
            => await this.accessLayer.GetCollection()
                .Select(x => new ArtMartialDto
                {
                    Id = x.Id,
                    Nom = x.Nom,
                    
                })
                .ToListAsync();

        public async Task<ArtMartialDto> GetByIdAsync(int id)
        {
            var artMartial = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id);

           return artMartial is null 
                ? null 
                : new()
                {
                    Id = artMartial.Id,
                    
                    Nom = artMartial.Nom
                };
        }

        public async Task UpdateAsync(int id, ArtMartialDto artMartial)
        {
            var toUpdate = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id, trackingEnabled: true);

            toUpdate.Nom = artMartial.Nom;
            

            await this.accessLayer.UpdateAsync(toUpdate);
        }
    }
}
