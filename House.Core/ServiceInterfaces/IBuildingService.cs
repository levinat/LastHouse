using House.Core.Domain;
using House.Core.Dto;
using House.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IBuildingService : IApplicationService
    {
        Task<Building> Add(BuildingDto dto);

        Task<Building> Delete(Guid id);

        Task<Building> Update(BuildingDto dto);

        Task<Building> GetAsync(Guid id);

    }
}
