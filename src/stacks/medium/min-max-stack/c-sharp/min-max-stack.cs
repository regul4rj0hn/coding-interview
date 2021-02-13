using System;
using System.Collections.Generic;

/*
Time : O(1) - All operations on the stack are done in constant time 
Space: O(n) - Where N is the number of elements in the stack, all operations are individually O(1) 
*/
public class Program {
    public class MinMaxStack {
        // store elements of the stack
        private List<int> stack;
        // list of the smallest elements on the stack
        private List<int> min;
        // list of the biggest elements on the stack
        private List<int> max;

        // Constructor
        public MinMaxStack () {
            stack = new List<int> ();
            min = new List<int> () { int.MaxValue };
            max = new List<int> () { int.MinValue };
        }

        public int Peek () {
            return stack.Count < 0 ? -1 : stack[stack.Count - 1];
        }

        public int Pop () {
            if (stack.Count < 0) {
                return -1;
            }

            int toPop = stack[stack.Count - 1];

            if (toPop == min[min.Count - 1]) {
                min.RemoveAt (min.Count - 1);
            }

            if (toPop == max[max.Count - 1]) {
                max.RemoveAt (max.Count - 1);
            }

            stack.RemoveAt (stack.Count - 1);

            return toPop;
        }

        public void Push (int number) {
            if (number <= min[min.Count - 1]) {
                min.Add (number);
            }

            if (number >= max[max.Count - 1]) {
                max.Add (number);
            }

            stack.Add (number);
        }

        public int GetMin () {
            return min[min.Count - 1];
        }

        public int GetMax () {
            return max[max.Count - 1];
        }

        public int GetSize () {
            return stack.Count;
        }
    }
}