using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrchardCore.Queries.Recipes;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;


namespace Samwise.Cms
{
    public class TestingStepModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public class TestingStep : IRecipeStepHandler
    {
        private readonly ILogger _logger;
        public TestingStep(ILogger<TestingStep> logger)
        {
            _logger = logger;
        }
        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            _logger.Log(LogLevel.Critical,"TestingStep.ExecuteAsync");
            //Never Gets Here
            if (!String.Equals(context.Name, "Testing", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            //Never Gets Here
            var model = context.Step.ToObject<TestingStepModel>();
        }
    }
}