//*****************************************************************************
//** 1508. Range Sum of Sorted Subarray Sums  leetcode                       **
//** I had time issues with this problem.  The sorting array ended up taking **
//** a lot of time.  I tried using ChatGPT to optimize it, but no success.   **
//** This is slow code, but it works.                               -Dan     **
//*****************************************************************************

// Function to compare two integers (used in qsort)
int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int rangeSum(int* nums, int numsSize, int n, int left, int right) {
    int *newArray = (int*)malloc((numsSize * (numsSize+1) / 2)*sizeof(int*));
    int counter = 0;
    for(int i = 0; i < numsSize; i++)
    {
        int sum = 0;
        for(int j = i; j < numsSize; j++)
        {
            sum += nums[j];
            newArray[counter++] = sum;
        }        
    }

    qsort(newArray, counter, sizeof(int), compare);
//    quickSort(newArray, 0, counter - 1);

    for(int i = 0; i < counter; i++)
    {

        printf("newArray[%d] = %d\n",i,newArray[i]);
    }


    long long retnum = 0;
    for(int i = left-1; i < right; i++)
    {
        retnum = (retnum + newArray[i]) % 1000000007;
    }

    return retnum;

}
