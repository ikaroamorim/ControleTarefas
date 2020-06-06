using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class AlunoFunctions
  {
    public static Task ExibeFormularioAluno(HttpContext context)
    {
      var html = HtmlUtils.CarregaArquivoHtml("AddAlunoForm.html"); ;
      return context.Response.WriteAsync(html);
    }

    //Implementar utilizacao do html
    public static Task ConsultaAlunoId(HttpContext context)
    {
      TarefaDAOEntity dao = new TarefaDAOEntity();
      int id = Convert.ToInt32(context.GetRouteValue("id"));
      var aluno = dao.Alunos().First(l => l.Id == id);
      return context.Response.WriteAsync(aluno.ToString());
    }

    public static Task CadastraAlunoQuery(HttpContext context)
    {
      Aluno a1 = new Aluno();
      //Quando a query era passda na url
      //a1.Nome = context.Request.Query["nome"].First().ToString();
      //Usando o metodo POST no formulario
      a1.Nome = context.Request.Form["nome"].First().ToString();

      TarefaDAOEntity dao = new TarefaDAOEntity();
      dao.AdicionaraAluno(a1);
      return context.Response.WriteAsync(a1.ToString());
    }

    public static Task ExibeAlunos(HttpContext context)
    {
      var _repo = new TarefaDAOEntity();
      var alunos = _repo.Alunos();
      var html = HtmlUtils.CarregaArquivoHtml("ListarAluno.html"); ;
      foreach (var item in alunos)
      {
        html = html.Replace("#ListAluno#", $"<li>{item.ToString()}</li>#ListAluno#");
      }
      html = html.Replace("#ListAluno#", "");
      return context.Response.WriteAsync(html);
    }


  }
}
