using System;
using System.Linq;
using System.Collections.Generic;

namespace golfcard.Models
{
  class Course
  {
    public List<int> Pars { get; set; }
    public string Name { get; set; }
    public int TotalPar { get; set; }
    public int Length { get; set; }

    public Course(string name, List<int> pars)
    {
      Name = name;
      Pars = pars;
      Length = Pars.Count();
      TotalPar = (from num in Pars select num).Sum();
    }
  }
}

