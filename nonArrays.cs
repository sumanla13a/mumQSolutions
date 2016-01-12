using System;
namespace ValueTasks {
  class Mathematics {
    public int nextPerfectSquare (int givenValue) {
      int currentSquare, sum=0, i=0;
      // currentSquare = (int)Math.Sqrt(givenValue);
      while(sum<givenValue) {
        sum+=i*i;
        i++;
      }
      return sum;
      // return (currentSquare + 1) * (currentSquare + 1);
    }
    public int countPrime(int start, int end) {
      int primeCount = 0, currentValue = start;
      if(start > end) {
        return 0;
      }
      while(currentValue <= end) {
        int flagPrime = 0;
        if(currentValue <= 1) {
          currentValue++;
          continue;
        }
        if (currentValue == 2 || currentValue == 3) { //if we don't want currentValue == 3 here then we will have to check up to currentValue - 1 times in following for loop
          primeCount++;
          Console.WriteLine("{0}", currentValue);
          currentValue++;
          continue;
        }
        for(int i = 2, halfValue = currentValue/2; i<=halfValue; i++) {
          if(currentValue%i == 0) {
            flagPrime = 1;
            break;
          }
        }
        if(flagPrime == 0) {
          Console.WriteLine("{0}", currentValue);
          primeCount++;
        }
        currentValue++;
      }
      return primeCount;
    }
    public int isPrimeNumber (int n) {
      int isPrime = 1;
      if(n<=1) {
        return 0;
      } else if(n==2 || n==3) {
        return 1;
      } else {
        for(int i=2;i<=n/2; i++) {
          if(n%i == 0) {
            isPrime = 0;
            break;
          }
        }
      }
      if(isPrime == 1) {
        return 1;
      } else {
        return 0;
      }
    }
    public int findNextPorcupineNumber(int n) {
      // checking isPrimeNumber function
      // Console.WriteLine(isPrimeNumber(1));
      // Console.WriteLine(isPrimeNumber(2));
      // Console.WriteLine(isPrimeNumber(3));
      // Console.WriteLine(isPrimeNumber(4));
      // Console.WriteLine(isPrimeNumber(5));
      // Console.WriteLine(isPrimeNumber(6));

      int porcupineNumberFound = 0, currentPrime = 2;
      while(porcupineNumberFound == 0) {
        if(isPrimeNumber(n) == 1 && n%10==9) {
          int nextPrimeFound = 0;
          currentPrime = n;
          while(nextPrimeFound == 0) {
            n++;
            if(isPrimeNumber(n) == 1) {
              nextPrimeFound = 1;
              if(n%10 == 9) {
                porcupineNumberFound = 1;
              }
            }
          }
        }
        n++;
      }

      return currentPrime;
    }
    public int getFactorialUsingRecursion(int n) {
      if(n<0) {
        return 0;
      } else if(n<=1) {
        return 1;
      }
      return n*getFactorialUsingRecursion(n-1);
    }
    public int getFactorial(int n) {
      if(n<0) {
        return 0;
      } else if(n<=1) {
        return 1;
      }
      int factorial = 1;
      while(n>1) {
        factorial = factorial * n;
        n--;
      }
      return factorial;
    }
    public int[] solve10() {
      int factorialOf10 = getFactorialUsingRecursion(10);
      int[] numbers = new int[2];
      int numbersFound = 0;
      for(int i = 1; i<10; i++) {
        for(int j = 1; j<10; j++) {
          if(getFactorialUsingRecursion(i) + getFactorialUsingRecursion(j) == factorialOf10) {
            numbers[0] = i;
            numbers[1] = j;
            numbersFound = 1;
            break;
          }
        }
        if(numbersFound == 1) {
          break;
        }
      }
      Console.WriteLine(numbers[0]);
      Console.WriteLine(numbers[1]);
      return numbers;
    }
    public int repsEqual(int[] array, int n) {
      int numberMadeFromArray =0;
      for(int i=0,length=array.Length; i<length; i++) {
        if(numberMadeFromArray==0 && array[i] == 0) {
          continue;
        }
        numberMadeFromArray = array[i] + numberMadeFromArray*10;
      }
      Console.WriteLine("number made from array is {0}",numberMadeFromArray);
      if(numberMadeFromArray == n) {
        return 1;
      } else {
        return 0;
      }
    }

