using System;
using System.Collections;

namespace ArrayTasks {
  class ArrayWorks {
    public int calculateSecondMax (int[] array) {
      int max, secondMax;
      if (array[0] < array[1]) {
        max = array[1];
        secondMax = array[0];
      } else {
        max = array[0];
        secondMax = array[1];
      }
      for(int i = 2, length=array.Length; i<length; i++) {
        if(max < array[i]) {
          secondMax = max;
          max = array[i];
        } else if (secondMax < array[i] && max != array[i]) { //this case is applied only when max is found before second max
          secondMax = array[i];
        }
      }
      return secondMax;
    }

    public int calculateNUpcount (int[] a, int n) {
      int upCount = 0, partialSum = 0, prevPartialSum;
      for (int i=0,length = a.Length; i<length; i++) {
        prevPartialSum = partialSum;
        partialSum = partialSum + a[i];
        if (partialSum > n && prevPartialSum <= n) {
          upCount++;
        }
      }
      return upCount;
    }
    public int isMadhavArray (int[] a) {
      int length = a.Length, n = 0;
      int isNumberConditionSatisfied = 0;
      for (int i = 0; i<length; i++) {
        if(i*(i+1)/2 == length) {
          isNumberConditionSatisfied = 1;
          n = i;
          break;
        }
      }
      if(isNumberConditionSatisfied == 1) {
        int j = 2, i = 1;
        while(j<=n) {
          int partialSum = 0;
          for(int k = 0; k<j; k++) {
            partialSum += a[i];
            i++;
          }
          if(partialSum != a[0]) {
            return 0;
          }
          j++;
        }
        return 1;
      } else {
        return 0;
      }
    }

    public int checkInertial(int[] array) {
      int max = array[0], length = array.Length, oddIndex=0, evenIndex = 0, countEven=0, countOdd=0;
      //calculating length of odd and even numbers in array
      for(int i = 0; i<length; i++) {
        if(array[i]%2==0) {
          countEven++;
        } else {
          countOdd++;
        }
      }

      int[] oddArray = new int[countOdd], evenArray = new int[countEven];
      bool hasAtLeast1Odd = false, hasMaxValueEven = false, everyOddGreaterThanOtherEven = true;
      for(int i = 0; i<length; i++) {
        if(array[i]%2 == 1) {
          hasAtLeast1Odd = true;
          oddArray[oddIndex] = array[i];
          oddIndex++;
        } else if(array[i]%2 == 0){
          evenArray[evenIndex] = array[i];
          evenIndex++;
        }
        if(max<array[i]) {
          max = array[i];
        }
      }
      if(max%2 == 0) {
        hasMaxValueEven = true;
      }
      for(int i=0; i<countOdd; i++) {
        for(int j =0; j<countEven; j++) {
          if(oddArray[i] < evenArray[j] && evenArray[j] != max) {
            everyOddGreaterThanOtherEven = false;
          }
        }
      }
      return hasAtLeast1Odd && hasMaxValueEven && everyOddGreaterThanOtherEven ? 1 : 0;
    }

    public int countSquarePairs(int[] array) {
      int countPerfectSquarePair = 0;
      for(int i =0, length = array.Length; i<length-1; i++) {
        if(array[i]<=0) {
          continue;
        }
        for(int j = i+1; j< length; j++ ) {
          if(array[j]<=0) {
            continue;
          }
          if(Math.Sqrt(array[i] + array[j])%1==0) {
            countPerfectSquarePair++;
          }
        }
      }
      return countPerfectSquarePair;
    }
    public int gutherieSequence(int[] array) {
      int startingNumber = array[0], gutherieSequenceNumber=0, isgutherieSequenceNumber = 0;
      if(array[array.Length-1] != 1 || startingNumber < 1) {
        return 0;
      }
      int i = 0;
      while(gutherieSequenceNumber != 1) {
        if(array[i]%2==0) {
          gutherieSequenceNumber = array[i]/2;
        } else {
          gutherieSequenceNumber = array[i]*3+1;
        }
        if(gutherieSequenceNumber != array[i+1]) {
          isgutherieSequenceNumber = 1;
          break;
        }
        i++;
      }
      if(isgutherieSequenceNumber == 0) {
        return 1;
      } else {
        return 0;
      }
    }

