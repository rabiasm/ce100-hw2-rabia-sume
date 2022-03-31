
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**********************************************************************************
***********************************************************************************
* @file ce100_hw2_algo_lib_cs *
* @author Rabia SÜME *
* @date 31 March 2022 * 
*
* @brief <b> hw-2 Functions </b> *
*
* HW-2 Sample Lib Functions *
*
* @see http://bilgisayar.mmf.erdogan.edu.tr/en/
*
***********************************************************************************
***********************************************************************************/




namespace ce100_hw2_algo_lib_cs
{
    public class Class1

    {

        /// <summary MatrixmultiplicationIterative > 
        /// 
        /// </summary>
        /// <param name="mat1"></int[,]>
        /// <param name="mat2"></intint[,]>
        /// <param name="res"></intint[,]>
        /// <param name="N"></int>
        /// <returns></returns>
        // This function multiplies mat1[][]
        // and mat2[][], and stores the result
        // in res[][]
        public static int[,] MatrixmultiplicationIterative(int[,] mat1,
                             int[,] mat2, int[,] res, int N)
        {

            int i, j, k; //we define a variable
            for (i = 0; i < N; i++) // i equals zero, i less than N then we increase i one by one
            {
                for (j = 0; j < N; j++) // j equals zero, j less than N then we increase j one by one
                {
                    res[i, j] = 0; // equate matrix to zero
                    for (k = 0; k < N; k++) // 
                        res[i, j] += mat1[i, k]
                                     * mat2[k, j];
                }
            }
            return res;

        }












        


        
        public static int i = 0, j = 0, k = 0;
        /// <summary>
        /// 
        /// </summary Note that below variables
        /// are static i and j are used
        /// to know current cell of result
        /// matrix C[][]. k is used to
        /// know current column number of
        /// A[][] and row number of B[][]
        /// to be multiplied>
        /// <param name="row1"></int>
        /// <param name="col1"></int>
        /// <param name="A"></int[,]>
        /// <param name="row2"></int>
        /// <param name="col2"></int>
        /// <param name="B"></int[,]>
        /// <param name="C"></int[,]>
        public static void MultiplyMatrixRec(int row1, int col1,
                                      int[,] A, int row2,
                                      int col2, int[,] B,
                                      int[,] C)
        {
            // If all rows traversed
            if (i >= row1)
                return;

            // If i < row1
            if (j < col2)
            {
                if (k < col1)
                {
                    C[i, j] += A[i, k] * B[k, j];
                    k++;

                    MultiplyMatrixRec(row1, col1, A,
                                      row2, col2, B, C);
                }

                k = 0;
                j++;
                MultiplyMatrixRec(row1, col1, A,
                                  row2, col2, B, C);
            }

            j = 0;
            i++;
            MultiplyMatrixRec(row1, col1, A,
                              row2, col2, B, C);
        }











        /// <MatrixMultStrassen>
        /// 
        /// </summary>
        /// <param name="a"></float[,]>
        /// <param name="b"></float[,]>
        /// <param name="n"></int>
        /// <returns></returns>

