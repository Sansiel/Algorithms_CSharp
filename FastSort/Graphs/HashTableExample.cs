using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class HashTableExample
    {
        public static void MainG()
        {
            var hashTable = new HashTable();
            hashTable.Insert("Little Prince", "I never wished you any sort of harm; but you wanted me to tame you...");
            hashTable.Insert("Fox", "And now here is my secret, a very simple secret: It is only with the heart that one can see rightly; what is essential is invisible to the eye.");
            hashTable.Insert("Rose", "Well, I must endure the presence of two or three caterpillars if I wish to become acquainted with the butterflies.");
            hashTable.Insert("King", "He did not know how the world is simplified for kings. To them, all men are subjects.");

            ShowHashTable(hashTable, "Created hashtable.");
            Console.ReadLine();

            return;
        }

        private static void ShowHashTable(HashTable hashTable, string title)
        {
            // Проверяем входные аргументы.
            if (hashTable == null) { throw new ArgumentNullException(nameof(hashTable)); }
            if (string.IsNullOrEmpty(title)) { throw new ArgumentNullException(nameof(title)); }

            // Выводим все имеющие пары хеш-значение
            Console.WriteLine(title);
            foreach (var item in hashTable.Items)
            {
                // Выводим хеш
                Console.WriteLine(item.Key);

                // Выводим все значения хранимые под этим хешем.
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }
    }

    public class Item
    {

        public string Key { get; private set; }
        public string Value { get; private set; }

        public Item(string key, string value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }
            if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }

            // Устанавливаем значения.
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Key;
        }
    }

    public class HashTable
    {
        private readonly byte _maxSize = 255;
        private Dictionary<int, List<Item>> _items = null;
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => _items?.ToList()?.AsReadOnly();
        public HashTable()
        {
            // Инициализируем коллекцию максимальным количество элементов.
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }

        public void Insert(string key, string value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }
            if (key.Length > _maxSize) { throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key)); }
            if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }

            // Создаем новый экземпляр данных.
            var item = new Item(key, value);
            var hash = GetHash(item.Key);
            List<Item> hashTableItem = null;
            if (_items.ContainsKey(hash))
            {
                hashTableItem = _items[hash];
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null) { throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. Ключ должен быть уникален.", nameof(key)); }
                _items[hash].Add(item); // Добавляем элемент данных в коллекцию элементов хеш таблицы.
            }
            else
            {
                hashTableItem = new List<Item> { item };
                _items.Add(hash, hashTableItem);
            }
        }

        public void Delete(string key)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }
            if (key.Length > _maxSize) { throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key)); }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash)) { return; }

            // Получаем коллекцию элементов по хешу ключа.
            var hashTableItem = _items[hash];
            // Получаем элемент коллекции по ключу.
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        public string Search(string key)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(key)) { throw new ArgumentNullException(nameof(key)); }
            if (key.Length > _maxSize) { throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(key)); }
            var hash = GetHash(key);
            if (!_items.ContainsKey(hash)) { return null; }

            var hashTableItem = _items[hash];
            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);
                if (item != null)
                {
                    return item.Value;
                }
            }
            return null;
        }

        private int GetHash(string value)
        {
            // Проверяем входные данные на корректность.
            if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }

            if (value.Length > _maxSize) { throw new ArgumentException($"Максимальная длинна ключа составляет {_maxSize} символов.", nameof(value)); }

            // Получаем длину строки.
            var hash = value.Length;
            return hash;
        }
    }
}