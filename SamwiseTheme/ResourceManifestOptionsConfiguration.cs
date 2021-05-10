using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace SamwiseTheme
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("SamwiseTheme-bootstrap-oc")
                .SetUrl("~/SamwiseTheme/css/bootstrap-oc.min.css", "~/SamwiseTheme/css/bootstrap-oc.css")
                .SetVersion("1.0.0");

        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
