using FluentMigrator;

namespace Smoothie.Migration.M20200517
{
    [Migration(0)]
    public class CreateTableCompany : FluentMigrator.Migration
    {
        private static string CompanyTableName => "Company";

        public override void Up()
        {
            Create.Table(CompanyTableName)
                .WithDescription("All Companies Data")

                // Id Column
                .WithColumn("Id")
                .AsInt32()
                .Identity()
                .PrimaryKey("PK_Company_Id")
                .NotNullable()
                .WithColumnDescription("Identity Company")
                .Unique("UI_001_Company_Id")

                // Name Column
                .WithColumn("Name")
                .AsString(200)
                .NotNullable()
                .WithColumnDescription("Name of Company")

                // IsActive Column 
                .WithColumn("IsActive")
                .AsBoolean()
                .WithDefaultValue(true)
                .NotNullable()
                .WithColumnDescription("Is Active Or Not of Company");

            Create.Index("I_Company_Name_IsActive").OnTable(CompanyTableName)
                .OnColumn("Name")
                .Descending()
                .OnColumn("IsActive")
                .Descending();

        }

        public override void Down()
        {
            Delete.Table(CompanyTableName);
        }
    }
}