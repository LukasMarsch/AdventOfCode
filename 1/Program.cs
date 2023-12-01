using System.Text;
public class Program {
    public static void Main() {
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
