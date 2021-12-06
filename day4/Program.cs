using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace day4
{
    internal class Board
    {
        private List<int> _board;
        private List<int> _numbers = new List<int>();
        public int Win = -1;
        public int Answer = -1;
        
        public Board(List<int> board)
        {
            _board = board;
        }

        public Boolean CheckNumber(int number)
        {
            _numbers.Add(number);
            
            for (var r = 0; r < _board.Count; r += 5)
            {
                var rowWin = 0;
                for (var c = r; c < r + 5; c++)
                {
                    if (_numbers.Contains(_board[c])) rowWin++;
                }

                if (rowWin == 5) return true;
            }
            
            for (var c = 0; c < 5; c++)
            {
                var colWin = 0;
                for (var r = c; r < _board.Count; r += 5)
                {
                    if (_numbers.Contains(_board[r])) colWin++;
                }

                if (colWin == 5) return true;
            }
            
            return false;
        }

        public int GetSum()
        {
            return _board.Where(b => !_numbers.Contains(b)).Sum();
        }
    }
    class Program
    {
        static void Main()
        {
            var numbers2 = System.IO.File.ReadAllLines(@"C:\Users\basdu\Downloads\day42021adventofcode.txt");
            var boards = new List<Board>();
            
            var numbers = numbers2[0].Split(',').Select(n => Convert.ToInt32(n)).ToList();
            
            for (var x = 2; x < numbers2.Length - 4; x += 6)
            {
                var totalRow = new List<int>();
                for (var y = x; y < x + 5; y++)
                {
                    var row = numbers2[y].Trim().Replace("  ", " ");
                    totalRow.AddRange(row.Split(' ').Select(n => Convert.ToInt32(n)).ToList());
                }
                
                boards.Add(new Board(totalRow));
            }
            
            var count = 0;
            foreach (var number in numbers)
            {
                foreach (var board in boards.Where(board => board.CheckNumber(number)))
                {
                    if (board.Win == -1)
                    {
                        board.Win = count;
                        board.Answer = board.GetSum() * number;
                    }
                    count++;
                }
            }
            var p1 = boards.First(board => board.Win == 0);
            Console.WriteLine(p1.Answer);
            
            var p2 = boards.First(board => board.Win == boards.Max(b => b.Win));
            Console.WriteLine(p2.Answer);
            
        }
    }
}