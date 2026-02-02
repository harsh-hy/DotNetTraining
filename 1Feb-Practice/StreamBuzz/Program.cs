using System;                       // For console input/output
using System.Collections.Generic;   // For List and Dictionary
using System.Linq;                  // For LINQ operations like Count()

// ================================
// CLASS: CreatorStats
// Purpose: Stores creator engagement data
// ================================
public class CreatorStats
{
    // Property to store creator's name
    public string CreatorName { get; set; }

    // Array to store weekly likes (Week 1 to Week 4)
    public double[] WeeklyLikes { get; set; }

    // Static list to store all registered creators
    // Shared across the application
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}

// ================================
// CLASS: Program
// Purpose: Application logic and menu handling
// ================================
public class Program
{
    // ================================
    // METHOD: RegisterCreator
    // Purpose: Adds creator record to EngagementBoard
    // ================================
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    // ================================
    // METHOD: GetTopPostCounts
    // Purpose:
    // Returns number of weeks where likes >= threshold for each creator
    // ================================
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        // Dictionary to store creator name and count of top-performing weeks
        Dictionary<string, int> result = new Dictionary<string, int>();

        // Iterate through each creator record
        foreach (CreatorStats creator in records)
        {
            // Count weeks where likes meet or exceed threshold
            int count = creator.WeeklyLikes.Count(like => like >= likeThreshold);

            // Add to dictionary only if at least one top-performing week exists
            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        // Return final result dictionary
        return result;
    }

    // ================================
    // METHOD: CalculateAverageLikes
    // Purpose: Calculates average likes across all creators and weeks
    // ================================
    public double CalculateAverageLikes()
    {
        // If no creators are registered, return 0
        if (CreatorStats.EngagementBoard.Count == 0)
            return 0;

        double totalLikes = 0;   // Stores sum of all likes
        int totalWeeks = 0;      // Counts total number of weeks

        // Loop through each creator
        foreach (CreatorStats creator in CreatorStats.EngagementBoard)
        {
            // Loop through weekly likes
            foreach (double like in creator.WeeklyLikes)
            {
                totalLikes += like;
                totalWeeks++;
            }
        }

        // Return average likes
        return totalLikes / totalWeeks;
    }

    // ================================
    // MAIN METHOD: Program Execution Starts Here
    // ================================
    public static void Main(string[] args)
    {
        Program program = new Program();   // Create Program object
        bool running = true;               // Controls menu loop

        // Menu-driven loop
        while (running)
        {
            // Display menu options
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            // Read user choice
            int choice = Convert.ToInt32(Console.ReadLine());

            // Switch-case for menu selection
            switch (choice)
            {
                // ================================
                // CASE 1: Register Creator
                // ================================
                case 1:
                    CreatorStats creator = new CreatorStats();

                    Console.WriteLine("Enter Creator Name:");
                    creator.CreatorName = Console.ReadLine();

                    // Initialize array for 4 weeks
                    creator.WeeklyLikes = new double[4];

                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        creator.WeeklyLikes[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    // Register creator
                    program.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                // ================================
                // CASE 2: Show Top Posts
                // ================================
                case 2:
                    Console.WriteLine("Enter like threshold:");
                    double threshold = Convert.ToDouble(Console.ReadLine());

                    Dictionary<string, int> topPosts =
                        program.GetTopPostCounts(CreatorStats.EngagementBoard, threshold);

                    // If no creator meets threshold
                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        // Display creator name and count
                        foreach (var item in topPosts)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                    }
                    break;

                // ================================
                // CASE 3: Calculate Average Likes
                // ================================
                case 3:
                    double average = program.CalculateAverageLikes();
                    Console.WriteLine($"Overall average weekly likes: {average}");
                    break;

                // ================================
                // CASE 4: Exit Program
                // ================================
                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;
            }
        }
    }
}
