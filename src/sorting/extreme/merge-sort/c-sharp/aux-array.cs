using System;

/*
Time : O(n.log(n)) - Where N is the length of the input array
Space: O(n)        - To store the auxiliary data structure
*/
public class Program
{
    public static int[] MergeSort (int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }
        var aux = array.Clone() as int[];
        MergeSort (array, 0, array.Length - 1, aux);

        return array;
    }

    private static void MergeSort (int[] main, int start, int end, int[] aux)
    {
        if (start == end)
        {
            return;
        }
        var mid = (start + end) / 2;
        MergeSort (aux, start, mid, main);
        MergeSort (aux, mid + 1, end, main);
        MergeArrays (main, start, mid, end, aux);
    }

    private static void MergeArrays (int[] main, int start, int mid, int end, int[] aux)
    {
        var i = start;
        var j = mid + 1;
        var k = start;

        while (i <= mid && j <= end)
        {
            if (aux[i] <= aux[j])
            {
                main[k++] = aux[i++];
            }
            else
            {
                main[k++] = aux[j++];
            }
        }
        while (i <= mid)
        {
            main[k++] = aux[i++];
        }
        while (j <= end)
        {
            main[k++] = aux[j++];
        }
    }
}
