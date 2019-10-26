using FluentAssertions;
using Kursator.Interfaces;
using Kursator.Services;
using Repositories.Interfaces;
using Repositories.Repository;
using Xunit;

namespace KursatorTestProject
{
    public class FixingServiceTests
    {
        private readonly IFixingService _fixingService;

        public FixingServiceTests()
        {
            INbpProvider provider = new NbpProvider(new System.Uri("http://api.nbp.pl/api/")); //todo
            _fixingService = new FixingService(provider);
        }

        [Fact]
        public void GetWorldwideFixingTests()
        {
            var result = _fixingService.GetWorldwideFixings().Result;
            result.Should().HaveCount(5);
        }
    }
}
