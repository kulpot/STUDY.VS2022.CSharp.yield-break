using System;
using System.Collections;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=CU0HwH_h-eY&list=PL9B5E4C37F7B234A8&index=8
//

class MainClass
{
    class GetRandomNumbersClass : IEnumerable<int>, IEnumerator<int>
    {
        //public int Current => throw new NotImplementedException();
        //object IEnumerator.Current => throw new NotImplementedException();

        public int count;
        public int i;
        int current;
        int state; // keeps track of loop

        public bool MoveNext() // this call means -- move to the next random number
        {
            //throw new NotImplementedException();
            //for (int i = 0; i < count; i++)
            //    yield return rand.Next();
            switch (state)
            {
                case 0:
                    i = 0;
                    goto case 1;
                case 1:
                    state = 1;
                    if (!(i < count))
                        return false;
                    current = MainClass.rand.Next();
                    state = 2;
                    return true;
                case 2:
                    i++;
                    //break;
                    goto case 1;
            }
            return false;
        }

        public int Current
        {
            //get { throw new NotImplementedException(); }
            get { return current; }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        public void Dispose() { }
        //object System.Collections.IEnumerator.Current
        object IEnumerator.Current  // ctrl+mm(collapse line)
        {
            //get { throw new NotImplementedException(); }
            get { return Current; } // will result none explicitly in (public int Current)
        }
        public IEnumerator<int> GetEnumerator()
        {
            //throw new NotImplementedException();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //throw new NotImplementedException();
            return GetEnumerator(); // call none explicitly implemented
        }
    }
    static Random rand = new Random(); // one static random required
    static IEnumerable<int> GetRandomNumbers()
    {
        //for (int i = 0; i < count; i++)
        //List<int> ret = new List<int>();
        //while (true)
        //yield return rand.Next();
        //ret.Add(rand.Next());
        //return ret; // unreachable code
        while (true)
        {
            int num = rand.Next();
            if(num % 100 == 0)
                yield break;
            yield return num;
        }
        //yield break;
    }
    static void Main()
    {
        foreach (int i in GetRandomNumbers())
        {
            //if (i % 100 == 0)
            //    break;
            Console.WriteLine(i);
        }          
    }
}