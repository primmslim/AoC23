using System.Runtime.ExceptionServices;

var lines = File.ReadAllLines(@"prod1.txt");


var cuebMax = new Dictionary<string,int>(){
    {"red",12},
    {"green",13},
    {"blue",14}
};


var badGames = new List<int>();
int totalPower = 0;


foreach(string line in lines){
    int gameNumber = int.Parse(line.Split(':')[0].Split(' ')[1]);
    string games = line.Split(':')[1];
    string[] rounds = games.Split(';');

        var roundTotals = new Dictionary<string,List<int>>(){
            {"red", new List<int>()},
            {"green", new List<int>()},
            {"blue", new List<int>()},
        };
    

    foreach(string round  in rounds){

        //3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        string[] hands = round.Split(',');
        foreach(string hand in hands){
            //3 blue, 4 red
            // 1 red, 2 green, 6 blue
            // 2 green
            foreach(string cubesResult in  hand.Split(',') ){
                int num = int.Parse(cubesResult.Trim().Split(' ')[0]);
                string col = cubesResult.Trim().Split(' ')[1];
                roundTotals[col].Add(num);
            }
        }


    }
    var maxes = roundTotals.Values.Select(l => l.Max());
    var power = maxes.Aggregate((i,v) => i * v );

    System.Console.WriteLine($"Game {gameNumber}: Power {power} Mins: {string.Join(',' , maxes) }");
    totalPower += power;
}

System.Console.WriteLine($"TotalPower: {totalPower}");



