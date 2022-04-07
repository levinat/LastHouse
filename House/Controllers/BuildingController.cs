using House.Core.Dto;
using House.Core.ServiceInterface;
using House.Data;
using House.Models.Building;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace House.Controllers
{
    public class BuildingController : Controller
    {
        private readonly BuildingDbContext _context;
        private readonly IBuildingService _buildingService;
       
        public BuildingController
            (
            BuildingDbContext context,
            IBuildingService buildingService

            )
        {
            _context = context;
            _buildingService = buildingService;

        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Building
                .OrderByDescending(y => y.CreatedAT)
                .Select(x => new BuildingListItem
                {
                    Id = x.Id,
                    Street = x.Street,
                    ApartmentNumber = x.ApartmentNumber,
                    Floor = x.Floor,
                    Typeofheating = x.Typeofheating,
                    Area = x.Area,
                    Parking = x.Parking,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            BuildingViewModel model = new BuildingViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BuildingViewModel model)
        {
            var dto = new BuildingDto()
            {
                Id = model.Id,
                Street = model.Street,
                ApartmentNumber = model.ApartmentNumber,
                Floor = model.Floor,
                Typeofheating = model.Typeofheating,
                Area = model.Area,
                Parking = model.Parking,
                CreatedAT = model.CreatedAT,
                ModifiedAT = model.ModifiedAT,

            };

            var result = await _buildingService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var building = await _buildingService.Delete(id);
            if (building == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var building = await _buildingService.GetAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            var model = new BuildingViewModel();

            model.Id = building.Id;
            model.Street = building.Street;
            model.ApartmentNumber = building.ApartmentNumber;
            model.Floor = building.Floor;
            model.Typeofheating = building.Typeofheating;
            model.Area = building.Area;
            model.Parking = building.Parking;
            model.ModifiedAT = building.ModifiedAT;
            model.CreatedAT = building.CreatedAT;


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BuildingViewModel model)
        {
            var dto = new BuildingDto()
            {
                Id = model.Id,
                Street = model.Street,
                ApartmentNumber = model.ApartmentNumber,
                Floor = model.Floor,
                Typeofheating = model.Typeofheating,
                Area = model.Area,
                Parking = model.Parking,
                CreatedAT = model.CreatedAT,
                ModifiedAT = model.ModifiedAT,

            };

            var result = await _buildingService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }
    }
}