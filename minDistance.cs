using System;

class MinDistance {
  public int minDistance(int n) {
    int minD=n, prevDivisor = 1;
    for(int i=2; i<=n/2; i++) {
      if(n%i==0) {
        if(i-prevDivisor < minD)
          minD = i-prevDivisor;
        prevDivisor = i;
      }
    }
    return minD;
  }

  public int isDaphne(int[] a) {
    int len=a.Length, i=0, j=len-1, oddFound=0;
    while(oddFound==0) {
      if(a[i]%2==0 && a[j]%2==0) {
        i++;
        j--;
        continue;
      }
      if(a[i]%2==0 && a[j]%2!=0) {
        i++; oddFound=1;
        continue;
      }
      if(a[i]%2!=0 && a[j]%2==0) {
        j--; oddFound=1;
        continue;
      }
      if(a[i]%2!=0 || a[j]%2!=0) {
        oddFound=1;
        continue;
      }
    }
    if(oddFound==0) {
      return 0;
    } else if(i+1!=len-j){
      return 0;
    } else {
      return 1;
    }
  }

  public int isDual(int[] a) {
    for(int i=0, len=a.Length; i<len; i++) {
      int count = 1;
      for(int j=0; j<len; j++) {
        if(i!=j && a[i] == a[j])
          count++;
      }
      if(count!=2)
        return 0;
    }
    return 1;
  }

  public int isFibonacci(int n) {
    int currentVal = 1, prevVal = 0;
    while(currentVal<n) {
      int temp = currentVal;
      currentVal += prevVal;
      prevVal = temp;
    }
    return currentVal==n? 1: 0;
  }
  public int checkAllDigit(int[] array) {
    //returns 1 if all values are 1. thus keeping the index of each digits
    int count = 0;
    for(int i=0, len=array.Length; i<len; i++) {
      if(array[i] == 1)
        count++;
    }
    return count==10? 1: 0;
  }
  public int computeDepth(int n) {
    int val = n, i=0;
    int[] digitIndex = new int[10];
    while(checkAllDigit(digitIndex) != 1) {
      i++;
      val = n * i;
      int temp = val;
      //checking and adding digits to the indexed array
      while(temp!=0) {
        int digit = temp%10;
        digitIndex[digit] = 1;
        temp = temp/10;
      }
    }
    return i;
  }

  public int isAllPossibilities(int[] a) {
    int len=a.Length, max=a[0];
    for(int i=0; i<len; i++) {
      if(max<a[i])
        max = a[i];
    }
    int totalLength = max+1;
    int[] totA = new int[totalLength];
    for(int i=0; i<totalLength; i++) {
      for(int j=0; j<len; j++) {
        if(a[j] == i) {
          totA[i] = 1;
        }
      }
    }

    for(int i=0; i<totalLength; i++) {
      if(totA[i]==0) {
        return 0;
      }
    }
    return 1;
  }

  public int dual(int[] a) {
    int len=a.Length;
    if(len%2!=0) {
      return 0;
    }
    int sum = 0;
    for(int i=1; i<len; i++) {
      int prev = sum;
      if(a[i]%2==0 && a[i-1]%2!=0 || a[i]%2!=0 && a[i-1]%2==0) {
        sum = a[i] + a[i-1];
        if(prev != 0 && prev !=sum)
          return 0;
      } 
    }
    return 1;
  }
  public int isCentered(int[] a) {
    int len = a.Length;
    if(len%2==0)
      return 0;
    for(int i=0; i<len; i++) {
      if(i!=len/2 && a[i]<=a[len/2])
        return 0;
    }
    return 1;
  }

