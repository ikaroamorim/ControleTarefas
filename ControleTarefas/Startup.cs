using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ControleTarefas.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ControleTarefas
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
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGet("/", HomeFunctions.ExibeHome);
        endpoints.MapPost("/Aluno/Cadastrar", AlunoFunctions.CadastraAlunoQuery);
        endpoints.MapGet("/Aluno", AlunoFunctions.ExibeAlunos);
        endpoints.MapGet("/Aluno/Form", AlunoFunctions.ExibeFormularioAluno);

        endpoints.MapGet("/Aluno/Consulta/{id:int}", AlunoFunctions.ConsultaAlunoId);
        

        

      });
      /*
            app.UseEndpoints(endpoints =>
            {
              endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
              endpoints.MapControllerRoute(
                        name: "exibeAluno",
                        pattern: "/Aluno"
                );
            });
      */
    }

  












  }
}
