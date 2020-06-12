using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamService.DataAccess.Main.UnitOfWork;

namespace ExamService.DataAccess.Main.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MainUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
