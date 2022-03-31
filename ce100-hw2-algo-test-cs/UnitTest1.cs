using ce100_hw2_algo_lib_cs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using System;

namespace ce100_hw2_algo_test_cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MatrixmultiplicationIterative_TestMethod1()
        {
            int[,] array1 = { { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 },
                         { 4, 4, 4, 4  },
                         { 4, 4, 4, 4 } };

            int[,] array2 = { { 1, 1, 1, 1 },
                         { 4, 4, 4, 4 },
                         { 3, 3, 3, 3 },
                         { 2, 2, 2, 2 } };


            int[,] res = { { 20, 20, 20, 20 },
                         { 30, 30, 30, 30 },
                         { 40, 40, 40, 40  },
                         { 40, 40, 40, 40 } };
            int key = 4;
            int[,] exp = Class1.MatrixmultiplicationIterative(array1, array2, res, key);
            CollectionAssert.AreEqual(exp, res);
        }




        [TestMethod]
        public void MatrixmultiplicationIterative_TestMethod2()
        {
            int[,] array1 = { { 3, 3, 3, 3 },
                         { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 },
                         { 4, 4, 4, 4 } };

            int[,] array2 = { { 1, 1, 1, 1 },
                         { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 },
                         { 2, 2, 2, 2 } };

            // To store result
            int[,] res = { { 24, 24, 24, 24 },
                         { 16, 16, 16, 16 },
                         { 24, 24, 24, 24  },
                         { 32, 32, 32, 32 } };
            int key = 4;
            int[,] exp = Class1.MatrixmultiplicationIterative(array1, array2, res, key);
            CollectionAssert.AreEqual(exp, res);
        }


        [TestMethod]
        public void MatrixmultiplicationIterative_TestMethod3()
        {
            int[,] array1 = { { 4, 4, 4, 4 },
                         { 3, 3, 3, 3 },
                         { 2, 2, 2, 2 },
                         { 1, 1, 1, 1 } };

            int[,] array2 = { { 1, 1, 1, 1 },
                         { 2, 2, 2, 2 },
                         { 4, 4, 4, 4  },
                         { 3, 3, 3, 3 } };


            int[,] res = { { 40, 40, 40, 40 },
                         { 30, 30, 30, 30 },
                         { 20, 20, 20, 20  },
                         { 20, 20, 20, 20 } };
            int key = 4;
            int[,] exp = Class1.MatrixmultiplicationIterative(array1, array2, res, key);
            CollectionAssert.AreEqual(exp, res);
        }



        [TestMethod]
        public void RadixSort_TestMethod1()
        {
            int[] array = { 2, 8, -3, 23, 5, 19, 74, 70, 65, 10 };
            int[] result = { -3, 2, 5, 8, 10, 19, 23, 65, 70, 74 };
            Class1.RadixSort(array);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void RadixSort_TestMethod2()
        {
            int[] array = { 9, 5, -6, 16, 2, 15, 27, 60, 77, 11 };
            int[] result = { -6, 2, 5, 9, 11, 15, 16, 27, 60, 77 };
            Class1.RadixSort(array);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void RadixSort_TestMethod3()
        {
            int[] array = { 38, 17, -1, -8, 2, 30, 24, 54, 101, 4 };
            int[] result = { -8, -1, 2, 4, 17, 24, 30, 38, 54, 101 };
            Class1.RadixSort(array);
            CollectionAssert.AreEqual(array, result);
        }


        [TestMethod]

        public void CountingSort_TestMethod1()
        {
            int[] array = { 2, 4, 5, 8, 2, 2, 5, 4, 6, 6 };
            int[] result = { 2, 2, 2, 4, 4, 5, 5, 6, 6, 8 };
            Class1.CountingSort(array);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void CountingSort_TestMethod2()
        {
            int[] array = { 2, 10, 2, 7, 9, 9, 2, 7, 10, 10 };
            int[] result = { 2, 2, 2, 7, 7, 9, 9, 10, 10, 10 };
            Class1.CountingSort(array);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void CountingSort_TestMethod3()
        {
            int[] array = { 9, 9, 6, 6, 10, 10, 2, 2, 7, 7 };
            int[] result = { 2, 2, 6, 6, 7, 7, 9, 9, 10, 10 };
            Class1.CountingSort(array);
            CollectionAssert.AreEqual(array, result);
        }

        [TestMethod]
        public void HeapSort_TestMethod1()
        {
            int n = 10;
            int[] array = { 46, 37, 100, 77, 18, 19, 39, 41, 9, 102 };
            int[] result = { 9, 18, 19, 37, 39, 41, 46, 77, 100, 102 };
            Class1.HeapSort(array, n);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void HeapSort_TestMethod2()
        {
            int n = 11;
            int[] array = { 88, 36, 102, 71, 79, 13, 80, 92, 4, 57, 2 };
            int[] result = { 2, 4, 13, 36, 57, 71, 79, 80, 88, 92, 102 };
            Class1.HeapSort(array, n);
            CollectionAssert.AreEqual(array, result);
        }
        [TestMethod]
        public void HeapSort_TestMethod3()
        {
            int n = 6;
            int[] array = { 92, 12, 52, 32, 82, 42 };
            int[] result = { 12, 32, 42, 52, 82, 92 };
            Class1.HeapSort(array, n);
            CollectionAssert.AreEqual(array, result);
        }



        [TestMethod]
        public void LomutoQuickSort_TestMethod1()
        {
            int[] arr = { 2, 11, 9, 11, 9, 9 };
            int n = arr.Length;
            int[] result = { 2, 9, 9, 9, 11, 11 };
            Class1.LomutoQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }

        [TestMethod]
        public void LomutoQuickSort_TestMethod2()
        {
            int[] arr = { 2, 7, 3, 5, 1, 10 };
            int n = arr.Length;
            int[] result = { 1, 2, 3, 5, 7, 10 };
            Class1.LomutoQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }

        [TestMethod]
        public void LomutoQuickSort_TestMethod3()
        {
            int[] arr = { 2, 7, 3, 5, 1, 10 };
            int n = arr.Length;
            int[] result = { 1, 2, 3, 5, 7, 10 };
            Class1.LomutoQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }

        [TestMethod]
        public void HoaresQuickSort_TestMethod1()
        {
            int[] arr = { 75, 59, 74, 68, 98, 32 };
            int n = arr.Length;
            int[] result = { 32, 59, 68, 74, 75, 98 };
            Class1.HoaresQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }

        [TestMethod]
        public void HoaresQuickSort_TestMethod2()
        {
            int[] arr = { 75, 59, 74, 68, 98, 32 };
            int n = arr.Length;
            int[] result = { 32, 59, 68, 74, 75, 98 };
            Class1.HoaresQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }

        [TestMethod]
        public void HoaresQuickSort_TestMethod3()
        {
            int[] arr = { 75, 59, 74, 68, 98, 32 };
            int n = arr.Length;
            int[] result = { 32, 59, 68, 74, 75, 98 };
            Class1.HoaresQuickSort(arr, 0, n - 1);
            CollectionAssert.AreEqual(arr, result);
        }


        [TestMethod]
        public void MatrixMultStrassen_TestMethod1()
        {
            float[,] array1 = { { 4, 4},
                              { 3, 3 }, };

            float[,] array2 = { { 1, 1 },
                              { 2, 2 }, };


            float[,] res = { { 12, 12 },
                           { 9, 9 }, };
            int key = 2;
            float[,] exp = Class1.MatrixMultStrassen(array1, array2, key);
            CollectionAssert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MatrixMultStrassen_TestMethod2()
        {
            float[,] array1 = { { 5, 6},
                              { 5, 6 }, };

            float[,] array2 = { { 8, 9 },
                              { 8, 9 }, };

            // To store result
            float[,] res = { { 88,99 },
                           { 88, 99 }, };
            int key = 2;
            float[,] exp = Class1.MatrixMultStrassen(array1, array2, key);
            CollectionAssert.AreEqual(exp, res);
        }

        [TestMethod]
        public void MatrixMultStrassen_TestMethod3()
        {
            float[,] array1 = { {7, 8},
                              {7, 8 }, };

            float[,] array2 = { {2, 3 },
                              {2, 3 }, };

            // To store result
            float[,] res = { {30, 45 },
                           {30, 45 }, };
            int key = 2;
            float[,] exp = Class1.MatrixMultStrassen(array1, array2, key);
            CollectionAssert.AreEqual(exp, res);
        }



        [TestMethod]
        public void MultiplyMatrixRec_testmethod_1()
        {
            int row1 = 2, col1 = 2;
            int row2 = 2, col2 = 3;

            int[,] X = {{1, 2},
                       {4, 5}};

            int[,] Y = {{1, 2, 3},
                       {4, 5, 6}};

            int[,] Z = new int[row1, col2];

            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            Class1.MultiplyMatrixRec(row1, col1, X, row2, col2, Y, Z);
            int[,] result = {{9, 12, 15},
                              {24, 33, 42}};
            CollectionAssert.AreEqual(Z, result);

        }

        [TestMethod]
        public void MultiplyMatrixRec_testmethod_2()
        {
            int row1 = 2, col1 = 2;
            int row2 = 2, col2 = 3;

            int[,] X = {{1, 2},
                       {4, 5}};

            int[,] Y = {{1, 2, 3},
                       {4, 5, 6}};

            int[,] Z = new int[row1, col2];

            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            Class1.MultiplyMatrixRec(row1, col1, X, row2, col2, Y, Z);
            int[,] result = {{9, 12, 15},
                              {24, 33, 42}};
            CollectionAssert.AreEqual(Z, result);

        }

        [TestMethod]
        public void MultiplyMatrixRec_testmethod_3()
        {
            int row1 = 2, col1 = 2;
            int row2 = 2, col2 = 3;

            int[,] X = {{1, 2},
                       {4, 5}};

            int[,] Y = {{1, 2, 3},
                       {4, 5, 6}};

            int[,] Z = new int[row1, col2];

            Class1.i = 0; Class1.j = 0; Class1.k = 0;
            Class1.MultiplyMatrixRec(row1, col1, X, row2, col2, Y, Z);
            int[,] result = {{9, 12, 15},
                              {24, 33, 42}};
            CollectionAssert.AreEqual(Z, result);

        }

        [TestMethod]
        public void SelectionProblem_TestMethod1()
        {
            int[] arr = { 15, 6, 8, 10, 7, 22, 29 };
            int n = arr.Length, k = 3;
            int result = Class1.SelectionProblem(arr, 0, n - 1, k);
            Assert.AreEqual(8, result);
        }


        [TestMethod]
        public void SelectionProblem_TestMethod2()
        {
            int[] arr = { 11, 2, 4, 6, 3, 18, 25 };
            int n = arr.Length, k = 2;
            int result = Class1.SelectionProblem(arr, 0, n - 1, k);
            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void SelectionProblem_TestMethod3()
        {
            int[] arr = { 14, 5, 7, 9, 6, 21, 28 };
            int n = arr.Length, k = 2;
            int result = Class1.SelectionProblem(arr, 0, n - 1, k);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void PrioritryHeapSort_TestMethod1()
        {

            Class1.insert(88);
            Class1.insert(73);
            Class1.insert(47);
            Class1.insert(11);
            Class1.insert(5);
            int key = 88;
            Class1.Priority_Queue_with_Heap(5, key);
            int result = 88;
            Assert.AreEqual(key, result);
        }


        [TestMethod]
        public void PrioritryHeapSort_TestMethod2()
        {

            Class1.insert(85);
            Class1.insert(70);
            Class1.insert(44);
            Class1.insert(8);
            Class1.insert(2);
            int key =85;
            Class1.Priority_Queue_with_Heap(2, key);
            int result = 85;
            Assert.AreEqual(key, result);
        }

        [TestMethod]
        public void PrioritryHeapSort_TestMethod3()
        {

            Class1.insert(89);
            Class1.insert(74);
            Class1.insert(48);
            Class1.insert(11);
            Class1.insert(6);
            int key = 89;
            Class1.Priority_Queue_with_Heap(6, key);
            int result = 89;
            Assert.AreEqual(key, result);
        }

        [TestMethod]
        public void RandomizedQuickSortLomuto_TestMethod1()
        {
            int[] array = { 10, 6, 4, 8, 11, 2, 3 };
            int n = array.Length - 1;
            int[] expected = { 2, 3, 4, 6, 8, 10, 11 };

            Class1.RandomizedQuickSortLomuto(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSortLomuto_TestMethod2()
        {
            int[] array = { 53, 31, 86, 20, 43, 93, 17 };
            int n = array.Length - 1;
            int[] expected = { 17, 20, 31, 43, 53, 86, 93 };

            Class1.RandomizedQuickSortLomuto(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSortLomuto_TestMethod3()
        {
            int[] array = { 488, 135, 793, 377, 932, 686, 202 };
            int n = array.Length - 1;
            int[] expected = { 135, 202, 377, 488, 686, 793, 932 };

            Class1.RandomizedQuickSortLomuto(array, 0, n);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSortHoare_TestMethod1()
        {
            int[] array = { 7, 3, 9, 2, 10, 1, 4, 6 };
            int n = array.Length;
            int[] expected = { 1, 2, 3, 4, 6, 7, 9, 10 };

            Class1.randomQuicksortHoare(array, 0, n - 1);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSortHoare_TestMethod2()
        {
            int[] array = { 45, 83, 18, 99, 55, 74, 27 };
            int n = array.Length;
            int[] expected = { 18, 27, 45, 55, 74, 83, 99 };

            Class1.randomQuicksortHoare(array, 0, n - 1);
            CollectionAssert.AreEqual(array, expected);
        }

        [TestMethod]
        public void RandomizedQuickSortHoare_TestMethod3()
        {
            int[] array = { 364, 611, 488, 152, 951, 555, 762, 294 };
            int n = array.Length;
            int[] expected = { 152, 294, 364, 488, 555, 611, 762, 951 };

            Class1.randomQuicksortHoare(array, 0, n - 1);
            CollectionAssert.AreEqual(array, expected);
        }



    }



}
