using System.Collections;
using System.Runtime.InteropServices;

namespace Domain;


public static class Extensions
{
    
    private static void CheckingElements<T>(
        this IEnumerable<T> values,
        IEqualityComparer<T> equalityComparer)
    {
        if (values.Distinct(equalityComparer).Count() != values.Count())
        {
            throw new ArgumentException("Elements are repeated", nameof(values));
        }
    }
    
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(
        IEnumerable<T>? _array, List<T> combinations, int k, int start)
    {
        List<IEnumerable<T>> resultList = new List<IEnumerable<T>>();
        
        if (combinations.Count == k)
        {
            resultList.Add(combinations.ToList()); // ToList - он возвращает List<T> который содержит элементы из входной последовательности
        }
        else
        {
            for (var i = start; i < _array.Count(); i++)
            {
                combinations.Add(_array.ElementAt(i)); // ElementAt - возвращает элемент по указанному индексу в последовательности.
                resultList.AddRange(GetCombinations(_array, combinations, k, i)); // AddRange - добавляет элементы указанной коллекции в конец списка List<T>
                combinations.RemoveAt(combinations.Count - 1); // RemoveAt - удаляет элемент списка List<T> с указанным индексом.
            }
        }

        return resultList;
    }
    
    public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(
        this IEnumerable<T>? array, int k, IEqualityComparer<T>? comparer)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }

        if (k > array.Count())
        {
            throw new ArgumentException(null, nameof(array));
        }

        CheckingElements(array, comparer);

        return GetCombinations(array, new List<T>(), k, 0);
    }

    public static IEnumerable<IEnumerable<T>> GetSubsets<T>(
        IEnumerable<T>? array)
    {
        var subsets = new List<List<T>>()
        {
            new()
        };

        foreach (var _array in array)
        {
            var currSubset = new List<List<T>>();
            foreach (var _subset in subsets)
            {
                currSubset.Add(new List<T>(_subset) { _array });
            }
            
            subsets.AddRange(currSubset);
        }

        return subsets;
    }
    
    public static IEnumerable<IEnumerable<T>> GenerateSubsets<T>(
        this IEnumerable<T>? array, IEqualityComparer<T>? comparer)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }
        
        CheckingElements(array, comparer);

        return GetSubsets(array);
    }
    
    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(
        IEnumerable<T> iterableObject)
    {
        List<IEnumerable<T>> resultList = new List<IEnumerable<T>>();

        if (iterableObject.Count() == 1)
        {
            return new List<IEnumerable<T>>() { iterableObject };
        }

        for (int i = 0; i < iterableObject.Count(); i++)
        {
            var element = iterableObject.ElementAt(i); // ElementAt - возвращает элемент по указанному индексу в последовательности.
            var remainingElements = iterableObject.Take(i).Concat(iterableObject.Skip(i + 1)); // Take - возвращает указанное число подряд идущих элементов с начала последовательности.
            var permutationsOfRemaining = GetPermutations<T>(remainingElements);

            foreach (var permutation in permutationsOfRemaining)
            {
                resultList.Add(new List<T>() { element }.Concat(permutation));
            }
        }

        return resultList;
    }
    
    public static IEnumerable<IEnumerable<T>> GeneratePermutations<T>(
        this IEnumerable<T>? array, IEqualityComparer<T>? comparer)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }
        
        CheckingElements(array, comparer);

        return GetPermutations(array);
    }
    
}
