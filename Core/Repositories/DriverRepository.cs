using FormulaApi.Data;
using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(APIDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public override async Task<IEnumerable<Driver>> GetAll()
        {
            try
            {
                return await _context.Drivers.ToListAsync();
            }
            catch (Exception? ex)
            {
                throw ex;
            }
        }

        public override async Task<Driver?> GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception? ex)
            {

                throw ex;
            }
        }


        public async Task<Driver?> getByNumber(int number)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == number);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
