using System;
using System.Linq;
using System.Collections.Generic;

namespace golfcard.Models
{
  class Player
  {
    public string Name { get; set; }
    public int TotalScore { get; set; }
    public int StrokeTotal()
    {
      int total = (from num in EachPar select num).Sum();
      return total;
    }
    public List<int> EachPar { get; set; }

    public Player(string name, List<int> eachpar)
    {
      Name = name;
      EachPar = eachpar;
      TotalScore = 0;
    }
  }
}
