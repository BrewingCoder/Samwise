using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Modules;
using OrchardCore.Recipes;
using OrchardCore.ResourceManagement;

namespace SamwiseTheme
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
            serviceCollection.AddMvc();
            serviceCollection.AddRecipeExecutionStep<SamwiseStep>();
        }
    }
}
