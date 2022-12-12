using Newtonsoft.Json;

public class Program
{
    public static  void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals =  GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int GetTotalScoredGoals(string team, int year)
    {
        var root =  Questao2.ApiClient.TeamClientApi.GetTeamAsync(year, team).Result;
        int totalTime1 = 0;
        int totalTime2 = 0;

        if (root.data != null && root.data.Any())
        {
            totalTime1 = (from obj in root.data where obj.team1 == team select obj.team1goals).Sum();
            totalTime2 = (from obj in root.data where obj.team2 == team select obj.team2goals).Sum();

        }
        if (totalTime1 > 0)
            return totalTime1;

        return totalTime2;
    }

}