    public int santonMeasures(int[] array) {
      int count1=0, countn=0;
      for(int i=0, length=array.Length; i<length; i++) {
        if(array[i] == 1) {
          count1++;
        }
      }
      for(int i=0, length=array.Length; i<length; i++) {
        if(array[i] == count1) {
          countn++;
        }
      }
      return countn;
    }

    public int sumFactor(int[] array) {
      int sum = 0, count = 0;
      for(int i=0, length=array.Length; i<length; i++) {
        sum += array[i];
      }
      for(int i=0, length=array.Length; i<length; i++) {
        if(sum == array[i]) {
          count++;
        }
      }
      return count;
    }

    public int center15(int[] array) {
      int length = array.Length, centerSum = 0, centerIndex = 0, centerBelow = 0, centerUp = 0;
      if(length%2!=0) {
        centerIndex = length/2;
        centerBelow = length/2 + 1;
        centerUp = length/2 - 1;
      } else {
        centerBelow = length/2 - 1;
        centerUp = length/2;
      }
      int i = centerBelow, j = centerUp;
      while(i>=0 && j<length) {
        if(centerSum == 0 && length%2!=0) {
          centerSum = centerSum + array[centerIndex];
        }
        if(centerSum == 15) {
          return 1;
        }
        centerSum = array[i] + array[j] + centerSum;
        i--;
        j++;
      }
      return 0;
    }

    public int Divisible(int[] array, int divisor) {
      for(int i = 0, length=array.Length; i<length; i++) {
        if(array[i]%divisor != 0) {
          return 0;
        }
      }
      return 1;
    }

    public int isNUnique(int[] array, int n) {
      int countPair = 0;
      for(int i = 0, length=array.Length; i<length; i++) {
        for(int j = i + 1; j<length; j++) {
          if(array[i] + array[j] == n) {
            countPair++;
          }
        }
      }
      return countPair == 1 ? 1 : 0;
    }

    public int isLegalNumber(int[] array, int n) {
      //won't work for base 11 +
      bool isNotLegal = false;
      int number = 0, counter = 0;
      for(int i=0, length = array.Length; i<length; i++) {
        if(array[i] >= n) {
          isNotLegal = true;
        }
      }
      if(!isNotLegal) {
        for(int i=array.Length-1, len = array.Length; i>=0; i--) {
          number = array[i] * (int)Math.Pow(n, counter) + number;
          Console.WriteLine(number);
          counter++;
        }
        return number;
      }
      else {
        return 0;
      }
      // return 1;
    }

    public int isNonZero(int[] array) {
      for(int i = 0, len = array.Length; i< len; i++) {
        if(array[i] == 0) {
          return 0;
        }
      }
      return 1;
    }

    public int matches(int[] array, int[] pattern) {
      int k = 0, sum=0;
      for(int i = 0; i<pattern.Length; i++) {
        if(pattern[i]==0) {
          return 0;
        }
        sum += Math.Abs(pattern[i]);
      }
      if(sum != array.Length) {
        return 0;
      }
      for(int i = 0; i<pattern.Length; i++) {
        for(int j=0; j<Math.Abs(pattern[i]); j++) {
          if(array[k] == 0) {
            return 0;
          }
          if(pattern[i]>0 && array[k]<0) {
            return 0;
          } else if(pattern[i]<0 && array[k]>0) {
            return 0;
          }
          k++;
        }
      }
      return 1;
    }

    public int isSumSafe(int[] array) {
      int sum = 0;
      for(int i=0, len=array.Length; i<len; i++) {
        sum += array[i];
      }
      for(int i=0, len=array.Length; i<len; i++) {
        if(array[i] == sum) {
          return 0;
        }
      }
      return 1;
    }

    public int isVanilla(int[] array) {
      if(array.Length == 0) {
        return 1;
      }
      int givenDigit = array[0]%10;
      for(int i=0, len=array.Length; i<len; i++) {
        int num = array[i];
        while(num!=0) {
          if(num%10 != givenDigit) {
            return 0;
          }
          num = num/10;
        }
      }
      return 1;
    }

