using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewWEB.Areas.Identity.Data;
using NewWEB.Models;

[assembly: HostingStartup(typeof(NewWEB.Areas.Identity.IdentityHostingStartup))]
namespace NewWEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NewWEBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NewWEBContextConnection")));

                services.AddDefaultIdentity<NewWEBUser>()
                    .AddEntityFrameworkStores<NewWEBContext>();
            });
        }
    }
}