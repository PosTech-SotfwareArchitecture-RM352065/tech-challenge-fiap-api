using NetArchTest.Rules;
using System.Linq;
using Xunit;

namespace ArchitectureTest
{
    public class CleanArchitectureTest
    {
        private const string DomainNamespace = "RestauranteSanduba.Core.Domain";
        private const string ApplicationNamespace = "RestauranteSanduba.Core.Application";
        private const string InfrastructureNamespace = "RestauranteSanduba.Adapter.Driven.Infrastructure";
        private const string PresentantionNamespace = "RestauranteSanduba.Adapter.Driver.Presentation";
        private const string ApiNamespace = "RestauranteSanduba.Adapter.Driver.API";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(DomainNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    ApplicationNamespace,
                    InfrastructureNamespace, 
                    PresentantionNamespace,
                    ApiNamespace
                )
                .GetResult().IsSuccessful);

        }

        [Fact]
        public void Application_Should_Only_HaveDependencyOnDomain()
        {
            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(ApplicationNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    InfrastructureNamespace,
                    PresentantionNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(ApplicationNamespace)
                .Should().HaveDependencyOnAny(
                    DomainNamespace
                ).GetResult().IsSuccessful);
        }

        [Fact]
        public void Infrastructure_Should_Only_HaveDependencyOnCore()
        {
            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(InfrastructureNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    PresentantionNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(ApplicationNamespace)
                .Should().HaveDependencyOnAny(
                    DomainNamespace, ApplicationNamespace
                ).GetResult().IsSuccessful);
        }

        [Fact]
        public void Presentation_Should_Only_HaveDependencyOnApplication()
        {
            Assert.True(Types.InCurrentDomain()
                .That().ResideInNamespace(PresentantionNamespace)
                .ShouldNot().HaveDependencyOnAny(
                    DomainNamespace,
                    InfrastructureNamespace,
                    ApiNamespace
                ).GetResult().IsSuccessful);

            Assert.True(Types.InCurrentDomain().That().ResideInNamespace(PresentantionNamespace)
                .Should().OnlyHaveDependenciesOn(
                    ApplicationNamespace
                ).GetResult().IsSuccessful);
        }
    }
}