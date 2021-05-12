using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Modules;
using OrchardCore.Recipes;
using OrchardCore.ResourceManagement;
using SamwiseTheme.Recipes.StepHandlers;

namespace SamwiseTheme
{
    public class Startup : StartupBase
    {
        private readonly AdminOptions _adminOptions;

        public Startup(IOptions<AdminOptions> adminOptions)
        {
            _adminOptions = adminOptions.Value;
        }

        public override void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
            serviceCollection.AddRecipeExecutionStep<DirectSqlStep>();
            serviceCollection.AddMvc();
            
        }
    }
}
