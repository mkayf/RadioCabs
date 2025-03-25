using Microsoft.EntityFrameworkCore;


namespace RadioCabs.Models
{
    public partial class RadioCabs_DBContext : DbContext
    {
        public RadioCabs_DBContext()
        {
        }

        public RadioCabs_DBContext(DbContextOptions<RadioCabs_DBContext> options) : base(options)
        {
        }
    }
}
