using System;

namespace oddHeavy {
  class oddHeavy {
    public int isOddHeavy(int[] array) {
      int lengthEven=0, lengthOdd=0, len=array.Length;
      for(int i=0;i<len;i++) {
        if(array[i]%2!=0) {
          lengthOdd++;
        } else {
          lengthEven++;
        }
      }
      if(lengthOdd<1) {
        return 0;
      }
      int[] oddArray = new int[lengthOdd];
      int[] evenArray = new int[lengthEven];
      int k=0,l=0;
      for(int i=0; i<array.Length; i++) {
        if(array[i]%2!=0) {
          oddArray[k]=array[i];
          k++;
        } else {
          evenArray[l] = array[i];
          l++;
        }
      }
      for(int i=0; i<lengthOdd; i++) {
        for(int j=0; j<lengthEven; j++) {
          if(oddArray[i]<evenArray[j]) {
            return 0;
          }
        }
      }
      return 1;
    }

    public int isOddHeavyInOneLoop(int[] a) {
      int len = a.Length, oddFound=0;
      for(int i=0; i<len; i++) {
        if(a[i]%2!=0) {
          oddFound=1;
        }
        for(int j=0; j<len; j++) {
          if(a[i]%2!=0 && a[j]%2==0) {
              if(a[i]<a[j]) {
                  return 0;
              }
          }
        }
      }
      return oddFound == 1? 1: 0;
    }

    public static void Main(string[] args) {
      int[] array = {11, 4, 9, 2, 8};
      oddHeavy oddObj = new oddHeavy();
      Console.WriteLine("The array is odd heavy {0}", oddObj.isOddHeavy(array));
    }
  }
}