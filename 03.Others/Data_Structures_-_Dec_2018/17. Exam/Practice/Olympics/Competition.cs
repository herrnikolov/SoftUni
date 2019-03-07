using System.Collections.Generic;

public class Competition
{
    public Competition(string name, int id, int score)
    {
        this.Name = name;
        this.Id = id;
        this.Score = score;

    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Score { get; set; }

    public ICollection<Competitor> Competitors { get; set; }

    public void AddCompetitor(Competitor competitor)
    {
        competitor.TotalScore = competitor.TotalScore + this.Score;
        this.Competitors.Add(competitor);
    }

    public bool Disqualify(Competitor competitor)
    {
        bool isSuccess = this.Competitors.Remove(competitor);
        if (isSuccess)
        {
            competitor.TotalScore = competitor.TotalScore - this.Score;
        }
        return isSuccess;
    }
}
