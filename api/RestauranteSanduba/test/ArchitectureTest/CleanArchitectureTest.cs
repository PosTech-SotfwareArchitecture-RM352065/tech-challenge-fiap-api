using NetArchTest.Rules;
using Xunit;

namespace RestauranteSanduba.Test.ArchitectureTest
{
    public class CleanArchitectureTest
    {
        private const string CoreDomainNamespace = "RestauranteSanduba.Core.Domain";
        private const string CoreApplicationNamespace = "RestauranteSanduba.Core.Application";
        private const string CoreApplicationAbstractionNamespace = "RestauranteSanduba.Core.Application.Abstraction";

        private const string GatewayPersistenceNamespace = "RestauranteSanduba.Adapter.Driven.Persistence";
        private const string ControllerNamespace = "RestauranteSanduba.Adapter.Driver.Controller";

        private const string ApiNamespace = "RestauranteSanduba.Adapter.Driver.API";

        private string[] CoreLayer = new[]
        {
            CoreDomainNamespace,
            CoreApplicationNamespace,
            CoreApplicationAbstractionNamespace
        };


        private string[] InterfaceAdapterLayer = new[]
        {
            ControllerNamespace,
        };

        private string[] DriverFrameworkLayer = new[]
        {
            GatewayPersistenceNamespace,
            ApiNamespace
        };

        [Fact]
        public void CoreLayer_ShouldNot_HaveDependencyOnExternalLayer()
        {

            foreach (var projectNamescpace in CoreLayer)
            {
                Assert.True(Types.InCurrentDomain().That().ResideInNamespace(projectNamescpace)
                    .ShouldNot().HaveDependencyOnAny(
                        InterfaceAdapterLayer
                    ).GetResult().IsSuccessful);

                Assert.True(Types.InCurrentDomain().That().ResideInNamespace(projectNamescpace)
                    .ShouldNot().HaveDependencyOnAny(
                        DriverFrameworkLayer
                    ).GetResult().IsSuccessful);
            }
        }

        [Fact]
        public void InterfaceAdapterLayer_Should_Only_HaveDependencyOnCoreNamespaces()
        {
            foreach (var projectNamescpace in InterfaceAdapterLayer)
            {
                Assert.True(Types.InCurrentDomain().That().ResideInNamespace(projectNamescpace)
                    .Should().HaveDependencyOnAny(CoreLayer)
                    .GetResult().IsSuccessful);

                Assert.True(Types.InCurrentDomain().That().ResideInNamespace(projectNamescpace)
                    .ShouldNot().HaveDependencyOnAny(
                        DriverFrameworkLayer
                    ).GetResult().IsSuccessful);
            }
        }
    }
}