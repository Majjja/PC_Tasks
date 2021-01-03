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
                Id = new Guid("A1111111-B111-C111-D111-E11111111111"),
                Name = "Lasly"
            };
            var meri = new User()
            {
                Id = new Guid("A2222222-B222-C222-D222-E22222222222"),
                Name = "Meri"
            };
            var joana = new User()
            {
                Id = new Guid("A3333333-B333-C333-D333-E33333333333"),
                Name = "Joana"
            };
            var juli = new User()
            {
                Id = new Guid("A4444444-B444-C444-D444-E44444444444"),
                Name = "Juli"
            };
            var sofi = new User()
            {
                Id = new Guid("A5555555-B555-C555-D555-E55555555555"),
                Name = "Sofi"
            };

            return new List<User>() { lasly, meri, joana, juli, sofi };
        }
    }
}
