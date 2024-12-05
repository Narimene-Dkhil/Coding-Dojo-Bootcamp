# Implement Quicksort (Optional)

## Objectives:
- Technical interview practice
- Implement quicksort
- Sort an unsorted array with no duplicate values

Using what you learned from the previous module, implement quicksort!

Begin by writing the code for Hoare's partitioning algorithm. Remember that we will need to call this function to partition not just the entire array, but sections of the array. Therefore, our function should receive not just the array to partition, but also boundaries to indicate the portion of the array that is being partitioned. Don't forget to return the position of the pivot value!

Once we have a way to partition, we can think about writing our quicksort function. Quicksort will call the partition algorithm and pass it the array to sort and the boundaries. Since partition returns the pivot position, quicksort will be able to use the pivot position to do the procedure all over again, but with different boundaries.

**Consider:** Where will the recursive call be? When do we know a portion of the array has been sorted? When do we know the entire array has been sorted?

**Bonus 1:**  Different strategies are used to choose the pivot. Any pivot would work, so why not just choose an easy pivot, such as the left-most value? The answer is that the time complexity could be greatly increased if we were to call quicksort on an array that is already sorted. Diagram this out and determine why this is true.

**Bonus 2:**  What is the Big O time complexity of this algorithm?

**Bonus 3:**  The Big O time complexity of quicksort is actually not impressive at all. So why is it called quicksort? Remember that Big O is for the worst case scenario. In this case, the worst case scenario is unlikely to be encountered - it's when we try to quicksort a sorted array and assign the pivot to an edge value. We use **Big Omega** to talk about the best case scenario and **Big Theta** to talk about the average case.  What are the Big Omega and Big Theta time complexities of quicksort?

