﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WearOutTCC_API.Models.ModelContext;
using Microsoft.EntityFrameworkCore;

namespace WearOutTCC_API
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
            services.AddDbContext<ClienteContext>(opt => opt.UseInMemoryDatabase("wearOut_TCC"));

            services.AddDbContext<FornecedorContext>(opt => opt.UseInMemoryDatabase("wearOut_TCC"));

            services.AddDbContext<NegociacaoContext>(opt => opt.UseInMemoryDatabase("wearOut_TCC"));

            services.AddDbContext<ProdutoContext>(opt => opt.UseInMemoryDatabase("wearOut_TCC"));

            services.AddDbContext<VendedorContext>(opt => opt.UseInMemoryDatabase("wearOut_TCC"));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