  // public int isBean(int[] a) {
  //   int len = a.Length;
  //   for(int i=0; i<len; i++) {
  //     int flag = 0;
  //     for(int j=0; j<len; j++) {
  //       if(a[i]!=a[j]*2 && a[i]!=a[j]*2+1 && a[i]/2 != a[j])
  //         flag = 1;
  //     }
  //   }
  // }
  int isPrime(int n) {
    if(n<=1) {
      return 0;
    }
    if(n==2 || n==3) {
      return 1;
    }
    for(int i=2;i<=n/2; i++) {
      if(n%i==0) {
        return 0;
      }
    }
    return 1;
  }
  int encodeN(int n) {
    int totalCount = 0;
    for(int i=2; i<=n/2; i++) {
      if(n%i==0 && isPrime(i)==1) {
        int temp = n;
        while(temp%i == 0) {
          totalCount++;
          temp=temp/i;
        }
      }
    }

    int k=0;
    int[] finalArray = new int[totalCount];
    for(int i=2; i<=n/2; i++) {
      if(n%i==0 && isPrime(i)==1) {
        int temp = n;
        while(temp%i == 0) {
          finalArray[k] = i;
          k++;
          temp=temp/i;
        }
      }
    }
    for(int i=0; i<totalCount; i++) {
      Console.WriteLine(finalArray[i]);
    }
    return 1;
  }

  public void doIntegerBasedRounding(int[] a, int n) {
    for(int i=0, len=a.Length; i<len; i++) {
      int l=a[i]/n;
      int m = a[i]/n+1;
      if(Math.Abs(l*n-a[i]) < Math.Abs(m*n-a[i]))
        a[i] = l*n;
      else
        a[i] = m*n;
    }
    for(int i=0, len=a.Length; i<len; i++) {
      Console.WriteLine(a[i]);
    }
  }

  public int decodeArray(int[] a) {
    int sum = 0;
    for(int i=1, len=a.Length; i<len; i++) {
      sum = sum*10 + Math.Abs(a[i-1] - a[i]);
    }
    if(a[0]<0)
      return sum*-1;
    else
      return sum;
  }
  public int zeroPlentiful() {
    int[] a = {1, 2, 0, 0, 0, 0, 2, -18, 0, 0, 0, 0, 0, 12};
    int zeroCount = 0;
    for(int i=0; i<a.Length; i++) {
      if(a[i] == 0) {
        int count0=1;
        for(int j=i+1; j<a.Length; j++) {
          if(a[j-1] == 0 && a[j]==0) {
            count0++;
          } else if(count0<4) {
            return 0;
          } else {
            zeroCount++;
            i=j;
            break;
          }
        }
      }
    }
    return zeroCount;
  }

  public int decodeArray2(int[] a) {
    int sum=0, i;
    if(a[0]<0) i=1;
    else
      i=0;
    int c =0;
    for(; i<a.Length; i++) {
      if(a[i]==0) {
        c++;
      } else {
        sum=sum*10+c;
        c=0;
      }
    }
    return a[0]<0? sum*-1:sum;
  }

  int isPrime(int n) {
    if(n<=1) return 0;
    if(n==2|| n==3) return 1;
    for(int i=2; i<=n/2; i++) {
        if(n%i==0) return 0;
    }
    return 1;
}
int isPrimeHappy(int n) {
    int sum = 0;
    // if(isPrime(n) == 0) return 0;
    for(int i=2; i<n; i++) {
        if(isPrime(i)==1) sum+=i;
    }
    return sum!=0 && sum%n==0 ? 1 : 0;
}

  public static void Main(string[] args) {
    MinDistance minD = new MinDistance();
    // Console.WriteLine(minD.minDistance(13013));
    // Console.WriteLine(minD.isFibonacci(22));
    // int[] arr = {1, 2, 1, 3, 3};
    // Console.WriteLine(minD.isDual(arr));
    // Console.WriteLine(minD.computeDepth(42));
    // int[] daphneArr = {4, 8, 6, 3, 2, 9, 8,11, 8, 13, 12, 1, 6};
    // int[] allP = {3,2,1,3,1,0,5,4};
    // Console.WriteLine(minD.isDaphne(daphneArr));
    // Console.WriteLine(minD.isAllPossibilities(daphneArr));
    // Console.WriteLine(minD.isAllPossibilities(allP));

    // int[] dualArray = {1, 2, 0, 1, 4, 0};
    // Console.WriteLine(minD.dual(dualArray));

    // int[] centeredArr = {4,2,2,2,3};
    // Console.WriteLine(minD.isCentered(centeredArr));

    // minD.encodeN(24);

    // minD.doIntegerBasedRounding(new int[] {1, 2, 3, 4, 5},2 );

    // Console.WriteLine(minD.decodeArray(new int[] {111, 115, 118, 127, 125}));
    Console.WriteLine(minD.decodeArray2(new int[] {0, 1, 1, 1, 1, 1, 0, 1}));

  }
}