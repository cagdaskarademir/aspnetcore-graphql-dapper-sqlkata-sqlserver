using System.Collections.Generic;
using Smoothie.Entity;

namespace Smoothie.Business.Test
{
    public class BaseCompanyTest
    {
        protected IEnumerable<Company> AllCompanies = new List<Company>()
        {
            new Company()
            {
                Id = 1,
                Name = "Roomm",
                IsActive = true
            },
            new Company()
            {
                Id = 2,
                Name = "Realmix",
                IsActive = true
            },
            new Company()
            {
                Id = 3,
                Name = "Browsebug",
                IsActive = true
            },
            new Company()
            {
                Id = 4,
                Name = "Kazu",
                IsActive = true
            },
            new Company()
            {
                Id = 5,
                Name = "Thoughtstorm",
                IsActive = true
            }
        };
    }
}