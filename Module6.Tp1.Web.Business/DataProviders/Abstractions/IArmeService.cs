namespace Module6.Tp1.Web.Business.DataProviders.Abstractions
{
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArmeService
    {
        Task<List<ArmeDto>> GetAllAsync();

        Task<ArmeDto> GetByIdAsync(int id);

        Task AddAsync(ArmeDto arme);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, ArmeDto arme);
    }
}
