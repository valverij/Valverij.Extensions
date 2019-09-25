using Microsoft.AspNetCore.Hosting;
using Moq;
using Xunit;

namespace Valverij.Extensions.Web.Tests
{
    public class HostingEnvironmentExtensionsTests
    {
        [Fact]
        public void IsDebug_True()
        {
            var envMock = new Mock<IHostingEnvironment>();
            envMock.Setup(x => x.EnvironmentName).Returns("Debug");

            Assert.True(envMock.Object.IsDebug());
            Assert.False(envMock.Object.IsDevelopment());
        }

        [Fact]
        public void IsDebug_False()
        {
            var envMock = new Mock<IHostingEnvironment>();
            envMock.Setup(x => x.EnvironmentName).Returns("Development");

            Assert.False(envMock.Object.IsDebug());
            Assert.True(envMock.Object.IsDevelopment());
        }
    }
}
