using Domain.FixingDomain;
using FluentAssertions;
using System;
using Xunit;

namespace KursatorTestProject
{
    public class FixingConverterTests
    {
        [Fact]
        public void ConvertProperCurrencies()
        {
            Fixing eur = new Fixing
            {
                Currency = "euro",
                CurrencyCode = "EUR",
                Rate = 4.0m
            };

            Fixing gbp = new Fixing
            {
                Currency = "funt",
                CurrencyCode = "gbp",
                Rate = 5.0m
            };

            var result = eur.ConvertTo(gbp, 10);
            result.Should().Be(8);
        }

        [Fact]
        public void ConvertSameCurrencies()
        {
            Fixing eur = new Fixing
            {
                Currency = "euro",
                CurrencyCode = "EUR",
                Rate = 4.0m
            };

            var result = eur.ConvertTo(eur, 10);
            result.Should().Be(10);
        }

        [Fact]
        public void ConvertNotValidFirstCurrency()
        {
            Fixing eur = new Fixing
            {
                Currency = "euro",
                CurrencyCode = "EUR",
                Rate = 0.0m
            };

            Fixing gbp = new Fixing
            {
                Currency = "funt",
                CurrencyCode = "gbp",
                Rate = 5.0m
            };

            var result = eur.ConvertTo(gbp, 10);
            result.Should().Be(0);
        }

        [Fact]
        public void ConvertNotValidSecondCurrency()
        {
            Fixing eur = new Fixing
            {
                Currency = "euro",
                CurrencyCode = "EUR",
                Rate = 4.0m
            };

            Fixing gbp = new Fixing
            {
                Currency = "funt",
                CurrencyCode = "gbp",
                Rate = 0.0m
            };

            Action act = () =>
            {
                eur.ConvertTo(gbp, 10);
            };

            act.Should().ThrowExactly<DivideByZeroException>();
        }

    }
}
