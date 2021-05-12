// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable ConvertToUsingDeclaration
using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json.Linq;
using OrchardCore.Data;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;
using OrchardCore.Settings;

namespace SamwiseTheme.Recipes.StepHandlers
{
    public class DirectSqlStep : IRecipeStepHandler
    {
        private readonly ISiteService _siteService;
        private readonly IDbConnectionAccessor _dbAccessor;

        public DirectSqlStep(ISiteService siteService,IDbConnectionAccessor dbAccessor)
        {
            _siteService = siteService;
            _dbAccessor = dbAccessor;
        }
        
        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            if (!string.Equals(context.Name, "DirectSQL", StringComparison.OrdinalIgnoreCase)) return;

            var siteSettings = await _siteService.LoadSiteSettingsAsync();

            var environSettings = new JArray(context.Environment);

            siteSettings.Properties["DatabaseProvider"] = environSettings["DatabaseProvider"]?.ToString();
            siteSettings.Properties["DatabaseConnectionString"] = environSettings["DatabaseConnectionString"]?.ToString();
            siteSettings.Properties["DatabaseTablePrefix"] = environSettings["DatabaseTablePrefix"]?.ToString();

            await _siteService.UpdateSiteSettingsAsync(siteSettings);
            
            var model = context.Step.ToObject<DirectSqlModel>();
            if (model != null)
                foreach (var jToken in model.Statements)
                {
                    var token = (JObject) jToken;
                    await using (var connection = _dbAccessor.CreateConnection())
                    {
                        await connection.OpenAsync();
                        await using (var transaction = await connection.BeginTransactionAsync())
                        {
                            await connection.ExecuteAsync(token["Script"]?.ToString(), null, transaction, 30, CommandType.Text);
                            await transaction.CommitAsync();
                        }
                        await connection.CloseAsync();
                    }
                }
        }
    }

    public class DirectSqlModel
    {
        public JArray Statements { get; set; }
    }
}