using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.Migrations
{
    [Migration(202106280001)]
    public class InitialTables_202106280001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Student");
        }

        public override void Up()
        {
            Create.Table("Student")
           .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
           .WithColumn("Name").AsString(50).NotNullable()
           .WithColumn("Age").AsInt32().NotNullable();
        }
    }
}
