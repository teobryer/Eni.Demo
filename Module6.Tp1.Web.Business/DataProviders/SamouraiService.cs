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
        private readonly IArmeAccessLayer armeAccessLayer;
        private readonly IArtMartialAccessLayer artMartialAccessLayer;

        public SamouraiService(ISamouraiAccessLayer accessLayer, IArmeAccessLayer armeAccessLayer, IArtMartialAccessLayer artMartialAccessLayer)
        {
            this.accessLayer = accessLayer;
            this.armeAccessLayer = armeAccessLayer;
            this.artMartialAccessLayer = artMartialAccessLayer;
        }

        public async Task AddAsync(SamouraiDto samourai)
        {
            var newArme = await armeAccessLayer.GetSingleAsync(filter: a => a.Id == samourai.ArmeId, trackingEnabled: true);


            if (newArme.SamouraiId == null)
            {

                var toAdd = new Samourai
                {
                    Force = samourai.Force,
                    Nom = samourai.Nom,
                    Arme = await armeAccessLayer.GetSingleAsync(filter: a => a.Id == samourai.ArmeId, trackingEnabled: true),
                    ArtsMartiaux = await artMartialAccessLayer.GetCollection(trackingEnabled: true, filter: a => samourai.ListeArtsMartiauxId.Contains(a.Id)).ToListAsync()

                };

                await this.accessLayer.AddAsync(toAdd);

            }

            else
            {
                throw new ArmeAlreadyUseException();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await this.accessLayer.RemoveAsync(id);
        }

        public async Task<List<SamouraiDto>> GetAllAsync()
             => await this.accessLayer.GetCollection(navigationProperties: data => data.Include(x => x.Arme).Include(x => x.ArtsMartiaux))
                .Select(x => new SamouraiDto
                {
                    Id = x.Id,
                    Force = x.Force,
                    Nom = x.Nom,
                    ArmeId = x.Arme.Id,
                    ArmeNom = x.Arme != null ? x.Arme.Nom : "",
                    ArtsMartiaux = x.ArtsMartiaux.Select(x => new ArtMartialDto() { Id = x.Id, Nom = x.Nom }).ToList(),
                    ListeArtsMartiauxId = x.ArtsMartiaux.Select(x=> x.Id).ToList()
                }

                 
                 )
                .ToListAsync();

        public async Task<SamouraiDto> GetByIdAsync(int id)
        {
            var samourai = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id, navigationProperties: data => data.Include(x => x.Arme).Include(x=> x.ArtsMartiaux));

            return samourai is null
                 ? null
                 : new()
                 {
                     Id = samourai.Id,
                     Force = samourai.Force,
                     Nom = samourai.Nom,
                     ArmeId = samourai.Arme?.Id,
                     ArmeNom = samourai.Arme?.Nom,
                     ArtsMartiaux = samourai.ArtsMartiaux.Select(x => new ArtMartialDto() { Id = x.Id, Nom = x.Nom }).ToList(),
                     ListeArtsMartiauxId = samourai.ArtsMartiaux.Select(x => x.Id).ToList()
                 };
        }

        public async Task UpdateAsync(int id, SamouraiDto samourai)
        {
            var toUpdate = await this.accessLayer.GetSingleAsync(filter: a => a.Id == id, trackingEnabled: true, navigationProperties: data => data.Include(x => x.Arme).Include(x => x.ArtsMartiaux));
            var newArme = await armeAccessLayer.GetSingleAsync(filter: a => a.Id == samourai.ArmeId, trackingEnabled: true);

            if (newArme.SamouraiId == null || newArme.Id == toUpdate.Arme?.Id)
            {


                toUpdate.Nom = samourai.Nom;
                toUpdate.Force = samourai.Force;
                toUpdate.ArtsMartiaux = await artMartialAccessLayer.GetCollection(trackingEnabled: true, filter: a => samourai.ListeArtsMartiauxId.Contains(a.Id)).ToListAsync();

                if (newArme.Id != toUpdate.Arme?.Id)
                {
                    if (toUpdate.Arme != null)
                    {
                        toUpdate.Arme.SamouraiId = null;
                    }

                    toUpdate.Arme = newArme;
                }


                await this.accessLayer.UpdateAsync(toUpdate);

            }



            else
            {
                throw new ArmeAlreadyUseException();
            }
        }
    }
}
