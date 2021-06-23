using Godot;
using System;

namespace TheWinterDev {
    public class Board : Node2D {
        //Board data
        [Export] string initialFenStr = "";

        public PData[] boardData = new PData[64];
        private PackedScene piecePrefab = ResourceLoader.Load<PackedScene>("res://Prefabs/Piece.tscn");
        private Vector2 offset = new Vector2(12, 16);
        
        //Board corner locations
        private Vector2 topLeft = new Vector2(96, 56);
        private Vector2 topRight = new Vector2(224, 56);
        private Vector2 bottomLeft = new Vector2(96, 184);
        private Vector2 bottomRight = new Vector2(96, 184);
        
        public override void _Ready() {
            for (int i = 0; i < boardData.Length; i++) {
                boardData[i] = new PData(0, 0, PType.None, PColor.None);
            }
            
            FenUtility.LoadPositionFromFen(ref boardData, initialFenStr);

            for (int i = 0; i < boardData.Length; i++) {
                PData pieceData = boardData[i];
                //GD.Print("ID: " + i.ToString() + " | Type: " + boardData[i].type.ToString() + " | Col: " + boardData[i].color.ToString());

                if (pieceData.type != PType.None) {
                    PackedScene piece = GD.Load<PackedScene>("res://Prefabs/Piece.tscn");
                    Node2D pieceNode = piece.Instance<Node2D>();

                    PieceObj pieceScr = (PieceObj)pieceNode;
                    pieceScr.SetData(pieceData);
                    
                    Node2D pieceNode2D = (Node2D)pieceNode;
                    pieceNode2D.GlobalPosition = new Vector2(pieceData.file * 16 + offset.x, (7 - pieceData.rank) * 16 + offset.y);
                    pieceNode2D.ZIndex = (7 - pieceData.rank) + 10; //10 is a bit arbitrary but it means that it shows above the board which is at z=0
                    
                    this.AddChild(pieceNode);
                }
            }
        }

        //Update
        public override void _Process(float delta) {

        }
    }
}
