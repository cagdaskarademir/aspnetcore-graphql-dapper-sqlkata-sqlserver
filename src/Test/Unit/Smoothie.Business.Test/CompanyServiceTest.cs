using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Moq;
using Smoothie.Model.Request;
using Smoothie.Repository;
using SqlKata.Execution;
using Xunit;

namespace Smoothie.Business.Test
{
    public class CompanyServiceTest : BaseCompanyTest
    {
        private readonly ICompanyService _companyService;
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;

        public CompanyServiceTest()
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();

            _companyRepositoryMock
                .Setup(p => p.GetCompanies(It.IsAny<SearchCompanies>()))
                .Callback((SearchCompanies s) =>
                {
                    if (s.Ids != null && s.Ids.Any())
                    {
                        AllCompanies = AllCompanies.Where(p => s.Ids.Contains(p.Id));
                    }

                    if (s.IsActive != null)
                    {
                        AllCompanies = AllCompanies.Where(p => s.IsActive == p.IsActive);
                    }
                })
                .ReturnsAsync(AllCompanies);

            _companyRepositoryMock.Setup(p => p.GetCompany(It.IsAny<SearchCompany>()))
                .Callback((SearchCompany filter) =>
                {

                })
                .ReturnsAsync((SearchCompany s) => AllCompanies.FirstOrDefault(company => company.Id == s.Id));
            
            _companyService = new CompanyService(_companyRepositoryMock.Object);
        }

        [Fact]
        public async Task Should_Return_Company_When_UserId_Is_1()
        {
            // Arrange
            var userId = 1;
            var requestFilter = new SearchCompany()
            {
                Id = userId
            };

            var expectedResult = AllCompanies.FirstOrDefault(p => p.Id == userId);

            // Act
            var result = await _companyService
                .GetCompany(requestFilter).ConfigureAwait(false);


            // Assert
            Assert.NotNull(expectedResult);
            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Name, result.Name);
            Assert.Equal(expectedResult.IsActive, result.IsActive);
        }

        [Fact]
        public async Task Should_Return_AllCompanies_When_Filter_Is_Null()
        {
            // Arrange
            SearchCompanies requestFilter = new SearchCompanies()
            {
                Ids = new int?[] { },
                IsActive = null,
                Names = null,
                Columns = null,
                Page = null,
                PageSize = null
            };
            var expectedResultCount = 5;

            // Act
            var result = await _companyService
                .GetCompanies(requestFilter)
                .ConfigureAwait(false);

            // Assert

            Assert.Equal(expectedResultCount, result.Count());
        }
    }
}