    public int isBounded(int[] array) {
      for(int i = 0, len=array.Length; i<len-1; i++) {
        if(array[i]>array[i+1]) {
          return 0;
        }
        int count = 0;
        for(int j = 0; j<len; j++) {
          if(array[i] == array[j]) {
            count++;
          }
        }
        Console.WriteLine("{0} times {1} with i {2}", count, array[i], i);
        if(count > array[i]) {
          return 0;
        }
      }
      return 1;
    }

    public int isMinMaxDisjoint(int[] array) {
      if(array.Length < 2) {
        return 0;
      }
      int min=array[0] > array[1] ? array[1]: array[0],
        max=array[1]>array[0] ? array[1]:array[0],
        len = array.Length,
        minCount=0, maxCount=0;
      for(int i=1; i<len; i++) {
        if(max<array[i]) {
          max = array[i];
        }
        if(min>array[i]) {
          min=array[i];
        }
      }

      for(int i=0; i<len; i++) {
        if(max == array[i]) {
          maxCount++;
        }
        if(min == array[i]) {
          minCount++;
        }
      }
      for(int i=0; i<len-1;i++) {
        if(array[i]==max && array[i+1]==min) {
          return 0;
        }
        if(array[i] == min && array[i+1] == max) {
          return 0;
        }
      }
      if(maxCount>1 || minCount>1) {
        return 0;
      }
      if(max==min) {
        return 0;
      }
      return 1;
    }

    public int isPacked(int[] array) {
      int len=array.Length;
      if(len==0) {
        return 1;
      }
      for(int i=0; i<len; i++) {
        if(array[i]<=0) {
          return 0;
        }
        int count=1;
        for(int j=0; j<len; j++) {
          int previousCount=count;
          if(array[i] == array[j] && i<j) {
            count++;
          }
          if(count!=previousCount) {
            if(array[j] != array[j-1]) {
              return 0;
            }
          }
        }
        Console.WriteLine(count);
        if(count>array[i] || count<array[i]) {
          return 0;
        }
      }
      return 1;
    }
    public int is121Array(int[] array) {
      int count1=0, len=array.Length, twoFound=0, endingBegun=0, countEnding=0;
      for(int i=0; i<len; i++) {
        if(array[i] != 1 && array[i] != 2) {
          return 0;
        }
        if(array[i] == 1 && twoFound ==0) {
          count1++;
        } else if(array[i] == 2) {
          twoFound=1;
        }

        if(twoFound==1 && array[i] == 1) {
          endingBegun = 1;
        }
        if(endingBegun == 1 && array[i] == 2) {
          return 0;
        } else if(endingBegun == 1) {
          countEnding++;
        }
      }
      return count1>0 && count1==countEnding ? 1 : 0;
    }

    public int[] filterArray(int[] array, int n) {
      int sizeOfArray=0, tempN = n;
      while(tempN!=0) {
        if(tempN%2==1) {
          sizeOfArray++;
        }
        tempN=tempN/2;
      }
      if(sizeOfArray > array.Length) {
        return null;
      }
      int[] finalArray = new int[sizeOfArray];
      int tempn = n, count=0, j=0;
      while(tempn!=0) {
        if(tempn%2==1) {
          finalArray[j] = array[count];
          j++;
        }
        count++;
        tempn=tempn/2;
      }
      for(int i=0; i<sizeOfArray; i++) {
        Console.WriteLine(finalArray[i]);
      }
      return finalArray;
    }

    public int largestAdjacentSum (int[] array) {
      int sum =array[0]+array[1];
      for(int i=1; i<array.Length-1; i++) {
        if(sum < array[i]+array[i+1]) {
          sum = array[i] + array[i+1];
        }
      }
      return sum;
    }

