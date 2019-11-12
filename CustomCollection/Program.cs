using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollection
{
    public class CustomArray<T> : IEnumerable, IComparer<CustomArray<T>>
    {
        List<T> list = new List<T>();


        int IComparer<CustomArray<T>>.Compare(CustomArray<T> obj,CustomArray<T> obj2)
        {
            Console.WriteLine("Inside Cutom Comparator");
            if (obj.list.Count() < obj2.list.Count())
                return 1;
            return (obj.list.Count()>obj2.list.Count())?-1:0;

        }

        public virtual IEnumerator GetEnumerator()
        {
            return new ItemIterator(this);
        }


        public class ItemIterator:IEnumerator
        {

            private CustomArray<T> array;
            private int index = -1;

            public ItemIterator(CustomArray<T> obj)
            { this.array = obj; }

            public bool MoveNext()
            {
                index += 1;
                if (index < array.list.Count())
                    return true;
                else
                    index = -1;
                return false;
            
            }
            public object Current
            {
                get
                {

                    if (index <= -1)
                        throw new Exception("Invalid Operation");
                    else
                        return array.list.ElementAt(index);
                }
            
            }
            public void Reset()
            {
                index = -1;
            }
        
        }



        public bool IsEmpty()
        {

            return (list.Count() == 0) ? true : false;
        }

        public void AddItem(T t)
        {

           list.Add(t);
        }

        public bool Remove(T t)
        {
            return list.Remove(t);
        }

        public bool Contains(T t)
        {
            foreach (T temp in list)
            {
                if (temp.Equals(t))
                    return true;
            
            }
            return false;
        
        }

        public int? Find(T t)
        {
            int count = 0;
            foreach (T temp in list)
            {
                if (temp.Equals(t))
                    return count;
                count += 1;
            
            }
            return null;
        
        }

        public T FetchAtIndex(int i)
        {
            return list.ElementAt(i);
        
        }




    
    }

    public class User
    {

        static void Main(string[] args)
        {
            CustomArray<int>[] objList = new CustomArray<int>[3];
            CustomArray<int> structure = new CustomArray<int>();
            structure.AddItem(5);
            structure.AddItem(6);
            structure.AddItem(78);
            for (IEnumerator enumerator = structure.GetEnumerator(); enumerator.MoveNext();)
            {
                Console.WriteLine(enumerator.Current);

            }

            objList[0]=structure;
            Console.ReadLine();

            CustomArray<string> structure1 = new CustomArray<string>();
            structure1.AddItem("hello0");
            structure1.AddItem(" are you working?");
            structure1.AddItem("Keep on then!!");
            structure1.AddItem("!!!!!");
            for (IEnumerator enumerator = structure1.GetEnumerator(); enumerator.MoveNext();)
            {
                Console.WriteLine(enumerator.Current);

            }

            CustomArray<int> structure2 = new CustomArray<int>();
            structure2.AddItem(56);
            structure2.AddItem(56);
            structure2.AddItem(56);
            structure2.AddItem(56);
            structure2.AddItem(56);
            structure2.AddItem(56);
            structure2.AddItem(56);
            objList[1]=structure2;

            Console.ReadLine();

            CustomArray<int> structure3 = new CustomArray<int>();
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);
            structure3.AddItem(123);

            objList[2] = structure3;

            Array.Sort(objList, structure2);
            Console.WriteLine();

            foreach (CustomArray<int> array in objList)
            {

                for (IEnumerator ie = array.GetEnumerator(); ie.MoveNext();)
                {
                    Console.WriteLine(ie.Current);
                }

                Console.WriteLine("Finished Printing the List");
            
            }

            Console.ReadKey();




        }

    }
}
