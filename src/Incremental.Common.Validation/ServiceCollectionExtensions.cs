using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Incremental.Common.Validation
{
    /// <summary>
    /// Extensions for adding validation resources.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds validation pipelines and services to the application.
        /// </summary>
        /// <param name="mvcBuilder"><see cref="IMvcBuilder"/>.</param>
        /// <param name="assemblies">Assembly or assemblies containing validators.</param>
        /// <returns><see cref="IMvcBuilder"/></returns>
        public static IMvcBuilder AddCommonValidation(this IMvcBuilder mvcBuilder, params Assembly[] assemblies)
        {
            return mvcBuilder.AddFluentValidation(
                options =>
                {
                    options.RegisterValidatorsFromAssemblies(assemblies);
                });
        }

    }
}