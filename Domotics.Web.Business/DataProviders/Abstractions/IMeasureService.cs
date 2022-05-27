namespace Domotics.Web.Business.DataProviders.Abstractions
{
    using Domotics.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMeasureService
    {
        Task<List<MeasureDto>> GetAllAsync();
    }
}
