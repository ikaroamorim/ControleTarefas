using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class HtmlUtils
  {
    public static string CarregaArquivoHtml(string nomearquivo)
    {
      var endereco = $"Pages/{nomearquivo}";
      using (var arquivo = File.OpenText(endereco))
      {
        return arquivo.ReadToEnd();
      }
    }
  }
}
