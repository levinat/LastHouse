using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using House.Core.ServiceInterface;
using House.Data;
using House.Core.Dto;
using House.Core.Domain;

namespace House.ApplicationService.Services
{
    public class BuildingServices : IBuildingService
    {
        private readonly BuildingDbContext _context;



        public BuildingServices
            (
            BuildingDbContext context

            )
        {
            _context = context;



        }

        public async Task<Building> Add(BuildingDto dto)
        {
            Building building = new Building();

            building.Id = Guid.NewGuid();
            building.Street = dto.Street;
            building.ApartmentNumber = dto.ApartmentNumber;
            building.Floor = dto.Floor;
            building.Typeofheating = dto.Typeofheating;
            building.Area = dto.Area;
            building.Parking = dto.Parking;
            building.CreatedAT = DateTime.Now;
            building.ModifiedAT = DateTime.Now;

            await _context.Building.AddAsync(building);
            await _context.SaveChangesAsync();

            return building;
        }


        public async Task<Building> Delete(Guid id)
        {
            var buildingId = await _context.Building
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Building.Remove(buildingId);
            await _context.SaveChangesAsync();

            return buildingId;
        }


        public async Task<Building> Update(BuildingDto dto)
        {
            Building building = new Building();

            building.Id = dto.Id;
            building.Street = dto.Street;
            building.ApartmentNumber = dto.ApartmentNumber;
            building.Floor = dto.Floor;
            building.Typeofheating = dto.Typeofheating;
            building.Area = dto.Area;
            building.Parking = dto.Parking;
            building.CreatedAT = DateTime.Now;
            building.ModifiedAT = DateTime.Now;


            _context.Building.Update(building);
            await _context.SaveChangesAsync();

            return building;
        }

        public async Task<Building> GetAsync(Guid id)
        {
            var result = await _context.Building
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}