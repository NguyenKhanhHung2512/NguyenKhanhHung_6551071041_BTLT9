using Bai2.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Models
{
    public partial class QL_NhaTroContext
    {
        public QL_NhaTroContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
            }
        }
    }
}
