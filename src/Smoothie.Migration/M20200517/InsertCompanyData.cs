using System;
using FluentMigrator;
using Smoothie.Entity;

namespace Smoothie.Migration.M20200517
{
    [Migration(202017051532, TransactionBehavior.Default, "17.05.2020 15:32 Company Data")]
    public class InsertCompanyData : FluentMigrator.Migration
    {
        private static string CompanyTableName => nameof(Company);

        public override void Up()
        {
            Insert.IntoTable(CompanyTableName)
                .Row(new
                {
                    Name = "Devpulse",
                    IsActive = true
                });
            
            Insert.IntoTable(CompanyTableName)
                .Row(new
                {
                    Name = "Zoonoodle",
                    IsActive = true
                });
            
            Insert.IntoTable(CompanyTableName)
                .Row(new
                {
                    Name = "Npath",
                    IsActive = false
                });
            
        }

        public override void Down()
        {
            throw new ApplicationException("Data Rollback Problem. Please Clean Manually.");
        }
    }
}