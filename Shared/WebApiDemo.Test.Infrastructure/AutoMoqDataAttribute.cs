using System.Diagnostics.CodeAnalysis;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.DataAnnotations;
using AutoFixture.NUnit3;
namespace WebApiDemo.Test.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() =>
        {
            var fixture = new Fixture().Customize(new CompositeCustomization(
                new AutoMoqCustomization(),
                new SupportMutableValueTypesCustomization(),
                new NoDataAnnotationsCustomization()));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
        {
        }
    }
}
