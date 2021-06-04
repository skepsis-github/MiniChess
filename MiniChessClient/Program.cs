using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MiniChess;

namespace MiniChessClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string piece = string.Empty;
            string position = string.Empty;

            bool isGood = false;
            while (!isGood)
            {
                Console.WriteLine("Please choose a Piece. King, Queen, Rook, Or Bishop" + System.Environment.NewLine);
                piece = Console.ReadLine();
                piece = piece.ToLower();
                if ((piece == "king" || piece == "queen" || piece == "rook" || piece == "bishop"))
                {
                    isGood = true;
                }
                else
                {
                    Console.WriteLine("Invalid Piece Name");
                }

            }

            isGood = false;

            while (!isGood)
            {
                Console.WriteLine("Please choose a position in chess notation, ex.g6" + System.Environment.NewLine);
                position = Console.ReadLine();
                position = position.ToLower();
                string expression = @"^(?=.*[a-zA-Z])(?=.*[0-9]).+$";
                Regex rx = new Regex(expression, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                //var match = Regex.Match(position, expression);
                if (rx.IsMatch(position))
                {
                    isGood = true;
                }
                else
                {
                    Console.WriteLine("Invalid Position");
                }
            }

            PieceInfo info = new PieceInfo();
            info.name = piece;
            info.position = position;
            List<string> moves= new List<string>();

            switch (piece)
            {
                case "king":
                    King king = new King(info);
                    moves = king.GetAllMoves();
                    break;
                case "queen":
                    Queen queen = new Queen(info);
                    moves = queen.GetAllMoves();
                    break;
                case "rook":
                    Rook rook = new Rook(info);
                    moves = rook.GetAllMoves();
                    break;
                case "bishop":
                    Bishop bishop = new Bishop(info);
                    moves = bishop.GetAllMoves();
                    break;
            }

            string moveString = string.Empty;
            foreach (string s in moves)
            {
                moveString += s + ", ";
            }
            moveString = moveString.Substring(0, moveString.Length - 2);

            Console.WriteLine(moveString);

            Console.ReadKey();

        }
    }
}
