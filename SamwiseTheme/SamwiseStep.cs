using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.Data;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;
using YesSql;

namespace SamwiseTheme
{
    public class SamwiseStep : IRecipeStepHandler
    {
        private readonly ILogger _logger;
        private readonly IDbConnectionAccessor _accessor;
        private readonly IStore _store;

        public SamwiseStep(ILogger<SamwiseStep> logger, IDbConnectionAccessor accessor, IStore store)
        {
            _logger = logger;
            _accessor = accessor;
            _store = store;
        }
        
        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            var z = _accessor.CreateConnection();

            _logger.Log(LogLevel.Critical,"SamwiseStep.ExecuteAsync");
            var y = context;
        }
    }
}