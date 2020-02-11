using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GenericTask
{
    class ArrayList<T>
    {
        T[] array;
        int lenght = 0;
        int pointer;
        public int Lenght { get { return this.lenght; } }
        public ArrayList(int lenght)
        {
            this.array = new T[lenght];
            this.lenght = lenght;
        }
        void Refill()
        {
            T[] temp = new T[this.lenght * 2];
            for (int i = 0; i < this.Lenght; i++)
            {
                temp[i] = array[i];
            }
            this.array = temp;
            this.lenght = this.lenght * 2;
        }
        public void Add(T toAdd)
        {
            if (pointer == this.Lenght - 1)
                this.Refill();
            this.array[pointer++] = toAdd;
        }
        public bool Contains(T value)
        {
            foreach(var val in this.array)
            {
                if (val.Equals(value)) return true;
            }
            return false;
        }
        public void CopyTo(T[] array)
        {
            Array.Copy(this.array, array, this.Lenght);
        }
        void RemoveDecrease(int remIndex)
        {
            T[] temp = new T[this.lenght - 1];
            for (int i = 0,j = 0; i < this.lenght - 1; i++)
            {
                if(i == remIndex)
                {
                    continue;
                }
                temp[j] = this.array[i];
                if (temp[j] != null) this.pointer = j;
                else this.pointer = 0;
                j++;                
            }
            this.array = temp;
            
        }
        public void Remove(T value)
        {
            int index = 0;
            foreach (var val in this.array)
            {
                if (val.Equals(value)) { this.RemoveDecrease(index); lenght--; return; }
                index++;
            }
            
        }
    }
}
