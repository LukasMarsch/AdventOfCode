public class Program {
    public static void Main() {
        StreamReader sr = new StreamReader("in.t");
        string line = sr.ReadLine();
        int res = 0;
        while(null != line) {
            string number = "";
            for(int i = 0; i < line.Length; i++) {
                if(line[i] <= '9' & line[i] >= '0') {
                    number += line[i];
                    i = Int32.MaxValue - 1;
                }
            }
            for(int i = line.Length - 1; i > 0; i--) {
                if(line[i] <= '9' & line[i] >= '0') {
                    number += line[i];
                    i = 0;
                }
            }
            int k = 0;
            if(!Int32.TryParse(number, out k)) {
                throw new SystemException($"Fehler in {number}");
            }
            res += k;
            line = sr.ReadLine();
        } 
        Console.WriteLine(">>>>>>>>>>>>>>>" + "\t" + res);
    }
}
