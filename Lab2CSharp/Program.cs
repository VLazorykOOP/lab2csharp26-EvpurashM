using System;
using System.Linq;

namespace Lab2Charp
{
    class Program
    {
        // =================================================================
        // Завдання 1.6: Середнє арифметичне від'ємних елементів (1D масив)
        // =================================================================
        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1.6 ---");
            Console.Write("Введіть розмірність масиву n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[] a = new int[n];
            double sum = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
                if (a[i] < 0)
                {
                    sum += a[i];
                    count++;
                }
            }

            if (count > 0)
                Console.WriteLine($"Середнє арифметичне від'ємних елементів: {sum / count:F2}");
            else
                Console.WriteLine("Від'ємних елементів немає.");
        }

        // =================================================================
        // Завдання 2.6: Номер першого мінімального елемента (дійсні числа)
        // =================================================================
        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2.6 ---");
            Console.Write("Введіть кількість елементів послідовності n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine());
            }

            int minIndex = 0;
            double minValue = a[0];

            // менший елемент, щоб зберегти індекс ПЕРШОГО
            for (int i = 1; i < n; i++)
            {
                if (a[i] < minValue)
                {
                    minValue = a[i];
                    minIndex = i;
                }
            }

            Console.WriteLine($"Перший мінімальний елемент: {minValue}, його номер (індекс): {minIndex}");
        }

        // =================================================================
        // Завдання 3.6 (Спосіб 1): Одновимірний масив як матриця n x n
        // =================================================================
        static void Task3_1D()
        {
            Console.WriteLine("\n--- Завдання 3.6 (Через одновимірний масив) ---");
            Console.Write("Введіть розмірність матриці n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[] a = new int[n * n];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i * n + j] = int.Parse(Console.ReadLine());
                }
            }

            // Логіка заміни
            int row1, row2;
            if (n % 2 == 0) // Парне
            {
                row1 = (n / 2) - 1;
                row2 = n / 2;
                Console.WriteLine("Кількість рядків парна: міняємо два середніх рядки.");
            }
            else // Непарне
            {
                row1 = 0;
                row2 = n / 2;
                Console.WriteLine("Кількість рядків непарна: міняємо перший рядок із середнім.");
            }

            // Міняємо рядки місцями
            for (int j = 0; j < n; j++)
            {
                int temp = a[row1 * n + j];
                a[row1 * n + j] = a[row2 * n + j];
                a[row2 * n + j] = temp;
            }

            Console.WriteLine("Матриця після зміни:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{a[i * n + j],5}");
                }
                Console.WriteLine();
            }
        }

        // =================================================================
        // Завдання 3.6 (Спосіб 2): Двовимірний масив n x n
        // =================================================================
        static void Task3_2D()
        {
            Console.WriteLine("\n--- Завдання 3.6 (Через двовимірний масив) ---");
            Console.Write("Введіть розмірність матриці n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[,] a = new int[n, n];

            Console.WriteLine("Введіть елементи матриці:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"a[{i},{j}] = ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }

            int row1, row2;
            if (n % 2 == 0)
            {
                row1 = (n / 2) - 1;
                row2 = n / 2;
                Console.WriteLine("Кількість рядків парна: міняємо два середніх рядки.");
            }
            else
            {
                row1 = 0;
                row2 = n / 2;
                Console.WriteLine("Кількість рядків непарна: міняємо перший рядок із середнім.");
            }

            // Обмін рядків
            for (int j = 0; j < n; j++)
            {
                int temp = a[row1, j];
                a[row1, j] = a[row2, j];
                a[row2, j] = temp;
            }

            Console.WriteLine("Матриця після зміни:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{a[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        // =================================================================
        // Завдання 4.6: Східчастий масив 
        // =================================================================
        static void Task4()
        {
            Console.WriteLine("\n--- Завдання 4.6 ---");
            Console.Write("Введіть кількість рядків східчастого масиву n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

            int[][] a = new int[n][];
            int maxCols = 0; // Для зберігання максимальної довжини рядка

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введіть кількість елементів у рядку {i}: ");
                int m = int.Parse(Console.ReadLine());
                a[i] = new int[m];
                if (m > maxCols) maxCols = m;

                for (int j = 0; j < m; j++)
                {
                    Console.Write($"a[{i}][{j}] = ");
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\nВаш східчастий масив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"{a[i][j],5}");
                }
                Console.WriteLine();
            }

            
            int[] result = new int[maxCols];

            for (int c = 0; c < maxCols; c++)
            {
                bool found = false;
                for (int r = 0; r < n; r++)
                {
                    
                    if (c < a[r].Length && a[r][c] > 0)
                    {
                        result[c] = a[r][c];
                        found = true;
                        break; 
                    }
                }
                // Якщо в стовпці немає додатніх чисел, ставимо 0 за замовчуванням
                if (!found) result[c] = 0;
            }

            Console.WriteLine("\nНовий масив (перший додатній елемент кожного стовпця):");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"Стовпець {i}: {(result[i] == 0 ? "немає додатніх" : result[i].ToString())}");
            }
        }

        // =================================================================
        // Головне меню програми
        // =================================================================
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("Оберіть завдання для запуску:");
                Console.WriteLine("1 - Завдання 1.6");
                Console.WriteLine("2 - Завдання 2.6");
                Console.WriteLine("3 - Завдання 3.6 (Спосіб 1: одновимірний масив)");
                Console.WriteLine("4 - Завдання 3.6 (Спосіб 2: двовимірний масив)");
                Console.WriteLine("5 - Завдання 4.6 (східчастий масив)");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.WriteLine("Роботу завершено. Успіхів!");
                    break;
                }

                switch (choice)
                {
                    case "1": Task1(); break;
                    case "2": Task2(); break;
                    case "3": Task3_1D(); break;
                    case "4": Task3_2D(); break;
                    case "5": Task4(); break;
                    default:
                        Console.WriteLine("Неправильне введення. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}