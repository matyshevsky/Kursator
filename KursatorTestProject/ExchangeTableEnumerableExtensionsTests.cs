using Domain.FixingDomain;
using FluentAssertions;
using Repositories.Entities;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace KursatorTestProject
{
    public class ExchangeTableEnumerableExtensionsTests
    {
        #region initialize inputs
        List<ExchangeTable> input = new List<ExchangeTable>
        {
            new ExchangeTable
            {
                EffectiveDate = DateTimeOffset.MinValue,
                No = "",
                Table = "A",
                Rates = new ExchangeTableRate[]
                {
                    new ExchangeTableRate
                    {
                        Code = "EUR",
                        Currency = "euro",
                        Mid = 1.0
                    },
                    new ExchangeTableRate
                    {
                        Code = "GBP",
                        Currency = "funt",
                        Mid = 1.5
                    }
                }
            }
        };

        #endregion

        #region expected

        IEnumerable<Fixing> expected = new List<Fixing>
        {
            new Fixing
            {
                Currency = "euro",
                CurrencyCode = "EUR",
                Rate = 1.0m
            },
            new Fixing
            {
                Currency = "funt",
                CurrencyCode = "GBP",
                Rate = 1.5m
            }
        };

        #endregion


        [Fact]
        public void TestExtension()
        {
            var result = input.ConvertToEnumerableDomain();
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(expected);
        }


        //todo
        [Fact]
        public void TestExtensionNull()
        {
            var result = new List<ExchangeTable>().ConvertToEnumerableDomain();
            result.Should().HaveCount(0);
        }

    }
}
