namespace Module6.Tp1.Web.Business.DataProviders.Abstractions
{
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArtMartialService
    {
        Task<List<ArtMartialDto>> GetAllAsync();

        Task<ArtMartialDto> GetByIdAsync(int id);

        Task AddAsync(ArtMartialDto artMartialDto);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, ArtMartialDto artMartialDto);
    }
}
