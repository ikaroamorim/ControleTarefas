using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class HomeFunctions
  {
    public static Task ExibeHome(HttpContext context)
    {
      var html = HtmlUtils.CarregaArquivoHtml("Home.html"); ;
      return context.Response.WriteAsync(html);
    }

  }
}
