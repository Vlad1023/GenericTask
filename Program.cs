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
        public void Add(T toAdd)
        {
            if (head == null) head = new List(toAdd);
            else
            {
                findLastAdd(ref head, toAdd);
            }
            this.lenght++;
        }
        public int Lenght { get { return this.lenght; } }
        void findLastAdd(ref List current, T toAdd)
        {
            if (current != null)
            {
                findLastAdd(ref current.next, toAdd);
                if (current != null) return;
            }
            current = new List(toAdd);
        }
        T findByIndex(int index)
        {
            int temp = 0;
            List current = this.head;
            while (temp != index)
            {
                try
                {
                    current = current.next;
                }
                catch (NullReferenceException e)
                {
                    throw new Exception(e.Message);
                }
                temp++;
            }
            return current.info;
        }
        public T this[int index]
        {
            get
            {
                return findByIndex(index);
            }
        }
    }


    static class MyExt
    {

        public static T[] GetArray<T>(this MyList<T> list)
        {
            T[] toReturn = new T[list.Lenght];
            for (int i = 0; i < list.Lenght; i++)
            {
                toReturn[i] = list[i];
            }
            return toReturn;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
}


