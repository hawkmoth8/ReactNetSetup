using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using React.AspNet;

namespace ReactNetDemo
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
              // This lambda determines whether user consent for non-essential cookies is needed for a given request.
              options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddReact();

      // Make sure a JS engine is registered, or you will get an error!
      services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
        .AddChakraCore();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
              .AddRazorPagesOptions(options =>
              {
                options.Conventions.AddPageRoute("/Privacy", "/page2");
                options.Conventions.AddPageRoute("/Privacy", "/page1");
                //options.Conventions.AddPageRoute("/Privacy", "/Privacy");
              });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      // Initialise ReactJS.NET. Must be before static files.
      app.UseReact(config =>
      {
              // If you want to use server-side rendering of React components,
              // add all the necessary JavaScript files here. This includes
              // your components as well as all of their dependencies.
              // See http://reactjs.net/ for more information. Example:
              //config
              //  .AddScript("~/js/First.jsx")
              //  .AddScript("~/js/Second.jsx");

              // If you use an external build too (for example, Babel, Webpack,
              // Browserify or Gulp), you can improve performance by disabling
              // ReactJS.NET's version of Babel and loading the pre-transpiled
              // scripts. Example:
              config
                .SetLoadBabel(false)
                .AddScriptWithoutTransform("~/static/js/react.bundle.js");
      });

      //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
      //{
      //    HotModuleReplacement = true
      //});

      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc();
    }
  }
}
