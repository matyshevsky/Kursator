using Domain.FixingDomain.Interfaces;
using FluentAssertions;
using Repositories.Repository;
using System;
using Xunit;

namespace KursatorTestProject
{
    public class NbpProviderTests
    {
        private readonly Uri _uri;
        public NbpProviderTests()
        {
            _uri = new Uri("http://api.nbp.pl/api/");
        }
        [Fact]
        public void GetFixingsTest()
        {
            INbpProvider systemUnderTest = new NbpProvider(_uri);
            var result = systemUnderTest.GetFixings().Result;
            result.Should().NotBeNull();
        }
    }
}
