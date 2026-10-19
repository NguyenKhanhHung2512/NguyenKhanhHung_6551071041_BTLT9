using Bai1.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Bai1.Models
{
    public partial class QL_ChiTieuContext
    {
        public QL_ChiTieuContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = AppConfig.Current.ConnectionStrings.DefaultConnection;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
