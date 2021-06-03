using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniChess
{

    public abstract class ChessPiece
    { 
        //properties
        protected string name;                        //string name
        protected string position;                    //chess notation for position
        protected int distance;                       //max travel distance of the piece

        public int GetDistance() { return distance; }

        public string GetPosition() { return position; }


        //abstract methods to implement
 
        public abstract List<string> GetAllMoves();
    }

    public class King : ChessPiece
    {
        public King(PieceInfo info)
        {
            position = info.position;
            distance = 1;
        }

        public override List<string> GetAllMoves()
        {
            return Check.ALL(this);
        }
    }

    public class Queen : ChessPiece
    {
        public Queen(PieceInfo info)
        {
            position = info.position;
            distance = 7;
        }
        public override List<string> GetAllMoves()
        {
            return Check.ALL(this);
        }
    }

    public class Rook : ChessPiece
    {
        public Rook(PieceInfo info)
        {
            position = info.position;
            distance = 7;
        }
        public override List<string> GetAllMoves()
        {
            return Check.STRAIGHT(this);
        }
    }

    public class Bishop : ChessPiece
    {
        public Bishop(PieceInfo info)
        {
            position = info.position;
            distance = 7;
        }
        public override List<string> GetAllMoves()
        {
            return Check.DIAGONALS(this);
        }
    }
}
