using ConsoleApp1.DAL;
using ConsoleApp1.Entities;
using ConsoleApp1.Services;
using System;
using System.ComponentModel.Design;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = new MenuService();
            while (true)
            {
                start.Menu();
            }
        }
    }
}

