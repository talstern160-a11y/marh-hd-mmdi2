
using System;


class Program
{
    static void Main()
    {
        main2();
    }
    static void Main2()
    {
        // 1. קליטת גודל המערך המקורי
        Console.WriteLine("הכנס את גודל המערך N:");
        int n = int.Parse(Console.ReadLine());

        int[] original = new int[n];
        int[] evens = new int[n];    // מערך למספרים זוגיים
        int[] negatives = new int[n]; // מערך למספרים שליליים

        // 2. קליטת המספרים למערך המקורי
        Console.WriteLine($"הכנס {n} מספרים שלמים:");
        for (int i = 0; i < n; i++)
        {
            original[i] = int.Parse(Console.ReadLine());
        }

        // 3. משתנים שיספרו כמה איברים הכנסנו לכל מערך חדש
        int evenCount = 0;
        int negCount = 0;

        // 4. מעבר על המערך המקורי ומיון לפי התנאים
        for (int i = 0; i < n; i++)
        {
            // בדיקה אם זוגי
            if (original[i] % 2 == 0)
            {
                evens[evenCount] = original[i];
                evenCount++;
            }

            // בדיקה אם שלילי
            if (original[i] < 0)
            {
                negatives[negCount] = original[i];
                negCount++;
            }
        }

        // 5. הדפסת המערכים

        // הדפסת המערך המקורי
        Console.WriteLine("\nהמערך המקורי:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(original[i] + " ");
        }

        // הדפסת המערך הזוגי 
        Console.WriteLine("\n\nמערך המספרים הזוגיים:");
        for (int i = 0; i < evenCount; i++)
        {
            Console.Write(evens[i] + " ");
        }

        // הדפסת המערך השלילי
        Console.WriteLine("\n\nמערך המספרים השליליים:");
        for (int i = 0; i < negCount; i++)
        {
            Console.Write(negatives[i] + " ");
        }

        Console.WriteLine();
    }

    static void main1()
    {
        Console.WriteLine("הכנס את גודל המערך N:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("הכנס את גודל המערך השני M:");
        int m = int.Parse(Console.ReadLine());
        while (m == n)
        {
            Console.WriteLine("אסור למערכים להיות זהים");
            Console.WriteLine("תבחר גודל שונה");
            m = int.Parse(Console.ReadLine());
        }
        int[] original = new int[n];
        int[] secondArray = new int[m];
        Console.WriteLine($"הכנס {n} מספרים שלמים:");
        for (int i = 0; i < n; i++)
        {
            original[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine($"הכנס {m} מספרים שלמים:");
        for (int i = 0; i < m; i++)
        {
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        // ✅ 1. ספירת איברים משותפים (ללא כפילויות)
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            bool existsInSecond = false;
            for (int j = 0; j < m; j++)
            {
                if (original[i] == secondArray[j])
                {
                    existsInSecond = true;
                    break;
                }
            }

            bool alreadyCounted = false;
            for (int k = 0; k < i; k++)
            {
                if (original[i] == original[k])
                {
                    alreadyCounted = true;
                    break;
                }
            }

            if (existsInSecond && !alreadyCounted)
            {
                count++;
            }
        }

        int[] commonArray = new int[count];
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            bool existsInSecond = false;
            for (int j = 0; j < m; j++)
            {
                if (original[i] == secondArray[j])
                {
                    existsInSecond = true;
                    break;
                }
            }

            bool alreadyAdded = false;
            for (int k = 0; k < i; k++)
            {
                if (original[i] == original[k])
                {
                    alreadyAdded = true;
                    break;
                }
            }

            if (existsInSecond && !alreadyAdded)
            {
                commonArray[index] = original[i];
                index++;
            }
        }


        Console.WriteLine("המערך החדש עם האיברים המשותפים:");
        for (int i = 0; i < commonArray.Length; i++)
        {
            Console.Write(commonArray[i] + " ");
        }

    }


    static void main2()
    {
        Console.WriteLine("הכנס את מספר הפרחים בערוגה המקורית (N):");
        int n = int.Parse(Console.ReadLine());

        int[] flw1 = new int[n];

        Console.WriteLine($"הכנס {n} קודים של פרחים (בני 3 ספרות):");
        for (int i = 0; i < n; i++)
        {
            flw1[i] = int.Parse(Console.ReadLine());
        }

        // 1. ספירת מספר הפרחים מכל משפחה
        int countFamily1 = 0;
        int countFamily2 = 0;

        for (int i = 0; i < n; i++)
        {
            int family = flw1[i] / 100; // חילוץ הספרה השמאלית
            if (family == 1)
            {
                countFamily1++;
            }
            else if (family == 2)
            {
                countFamily2++;
            }
        }

        // 2. יצירת המערכים בגודל המדויק
        int[] originalRemaining = new int[countFamily1]; // משפחה 1
        int[] newBed = new int[countFamily2];            // משפחה 2

        // 3. פיצול הפרחים למערכים המתאימים
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < n; i++)
        {
            int family = flw1[i] / 100;
            if (family == 1)
            {
                originalRemaining[index1] = flw1[i];
                index1++;
            }
            else if (family == 2)
            {
                newBed[index2] = flw1[i];
                index2++;
            }
        }

        Console.WriteLine("\nהמערך המקורי שנותרו בו פרחים ממשפחה 1:");
        for (int i = 0; i < originalRemaining.Length; i++)
        {
            Console.Write(originalRemaining[i] + " ");
        }
        Console.WriteLine();

        Console.WriteLine("\nהמערך החדש של ערוגה 2 (משפחה 2):");
        for (int i = 0; i < newBed.Length; i++)
        {
            Console.Write(newBed[i] + " ");
        }
        Console.WriteLine();
    }
}






