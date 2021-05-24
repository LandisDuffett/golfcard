using System;
using System.Linq;
using System.Collections.Generic;

namespace golfcard.Models
{
  class Game
  {
    List<Player> Golfers { get; set; }
    List<Course> Courses { get; set; }
    List<Player> Ties { get; set; }
    public Course current { get; set; }

    public void PrintCourses()
    {
      for (int i = 0; i < Courses.Count; i++)
      {
        Console.WriteLine((i + 1) + ". " + Courses[i].Name);
      }
    }
    public void SelectCourse(string index)
    {
      if (Int32.TryParse(index, out int i))
      {
        i = i - 1;
        if (i > -1 && i < Courses.Count)
        {
          current = Courses[i];
          NewPlayers();
        }
        else
        {
          Console.WriteLine("Invalid selection.");
          SelectCourse(index);
        }
      }
      else
      {
        Console.WriteLine("Invalid selection.");
        SelectCourse(index);
        ;
      }
    }
    public void NewPlayers()
    {
      Console.WriteLine("Number of players? (maximum = 4): ");
      string playnum = Console.ReadLine();
      if (Int32.TryParse(playnum, out int i))
      {
        if (i > 0 && i < 5)
        {
          for (int x = 0; x < i; x++)
          {
            Console.WriteLine($"Player {x + 1} Name: ");
            string name = Console.ReadLine();
            string newName = "";
            Player newPlayer = new Player(name, newName, new List<int> { });
            Golfers.Add(newPlayer);
          }
        }
        else
        {
          Console.WriteLine("Please enter a number between 1 and 4");
          NewPlayers();
        }
      }
      else
      {
        Console.WriteLine("Please enter a number between 1 and 4");
        NewPlayers();
      }
    }
    public void HoleByHole()
    {
      for (int i = 1; i <= current.Pars.Count; i++)
      {
        Console.Clear();
        Console.Write($"Hole: {i}\n");
        for (int x = 0; x < Golfers.Count; x++)
        {
          Console.Write($"Strokes for {Golfers[x].Name}: ");
          string strokes = Console.ReadLine();
          while (Int32.TryParse(strokes, out int strokeno))
          {
            Golfers[x].EachPar.Add(strokeno);
          }
        }
        Console.Clear();
      }
    }

    public void WrapUp()
    {
      string list = "";
      Console.Clear();
      Console.WriteLine(@$"{current.Name}");
      for (int i = 0; i < current.Pars.Count; i++)
      {
        list += $"{current.Pars[i]}  ";
      }
      Console.Write($"Par:      {list}\n");
      for (int x = 0; x < Golfers.Count; x++)
      {
        string list2 = "";
        for (int y = 0; y < Golfers[x].EachPar.Count; y++)
        {
          list2 += $"{Golfers[x].EachPar[y]}  ";
        }
        if (Golfers[x].Name.Count() > 7)
        {
          string newName = "";
          for (int b = 0; b < 7; b++)
          {
            newName += Golfers[x].Name[b];
          }
          Golfers[x].NewName = newName;
        }
        switch (Golfers[x].Name.Count())
        {
          case > 7:
            Console.WriteLine($"{Golfers[x].NewName}:  {list2}");
            break;
          case 7:
            Console.WriteLine($"{Golfers[x].Name}:  {list2}");
            break;
          case 6:
            Console.WriteLine($"{Golfers[x].Name}:   {list2}");
            break;
          case 5:
            Console.WriteLine($"{Golfers[x].Name}:    {list2}");
            break;
          case 4:
            Console.WriteLine($"{Golfers[x].Name}:     {list2}");
            break;
          case 3:
            Console.WriteLine($"{Golfers[x].Name}:      {list2}");
            break;
          case 2:
            Console.WriteLine($"{Golfers[x].Name}:       {list2}");
            break;
          case 1:
            Console.WriteLine($"{Golfers[x].Name}:        {list2}");
            break;
        }
      }
      Console.WriteLine(@$"
Course Par: {current.TotalPar}");
      for (int z = 0; z < Golfers.Count; z++)
      {
        Golfers[z].TotalScore = Golfers[z].StrokeTotal();
        Console.Write($"{Golfers[z].Name}: {Golfers[z].TotalScore}\n");
      }

      Player win = Golfers[0];
      for (int c = 1; c < Golfers.Count; c++)
      {
        if (Golfers[c].TotalScore < win.TotalScore)
        {
          win = Golfers[c];
        }
      }
      Ties = Golfers.FindAll(g => g.TotalScore == win.TotalScore);
      if (Ties.Count > 1)
      {
        string tieList = "";
        for (int d = 0; d < Ties.Count; d++)
        {
          tieList += $"{Ties[d].Name} ";
        }
        Console.WriteLine($"Winners: {tieList}");
      }
      else
      {
        Console.WriteLine($"Winner: {win.Name}");
      }
    }

    public void Reset()
    {
      Golfers.Clear();
      return;
    }
    public Game()
    {
      Ties = new List<Player>()
      {

      };
      current = new Course("", new List<int> { });
      Courses = new List<Course>(){
        new Course("Mini PutPut", new List<int>{3, 5, 3, 2, 5, 4, 4, 2, 4, 3, 5, 7} ),
        new Course("Fox Hill Executive Course", new List<int>{3, 3, 4, 4, 3, 5, 4, 4, 3}),
        new Course("Rivers Canyon", new List<int>{3, 3, 4, 4, 3, 5, 5, 4, 3, 4, 4, 3, 3, 4, 5, 4, 4, 3})
      };
      Golfers = new List<Player>()
      {

      };
    }
  }
};