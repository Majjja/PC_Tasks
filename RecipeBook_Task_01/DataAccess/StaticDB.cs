using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public static class StaticDB
    {
        public static List<User> Users()
        {
            var lasly = new User()
            {
                Id = 1,
                Name = "Lasly"
            };
            var meri = new User()
            {
                Id = 2,
                Name = "Meri"
            };
            var joana = new User()
            {
                Id = 3,
                Name = "Joana"
            };
            var juli = new User()
            {
                Id = 4,
                Name = "Juli"
            };
            var sofi = new User()
            {
                Id = 5,
                Name = "Sofi"
            };

            return new List<User>() { lasly, meri, joana, juli, sofi };
        }
    }
}
