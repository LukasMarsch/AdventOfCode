using System.Text;

public class Program {
    static readonly string[] numstr = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    public static void Main() {
        StreamReader sr = new StreamReader("in.txt");
        string line = sr.ReadLine();
        StringBuilder number = new StringBuilder();
        int res = 0;
        while(null != line) {
            // find out which numbers are in there
            bool[] cont = new bool[9];
            Array.ForEach(cont, (x) => x = false);
            if(ContainsNumStr(line)) {
                for(int i = 0; i < numstr.Length; i++) {
                    if(line.Contains(numstr[i]))
                    {
                        cont[i] = true;
                    }
                    else
                        cont[i] = false;
                }
            }

            int[] numStrFound = TrueIndices(cont);
            //foreach character in the line
            bool haventFoundYet = true;
            for(int i = 0; i < line.Length && haventFoundYet; i++)
            {
                // check if it's a number
                if (line[i] >= '1' && line[i] <= '9')
                {
                    number.Append(line[i]);
                    haventFoundYet = false;
                }
                // or check if it's a number
                else
                {
                    // for each number we found in the line
                    foreach(int numWeFound in numStrFound)
                    {
                        bool mightStillBe = true;
                        
                        // for each letter in the number until it's not
                        for(int letter = 0; letter < numstr[numWeFound].Length & mightStillBe; letter++)
                        {
                            // is it?
                            if(i + letter < line.Length)
                            {
                               mightStillBe = numstr[numWeFound][letter] == line[i+letter];
                            }
                            else
                            {
                                mightStillBe = false;
                            }
                        }
                        // if it still is, it must be
                        if(mightStillBe)
                        {
                            // so add it
                            number.Append(numWeFound + 1);
                            // and we can break from the outerest loop
                            haventFoundYet = false;
                        }
                    }
                }
            }

            haventFoundYet = true;
            // for each number in reverser order
            for(int i = line.Length - 1; haventFoundYet &&  i >= 0; i--)
            {
                // check if it's a number
                if (line[i] >= '1' && line[i] <= '9')
                {
                    number.Append(line[i]);
                    haventFoundYet = false;
                }
                // or check if it's a number
                else
                {
                    // for each number we found in the line
                    foreach (int numWeFound in numStrFound)
                    {
                        // for each of its letters
                        bool mightStillBe = true;
                        for(int letter = 0; mightStillBe && letter < numstr[numWeFound].Length; letter++)
                        {
                            // check if they match
                            if(i+ letter < line.Length)
                                mightStillBe = numstr[numWeFound][letter] == line[i + letter];
                            else
                            {
                                mightStillBe = false;
                            }
                        }
                        // and if all do
                        if(mightStillBe)
                        {
                            // add and break out
                            number.Append(numWeFound + 1);
                            haventFoundYet = false;
                        }
                    }
                }
            }
            int t;
            Console.WriteLine(Int32.TryParse(number.ToString(), out t) ? t : $"Error parsing {t}");
            res += t; 
            number.Clear();
            line = sr.ReadLine();
        }
        Console.WriteLine($">>>>> {res}");
    }

    public static int[] TrueIndices(bool[] input)
    {
        List<int> correct = new List<int>();
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i])
            {
                correct.Add(i);
            }
        }
        return correct.ToArray();
    }

    public static bool ContainsNumStr(string line) {
        string[] zahlen = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        foreach(string zahl in zahlen) {
            if(line.Contains(zahl))
                return true;
        }
        return false;
    }

    public static void Teil1() {
        StreamReader sr = new StreamReader("in.t");
        string line = sr.ReadLine();
        int res = 0;
        StringBuilder number = new StringBuilder();
        while(null != line) {
            Console.WriteLine($"{line}");
            for(int i = 0; i < line.Length; i++) {
                if(line[i] <= '9' & line[i] >= '0') {
                    number.Append(line[i]);
                    Console.WriteLine($"{i}: {line[i]}");
                    i = Int32.MaxValue - 1;
                }
            }
            for(int i = line.Length - 1; i >= 0; i--) {
                if(line[i] <= '9' & line[i] >= '0') {
                    number.Append(line[i]);
                    Console.WriteLine($"{i}: {line[i]}");
                    i = -1;
                }
            }
            Console.WriteLine(number.ToString());
            int k = 0;
            if(!Int32.TryParse(number.ToString(), out k)) {
                throw new SystemException($"Fehler in {number}");
            }
            res += k;
            line = sr.ReadLine();
            number.Clear();
        } 
        Console.WriteLine(">>>>>>>>>>>>>>>" + "\t" + res);
    }
}
