using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    static class VariableData
    {
        public static bool pause = false;
        public static int points = 0;
        public static int speed = 1000;
        public static List<List<string>> coords = new List<List<string>>();
        public static List<Figure> figures = new List<Figure>();
        public static List<String> leaders;
    }
}