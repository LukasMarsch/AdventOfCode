using System.Text;
<<<<<<< HEAD

public class Program {
    static readonly string[] numstr = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
    public static void Main() {
        StreamReader sr = new StreamReader("in.t");
        string line = sr.ReadLine();
        StringBuilder number = new StringBuilder();
        while(null != line) {
            bool[] cont = new bool[9];
            if(ContainsNumStr(line)) {
                for(int i = 0; i < numstr.Length; i++) {
                    if(line.Contains(numstr[i]))
                        cont[i] = true;
                    else
                        cont[i] = false;
                }
            }

            //TODO: String matching zur index suche
            // for k = 0; k < cont.length; k++) {
            //      if(cont[k]){
            //           currZahl = numstr[k]
            //           für i = 0; i< length i++) {
            //               repeat = true;
            //               for(n = 0; repeat & n < numstr.Length; n++) {
            //                  repeat = numstr[n] == line[n+i];
            //               } 
            //                
            //           }
            //
            //      }
            // }

            line = sr.ReadLine();
        }
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