        public static float[,] MatrixMultStrassen(float[,] a, float[,] b, int n)
        {
            if (n == 2)
            {
                var m1 = (a[0, 0] + a[1, 1]) * (b[0, 0] + b[1, 1]);
                var m2 = (a[1, 0] + a[1, 1]) * b[0, 0];
                var m3 = a[0, 0] * (b[0, 1] - b[1, 1]);
                var m4 = a[1, 1] * (b[1, 0] - b[0, 0]);
                var m5 = (a[0, 0] + a[0, 1]) * b[1, 1];
                var m6 = (a[1, 0] - a[0, 0]) * (b[0, 0] + b[0, 1]);
                var m7 = (a[0, 1] - a[1, 1]) * (b[1, 0] + b[1, 1]);
                a[0, 0] = m1 + m4 - m5 + m7;
                a[0, 1] = m3 + m5;
                a[1, 0] = m2 + m4;
                a[1, 1] = m1 - m2 + m3 + m6;
                return a;
            }
            else
            {
                float[,] a11 = matrixDivide(a, n, 11);
                float[,] a12 = matrixDivide(a, n, 12);
                float[,] a21 = matrixDivide(a, n, 21);
                float[,] a22 = matrixDivide(a, n, 22);

                float[,] b11 = matrixDivide(b, n, 11);
                float[,] b12 = matrixDivide(b, n, 12);
                float[,] b21 = matrixDivide(b, n, 21);
                float[,] b22 = matrixDivide(b, n, 22);

                float[,] p1 = MatrixMultStrassen(a11, matrixDiff(b12, b22, n / 2), n / 2);
                float[,] p2 = MatrixMultStrassen(matrixSum(a11, a12, n / 2), b22, n / 2);
                float[,] p3 = MatrixMultStrassen(matrixSum(a21, a22, n / 2), b11, n / 2);
                float[,] p4 = MatrixMultStrassen(a22, matrixDiff(b21, b11, n / 2), n / 2);
                float[,] p5 = MatrixMultStrassen(matrixSum(a11, a22, n / 2), matrixSum(b11, b22, n / 2), n / 2);
                float[,] p6 = MatrixMultStrassen(matrixDiff(a12, a22, n / 2), matrixSum(b21, b22, n / 2), n / 2);
                float[,] p7 = MatrixMultStrassen(matrixDiff(a11, a21, n / 2), matrixSum(b11, b12, n / 2), n / 2);

                float[,] c11 = matrixDiff(matrixSum(p5, p4, n / 2), matrixDiff(p2, p6, n / 2), n / 2);
                float[,] c12 = matrixSum(p1, p2, n / 2);
                float[,] c21 = matrixSum(p3, p4, n / 2);
                float[,] c22 = matrixDiff(matrixSum(p1, p5, n / 2), matrixSum(p3, p7, n / 2), n / 2);

                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = 0; j < n / 2; j++)
                    {
                        a[i, j] = c11[i, j];
                        a[i, j + n / 2] = c12[i, j];
                        a[i + n / 2, j] = c21[i, j];
                        a[i + n / 2, j + n / 2] = c22[i, j];
                    }
                }
                return a;
            }
        }


        /// < matrixSum>
        /// 
        /// </summary  >
        /// <param name="a"></float[,]>
        /// <param name="b"></float[,]>
        /// <param name="n"></int>
        /// <returns></returns>
        static float[,] matrixSum(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] + b[i, j];
            return c;
        }

        /// < matrixDiff>
        /// 
        /// </summary>
        /// <param name="a"></float[,]>
        /// <param name="b"></float[,]>
        /// <param name="n"></int>
        /// <returns></returns>
        static float[,] matrixDiff(float[,] a, float[,] b, int n)
        {
            float[,] c = new float[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    c[i, j] = a[i, j] - b[i, j];
            return c;
        }

        /// < matrixCombine>
        /// 
        /// </summary>
        /// <param name="a11"></float[,]>
        /// <param name="a12"></float[,]>
        /// <param name="a21"></float[,]>
        /// <param name="a22"></float[,]>
        /// <param name="n"></int>
        /// <returns></returns>
        static float[,] matrixCombine(float[,] a11, float[,] a12, float[,] a21, float[,] a22, int n)
        {
            float[,] a = new float[n, n];
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    a[i, j] = a11[i, j];
                    a[i, j + n / 2] = a12[i, j];
                    a[i + n / 2, j] = a21[i, j];
                    a[i + n / 2, j + n / 2] = a22[i, j];
                }
            }
            return a;
        }

        /// < matrixDivide>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="region"></param>
        /// <returns></returns>
        static float[,] matrixDivide(float[,] a, int n, int region)
        {
            float[,] c = new float[n / 2, n / 2];
            if (region == 11)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 12)
            {
                for (int i = 0, x = 0; x < n / 2; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 21)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = 0; y < n / 2; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            else if (region == 22)
            {
                for (int i = 0, x = n / 2; x < n; i++, x++)
                {
                    for (int j = 0, y = n / 2; y < n; j++, y++)
                    {
                        c[i, j] = a[x, y];
                    }
                }
            }
            return c;

        }










        /// <RadixSort>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        public static void RadixSort(int[] arr)
        {
            int i, j;
            int[] tmp = new int[arr.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < arr.Length; ++i)
                {
                    bool move = (arr[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        arr[i - j] = arr[i];
                    else
                        tmp[j++] = arr[i];
                }
                Array.Copy(tmp, 0, arr, arr.Length - j, j);

            }
        }










        /// <CountingSort>
        /// 
        /// </summary>
        /// <param name="Array"></param>
        public static void CountingSort(int[] Array)

        {
            int n = Array.Length;
            int max = 0;
            //find largest element in the Array
            for (int a = 0; a < n; a++)
            {
                if (max < Array[a])
                {
                    max = Array[a];
                }
            }

            //Create a freq array to store number of occurrences of 
            //each unique elements in the given array 
            int[] freq = new int[max + 1];
            for (int a = 0; a < max + 1; a++)
            {
                freq[a] = 0;
            }
            for (int a = 0; a < n; a++)
            {
                freq[Array[a]]++;
            }

            //sort the given array using freq array
            for (int a = 0, b = 0; a <= max; a++)
            {
                while (freq[a] > 0)
                {
                    Array[b] = a;
                    b++;
                    freq[a]--;
                }
            }
        }











        /// <HeapSort>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        public static void HeapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                heapify(arr, n, largest);
            }
        }



        /// < Partition>
        /// 
        /// </summary This function takes first element as pivot, and 
        /// places all the elements smaller than the pivot on the
        /// left side and all the elements greater than the pivot
        /// on the right side.It returns the index of the last
        /// element on the smaller side>
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>
        /// <returns></j>
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                // Find leftmost element greater
                // than or equal to pivot
                do
                {
                    //increase i by 1
                    i++;
                }
                //do this until the ith number of the array is greater than the pivot
                while (arr[i] < pivot);

                // Find rightmost element smaller
                // than or equal to pivot
                do
                {
                    //increase j by 1
                    j--;
                }
                //do this until the ith number of the array is less than the pivot
                while (arr[j] > pivot);

                // If two pointers met.
                if (i >= j)
                { return j; }

                //Swap processing
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;


            }
        }


        /* The main function that
         implements QuickSort
          arr[] --> Array to be sorted,
          low --> Starting index,
          high --> Ending index */


        /// <LomutoQuickSort>
        /// 
        /// </summary>
        /// <param name="arr"></int>
        /// <param name="low"></int>
        /// <param name="high"></int>
        public static void LomutoQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {



                /* pi is partitioning index,
                arr[p] is now at right place */
                int pi = Partition(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                LomutoQuickSort(arr, low, pi - 1);
                LomutoQuickSort(arr, pi + 1, high);



            }
        }

        /// < partitionforHoares>
        /// 
        /// </summary>
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>
        /// <returns></returns>

        /* This function takes first element as pivot, and
          places all the elements smaller than the pivot on the
          left side and all the elements greater than the pivot
          on the right side. It returns the index of the last
          element on the smaller side*/
        static int partitionforHoares(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {
                // Find leftmost element greater
                // than or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller
                // than or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met.
                if (i >= j)
                    return j;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                // swap(arr[i], arr[j]);
            }
        }



        /// < HoaresQuickSort>
        /// 
        /// </summary>
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>


        /* The main function that
           implements QuickSort
        arr[] --> Array to be sorted,
        low --> Starting index,
        high --> Ending index */
        public static void HoaresQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index,
                arr[p] is now at right place */
                int pi = partitionforHoares(arr, low, high);

                // Separately sort elements before
                // partition and after partition
                HoaresQuickSort(arr, low, pi);
                HoaresQuickSort(arr, pi + 1, high);

            }
        }




        static int[] H = new int[50];
        static int sz = -1;

        // Function to return the index of the
        // parent node of a given node
        static int parent(int i)
        {
            return (i - 1) / 2;
        }

        // Function to return the index of the
        // left child of the given node
        static int leftChild(int i)
        {
            return ((2 * i) + 1);
        }

        // Function to return the index of the
        // right child of the given node
        static int rightChild(int i)
        {
            return ((2 * i) + 2);
        }


        /// < shiftUp>
        /// 
        /// </summary Function to shift up the
        /// node in order to maintain
        /// the heap property>
        /// <param name="i"></int>
        static void swap(int i, int j)
        {
            int temp = H[i];
            H[i] = H[j];
            H[j] = temp;
        }
        static void shiftUp(int i)
        {
            while (i > 0 && H[parent(i)] < H[i])
            {

                // Swap parent and current node
                swap(parent(i), i);

                // Update i to parent of i
                i = parent(i);
            }
        }


        /// < shiftDown>
        /// 
        /// </summaryFunction to shift down the node in
        /// order to maintain the heap property>
        /// <param name="i"></int>
        static void shiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = leftChild(i);

            if (l <= sz && H[l] > H[maxIndex])
            {
                maxIndex = l;
            }

            // Right Child
            int r = rightChild(i);

            if (r <= sz && H[r] > H[maxIndex])
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                swap(i, maxIndex);
                shiftDown(maxIndex);
            }
        }


        /// < insert>
        /// 
        /// </summary Function to insert a
        /// new element in
        /// the Binary Heap>
        /// <param name="p"></int>
        public static void insert(int p)
        {
            sz = sz + 1;
            H[sz] = p;

            // Shift Up to maintain
            // heap property
            shiftUp(sz);
        }


        /// < extractMax>
        /// 
        /// </summary Function to extract
        /// the element with
        /// maximum priority>
        /// <returns></result>
        static int extractMax()
        {
            int result = H[0];

            // Replace the value
            // at the root with
            // the last leaf
            H[0] = H[sz];
            sz = sz - 1;

            // Shift down the replaced
            // element to maintain the
            // heap property
            shiftDown(0);
            return result;
        }










        /// < Priority_Queue_with_Heap>
        /// 
        /// </summary Function to change the priority
        /// of an element>
        /// <param name="i"></int>
        /// <param name="p"></int>
        public static void Priority_Queue_with_Heap(int i, int p)
        {
            int oldp = H[i];
            H[i] = p;

            if (p > oldp)
            {
                shiftUp(i);
            }
            else
            {
                shiftDown(i);
            }
        }


        /// < getMax>
        /// 
        /// </summary Function to get value of
        /// the current maximum element>
        /// <returns></H[0]>
        static int getMax()
        {
            return H[0];
        }


        /// < Remove>
        /// 
        /// </summary Function to remove the element
        /// located at given index>
        /// <param name="i"></int>
        public static void Remove(int i)
        {
            H[i] = getMax() + 1;

            // Shift the node to the root
            // of the heap
            shiftUp(i);

            // Extract the node
            extractMax();
        }

        // int partition(int arr[], int l, int r, int k);

        // A simple function to find median of arr[]. This is called
        // only for an array of size 5 in this program.
        static int findMedian(int[] arr, int i, int n)
        {
            if (i <= n)
                Array.Sort(arr, i, n); // Sort the array
            else
                Array.Sort(arr, n, i);
            return arr[n / 2]; // Return middle element
        }

        // Returns k'th smallest element
        // in arr[l..r] in worst case
        // linear time. ASSUMPTION: ALL
        // ELEMENTS IN ARR[] ARE DISTINCT











        /// <SelectionProblem>

        /// </summary>
        /// <param name="arr"></int[]>
        /// <param name="l"></int>
        /// <param name="r"></int>
        /// <param name="k"></int>
        /// <returns></returns>

        public static int SelectionProblem(int[] arr, int l,
                                    int r, int k)
        {
            // If k is smaller than
            // number of elements in array
            if (k > 0 && k <= r - l + 1)
            {
                int n = r - l + 1; // Number of elements in arr[l..r]

                // Divide arr[] in groups of size 5,
                // calculate median of every group
                // and store it in median[] array.
                int i;

                // There will be floor((n+4)/5) groups;
                int[] median = new int[(n + 4) / 5];
                for (i = 0; i < n / 5; i++)
                    median[i] = findMedian(arr, l + i * 5, 5);

                // For last group with less than 5 elements
                if (i * 5 < n)
                {
                    median[i] = findMedian(arr, l + i * 5, n % 5);
                    i++;
                }

                // Find median of all medians using recursive call.
                // If median[] has only one element, then no need
                // of recursive call
                int medOfMed = (i == 1) ? median[i - 1] :
                                        SelectionProblem(median, 0, i - 1, i / 2);

                // Partition the array around a random element and
                // get position of pivot element in sorted array
                int pos = partitionforselection(arr, l, r, medOfMed);

                // If position is same as k
                if (pos - l == k - 1)
                    return arr[pos];
                if (pos - l > k - 1) // If position is more, recur for left
                    return SelectionProblem(arr, l, pos - 1, k);

                // Else recur for right subarray
                return SelectionProblem(arr, pos + 1, r, k - pos + l - 1);
            }

            // If k is more than number of elements in array
            return int.MaxValue;
        }



        /// <summary Swapforselection>
        /// 
        /// </summary>
        /// <param name="arr"></int[]>
        /// <param name="i"></int>
        /// <param name="j"></int>
        /// <returns></returns>
        public static int[] Swapforselection(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return arr;
        }
        // It searches for x in arr[l..r], and
        // partitions the array around x.
        static int partitionforselection(int[] arr, int l,
                                int r, int x)
        {
            // Search for x in arr[l..r] and move it to end
            int i;
            for (i = l; i < r; i++)
                if (arr[i] == x)
                    break;
  
            Swapforselection(arr, i, r);

            // Standard partition algorithm
            i = l;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    Swapforselection(arr, i, j);
                    i++;
                }
            }
            Swapforselection(arr, i, r);
            return i;
        }
        int size = 0;
        static void Swap(int a, int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }









        //RANDOMIZED QUICKSORT LOMUTO:

        /**
        *
        *   @name   RANDOMIZED QUICKSORT LOMUTO
        *
        *	@brief  RANDOMIZED QUICKSORT LOMUTO Function
        *
        *   In QuickSort we first partition the array in place such that all elements to the left of the pivot element are smaller,
        *   while all elements to the right of the pivot are greater than the pivot.
        *
        *	@param  [in] mass [\arr, low, high int]   RANDOMIZED QUICKSORT LOMUTO in the serie
        *
        *	@retval [\arr, low, high int] RANDOMIZED QUICKSORT LOMUTO
        **/

        /* This function takes last element as pivot,
            places the pivot element at its correct
            position in sorted array, and places all
            smaller (smaller than pivot) to left of
            pivot and all greater elements to right
            of pivot */




        /// < partition for random lomuto>
        /// 
        /// </summary This function takes last element as pivot,
        /// places the pivot element at its correct
        /// position in sorted array, and places all
        /// smaller(smaller than pivot) to left of
        /// pivot and all greater elements to right
        /// of pivot >
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>
        /// <returns></i+1>
        static int partition_forrandom_lomuto(int[] arr, int low, int high)
        {

            // pivot is chosen randomly
            randomfor_lomuto(arr, low, high);
            int pivot = arr[high];

            int i = (low - 1); // index of smaller element
            for (int j = low; j < high; j++)
            {

                // If current element is smaller than or
                // equal to pivot
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j]
                    int tempp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot)
            int tempp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tempp2;

            return i + 1;
        }

        /// < randomfor_lomuto>
        /// 
        /// </summary This Function helps in calculating
        /// random numbers between low(inclusive)
        /// and high(inclusive)>
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>
        /// <returns></tempp1>
        static int randomfor_lomuto(int[] arr, int low, int high)
        {
            //Create a random number then declared to rand
            Random rand = new Random();

            int pivot = rand.Next(low, high) % (high - low) + low;

            //Swap proccessing
            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return tempp1;
        }




        /// <RandomizedQuickSortLomuto>
        /// 
        /// </summary>
        /// <param name="arr"></int[]>
        /// <param name="low"></int>
        /// <param name="high"></int>
        /// <returns></returns>


        /* The main function that implements Quicksort()
            arr[] --> Array to be sorted,
            low --> Starting index,
            high --> Ending index */
        public static int[] RandomizedQuickSortLomuto(int[] arr, int low, int high)
        {
            if (low < high)
            {
                /* pi is partitioning index, arr[pi] is
                        now at right place */
                int pi = partition_forrandom_lomuto(arr, low, high);

                // Recursively sort elements before
                // partition and after partition
                RandomizedQuickSortLomuto(arr, low, pi - 1);
                RandomizedQuickSortLomuto(arr, pi + 1, high);
            }
            return arr;
        }















        //RANDOMIZED QUICKSORT HOARE:

        /**
        *
        *   @name   RANDOMIZED QUICKSORT HOARE
        *
        *	@brief  RANDOMIZED QUICKSORT HOARE Function
        *
        *   In QuickSort we first partition the array in place such that all elements to the left of the pivot element are smaller,
        *   while all elements to the right of the pivot are greater than the pivot.
        *
        *	@param  [in] mass [\arr, low, high int]   RANDOMIZED QUICKSORT HOARE in the serie
        *
        *	@retval [\arr, low, high int] RANDOMIZED QUICKSORT HOARE
        **/



       
        public static int randomhoarepartition(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low - 1, j = high + 1;

            while (true)
            {

                // Find leftmost element greater than
                // or equal to pivot
                do
                {
                    i++;
                } while (arr[i] < pivot);

                // Find rightmost element smaller than
                // or equal to pivot
                do
                {
                    j--;
                } while (arr[j] > pivot);

                // If two pointers met
                if (i >= j)
                    return j;

                int tempp = arr[i];
                arr[i] = arr[j];
                arr[j] = tempp;
            }
        }
        public static int Random(int[] arr, int low, int high)
        {
            // Generate a random number in between
            // low .. high
            Random rand = new Random();
            int pivot = rand.Next() % (high - low) + low;

            int tempp1 = arr[pivot];
            arr[pivot] = arr[high];
            arr[high] = tempp1;

            return randomhoarepartition(arr, low, high);
        }



        /// <randomQuicksortHoare>
        /// 
        /// </summary>
        /// <param name="array"></int[]>
        /// <param name="lw"></int>
        /// <param name="high"></int>


        public static void randomQuicksortHoare(int[] array, int lw, int high)
        {
            if (lw < high)
            {
                /* pi is partitioning index, arr[pi] is
                      now at right place */
                int pi = Random(array, lw, high);

                // Recursively sort elements before
                // partition and after partition
                randomQuicksortHoare(array, lw, pi);
                randomQuicksortHoare(array, pi + 1, high);
            }
        }







    }
}











