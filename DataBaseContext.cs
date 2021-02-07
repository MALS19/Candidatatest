using Microsoft.EntityFrameworkCore;

namespace CandidatesPortal
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options) { }

        public DbSet<Models.CandidateData> CandidateDatas { get; set; }
    }
}
