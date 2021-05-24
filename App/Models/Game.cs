using System;
using System.Linq;
using System.Collections.Generic;

namespace golfcard.Models
{
  class Game
  {
    List<Player> Golfers { get; set; }
    List<Course> Courses { get; set; }

    List<int> Eachpar { get; set; }

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
            Player newPlayer = new Player(name, Eachpar);
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
      for (int i = 1; i < current.Pars.Count; i++)
      {
        Console.Write($"Hole: {i}\n");
        for (int x = 0; x < Golfers.Count; x++)
        {
          Console.Write($"Strokes for {Golfers[x].Name}: ");
          string strokes = Console.ReadLine();
          Golfers[x].EachPar.Add(Int32.Parse(strokes));
        }
        Console.Clear();
      }
    }

    public void WrapUp()
    {
      string list = "";
      Console.WriteLine(@$"{current.Name}");
      Console.Write($"Par:      {list}");
      for (int i = 0; i < current.Pars.Count; i++)
      {
        list += $"{current.Pars[i]}  ";
      }
      for (int x = 0; x < Golfers.Count; x++)
      {
        string list2 = "";
        for (int y = 0; y < Golfers[x].EachPar.Count; y++)
        {
          list2 += $"{Golfers[x].EachPar[y]}  ";
        }
        Console.WriteLine($"{Golfers[x].Name}:  {list2}");
      }
      Console.WriteLine(@$"

      Course Par: {current.TotalPar}");
      for (int z = 0; z < Golfers.Count; z++)
      {
        Golfers[z].TotalScore = Golfers[z].StrokeTotal();
        Console.Write($"{Golfers[z].Name}: {Golfers[z].TotalScore}");
      }
    }
    public Game()
    {
      current = new Course("", new List<int> { });
      Eachpar = new List<int>() { };
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