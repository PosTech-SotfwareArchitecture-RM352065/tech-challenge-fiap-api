using NetArchTest.Rules;
using System.Linq;
using Xunit;

namespace RestauranteSanduba.Test.ArchitectureTest
{
    public class CleanArchitectureTest
    {
        private const string CoreDomainNamespace = "RestauranteSanduba.Core.Domain";
        private const string CoreApplicationNamespace = "RestauranteSanduba.Core.Application";
        private const string CoreApplicationAbstractionNamespace = "RestauranteSanduba.Core.Application.Abstraction";

        private const string GatewayPersistenceNamespace = "RestauranteSanduba.Adapter.Driven.Persistence";
        private const string PresentantionNamespace = "RestauranteSanduba.Adapter.Driver.Presentation";
        
        private const string ApiNamespace = "RestauranteSanduba.Adapter.Driver.API";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(CoreDomainNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    CoreApplicationNamespace,
                    GatewayPersistenceNamespace,
                    PresentantionNamespace,
                    ApiNamespace
                )
                .GetResult().IsSuccessful);
        }

        [Fact]
        public void ApplicationAbstraction_Should_Only_HaveDependencyOnDomain()
        {
            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(CoreApplicationAbstractionNamespace)
                .Should().HaveDependencyOnAny(
                    CoreDomainNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(CoreApplicationAbstractionNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    CoreApplicationNamespace,
                    PresentantionNamespace,
                    GatewayPersistenceNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);
        }

        [Fact]
        public void Application_Should_Only_HaveDependencyOnCoreNamespaces()
        {
            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(CoreApplicationNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    CoreDomainNamespace,
                    CoreApplicationAbstractionNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(CoreApplicationNamespace)
                .Should().HaveDependencyOnAny(
                    PresentantionNamespace,
                    GatewayPersistenceNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);
        }

        [Fact]
        public void Infrastructure_Should_Only_HaveDependencyOnApplicationAbstraction()
        {
            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(GatewayPersistenceNamespace)
                .Should().HaveDependencyOn(
                    CoreApplicationAbstractionNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(GatewayPersistenceNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    CoreDomainNamespace,
                    PresentantionNamespace,
                    GatewayPersistenceNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);
        }

        [Fact]
        public void Presentation_Should_Only_HaveDependencyOnApplication()
        {
            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(PresentantionNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    CoreDomainNamespace,
                    GatewayPersistenceNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(PresentantionNamespace)
                .Should().OnlyHaveDependenciesOn(
                    CoreApplicationNamespace
                ).GetResult().IsSuccessful);
        }
    }
}