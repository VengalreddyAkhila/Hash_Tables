using System;
using System.Collections.Generic;
using System.Text;

namespace Hash_Table
{
    class MyMapNode<K, V>
    {
        public struct KeyValuePair<k, v>
        {
            //properties
            public K Key { get; set; }
            public V Value { get; set; }
        }
        private readonly int size;
        private readonly LinkedList<KeyValuePair<K, V>>[] items;
        /// <summary>
        /// using constructor
        /// </summary>
        /// <param name="size"></param>

        public MyMapNode(int size)
        {
            this.size = size;
            items = new LinkedList<KeyValuePair<K, V>>[size];
        }
        /// <summary>
        /// Gets a unique array  position for entered key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            //returns the array position
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// linked list presented at the entered position or not
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        protected LinkedList<KeyValuePair<K, V>> GetLinkedList(int pos)
        {
            LinkedList<KeyValuePair<K, V>> linkedlist = items[pos];
            if (linkedlist == null)
            {
                //creates a new linkedlist for array 
                linkedlist = new LinkedList<KeyValuePair<K, V>>();
                items[pos] = linkedlist;
            }
            return linkedlist;
        }
        /// <summary>
        /// return back the value pointed by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Find(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValuePair<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(V);
        }
        /// <summary>
        /// adds the key to hashtable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            KeyValuePair<K, V> item = new KeyValuePair<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        /// <summary>
        /// removes the value from hastable using key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValuePair<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValuePair<K, V> foundItem = default(KeyValuePair<K, V>);
            foreach (KeyValuePair<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
    }
}

    

