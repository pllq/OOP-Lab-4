using Internet;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    delegate int Compare<T>(T[] array_1, T[] array_2, int ind);

    private static void Main(string[] args)
    {
        //Task 1

        //anonymous method
        Compare<int> anonymous_comparer = delegate (int[] array_1, int[] array_2, int ind)
        {
            if (array_1.Length > ind && array_2.Length > ind)
            {
                return array_1[ind].CompareTo(array_2[ind]);
            }
            else
            {
                throw new ArgumentOutOfRangeException("This element doesn't exist.");
            }
        };

        //lambda
        Compare<int> lambda_comparer = (int[] a_1, int[] a_2, int index) => a_1[index].CompareTo(a_2[index]);

        int[] array1 = new int[5] { 15, 10, 0, 5, 25 };
        int[] array2 = new int[5] { 16, 20, 14, 5, 3 };

        int compared_1 = anonymous_comparer.Invoke(array1, array2, 3);
        int compared_2 = lambda_comparer(array1, array2, 1);



        //___________________________________________________________________________________________________________________



        //Task 2-3
        InternetUserInterface user_of_the_internet = new InternetUserInterface("Vasyl", "8305");
        user_of_the_internet.UseInternet(1024);

        user_of_the_internet.EnterPassword("6209");
        user_of_the_internet.EnterPassword("8305");

        user_of_the_internet.SetTraffic(10240);

        user_of_the_internet.Pay(20);

        user_of_the_internet.UseInternet(11264);
        Console.WriteLine();
        Console.WriteLine("Next month. Traffic updated and additional fee is charged for excess traffic .");

        user_of_the_internet.EndMonth();

        user_of_the_internet.UseInternet(5000);
        Console.Read();
    }
}