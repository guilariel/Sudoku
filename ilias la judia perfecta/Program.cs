using System;

namespace SudokuSolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            if (SolveSudoku(board))
            {
                Console.WriteLine("Sudoku resuelto correctamente:");
                Mostrar(board);
            }
            else
            {
                Console.WriteLine("No se encontró solución.");
            }
        }

        public static bool SolveSudoku(char[][] board)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == '.')
                    {
                        for (char num = '1'; num <= '9'; num++)
                        {
                            if (EsCorrecto(board, num, row, col))
                            {
                                board[row][col] = num;

                                if (SolveSudoku(board)) return true;

                                board[row][col] = '.'; // Retroceder si no es válido
                            }
                        }
                        return false; // No hay números válidos para esta celda
                    }
                }
            }
            return true; // Sudoku resuelto
        }

        public static bool EsCorrecto(char[][] board, char num, int row, int col)
        {
            // Revisar fila y columna
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == num || board[i][col] == num) return false;
            }

            // Revisar subcuadrícula 3x3
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[startRow + i][startCol + j] == num) return false;
                }
            }

            return true;
        }

        public static void Mostrar(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
