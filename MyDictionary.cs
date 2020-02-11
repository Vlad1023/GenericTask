using System;
using System.Text;
namespace GenericTask
{
    class Item<TKey, TValue>
    {
        public TValue Value { get; private set; }
        public TKey Key { get; private set; }
        public bool Deleted { get; set; }
        public Item(TValue value, TKey key)
        {
            Value = value;
            Key = key;
        }
        public Item<TKey, TValue> DeepCopy()
        {
            return new Item<TKey, TValue>(Value, Key);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Value :");
            sb.AppendLine(Value.ToString());
            sb.AppendLine("Key :");
            sb.AppendLine(Key.ToString());
            return sb.ToString();
        }
    }
    class MyDictionary<TKey, TValue>
    {
        private Item<TKey, TValue>[] table;
        int lenght = 0;
        int keyPairLen = 0;
        public int Lenght { get { return this.lenght; } }
        public int KeyPairLen { get { return this.keyPairLen; } }
        public MyDictionary(int lenght)
        {
            this.lenght = lenght;
            table = new Item<TKey,TValue>[lenght];
        }
        public MyDictionary(){ }
        public void Insert(TKey key, TValue value)
        {
            var hash = GetHash(key);
            int tmp = hash;
            int count = 0;
            while (table[tmp] != null && !(table[tmp].Deleted))
            {
                if (table[tmp].Key.Equals(key))
                    throw new Exception("Elements with equal keys");
                if (count == lenght - 1) 
                    this.ArrRefill();
                if (table[tmp] == table[lenght-1])
                {
                    tmp = 0;
                }
                else
                {
                    tmp++;
                    count++;
                }
            }
            Item<TKey, TValue> it = new Item<TKey,TValue>(value, key);
            table[tmp] = it;
            this.keyPairLen ++;
        }
        void ArrRefill()
        {
           
            Item<TKey, TValue>[] temp = new Item<TKey, TValue>[this.lenght * 2];
            for (int i = 0; i < this.lenght; i++)
            {
                temp[i] = this.table[i];
            }
            this.table = temp;
            this.lenght = this.lenght * 2;
        }
        public void Delete(TKey key)
        {
            var hash = GetHash(key);
            int tmp = hash;
            int count = 0;
            while (!table[tmp].Key.Equals(key))
            {

                if (count == lenght)
                    throw new Exception("Element doesn`t exist");

                if (table[tmp] == table[lenght-1])
                {
                    tmp = 0;
                }
                else
                {
                    tmp++;
                    count++;
                }
            }
            table[tmp].Deleted = true;
            Console.WriteLine("Element with hash {0} deleted", hash);

        }
        public TValue this[TKey key]
        {
            get
            {
                var hash = GetHash(key);
                int tmp = hash;
                int count = 0;
                while (!table[tmp].Key.Equals(key))
                {
                    if (count == lenght - 1)
                        throw new Exception("Element with this key does not exist");

                    if (table[tmp] == table[lenght - 1])
                    {
                        tmp = 0;
                    }
                    else
                    {
                        tmp++;
                        count++;
                    }
                }
                return table[tmp].Value;
            }
        }
        private int GetHash(TKey value)
        {
            double tmp = value.GetHashCode() % 1;
            int hash = (int)(lenght * tmp);
            return hash;
        }
    }
}
