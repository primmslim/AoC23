using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("p1.txt");

var Parts = new List<(int row, int col, string val)>();


for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];
    //get nums
    foreach(Match match in Regex.Matches(line,@"([^\w^\.])|([0-9]*)")){
        if (match.Length>0)
            Parts.Add((row:i, col: match.Index, val: match.Value));
    }
}

var symbols = Parts.Where(p => !p.val.All(c => char.IsNumber(c)));

// abcd      --case 1 
//    efgh
// ab
//       vas   --case 2

var MatchingParts = new List<(int row, int col, string val)>();
var Gears = new List<(int row, int col, string val)>();
int totalPower = 0;

foreach(var symbol in symbols){
    var matchesToSymbol = Parts.Where(p => 
    p.row >= symbol.row -1 && //row below
    p.row <= symbol.row +1 && //row above
    p.col + p.val.Length -1 >= symbol.col -1 && //case 1
    p.col  <= symbol.col  + 1 // case 2
    ).Where(m => !symbols.Select(s => s.val)
                            .Contains(m.val));

    foreach (var match in matchesToSymbol)
    {
        if (!MatchingParts.Contains(match))
            MatchingParts.Add(match);
    }
        //check if gear with 2 non symbol matches
        if (symbol.val.Equals("*") && matchesToSymbol.Count() == 2){
            int ratio = matchesToSymbol.Select(m => int.Parse(m.val))
                                    .Aggregate((a,m) =>  a * m);
            totalPower += ratio;
        }
    
}

int total = MatchingParts.Sum(m => int.Parse(m.val));


System.Console.WriteLine(total);
System.Console.WriteLine(totalPower);




