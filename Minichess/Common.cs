using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniChess
{

    public class Position
    {
        //class fields
        public int x;
        public int y;
        public static Dictionary<string, int> mapping = new Dictionary<string, int>() {
                { "a", 1 },
                { "b", 2 },
                { "c", 3 },
                { "d", 4 },
                { "e", 5 },
                { "f", 6 },
                { "g", 7 },
                { "h", 8 } };

        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }

        public static Position TranslatePosition(string positionString)
        {
            int y = Convert.ToInt32(positionString.Substring(1, 1));
            int x = 0;
            Position.mapping.TryGetValue(positionString.Substring(0, 1), out x);

            return new Position(x, y);
        }

        public static string TranslateReverse(Position positionNumeric)
        {
            string position = string.Empty;
            position += Position.mapping.FirstOrDefault(x => x.Value == positionNumeric.x).Key;
            position += positionNumeric.y;

            return position;
        }

        public static List<string> TranslateReverseList(List<Position> list)
        {
            List<string> newList = new List<string>();
            foreach (var l in list)
            {
                newList.Add(TranslateReverse(l));
            }

            return newList;
        }
    }

    public static class Check
    {
        public static List<string> UP(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);

                while (temp.y < 8)
                {
                    temp.y++;
                    if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
            
            return Position.TranslateReverseList(moves);
        }

        public static List<string> UPRIGHT(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);

                while (temp.y < 8 && temp.x < 8)
                {
                    temp.y++;
                    temp.x++;
                    if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                    if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
            
            return Position.TranslateReverseList(moves);
        }

        public static List<string> RIGHT(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);
            
                while (temp.x < 8)
                {
                    temp.x++;
                    if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
            
            return Position.TranslateReverseList(moves);
        }

        public static List<string> DOWNRIGHT(ChessPiece piece)
            {
                List<Position> moves = new List<Position>();
                Position translated = Position.TranslatePosition(piece.GetPosition());
                Position temp = new Position(translated.x, translated.y);
                
            while (temp.y > 1 && temp.x < 8)
                {
                    temp.y--;
                    temp.x++;
                    if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                    if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
                return Position.TranslateReverseList(moves);
            }

        public static List<string> DOWN(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);
            
                while (temp.y > 1)
                {
                    temp.y--;
                    if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
            
            return Position.TranslateReverseList(moves);
        }

        public static List<string> DOWNLEFT(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);

            while (temp.y > 1 && temp.x > 1)
            {
                temp.y--;
                temp.x--;
                if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                moves.Add(new Position(temp.x, temp.y));
            }
            return Position.TranslateReverseList(moves);
        }

        public static List<string> LEFT(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);

                while (temp.x > 1)
                {
                    temp.x--;
                    if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                    moves.Add(new Position(temp.x, temp.y));
                }
            
            return Position.TranslateReverseList(moves);
        }

        public static List<string> UPLEFT(ChessPiece piece)
        {
            List<Position> moves = new List<Position>();
            Position translated = Position.TranslatePosition(piece.GetPosition());
            Position temp = new Position(translated.x, translated.y);

            while (temp.y < 8 && temp.x > 1)
            {
                temp.y++;
                temp.x--;
                if (Math.Abs(translated.y - temp.y) > piece.GetDistance()) { break; }
                if (Math.Abs(translated.x - temp.x) > piece.GetDistance()) { break; }
                moves.Add(new Position(temp.x, temp.y));
            }

            return Position.TranslateReverseList(moves);
        }

        public static List<string> DIAGONALS(ChessPiece piece)
        {

            List<string> a = UPLEFT(piece);
            List<string> b = UPRIGHT(piece);
            b = Combine(a, b);
            List<string> c = DOWNLEFT(piece);
            c = Combine(b, c);
            List<string> d = DOWNRIGHT(piece);
            d = Combine(c, d);

            return d;
        }

        public static List<string> STRAIGHT(ChessPiece piece)
        {

            List<string> a = UP(piece);
            List<string> b = RIGHT(piece);
            b = Combine(a, b);
            List<string> c = DOWN(piece);
            c = Combine(b, c);
            List<string> d = LEFT(piece);
            d = Combine(c, d);

            return d;
        }

        public static List<string> ALL(ChessPiece piece)
        {

            List<string> a = DIAGONALS(piece);
            List<string> b = STRAIGHT(piece);
            b = Combine(a, b);

            return b;
        }

        public static List<String> Combine(List<string> a, List<string> b)
        {
            List<string> newList = new List<string>();
            foreach (string s in a)
            {
                newList.Add(s);
            }
            foreach (string s in b)
            {
                newList.Add(s);
            }
            return newList;
        }


    }
}