    public int isSequencedArray(int[] array, int m, int n) {
      for(int i=0, len=array.Length; i<len; i++) {
        if(array[i]<m || array[i]>n) {
          return 0;
        }
        if(i+1<len && array[i]>array[i+1]) {
          return 0;
        }
      }
      for(int j=m; j<=n; j++) {
        int foundItem=0;
        for(int i=0, len=array.Length; i<len; i++) {
          if(j==array[i]) {
            foundItem=1;
          }
        }
        if(foundItem==0) {
          return 0;
        }  
      }
      return 1;
    }
    public int isTrivalent(int[] array) {
      Hashtable uniqueElement = new Hashtable();
      if(array.Length < 3) {
        return 0;
      }
      for(int i=0; i<array.Length; i++) {
        if(!uniqueElement.ContainsKey(array[i])) {
          uniqueElement.Add(array[i],array[i]);
        }
      }
      int count=0;
      foreach (DictionaryEntry de in uniqueElement) {
        count++;
      }
      if(count>3 || count < 3) {
        return 0;
      }
      return 1;
    }

    public int[] sortArray(int[] array) {
      int[] copy = new int[array.Length];
      for(int i=0, len = array.Length; i<len; i++) {
        copy[i] = array[i];
      }
      for(int i=0, len=copy.Length; i<len; i++) {
        for(int j=i+1; j<len; j++) {
          if(copy[i]>copy[j]) {
            int temp = copy[i];
            copy[i] = copy[j];
            copy[j] = temp;
          }
        }
      }
      for(int i=0, len = array.Length; i<len; i++) {
        Console.WriteLine(copy[i]);
      }
      return copy;
    }

    public int countUnique(int[] array) {
      int count=1, len=array.Length;
      // by sorting
      int[] sortedArray = sortArray(array);
      for(int i=1; i<len; i++) {
        if(sortedArray[i] != sortedArray[i-1]) {
          count++;
        }
      }
      return count;

      // Works by checking if current element exists before . if it does increase duplicate count
      /*
      for(int i=0; i<len; i++) {
        for(int j=0; j<i; j++) {
          if(i!=j && array[i]==array[j]) {
            count++;
            break;
          }
        }
      }
      return len-count;*/
    }

    public int[] findUnique(int[] array) {
      int count =1, len = array.Length;
      // sort
      for(int i=0; i<len; i++) {
        for(int j=i+1; j<len; j++) {
          if(array[i]>array[j]) {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
          }
        }
      }
      Console.WriteLine("sorted");
      for(int i=0; i<array.Length; i++) {
        Console.WriteLine(array[i]);
      }
      // count unique
      for(int i=1; i<len; i++) {
        if(array[i] != array[i-1]) {
          count++;
        }        
      }

      // new array with unique
      int k=1;
      int[] uniqueArray = new int[count];
      uniqueArray[0] = array[0];
      for(int i=1; i<len; i++) {
        if(array[i] != array[i-1]) {
          uniqueArray[k] = array[i];
          k++;
        }   
      }
      Console.WriteLine("uniques");
      for(int i=0; i<uniqueArray.Length; i++) {
        Console.WriteLine(uniqueArray[i]);
      }
      return uniqueArray;
    }

    public void countDuplicatesUsingHash(int[] array) {
      Hashtable duplicates = new Hashtable();
      for(int i=0, len=array.Length; i<len; i++) {
        if(!duplicates.ContainsKey(array[i])) {
          duplicates.Add(array[i],1);
        } else {
          duplicates[array[i]] = (int)duplicates[array[i]] + 1;
        }
      }
      foreach(DictionaryEntry de in duplicates) {
        Console.WriteLine("{0} is repeated {1} times", de.Key, de.Value);
      }
    }

    public void countDuplicates(int[] a) {
      for(int i=0; i<a.Length; i++) {
        for(int j=i+1; j<a.Length; j++) {
          if(a[i]>a[j]) {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
          }
        }
      }
      int count=1;
      for(int i=1; i<a.Length; i++) {
        if(a[i] != a[i-1]) {
          Console.WriteLine("{0} is repeated {1} times", a[i-1], count);
          count =1;
        } else {
          count++;
        }
        if(count==1 && i==a.Length-1){
          Console.WriteLine("{0} is repeated {1} times", a[i], count);
        }
      }
    }

  }

