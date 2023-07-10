using Domain;

namespace Launcher.App
{
    class Program
    {
        static void Main()
        {
            
            var combinations = Extensions.GenerateCombinations(
                new List<int>() {1, 2},
                2,
                Comparer<int>.Instance);
            var subsets = Extensions.GenerateSubsets(
                new List<int>() {1, 2, 3},
                Comparer<int>.Instance);
            var permutations = Extensions.GeneratePermutations(
                new List<int>() {1, 2, 3, 4},
                Comparer<int>.Instance);

            foreach (var combination in combinations)
            {
                Console.WriteLine($"[{string.Join(", ", combination)}]");
            }
            
            Console.WriteLine("------------------------------");

            foreach (var subset in subsets)
            {
                Console.WriteLine($"[{string.Join(", ", subset)}]");
            }
            
            Console.WriteLine("------------------------------");
            
            foreach (var permutation in permutations)
            {
                Console.WriteLine($"[{string.Join(", ", permutation)}]");
            }
            
        }
    }
}