    public int isPerfectNumber(int n) {
      int sum=1;
      //1 doesn't count as a perfect number?
      if(n==0 || n == 1) {
        return 0;
      }
        for(int i = 2; i<n; i++) {
          if(n%i == 0) {
            sum += i;
          }
        }
      return sum == n ? 1: 0;
    }
    public int henry(int a, int b) {
      int foundBoth = 0, count = 0, number = 0, sum = 0;
      while(foundBoth != 2) {
        if(isPerfectNumber(number) == 1) {
          count++;
          if(count == a || count == b) {
            sum = sum + number;
            foundBoth++;
          }
        }
        number++;
      }
      return sum;
    }
    public int isPerfectSquareWithoutMathLibrary(int n) {
      if(n <= 0) {
        return 1;
      }
      for(int i = 0; i<=n/2; i++) {
        if(i*i == n) {
          return 1;
        }
      }
      return 0;
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
    public int countDepth(int n) {
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

    public int isStacked (int n) {
      int sum = 0;
      for(int i = 1; i<=n; i++) {
        if(sum == n) {
          break;
        } else if(sum > n) {
          break;
        }
        sum = sum + i;
      }
      if(sum == n) {
        return 1;
      }
      return 0;
    }

    public int isIsolated(long n) {
      long square = n*n, cube = n*n*n;
      if(n>2097151) {
        return -1;
      }
      while(cube!=0) {
        long number = square;
        long cubeDigit = cube%10;
        cube=cube/10;
        while(number!=0) {
          long digit = number%10;
          number = number/10;
          if(cubeDigit==digit) {
            return 0;
          }
        }
      }
      return 1;
    }

    public int countRepresentation(int n) {
      int count=0;
      for (int rupee20=0; rupee20<=n/20; rupee20++) {
        for (int rupee10=0; rupee10<=n/10; rupee10++) {
          for (int rupee5=0; rupee5<=n/5; rupee5++) {
            for (int rupee2=0; rupee2<=n/2; rupee2++) {
              for (int rupee1=0;  rupee1<=n; rupee1++) {
                if (rupee1*1 + rupee2*2 + rupee5*5 + rupee10*10 + rupee20*20==n) { 
                  count++;
                }
              }
            }
          }
        }
      }
      return count;
    }

    public int fullNessQuotient(int n) {
      int count = 0;
      for(int i=2; i<=9; i++) {
        int flagZero=0;
        int num=n;
        while(num!=0) {
          int digit = num%i;
          if(digit==0) {
            flagZero=1;
            break;
          }
          num=num/i;
        }
        if(flagZero==0) {
          count++;
        }
      }
      return count;
    }

    public int getExponent(int n, int p) {
      int i=1, exp=0;
      while(n%i==0) {
        exp++;
        i=(int)Math.Pow((double)p, (double)exp);
        Console.WriteLine(i);
      }
      return exp-1;
    }

    public int checkConcatenatedSum(int n, int catlen) {
      int sum=0, tempn=n;
      while(tempn!=0) {
        int digit = tempn%10;
        int tempdigit =digit;
        for(int i=0; i<catlen-1; i++) {
          digit= digit*10+tempdigit;
        }
        Console.WriteLine(digit);
        sum=sum+digit;
        tempn=tempn/10;
      }
      return sum==n ? 1: 0;
    }
  }

  class Calculations {
    public static void Main(string[] args) {
      Mathematics mathematicsObject = new Mathematics();
      // Console.WriteLine("Next Perfect Square of 15 is {0}", mathematicsObject.nextPerfectSquare(15));
      // Console.WriteLine("Next Perfect Square of 20 is {0}", mathematicsObject.nextPerfectSquare(20));
      // Console.WriteLine("Next Perfect Square of 27 is {0}", mathematicsObject.nextPerfectSquare(27));
      // Console.WriteLine("Next Perfect Square of 101 is {0}", mathematicsObject.nextPerfectSquare(101));
      
      // Console.WriteLine("Number of prime number between 10 and 30 is {0}", mathematicsObject.countPrime(1,30));
      // Console.WriteLine("Number of prime number between 11 and 29 is {0}", mathematicsObject.countPrime(11,29));
      // Console.WriteLine("Number of prime number between 20 and 22 is {0}", mathematicsObject.countPrime(20,22));
      // Console.WriteLine("Number of prime number between 1 and 1 is {0}", mathematicsObject.countPrime(1,1));
      // Console.WriteLine("Number of prime number between 5 and 5 is {0}", mathematicsObject.countPrime(5,5));
      // Console.WriteLine("Number of prime number between -10 and 6 is {0}", mathematicsObject.countPrime(-10,6));
      // Console.WriteLine("Number of prime number between 6 and 2 is {0}", mathematicsObject.countPrime(6,2));

      // Console.WriteLine("Porcupine Number {0}",mathematicsObject.findNextPorcupineNumber(2));
      
      // Console.WriteLine("Factorial of 4 is {0}", mathematicsObject.getFactorialUsingRecursion(4));
      // Console.WriteLine("Factorial of 4 is {0}", mathematicsObject.getFactorial(4));
      
      // Console.WriteLine("Answer of solve10 is {0}", mathematicsObject.solve10());

      // int[] array = {3,1,2,3};
      // int[] array1 = {0,0,3,1,2,3};
      // Console.WriteLine("The array is correct with value? {0}", mathematicsObject.repsEqual(array, 3123));
      // Console.WriteLine("The array is correct with value? {0}", mathematicsObject.repsEqual(array, 31230));
      // Console.WriteLine("The array is correct with value? {0}", mathematicsObject.repsEqual(array1, 3123));
      // Console.WriteLine("The array is correct with value? {0}", mathematicsObject.repsEqual(array1, 31230));
    
      // Console.WriteLine("6 should be a perfect number {0}", mathematicsObject.henry(1,3));
    
      // Console.WriteLine("4 should be a perfect square number {0}", mathematicsObject.isPerfectSquareWithoutMathLibrary(4));
      // Console.WriteLine("121 should be a perfect square number {0}", mathematicsObject.isPerfectSquareWithoutMathLibrary(121));
      // Console.WriteLine("6 should be a perfect square number {0}", mathematicsObject.isPerfectSquareWithoutMathLibrary(6));

      // Console.WriteLine("25 should have a depth of 36 -> {0}", mathematicsObject.countDepth(25));
    
      //is Stacked
      // Console.WriteLine("15 should be stacked -> {0}", mathematicsObject.isStacked(15));
      // Console.WriteLine("9 should not be stacked -> {0}", mathematicsObject.isStacked(09));
    
      //is isolated
      // Console.WriteLine("2 should be isolated -> {0}", mathematicsObject.isIsolated(2));
      // Console.WriteLine("4 should not be isolated -> {0}", mathematicsObject.isIsolated(4));
      // Console.WriteLine("63 should be isolated -> {0}", mathematicsObject.isIsolated(63));
      // Console.WriteLine("2097152 should be neither -> {0}", mathematicsObject.isIsolated(2097152));

      //count rupee
      // Console.WriteLine("12 should have 15 count {0}", mathematicsObject.countRepresentation(12));
    
      //fullness quotient
      // Console.WriteLine("Full ness quotient of 94 {0}", mathematicsObject.fullNessQuotient(94));
      // Console.WriteLine("Full ness quotient of 1 {0}", mathematicsObject.fullNessQuotient(1));
      // Console.WriteLine("Full ness quotient of 9 {0}", mathematicsObject.fullNessQuotient(9));

      //getExponent
      // Console.WriteLine("Exponent of 27 {0}", mathematicsObject.getExponent(-250,5));
      // Console.WriteLine("Exponent of 28 {0}", mathematicsObject.getExponent(28,3));

      //isconcatenatedSum
      Console.WriteLine("198 is concatenated with n = 2 {0}", mathematicsObject.checkConcatenatedSum(198,2));
      Console.WriteLine("198 is not concatenated with n = 3 {0}", mathematicsObject.checkConcatenatedSum(198,3));
      Console.WriteLine("2997 is concatenated with n = 3 {0}", mathematicsObject.checkConcatenatedSum(2997,3));
      Console.WriteLine("2997 is not concatenated with n = 2 {0}", mathematicsObject.checkConcatenatedSum(2997,2));
    }
  }
}