  class ArrayTasks {
    public static void testArrayRef(int[] array) {
      array[0] = 2;
    }
    public static void Main(string[] args) {
      ArrayWorks secMax = new ArrayWorks();
      // int[] array1 = {-1,2,3,-3,4,5};
      // int[] array2 = {1,-2,3,3,4,5,-13,-5};
      // int[] array3 = {1,2,-3,-1,5,-4};
      // Console.WriteLine("Second Max is {0}", secMax.calculateSecondMax(array1));
      // Console.WriteLine("Second Max is {0}", secMax.calculateSecondMax(array2));
      // Console.WriteLine("Second Max is {0}", secMax.calculateSecondMax(array3));
      
      // int[] upCountArray1 = {2,3,1,-6,8,-3,-1,2};
      // int[] upCountArray2 = {6,1,3};
      // int[] upCountArray3 = {1,2,-1,5,2,-3};
      // Console.WriteLine("Upcount for array1 should be 3 and is : {0}", secMax.calculateNUpcount(upCountArray1, 5));
      // Console.WriteLine("Upcount for array2 should be 1 and is : {0}", secMax.calculateNUpcount(upCountArray2, 6));
      // Console.WriteLine("Upcount for array3 should be 0 and is : {0}", secMax.calculateNUpcount(upCountArray3, 20));
      
      //MadhavArray
      // int[] isMadhav1 = {2,1,1};
      // int[] isMadhav2 = {2, 1, 1, 4, -1, -1};
      // int[] isMadhav3 = {6, 2, 4, 2, 2, 2, 1, 5, 0, 0};
      // int[] isMadhav4 = {18, 9, 10, 6, 6, 6};
      // int[] isMadhav5 = {-6, -3, -3, 8, -5, -4};
      // int[] isMadhav6 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, -2, -1};
      // int[] isMadhav7 = {3,1,2,3,0};
      // Console.WriteLine("Is Madhav Array 1 : {0}", secMax.isMadhavArray(isMadhav1));
      // Console.WriteLine("Is Madhav Array 2 : {0}", secMax.isMadhavArray(isMadhav2));
      // Console.WriteLine("Is Madhav Array 3 : {0}", secMax.isMadhavArray(isMadhav3));
      // Console.WriteLine("Is Madhav Array 4 : {0}", secMax.isMadhavArray(isMadhav4));
      // Console.WriteLine("Is Madhav Array 5 : {0}", secMax.isMadhavArray(isMadhav5));
      // Console.WriteLine("Is Madhav Array 6 : {0}", secMax.isMadhavArray(isMadhav6));
      // Console.WriteLine("Is Madhav Array 7 : {0}", secMax.isMadhavArray(isMadhav7));


      //inertial
      // int[] inertialArray = {11, 4, 20, 9, 2, 8};
      // Console.WriteLine("Is inertial Array : {0}", secMax.checkInertial(inertialArray));

    
      //perfectSquare pair
      // int[] pairArray = {9, 0, 2, -5, 7};
      // Console.WriteLine("Number of perfectSquare pairs is {0}", secMax.countSquarePairs(pairArray));
    
      //gutherie number
      // int[] guthAr{3, 1, 1, 4}ray = {8, 4, 4, 2, 1};
      // Console.WriteLine("Array is Gutherie sequence: {0}", secMax.gutherieSequence(guthArray) == 1 ? true : false);
    
      //santon measures
      // int[] santonArray = {2, 1, 1, 2, 4, 3, 2};
      // Console.WriteLine("Santon Measure is {0}", secMax.santonMeasures(santonArray));
    
      //sum factor
      // int[] sumFactorArray = {1, -1, 1, -1, 1, -1, 1};
      // Console.WriteLine("Sum Factor number is {0}", secMax.sumFactor(sumFactorArray));

      //center15
      // int[] center15array1 = {3,2,10,4,1,6,9};
      // int[] center15array2 = {2,10,4,1,6,9};
      // int[] center15array3 = {1,1,15,-1,-1};
      // int[] center15array4 = {3,2,10,4,1,6};
      // Console.WriteLine("CenterSum should be 1 number is {0}", secMax.center15(center15array1));
      // Console.WriteLine("CenterSum should be 0 number is {0}", secMax.center15(center15array2));
      // Console.WriteLine("CenterSum should be 0 number is {0}", secMax.center15(center15array4));
      // Console.WriteLine("CenterSum should be 1 number is {0}", secMax.center15(center15array3));

      //Divisible
      // int[] divisorArray = {2,4,6,8,10,12};
      // int[] divisorArray1 = {3,15,27};
      // int[] divisorArray2 = {2,3,4};
      // Console.WriteLine("Divisible should be 1 number is {0}", secMax.Divisible(divisorArray,2));
      // Console.WriteLine("Divisible should be 1 number is {0}", secMax.Divisible(divisorArray1,3));
      // Console.WriteLine("Divisible should be 0 number is {0}", secMax.Divisible(divisorArray2,2));
    
      //n-unique
      // int[] nUniqueArray = {7, 3, 3, 2, 4};
      // int[] nUniqueArray1 = {1};
      // Console.WriteLine("Array should not be 6-unique number: {0}", secMax.isNUnique(nUniqueArray,6));
      // Console.WriteLine("Array should not be 10-unique number: {0}", secMax.isNUnique(nUniqueArray,10));
      // Console.WriteLine("Array should be 11-unique number: {0}", secMax.isNUnique(nUniqueArray,11));
      // Console.WriteLine("Array should not be 8-unique number: {0}", secMax.isNUnique(nUniqueArray,8));
      // Console.WriteLine("Array should be 9-unique number: {0}", secMax.isNUnique(nUniqueArray,9));
      // Console.WriteLine("Array should not be any-unique number: {0}", secMax.isNUnique(nUniqueArray1,2));

      //isValidNumber and conversion
      // int[] validArray = {1,0,1,1};
      // int[] invalidArray = {1,1,2};
      // int[] validArray1 = {3,2,5};
      // int[] invalidArray1 = {3,7,1};
      // Console.WriteLine("Array should not be valid number: {0}", secMax.isLegalNumber(validArray,2));
      // Console.WriteLine("Array should not be valid number: {0}", secMax.isLegalNumber(invalidArray,3));
      // Console.WriteLine("Array should not be valid number: {0}", secMax.isLegalNumber(validArray1,8));
      // Console.WriteLine("Array should not be invalid number: {0}", secMax.isLegalNumber(invalidArray1,6));

      //Pattern Matching
      // int[] arrayToMatch = {1,  2,  3, -5, -5,  2, 3, 18};
      // int[] pattern1 = {3, -2, 3};
      // int[] pattern2 = {1,1,1,-1,-1,1,1,1};
      // int[] failingPattern1 = {4, -1, 3};
      // int[] failingPattern2 = {8};
      // int[] failingPattern3 = {2,3,-3};
      // Console.WriteLine("Array should be pattern verified: {0}", secMax.matches(arrayToMatch,pattern1));
      // Console.WriteLine("Array should be pattern verified: {0}", secMax.matches(arrayToMatch,pattern2));
      // Console.WriteLine("Array should not be pattern verified: {0}", secMax.matches(arrayToMatch,failingPattern1));
      // Console.WriteLine("Array should not be pattern verified: {0}", secMax.matches(arrayToMatch,failingPattern2));
      // Console.WriteLine("Array should not be pattern verified: {0}", secMax.matches(arrayToMatch,failingPattern3));

      //SumSafe
      // int[] sumSafeArray = {4,-2,1};
      // int[] sumUnSafeArray = {5,-5,0};
      // Console.WriteLine("Array should be sum safe: {0}", secMax.isSumSafe(sumSafeArray));
      // Console.WriteLine("Array should not be sum safe: {0}", secMax.isSumSafe(sumUnSafeArray));

   
      // isVanilla
      // int[] vanillaArray = {1,11,111,111,1111,1111,1};
      // int[] nonVanillaArray = {};
      // Console.WriteLine("Array should be vanilla array: {0}", secMax.isVanilla(vanillaArray));
      // Console.WriteLine("Array should not be vanilla array: {0}", secMax.isVanilla(nonVanillaArray));
   
      // isTrivalent
      // int[] trivalentArray = {1,1,2,2,3,3,1};
      // int[] nonTrivalentArray = {};
      // int[] nonTrivalentArray1 = {1,1,1};
      // Console.WriteLine("Array should be trivalent array: {0}", secMax.isTrivalent(trivalentArray));
      // Console.WriteLine("Array should not be trivalent array: {0}", secMax.isTrivalent(nonTrivalentArray));
      // Console.WriteLine("Array should not be trivalent array: {0}", secMax.isTrivalent(nonTrivalentArray1));

      // isBounded
      // int[] boundedArray = {1,2,2,3,3,4,4};
      // int[] nonBoundedArray = {1,2,1};
      // int[] nonBoundedArray1 = {1,2,2,2};
      // Console.WriteLine("Array should be Bounded array: {0}", secMax.isBounded(boundedArray));
      // Console.WriteLine("Array should not be Bounded array: {0}", secMax.isBounded(nonBoundedArray));
      // Console.WriteLine("Array should not be Bounded array: {0}", secMax.isBounded(nonBoundedArray1));


      // MinMaxDisjoint
      // int[] minMaxDisjoint = {5, 4, 1, 3, 2};
      // int[] minMaxDisjoint1 = {18, -1, 3, 4, 0};
      // int[] minMaxDisjoint2 = {9, 0, 5, 9};
      // int[] minMaxDisjoint3 = {};
      // int[] minMaxDisjoint4 = {1};
      // Console.WriteLine("Array should be min max disjoint array: {0}", secMax.isMinMaxDisjoint(minMaxDisjoint));
      // Console.WriteLine("Array should not be min max disjoint array: {0}", secMax.isMinMaxDisjoint(minMaxDisjoint1));
      // Console.WriteLine("Array should not be min max disjoint array: {0}", secMax.isMinMaxDisjoint(minMaxDisjoint2));
      // Console.WriteLine("Array should not be min max disjoint array: {0}", secMax.isMinMaxDisjoint(minMaxDisjoint3));
      // Console.WriteLine("Array should not be min max disjoint array: {0}", secMax.isMinMaxDisjoint(minMaxDisjoint4));
    
      //is121
      // int[] onetwooneArray = {1,2,1};      
      // int[] onetwooneArray1 = {1,1,2,2,1,1};      
      // int[] onetwooneArray2 = {1,2,1,1};      
      // int[] onetwooneArray3 = {2,1};      
      // int[] onetwooneArray4 = {2,2};      
      // int[] onetwooneArray5 = {1,2,2,1};      
      // Console.WriteLine("Array should be one two one array: {0}", secMax.is121Array(onetwooneArray));
      // Console.WriteLine("Array should be one two one array: {0}", secMax.is121Array(onetwooneArray1));
      // Console.WriteLine("Array should not be one two one array: {0}", secMax.is121Array(onetwooneArray2));
      // Console.WriteLine("Array should not be one two one array: {0}", secMax.is121Array(onetwooneArray3));
      // Console.WriteLine("Array should not be one two one array: {0}", secMax.is121Array(onetwooneArray4));
      // Console.WriteLine("Array should be one two one array: {0}", secMax.is121Array(onetwooneArray5));

      // filterArray
      // int[] filterArray = {9,-9};
      // Console.WriteLine("FilteredArray should be {0}", secMax.filterArray(filterArray, 2));

      //largestSumCorresponding...
      // int[] largestAdjacentSumArray = {18, -12, 9, -10};
      // Console.WriteLine("Largest Adjacent Sum should be {0}", secMax.largestAdjacentSum(largestAdjacentSumArray));
    
      // isSequencedArray
      // int[] sequencedArray = {1,2,3,4,5};
      // int[] sequencedArray1 = {-5,-5,-4,-4,-3,-3,-2,-2,-2};
      // int[] nonSequencedArray = {1,3,5,2};
      // Console.WriteLine("Array should be sequenced {0}", secMax.isSequencedArray(sequencedArray,1,5));
      // Console.WriteLine("Array should be sequenced {0}", secMax.isSequencedArray(sequencedArray1,-5,-2));
      // Console.WriteLine("Array should not be sequenced {0}", secMax.isSequencedArray(nonSequencedArray, 1,5));


      //sort test
      // int [] arrayToSort = {1,5,5,4,3};
      // Console.WriteLine(secMax.findUnique(arrayToSort));
      
      //cound duplicates
      int[] arrayWithDuplicates = {1,2,3,5,3,0,2,1,1,1};
      secMax.countDuplicates(arrayWithDuplicates);
    }
  }
}