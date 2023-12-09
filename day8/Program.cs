var lines = File.ReadAllLines("prod.txt");

var directions = lines[0].ToCharArray();

var coords = new List<(string pos, (string left, string right) dirs)>();

for (int i = 2; i < lines.Length; i++)
{
    string line = lines[i];
    string pos = line[0..3];
    string coordsString = line[(line.IndexOf("(")+1)..line.IndexOf(")")];
    coords.Add((pos:pos, (left: coordsString.Split(',')[0].Trim(),  right:coordsString.Split(',')[1].Trim() )));
}


var currentPos = coords.Single(p => p.pos == "AAA");
int loops = 0;



while (currentPos.pos != "ZZZ")
{
    for (int i = 0; i < directions.Count(); i++)
    {
        char direction = directions[i];
        if (direction == 'L'){
            currentPos = coords.Single(c => c.pos == currentPos.dirs.left);
        }else{
            currentPos = coords.Single(c => c.pos == currentPos.dirs.right);
        }


        if (currentPos.pos == "ZZZ") {
            System.Console.WriteLine(i+1 + loops);
            break;
        }
    }
    
    loops += directions.Count();

}