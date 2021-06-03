using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using MiniChess;
using System.Linq;
using System.Collections.Generic;

namespace MiniChessTest
{
    [TestClass]
    public class MiniChessTest
    {
        //Test data for 'TestGetAllMoves'
        //PieceInfo testdata = new MiniChess.PieceInfo() { name = "king", position = "b3" };    //expected 8 results 
        //PieceInfo testdata = new MiniChess.PieceInfo() { name = "queen", position = "b3" };   //expected 23 results 
        PieceInfo testdata = new MiniChess.PieceInfo() { name = "rook", position = "h4" };    //expected 14 results
        //PieceInfo testdata = new MiniChess.PieceInfo() { name = "bishop", position = "e5" };    //expected 13 results

        //use to test TestDirections
        PieceInfo testDirectionsData = new MiniChess.PieceInfo() { name = "queen", position = "d7" };   //expected 1 results




        public ChessPiece TestConstructors(PieceInfo info)
        {
            ChessPiece test = null;
            try
            {
                if (info.name == "king")
                {
                    test = new King(info);
                    
                }
                if (info.name == "queen")
                {
                    test = new Queen(info);
                }
                if (info.name == "rook")
                {
                    test = new Rook(info);
                }
                if (info.name == "bishop")
                {
                    test = new Bishop(info);
                }

                Debug.WriteLine(info.position);
                return test;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
                return null;
            }
        }

        [TestMethod]
        public void TestGetAllMoves()
        {
            try
            {
                var piece = TestConstructors(testdata);
                List<string> moves = piece.GetAllMoves();

                Debug.WriteLine(moves);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }

        [TestMethod]
        public void TestDirections()
        {
            //use king or queen for this test
            try
            {
                var piece = TestConstructors(testDirectionsData);

                List<string> moves = Check.UP(piece);
                Debug.WriteLine(moves);

                moves = Check.UPRIGHT(piece);
                Debug.WriteLine(moves);

                moves = Check.RIGHT(piece);
                Debug.WriteLine(moves);

                moves = Check.DOWNRIGHT(piece);
                Debug.WriteLine(moves);

                moves = Check.DOWN(piece);
                Debug.WriteLine(moves);

                moves = Check.DOWNLEFT(piece);
                Debug.WriteLine(moves);

                moves = Check.LEFT(piece);
                Debug.WriteLine(moves);

                moves = Check.UPLEFT(piece);
                Debug.WriteLine(moves);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }
    }
}
