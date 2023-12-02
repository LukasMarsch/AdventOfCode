package main;

import java.io.*;

public class First {

    public static int numberFromLine(String line) {
        int first = -1;
        int last = -1;
        char[] letters = line.toCharArray();

        for(int i = 0; i < letters.length; i++) {
            char letter = letters[i];
            char letterLast = letters[letters.length - i - 1];
            if(first < 0 && letterIsNumber(letter)) {
                first = letter - 48;
                if(last >= 0) {
                    break;
                }
            }
            if(last < 0 && letterIsNumber(letterLast)) {
                last = letterLast - 48;
                if(first >= 0) {
                    break;
                }
            }
        }

        return first * 10 + last;
    }

    private static boolean letterIsNumber(char letter) {
        return letter >= '0' && letter <= '9';
    }

    public static void main(String[] args) {
        try {
            long before2 = System.currentTimeMillis();
            BufferedReader br = new BufferedReader(new FileReader("./src/main/input1.txt"));
            System.out.println(br.lines().map(First::numberFromLine).mapToInt(Integer::intValue).sum());
            br.close();
            System.out.println(System.currentTimeMillis() - before2);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
