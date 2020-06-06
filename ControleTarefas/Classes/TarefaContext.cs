using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleTarefas.Classes
{
  public class TarefaContext : DbContext, IDisposable
  {
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Tarefa> Tarefa { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server= (localdb)\\MSSQLLocalDB;Database=TarefasDB;Trusted_Connection=true;");
    }
  }
}
