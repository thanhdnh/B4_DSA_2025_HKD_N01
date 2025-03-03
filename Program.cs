using System.Collections.ObjectModel;

public class Program
{
    static int SeqSearch(int[] arr, int value){
        int i = 0;
        while(arr[i]!=value){
            //if(arr[i]!=value)
                i++;
        }
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value){
        if(arr[from]==value)
            return from;
        else
            return RecuSearch(arr, from+1, value);
    }
    static int RecuSearchList(List<int> arr, int value){
        if(arr[0]==value)
            return 0;
        else{
            arr.RemoveAt(0);
            return 1 + RecuSearchList(arr, value);
        }
    }
    static int RecuSearchArray(Array arr, int value){
        if((int)arr.GetValue(arr.GetLowerBound(0))==value)
            return arr.GetLowerBound(0);
        else{
            Array temp = Array.CreateInstance(typeof(int), 
                    new int[]{arr.Length-1}, 
                    new int[]{arr.GetLowerBound(0)+1});
            //arr.CopyTo(temp, arr.GetLowerBound(0)+1);
            for(int i = arr.GetLowerBound(0)+1; 
                                i<arr.Length; i++){
                temp.SetValue((int)arr.GetValue(i), i);
            }
            return RecuSearchArray(temp, value);
        }
    }
    public static void Main(string[] args){
        Console.Clear();
        int[] arr = {9, 7, 2, 4, 11, 8}; int value = 4;
        int result = SeqSearch(arr, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
        result = RecuSearch(arr, 0, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
        Array arr2 = arr;
        result = RecuSearchArray(arr2, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
    }
}