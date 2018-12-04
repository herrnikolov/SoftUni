using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
        this.Name = name;
    }

    public List<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }

    public List<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }

    public override string ToString()
    {
        return $"First team has {this.FirstTeam.Count} players. {Environment.NewLine}Reserve team has {this.ReserveTeam.Count} players.";
    }


}

