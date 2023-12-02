package main;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class First {

    private static final String[] numbers = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

    public static int numberFromLine(String line) {
        int first = -1;
        int last = -1;
        char[] letters = line.toCharArray();

        for (int i = 0; i < letters.length; i++) {
            char letter = letters[i];
            char letterLast = letters[letters.length - i - 1];

            if (first < 0 && isNumber(letter)) {
                first = letter - 48;
            }
            if (last < 0 && isNumber(letterLast)) {
                last = letterLast - 48;
            }
            for (int j = 0; j < numbers.length; j++) {
                if (first < 0 && line.startsWith(numbers[j], i)) {
                    first = j + 1;
                }
                if (last < 0 && line.substring(0, letters.length - i).endsWith(numbers[j])) {
                    last = j + 1;
                }
            }
            if (first > 0 && last > 0) {
                break;
            }
        }

        return first * 10 + last;
    }

    private static boolean isNumber(char letter) {
        return (letter >= '0' && letter <= '9');
    }

    public static void main(String[] args) {
        try {
            long before2 = System.currentTimeMillis();
            BufferedReader br = new BufferedReader(new FileReader("./src/main/input1.txt"));
            System.out.println(br.lines().map(First::numberFromLine).mapToInt(Integer::intValue).sum());
            // 1.1 -> 54597 (5 ms)
            // 1.2 -> 54504 (12 ms)
            br.close();
            System.out.println(System.currentTimeMillis() - before2);
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
