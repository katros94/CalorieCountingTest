using System;
using System.Collections.Generic;
using System.IO;

// https://adventofcode.com/2022/day/1

class Program
{
    static List<int> currentElfCaloriesFood = new List<int>();

    static void Main(string[] args)
    {
        string filename = "C:\\Users\\katri\\source\\repos\\Advent-Code-Test\\ElfsFoodCalorieList.txt";
        (int elfNumber, int maxCalories, List<int> maxCaloriesFood) = FindElfWithMaxCalories(filename);
        Console.WriteLine($"Elf {elfNumber} is carrying the most Calories: {maxCalories}");
        Console.WriteLine($"Food items carried by Elf {elfNumber}:");
        foreach (int food in maxCaloriesFood)
        {
            Console.WriteLine(food);
        }
    }

    static (int, int, List<int>) FindElfWithMaxCalories(string filename)
    {
        int maxCalories = 0;
        int currentElfCalories = 0;
        int elfNumber = 0;
        int maxCaloriesElfNumber = 0;
        List<int> maxCaloriesFood = new List<int>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    if (currentElfCalories > maxCalories)
                    {
                        maxCalories = currentElfCalories;
                        maxCaloriesElfNumber = elfNumber;
                        maxCaloriesFood = new List<int>(currentElfCaloriesFood); 
                    }
                    currentElfCalories = 0; 
                    elfNumber++; 
                    currentElfCaloriesFood.Clear();
                }
                else
                {
                    currentElfCalories += int.Parse(line);
                    currentElfCaloriesFood.Add(int.Parse(line));
                }
            }

            if (currentElfCalories > maxCalories)
            {
                maxCalories = currentElfCalories;
                maxCaloriesElfNumber = elfNumber;
                maxCaloriesFood = new List<int>(currentElfCaloriesFood);
            }
        }

        return (maxCaloriesElfNumber, maxCalories, maxCaloriesFood);
    }
}
