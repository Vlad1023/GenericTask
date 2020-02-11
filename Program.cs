using System;

namespace GenericTask
{
    class MyClass<T>
    {
        public static T FacrotyMethod()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
    class MyList<T>
    {
        public MyList()
        {

        }
        class List
        {
            public T info;
            public List next = null;
            public List(T toAdd)
            {
                this.info = toAdd;
            }
            public List() { }
        }
        int lenght = 0;
        List head;
        public T getInfo()
        {
            return this.head.next.info;
        }
        public void Add(T toAdd)
        {
            if (head == null) head = new List(toAdd);
            else
            {
                findLast(ref head, toAdd);
            }
            this.lenght++;
        }
        void findLast(ref List current,T toAdd)
        {
            while(current != null)
            {
                findLast(ref current.next,toAdd);
            }
            current = new List(toAdd);
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            MyList<int> list = new MyList<int>();
            list.Add(6);
            list.Add(68);
            Console.WriteLine(list.getInfo()); 
               
            }
        }
    }


