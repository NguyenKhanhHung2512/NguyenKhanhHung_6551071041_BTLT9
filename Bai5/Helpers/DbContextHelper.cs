using Bai5.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai5.Helpers;

public static class DbContextHelper
{
    public static QL_DatTourContext GetContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<QL_DatTourContext>();
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        return new QL_DatTourContext(optionsBuilder.Options);
    }
}
