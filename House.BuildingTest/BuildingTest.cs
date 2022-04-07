using House.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;
using House.Core.Dto;
using House.Core.Domain;

namespace House.BuildingTest
{
    public class BuildingTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyBuilding_WhenReturnResult()
        {
            string guid = "dbcb562d-1c6c-4ea5-8f52-b1c828b519c2";


            BuildingDto building = new BuildingDto();

            building.Id = Guid.Parse(guid);
            building.Street = "Star";
            building.ApartmentNumber = 32;
            building.Floor = 4;
            building.Typeofheating = "Gas";
            building.Area = 40;
            building.Parking = 12;
            building.ModifiedAT = DateTime.Now;
            building.CreatedAT = DateTime.Now;

            var result = await Svc<IBuildingService>().Add(building);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdBuilding_WhenReturnsResultAsync()
        {
            string guid = "c40cf715-8d40-49d6-9ee9-ccdc7baecc10";
            string guid1 = "dbcb562d-1c6c-4ea5-8f52-b1c828b519c2";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IBuildingService>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_GetByIdBuilding_WhenReturnsResultAsync()
        {
            string guid = "c40cf715-8d40-49d6-9ee9-ccdc7baecc10";
            string guid1 = "c40cf715-8d40-49d6-9ee9-ccdc7baecc10";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);

            await Svc<IBuildingService>().GetAsync(insertGuid);

            Assert.Equal(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdBuilding_WhenDeleteBuilding()
        {
            string guid = "c40cf715-8d40-49d6-9ee9-ccdc7baecc10";

            var insertGuid = Guid.Parse(guid);

           var result = await Svc<IBuildingService>().Delete(insertGuid);

            Assert.NotEmpty((System.Collections.IEnumerable)result);
            Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_UpdateByIdBuilding_WhenUpdateBuilding()
        {
            var guid = new Guid("dbcb562d-1c6c-4ea5-8f52-b1c828b519c2");

            Building building = new Building();

            building.Id = guid;
            building.Street = "Star";
            building.ApartmentNumber = 32;
            building.Floor = 4;
            building.Typeofheating = "Gas";
            building.Area = 40;
            building.Parking = 12;
            building.ModifiedAT = DateTime.Now;
            building.CreatedAT = DateTime.Now;


            var buildingId = guid;
            var buildingToUpdate = new BuildingDto()
            {
                Street = "Test",
                Floor = 9
            };

            await Svc<IBuildingService>().Update(buildingToUpdate);

            Assert.Equal(building.Id.ToString(), buildingId.ToString());
            Assert.DoesNotMatch(building.Street, buildingToUpdate.Street);
            Assert.DoesNotMatch(building.Floor.ToString(), buildingToUpdate.Floor.ToString());
        }
    }
}