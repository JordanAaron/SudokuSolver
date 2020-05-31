﻿using System;
using System.Collections.Generic;

namespace SudokuSolver {
    class Program {
        public static List<List<int>> listOfRows = new List<List<int>>();
        public static List<List<int>> listOfColumns = new List<List<int>>();

        static void Main(string[] args) {
            getRows();
            getColumns(listOfRows);

            foreach (List<int> row in getListOfRows()) {
                Console.Write("Row: ");
                foreach(int val in row) {
                    Console.Write(val);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            foreach (List<int> col in getListOfColumns()) {
                Console.Write("Column: ");
                foreach (int val in col) {
                    Console.Write(val);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private static void getRows() {
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
                listOfRows.Add(list);
            }
        }

        private static void getColumns(List<List<int>> board) {
            for (int i = 0; i < listOfRows.Count; i++) {
                listOfColumns.Add(createColumn(i, board));
            }
        }

        static List<int> createColumn(int columnNum, List<List<int>> board) {
            List<int> column = new List<int>();
            foreach (List<int> row in board) {
                for (int i = 0; i < row.Count; i++) {
                    if (columnNum == i) {
                        column.Add(row[columnNum]);
                    }
                }
            }
            return column;
        }

        static bool rowValid(string s) {
            return s.Length == 9 && int.TryParse(s, out _);
        }

        private static void printBoard(List<List<int>> board) {
            foreach (var row in board) {
                foreach (var value in row) {
                    Console.Write(value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        static List<List<int>> getListOfRows() {
            return listOfRows;
        }

        static List<List<int>> getListOfColumns() {
            return listOfColumns;
        }
    }
}
