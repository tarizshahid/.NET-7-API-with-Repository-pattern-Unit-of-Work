using FormulaApi.Core;
using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private static readonly List<Driver> _drivers = new List<Driver>()
        //{
        //    new Driver()
        //    {
        //        Id = 1,
        //        Name = "Driver A",
        //        Team = "BMW",
        //        DriverNumber = 1122,
        //    },
        //    new Driver()
        //    {   Id = 2,
        //        Name = "Driver B",
        //        Team = "BMW",
        //        DriverNumber = 112233
        //    },
        //    new Driver()
        //    {
        //        Id = 3,
        //        Name = "Driver C",
        //        Team = "Aston Martin",
        //        DriverNumber = 221133
        //    }
        //};

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Drivers.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();
            return Ok($"Driver Added : {driver.Name}");
        }

        [HttpDelete]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            Driver? driver = await _unitOfWork.Drivers.GetById(id);
            if (driver == null)
            {
                return NotFound();
            }
            await _unitOfWork.Drivers.Delete(driver);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }


        [HttpPatch]
        [Route("UpdateDriver")]
        public async Task<IActionResult> PatchDriver(Driver driver)
        {
            Driver? existDriver = await _unitOfWork.Drivers.GetById(driver.Id);
            if (existDriver == null)
            {
                return NotFound();
            }
            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();
            return Ok($"Driver Updated {driver.Name}");
        }
    }
}
