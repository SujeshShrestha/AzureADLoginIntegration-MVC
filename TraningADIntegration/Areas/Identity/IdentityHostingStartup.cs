using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraningADIntegration.Data;

[assembly: HostingStartup(typeof(TraningADIntegration.Areas.Identity.IdentityHostingStartup))]
namespace TraningADIntegration.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TraningADIntegrationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TraningADIntegrationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TraningADIntegrationContext>();
            });
        }
    }
}