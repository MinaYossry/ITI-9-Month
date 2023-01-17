namespace Task_1
{
    internal class Task1
    {
        static int[] takeInput()
        {
            // Get a positive element from the uset
            Console.Write("Enter number of elements: ");
            int n;
            do
            {
                n = Convert.ToInt32(Console.ReadLine());

            } while (n <= 0);

            int[] arr = new int[n];

            // fill the array with numbers
            Console.WriteLine("\nEnter elements: ");
            Console.WriteLine("=====================================");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            return arr;
        }

        static int getMaxDistance(int[] arr)
        {
            int currentMax = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int distance = Array.LastIndexOf(arr, arr[i]) - i - 1;
                if (distance > currentMax)
                    currentMax = distance;
            }

            return currentMax;
        }
        static void Main(string[] args)
        {
            int[] arr = takeInput();
            int maxDistance = getMaxDistance(arr);
            Console.WriteLine($"\nMax distance is between the number {arr[maxDistance+1]} = {maxDistance}");
        }
    }
}