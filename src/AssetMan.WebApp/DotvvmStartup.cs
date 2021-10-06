using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace AssetMan.WebApp
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("AssetList", "asset/danh-sach-tai-san", "Views/AssetMan/AssetList.dothtml");           
            config.RouteTable.Add("AssetDetail", "asset/chi-tiet-tai-san/{id?}", "Views/AssetMan/AssetDetail.dothtml");
            config.RouteTable.Add("AssetEdit", "asset/sua-tai-san/{id?}", "Views/AssetMan/AssetEdit.dothtml");
            config.RouteTable.Add("AssetCreate", "asset/them-tai-san", "Views/AssetMan/AssetCreate.dothtml");
            //Location:
            config.RouteTable.Add("LocationList", "asset/danh-sach-vi-tri", "Views/AssetMan/LocationList.dothtml");
            config.RouteTable.Add("LocationDetail", "asset/chi-tiet-vi-tri/{id?}", "Views/AssetMan/LocationDetail.dothtml");
            config.RouteTable.Add("LocationEdit", "asset/sua-vi-tri/{id?}", "Views/AssetMan/LocationEdit.dothtml");
            config.RouteTable.Add("LocationCreate", "asset/them-vi-tri", "Views/AssetMan/LocationCreate.dothtml");
            //contact:
            config.RouteTable.Add("ContactList", "asset/danh-sach-lien-he", "Views/AssetMan/ContactList.dothtml");
            config.RouteTable.Add("ContactDetail", "asset/chi-tiet-lien-he/{id?}", "Views/AssetMan/ContactDetail.dothtml");
            config.RouteTable.Add("ContactEdit", "asset/sua-lien-he/{id?}", "Views/AssetMan/ContactEdit.dothtml");
            config.RouteTable.Add("ContactCreate", "asset/them-lien-he", "Views/AssetMan/ContactCreate.dothtml");

            config.RouteTable.Add("CategoryList", "asset/danh-sach-danh-muc", "Views/AssetMan/CategoryList.dothtml");
            config.RouteTable.Add("CategoryEdit", "asset/sua-danh-muc/{id?}", "Views/AssetMan/CategoryEdit.dothtml");
            config.RouteTable.Add("CategoryCreate", "asset/them-danh-muc", "Views/AssetMan/CategoryCreate.dothtml");
            //Gốc:
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("bootstrap-css", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/css/bootstrap.min.css")
            });
            config.Resources.Register("bootstrap", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/bootstrap/js/bootstrap.min.js"),
                Dependencies = new[] { "bootstrap-css" , "jquery" }
            });
            config.Resources.Register("jquery", new ScriptResource
            {
                Location = new UrlResourceLocation("~/lib/jquery/jquery.min.js")
            });
			config.Resources.Register("Styles", new StylesheetResource()
            {
                Location = new UrlResourceLocation("~/styles.css")
            });
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
		
            options.AddBusinessPack();
            options.AddDefaultTempStorages("temp");
		}
    }
}
