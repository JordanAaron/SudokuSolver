using System;
using System.Collections.Generic;

namespace SudokuSolver {
    class Program {
        public static List<List<int>> board = new List<List<int>>();
        public static List<int> columns = new List<int>();
        public bool solved = false;

        static void Main(string[] args) {
            getValues();
            createBoard(board);
            getColumn(0,board);

            foreach (int num in columns) {
                Console.Write(num);
                Console.Write(' ');
            }
        }

        private static void getValues() {
            string enteredRow;
            char[] enteredRowArr;
            List<int> list;

            for (int i = 0; i < 9; i++) {
                list = new List<int>();

                Console.WriteLine("Enter row:");
                enteredRow = Console.ReadLine();

                if (!rowValid(enteredRow)) {
                    do {
                        Console.WriteLine("Enter row again:");
                        enteredRow = Console.ReadLine();
                    } while (!rowValid(enteredRow));
                }

                enteredRowArr = enteredRow.ToCharArray();

                foreach (char ch in enteredRowArr) {
                    list.Add(int.Parse(ch.ToString()));
                }
                board.Add(list);
            }
        }

        static bool rowValid(string s) {
            return s.Length == 9 && int.TryParse(s, out _);
        }

        private static void createBoard(List<List<int>> board) {
            foreach (var row in board) {
                foreach (var value in row) {
                    Console.Write(value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        static void getColumn(int columnNum, List<List<int>> board) {
            foreach (List<int> row in board) {
                for(int i = 0; i < row.Count; i++) {
                    if(columnNum == i) {
                        //Console.Write(row[columnNum]);
                        //Console.Write(' ');
                        columns.Add(row[columnNum]);
                    }
                    
                }
            }
        }

        private void solve() {
            while (!solved) {
             
            }
        }
    }
}
