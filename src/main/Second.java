package main;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class Second {

    private static int isPossible(String line) {
        String[] gameNumber = line.split(": ");
        String[] rounds = gameNumber[1].split("; ");
        Map<String, Integer> colors = new HashMap<>();
        colors.put("red", 0);
        colors.put("green", 0);
        colors.put("blue", 0);
        for (String round : rounds) {
/*
            colors.put("red", 12);
            colors.put("green", 13);
            colors.put("blue", 14);
*/
            String[] parts = round.split(" ");
            for (int i = 1; i < parts.length; i += 2) {
                int temp = Integer.parseInt(parts[i - 1]);
                String color = parts[i].replaceAll(",", "");
/*
                colors.put(color, colors.get(color) - temp);
                if (colors.get(color) < 0) {
                    return 0;
                }
*/
                if (colors.get(color) < temp) colors.put(color, temp);
            }
        }
//        return Integer.parseInt(gameNumber[0].split(" ")[1]);
        return colors.values().stream().mapToInt(Integer::intValue).reduce(1, (a, b) -> a * b);
    }

    public static void main(String[] args) {
        try {
            long before = System.currentTimeMillis();
            BufferedReader br = new BufferedReader(new FileReader("./src/main/input2.txt"));
            System.out.println(br.lines().map(Second::isPossible).mapToInt(Integer::intValue).sum());
            System.out.println("Execution Time: " + (System.currentTimeMillis() - before) + "ms");
            br.close();
            // 2.1 2076 - 11ms
            // 2.2 70950 - 13ms
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }

}
