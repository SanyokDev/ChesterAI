using Godot;
using System;
using System.Collections.Generic;

namespace TheWinterDev {
    public static class FenUtility {
        public static void LoadPositionFromFen(ref PData[] boardData, string fenRecord) {
            Dictionary<char, PType> pieceTypeFromSymbol = new Dictionary<char, PType>() {
                ['p'] = PType.Pawn,
                ['b'] = PType.Bishop,
                ['n'] = PType.Knight,
                ['r'] = PType.Rook,
                ['q'] = PType.Queen,
                ['k'] = PType.King,
            };

            string boardPlacement = fenRecord.Split(' ')[0];
            int file = 0, rank = 7;
            
            foreach(char symbol in boardPlacement) {
                if (symbol == '/') {
                    file = 0;
                    rank--;

                } else {
                    if (char.IsDigit(symbol)) {
                        file += (int)char.GetNumericValue(symbol);

                    } else {
                        PType pieceType = pieceTypeFromSymbol[char.ToLower(symbol)];
                        PColor pieceColor = char.IsUpper(symbol) ? PColor.White : PColor.Black;
                        
                        boardData[rank * 8 + file] = new PData(file, rank, pieceType, pieceColor);
                        
                        file++;
                    }
                }
            }
        }
    }
}
