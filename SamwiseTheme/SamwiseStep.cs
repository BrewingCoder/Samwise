using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;

namespace SamwiseTheme
{
    public class SamwiseStep : IRecipeStepHandler
    {
        private readonly ILogger _logger;

        public SamwiseStep(ILogger<SamwiseStep> logger)
        {
            _logger = logger;
        }
        
        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            _logger.Log(LogLevel.Critical,"SamwiseStep.ExecuteAsync");
            var y = context;
        }
    }
}