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
    //B1. Viết lại SentSearch dùng đệ quy
    static int SentSearch(int[] arr, int value){
        int i = 0;
        int lastele = arr[arr.Length-1];
        arr[arr.Length-1] = value;
        while(arr[i]!=value){
                i++;
        }
        arr[arr.Length-1] = lastele;
        if(i<arr.Length-1)
            return i;
        else if(lastele==value)
            return arr.Length-1;
        else
            return -1;
    }
    //B2. Viết lại BinSearch dùng đệ quy
    //B3. Viết lại BinSearch với phần tử mid được random có kiểm soát
    //B4. Viết lại BinSearch với 2 phần tử làm mốc
    static int BinSearch(int[] sortedarr, int value){
        int left = 0, right = sortedarr.Length-1;
        while(left<=right){
            int mid = (left+right)/2;
            if(sortedarr[mid]==value)
                return mid;
            else if(sortedarr[mid]>value){
                //tìm bên trái
                right = mid-1;
            }else{
                //tìm bên phải
                left = mid+1;
            }
        } 
        return -1; 
    }
    public static void Main(string[] args){
        Console.Clear();
        int[] arr = {9, 7, 2, 4, 11, 8}; int value = 7;
        /* int result = SeqSearch(arr, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
        result = RecuSearch(arr, 0, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
        Array arr2 = arr;
        result = RecuSearchArray(arr2, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);*/

        /*int result = SentSearch(arr, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);*/
        int[] orderedarr = {2, 4, 7, 8, 9, 11};
        int result = BinSearch(orderedarr, value);
        Console.WriteLine("Index of element {0} is {1}", 
                                    value, result);
    }
}