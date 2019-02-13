using System.Data.Entity;

namespace Prisoner.Test
{
    public class TestContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public TestContext() : base("DefaultConnection") {
            Database.SetInitializer<TestContext>(null);

        }
    }
}
