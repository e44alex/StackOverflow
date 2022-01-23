using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackOverflow.Areas.Identity;
using StackOverflow.Models;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace StackOverflow.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    context.Configuration.GetConnectionString("IdentityAppContextConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
        });
    }
}