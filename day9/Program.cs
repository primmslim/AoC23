var lines = File.ReadAllLines("input.txt");

int[][] rows = lines.Select(l => l.Split(' ')
                                .Select(n => int.Parse(n)).ToArray())
                                .ToArray();

var (left, right) = rows.Select(r => (left:ExtrapolateLeft(r) ,right:ExtrapolateRight(r)))
                        .Aggregate((a,r) => (a.left + r.left, a.right + r.right));

Console.WriteLine($"Left total {left}\t Right total {right}");

static int ExtrapolateRight(int[] nums) => nums.All(n => n == 0) ?nums[0] : ExtrapolateRight(diffs(nums)) + nums[^1];

static int ExtrapolateLeft(int[] nums) => nums.All(n => n==0) ? nums[0] :  nums[0] - ExtrapolateLeft(diffs(nums)) ;

static int[] diffs(int[] nums) =>  nums[..^1] 
                                        .Select((n,i) =>  nums[i+1] - n )
                                        .ToArray();
