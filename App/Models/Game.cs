using System;
using System.Linq;
using System.Collections.Generic;

namespace golfcard.Models
{
  class Game
  {
    List<Hole> Course { get; set; }
    public string Name { get; set; }
    public int TotalPar { get; set; }
    public int Length { get; set; }

    public Game(string name, int Length, int TotalPar)
    {
      Name = name;
      Course = new List<Hole>();
      Length = Course.Count();
      TotalPar = (from num in Course select num.Par).Sum();
    }
  }
}
