using Domain.FixingDomain.Interfaces;
using FluentAssertions;
using Kursator.Interfaces;
using Kursator.Services;
using Library.Exceptions;
using Repositories.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KursatorTestProject
{
    public class FixingServiceTests
    {
        private readonly IFixingService _fixingService;

        public FixingServiceTests()
        {
            INbpProvider provider = new NbpProvider(new System.Uri("http://api.nbp.pl/api/"));
            _fixingService = new FixingService(provider);
        }

        [Fact]
        public void GetWorldwideFixingTests()
        {
            var result = _fixingService.GetWorldwideFixings().Result;
            result.Should().HaveCount(5);
            var curriencesCodes = result.Select(c => c.CurrencyCode.ToUpper()).ToList();
            curriencesCodes.Should().Contain(new string[] { "EUR", "GBP", "HUF", "USD", "CHF" });
        }


        [Fact]
        public void ConvertCurrencies()
        {
            var result = _fixingService.ConvertCurrencies("EUR", "GBP", 100).Result;
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public void ConvertCurrenciesMatchCase()
        {
            var result = _fixingService.ConvertCurrencies("eur", "Gbp", 100).Result;
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ConvertCurrenciesNotFound()
        {
            Func<Task> sutMethod = async () =>
            {
                await _fixingService.ConvertCurrencies("AAA", "GBP", 100);
            };

            await sutMethod.Should().ThrowExactlyAsync<FixingNotFoundException>();
        }

    }
}
