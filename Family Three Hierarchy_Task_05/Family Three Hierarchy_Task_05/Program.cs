using System;
using System.Collections.Generic;
using System.Linq;

namespace Family_Three_Hierarchy_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent parent = new Parent()
            {
                Name = "Jovan",
                Children = new List<Child>()
                {
                    new Child()
                    {
                        Name = "Zorica",
                        Children = new List<Child>()
                        {
                            new Child()
                            {
                                Name = "Dushan",
                                Children = new List<Child>()
                                {
                                    new Child()
                                    {
                                        Name = "Marko"
                                    }
                                }
                            },
                            new Child()
                            {
                                Name = "Maja"
                            }
                        }
                    },
                    new Child()
                    {
                        Name = "Dushan",
                        Children = new List<Child>()
                        {
                            new Child()
                            {
                                Name = "Stefan"
                            },
                            new Child()
                            {
                                Name = "Marija"
                            }
                        }
                    }
                }
            };

            FamilyTree(parent, 0);
        }
        public static void FamilyTree(Parent parent, int count)
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
