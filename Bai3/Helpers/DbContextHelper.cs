using Bai3.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai3.Helpers;

// Giống bài mẫu AppDeployment_Chap11: tạo DbContext với connection string đọc từ appsettings.json
public static class DbContextHelper
{
    public static QL_DaNgoaiContext GetContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<QL_DaNgoaiContext>();
        optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        return new QL_DaNgoaiContext(optionsBuilder.Options);
    }
}
