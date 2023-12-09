var lines = File.ReadAllLines("data.txt");

int total = 0;
var games = new List<(int num,int plays, string data)>().ToArray();
Array.Resize(ref games,lines.Length);
for (int i = 0; i < lines.Length; i++)
{
    games[i] = new (i,1,lines[i]);
}


for (int i = 0; i < games.Length; i++)
{
    string gameData = games[i].data[(games[i].data.IndexOf(":")+2) ..];
    string[] winningNumbers = gameData.Split('|')[0].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
    string[] myNumbers = gameData.Split('|')[1].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

    int wins = myNumbers.Intersect(winningNumbers).Count();

    for (int j = 0; j < games[i].plays; j++)
    {
        for (int k = 0; k < wins; k++)
        {
            games[i+k+1].plays += 1;
        }
    }
}

System.Console.WriteLine(games.Sum(g => g.plays));