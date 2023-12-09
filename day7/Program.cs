
var TypesToRank = new Dictionary<char,char>(){
    {'A','A'},
    {'K','B'},
    {'Q','C'},
    {'T','E'},
    {'9','F'},
    {'8','G'},
    {'7','H'},
    {'6','I'},
    {'5','J'},
    {'4','K'},
    {'3','L'},
    {'2','M'},
    {'J','O'}
};

var hands = new List<(string hand,int bid, int handStrength, string typeString)>();
var lines = File.ReadAllLines("test.txt");
foreach (string line in lines)
{
    string hand = line.Split(' ')[0];
    int bid = int.Parse(line.Split(' ')[1]);
    int handStrength = GetHandStrength(hand);
    string typeStrength = GetTypeString(hand,TypesToRank);
    hands.Add((hand,bid,handStrength,typeStrength));

}


//rank the hands

var ranked = hands.OrderBy(h => h.handStrength).ThenByDescending(h => h.typeString).ToList();
int total = 0;
for (int i = 0; i < ranked.Count; i++)
{
    int handTotal = ranked[i].bid * (i+1);
    total += handTotal;
}


hands.ForEach(h => {
    System.Console.WriteLine($"Hand {h.hand}\tHandStrength {h.handStrength}\tTypeStrength {h.typeString}");
});
System.Console.WriteLine(total);


static string GetTypeString(string hand, dynamic typesDict){

    var result = hand.ToCharArray().Select(c => (char) typesDict[c]).ToArray();
    return new string(result);

}


static int GetHandStrength(string hand){

    var types = hand.ToCharArray()
                    .ToList()
                    .GroupBy(h => h)
                    .Select(group => new {
                        hand = group.Key,
                        count = group.Count()
                    })
                    .ToList();

    //check for 5 of a kind 
    if (types.Count == 1) return 7;

    //check for 4 of a kind
    if (types.Any(t => t.count == 4)) return 6;

    //check for full house

    if (types.Any(t => t.count == 2) && types.Any(t => t.count == 3)) return 5;

    //check for 3 of a kind

    if (types.Any(t=> t.count == 3) && types.Where(t => t.count == 1).Count() == 2) return 4;

    //cehck for 2 pair

    if (types.Where(t => t.count == 2).Count() == 2) return 3;

    // 1 pair or all same
    return types.Max(t => t.count);

}





