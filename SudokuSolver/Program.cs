using System;
using System.Collections.Generic;

namespace SudokuSolver {
    class Program {
        public static List<List<int>> listOfRows = new List<List<int>>();
        public static List<List<int>> listOfColumns = new List<List<int>>();
        public static List<List<int>> listOfCells = new List<List<int>>();

        static void Main(string[] args) {
            getRows();
            createListOfColumns(listOfRows);
            printBoard(listOfRows);
            solve();
            Console.WriteLine();
            printBoard(listOfRows);


            //if box contains 0 then 
            //check for remaining numbers in the cell (if cell !contain i check if the number occurs in the row or the column)
            //if row contains i or column contains i move onto the next number
        }

        static void getRows() {
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

        static bool rowValid(string s) {
            return s.Length == 9 && int.TryParse(s, out _);
        }

        static void createListOfColumns(List<List<int>> board) {
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

        static List<int> getCell(int cellNumber) {
            List<int> cell;
            switch (cellNumber) {
                case 1:
                    cell = new List<int>();
                    for (int i = 0; i < 3; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 0; j < 3; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 2:
                    cell = new List<int>();
                    for (int i = 0; i < 3; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 3; j < 6; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 3:
                    cell = new List<int>();
                    for (int i = 0; i < 3; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 6; j < 9; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 4:
                    cell = new List<int>();
                    for (int i = 3; i < 6; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 0; j < 3; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 5:
                    cell = new List<int>();
                    for (int i = 3; i < 6; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 3; j < 6; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 6:
                    cell = new List<int>();
                    for (int i = 3; i < 6; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 6; j < 9; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 7:
                    cell = new List<int>();
                    for (int i = 6; i < 9; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 0; j < 3; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 8:
                    cell = new List<int>();
                    for (int i = 6; i < 9; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 3; j < 6; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
                case 9:
                    cell = new List<int>();
                    for (int i = 6; i < 9; i++) {
                        List<int> row = getListOfRows()[i];
                        for (int j = 6; j < 9; j++) {
                            cell.Add(row[j]);
                        }
                    }
                    listOfCells.Add(cell);
                    return cell;
                    //break;
            }
            return null;
        }

        static void replaceVal(List<int> list,int location, int value) {
            list.RemoveAt(location);
            list.Insert(location, value);
        }

        static void solve() {
            foreach(var row in listOfRows) {
                if (row.Contains(0)) {
                    int locOfZero = row.IndexOf(0);
                    for (int i = 1; i < 10; i++) {
                        if (!row.Contains(i) && !getListOfColumns()[locOfZero].Contains(i)) {
                            replaceVal(row, locOfZero, i);
                        }
                    } 
                }
            }

            //For loop to check which cell to operate on
            for(int row = 0; row < listOfRows.Count; row++) {
                for(int col = 0; col < listOfColumns.Count; col++) {
                    if(row < 3) {
                        if (col < 3) {

                        }
                        if (col < 6) {

                        }
                        if (col < 9) {

                        }
                    }
                }
            }
            /*for (int i = 1; i < 10; i++) {
                //Check the cell
                for (int j = 1; j < 10; j++) {
                    if (!getCell(i).Contains(j)) {
                        if (!getListOfRows()[--i].Contains(j) || !getListOfColumns()[--i].Contains(j)) {
                            row.Insert(row.IndexOf(0), j);
                        }
                    }
                }
            }*/
        }

        static List<List<int>> getListOfRows() {
            return listOfRows;
        }

        static List<List<int>> getListOfColumns() {
            return listOfColumns;
        }

        static List<List<int>> getListOfCells() {
            return listOfCells;
        }

        static void printBoard(List<List<int>> board) {
            foreach (var row in board) {
                foreach (var value in row) {
                    Console.Write(value);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
