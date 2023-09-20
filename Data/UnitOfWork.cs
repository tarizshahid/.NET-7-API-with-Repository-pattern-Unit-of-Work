using FormulaApi.Core;
using FormulaApi.Core.Repositories;

namespace FormulaApi.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly APIDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(APIDbContext aPIDbContext, ILoggerFactory loggerFactory)
        {
            _context = aPIDbContext;
            var _logger = loggerFactory.CreateLogger("Logs");
            Drivers = new DriverRepository(_context, _logger);
        }

        public IDriverRepository? Drivers { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
