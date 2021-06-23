using System;

namespace TheWinterDev {
    public enum PType {
        //Piece type
        None = 0,
        Pawn = 1,
        Bishop = 2,
        Knight = 3,
        Rook = 4,
        Queen = 5,
        King = 6
    }

    public enum PColor {
        //Piece color
        None = 0,
        White = 1,
        Black = 2
    }

    public class PData {
        public int file; //X pos on the board
        public int rank; //Y pos on the board

        public PType type;
        public PColor color;
        
        public PData(int _file, int _rank, PType _type, PColor _color) {
            file = _file;
            rank = _rank;
            
            type = _type;
            color = _color;
        }
    }
    
    public enum PVal {
        //Piece value in points
        Pawn = 1,
        Knight = 3,
        Bishop = 3,
        Rook = 5,
        Queen = 9
    }
}
