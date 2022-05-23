namespace Module6.Tp1.Web.Business.DataProviders.Abstractions
{
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISamouraiService
    {
        Task<List<SamouraiDto>> GetAllAsync();

        Task<SamouraiDto> GetByIdAsync(int id);

        Task AddAsync(SamouraiDto samourai);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, SamouraiDto samourai);
    }
}
