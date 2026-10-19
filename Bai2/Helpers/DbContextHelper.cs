using Bai2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Helpers
{
    public static class DbContextHelper
    {
        public static QL_NhaTroContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<QL_NhaTroContext>();
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            return new QL_NhaTroContext(optionsBuilder.Options);
        }
    }
}
