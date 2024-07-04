using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeFunctions avlTree = new BinaryTreeFunctions();

            List<(string, int)> data = new List<(string, int)>()
            {
                ("John Doe", 12),
                ("Jane Smith", 23),
                ("Alice Johnson", 34),
                ("Bob Brown", 45),
                ("Carol White", 56),
                ("David Black", 67),
            };

            foreach (var (name, key) in data)
            {
                avlTree.Insert(key, name);
                
            }
            while (true)
            {
                Console.WriteLine("нажми 1 если хочешь добавить элемент в дерево : ");
                Console.WriteLine("нажми 2 если хочешь вывести все эелементы дерева : ");
                Console.WriteLine("нажми 3 если хочешь вывести 1 эелемент дерева : ");
                Console.WriteLine("нажми 4 если хочешь удалить элемент дерева : ");
                Console.WriteLine("нажми 5 если хочешь вывести все эелементы дерева в виде дерева : ");
                Console.WriteLine("Выйти любая другая кнопка ");
                string key = Console.ReadLine();
                if (key == "1")
                {
                    Console.WriteLine("введи id человека : ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("введи Фамилию человека : ");
                    string SurName = Console.ReadLine();
                    avlTree.Insert(Id, SurName);
                }
                else if (key == "2")
                {
                    avlTree.WriteTree();
                }
                else if (key == "3")
                {
                    Console.WriteLine("введи id человека которого хотите вывести : ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(avlTree.Search(Id));
                }
                else if (key == "4")
                {
                    Console.WriteLine("введи id человека : ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    avlTree.Delete(Id);
                }
                else if (key == "5")
                {
                    avlTree.PrintTree();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
