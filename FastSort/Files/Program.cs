using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            // объект для сериализации
            Game game = new Game("TomAndJerry", 2001, "rpg", 200);
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("game.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, game);

                Console.WriteLine("Объект сериализован");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("game.dat", FileMode.OpenOrCreate))
            {
                Game newGame = (Game)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newGame.Name} --- Возраст: {newGame.Year} --- Жанр: {newGame.Janr} --- Объем: {newGame.V} Мб");
            }

            List<Game> games = new List<Game>();
            games.Add(game);
            games.Add(new Game("A", 2002, "rpg", 200));
            games.Add(new Game("B", 2002, "rpg", 100));
            games.Add(new Game("C", 2003, "horror", 200));

            var selectedGames = from g in games // определяем каждый объект из games как g
                                where g.Janr.ToUpper().StartsWith("H") //фильтрация по критерию
                                orderby g  // упорядочиваем по возрастанию
                                select g; // выбираем объект
            Console.WriteLine(selectedGames.FirstOrDefault().Name.ToString());

            selectedGames = from g in games
                                orderby g.Janr 
                                select g;
            Console.WriteLine(selectedGames.GroupBy(g => g.Janr).Count().ToString());
            Console.ReadLine();
        }
    }

    [Serializable]
    class Game
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Janr { get; set; }
        public int V { get; set; }

        public Game(string name, int year, string janr, int v)
        {
            Name = name;
            Year = year;
            Janr = janr;
            V = v;
        }
    }
}
