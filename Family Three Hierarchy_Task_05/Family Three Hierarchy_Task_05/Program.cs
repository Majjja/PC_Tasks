using System;
using System.Collections.Generic;
using System.Linq;

namespace Family_Three_Hierarchy_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Person parent = new Person()
            {
                Name = "Jovan",
                Children = new List<Person>()
                {
                    new Person()
                    {
                        Name = "Zorica",
                        Children = new List<Person>()
                        {
                            new Person()
                            {
                                Name = "Dushan",
                                Children = new List<Person>()
                                {
                                    new Person()
                                    {
                                        Name = "Marko"
                                    }
                                }
                            },
                            new Person()
                            {
                                Name = "Maja"
                            }
                        }
                    },
                    new Person()
                    {
                        Name = "Dushan",
                        Children = new List<Person>()
                        {
                            new Person()
                            {
                                Name = "Stefan"
                            },
                            new Person()
                            {
                                Name = "Marija"
                            }
                        }
                    }
                }
            };

            FamilyTree(parent, 0);
        }
        public static void FamilyTree(Person parent, int count)
        {
            var name = parent.Children.Any() ? $"*{parent.Name}*" : $" {parent.Name}";
            var whiteSpace = "";
            Console.WriteLine($"{whiteSpace.PadLeft(count * 5)}{name}");
            foreach (var member in parent.Children)
            {
                FamilyTree(member, count + 1);
            }
        }
    }
}
