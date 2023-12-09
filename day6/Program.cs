
var testRaces = new List<(int time, int distance)>(){
    (time: 7, distance:9),
    (time: 15, distance:40),
    (time: 30, distance:200) 
};

// Time:        48     87     69     81
// Distance:   255   1288   1117   1623


var prodRaces = new List<(int time, int distance)>(){
    (time: 48, distance:255),
    (time: 87, distance:1288),
    (time: 69, distance:1117) ,
    (time: 81, distance:1623) 
};

// Time:        48     87     69     81
// Distance:   255   1288   1117   1623


var test2 = new List<(long time, long distance)>(){
    (time: 71530, distance:940200
    )
};

var prod2 = new List<(long time, long distance)>(){
    (time: 48876981, distance:255128811171623)
};

var totalWays = new List<int>();
foreach(var race in prod2){
    long lowerBound = 0;
    long upperBound = 0;
    for (long i = 0; i < race.time; i++)
    {
        if (CalcWin(i,race.time,race.distance) > 0){
            lowerBound = i-1;
            break;

        }
    }
    for (long i = race.time; i > 0; i--)
    {
        if (CalcWin(i,race.time,race.distance) > 0){
            upperBound = i;
            break;

        }
    }
    System.Console.WriteLine($"lower {lowerBound} upper {upperBound} ways {upperBound - lowerBound}");;
} 




static long CalcWin(long holdTime, long recordTime, long recordDistance) {
    long moveTime =  recordTime - holdTime;
    long  travelDistance = moveTime * holdTime;

    return (travelDistance > recordDistance) ? travelDistance - recordDistance : 0;
} 
