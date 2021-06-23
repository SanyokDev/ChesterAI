using Godot;
using System;

public class Board : Node2D {
    //Variables
    public PieceData[,] board = new PieceData[8, 8];
    private PackedScene piecePrefab = ResourceLoader.Load<PackedScene>("res://Prefabs/Piece.tscn");
    private Vector2 offset = new Vector2(12, 16);
    
    public void PlacePiece(int _x, int _y, PieceType _type, PieceColor _color) {
        board[_x, _y] = new PieceData(_type, _color);
    }


    private Vector2 topLeft = new Vector2(96, 56);
    private Vector2 topRight = new Vector2(224, 56);
    private Vector2 bottomLeft = new Vector2(96, 184);
    private Vector2 bottomRight = new Vector2(96, 184);

    public override void _Input(InputEvent @event) {
        // Mouse in viewport coordinates.
        if (@event is InputEventMouseButton eventMouseButton)
            GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
        else if (@event is InputEventMouseMotion eventMouseMotion)
            GD.Print("Mouse Motion at: ", eventMouseMotion.Position);

        // Print the size of the viewport.
        GD.Print("Viewport Resolution is: ", GetViewportRect().Size);
        
    }
    
    //Start
    public override void _Ready() {
        for (int x = 0; x < board.GetLength(0); x++) {
            for (int y = 0; y < board.GetLength(1); y++) {
                board[x, y] = new PieceData(PieceType.None, PieceColor.White);
            }
        }

        //Rank 1
        PlacePiece(0, 0, PieceType.Rook, PieceColor.White);
        board[1, 0] = new PieceData(PieceType.Knight, PieceColor.White);
        board[2, 0] = new PieceData(PieceType.Bishop, PieceColor.White);
        board[3, 0] = new PieceData(PieceType.Queen, PieceColor.White);
        board[4, 0] = new PieceData(PieceType.King, PieceColor.White);
        board[5, 0] = new PieceData(PieceType.Bishop, PieceColor.White);
        board[6, 0] = new PieceData(PieceType.Knight, PieceColor.White);
        board[7, 0] = new PieceData(PieceType.Rook, PieceColor.White);

        //Rank 2
        board[0, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[1, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[2, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[3, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[4, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[5, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[6, 1] = new PieceData(PieceType.Pawn, PieceColor.White);
        board[7, 1] = new PieceData(PieceType.Pawn, PieceColor.White);

        //Rank 7
        board[0, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[1, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[2, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[3, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[4, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[5, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[6, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);
        board[7, 6] = new PieceData(PieceType.Pawn, PieceColor.Black);

        //Rank 8
        board[0, 7] = new PieceData(PieceType.Rook, PieceColor.Black);
        board[1, 7] = new PieceData(PieceType.Knight, PieceColor.Black);
        board[2, 7] = new PieceData(PieceType.Bishop, PieceColor.Black);
        board[3, 7] = new PieceData(PieceType.Queen, PieceColor.Black);
        board[4, 7] = new PieceData(PieceType.King, PieceColor.Black);
        board[5, 7] = new PieceData(PieceType.Bishop, PieceColor.Black);
        board[6, 7] = new PieceData(PieceType.Knight, PieceColor.Black);
        board[7, 7] = new PieceData(PieceType.Rook, PieceColor.Black);

        for (int x = 0; x < board.GetLength(0); x++) {
            for (int y = 0; y < board.GetLength(1); y++) {
                PackedScene piece = GD.Load<PackedScene>("res://Prefabs/Piece.tscn");
                Node2D pieceNode = piece.Instance<Node2D>();

                PieceObject pieceScr = (PieceObject)pieceNode;

                var boardPiece = board[x, y];
                pieceScr.myType = boardPiece.type;
                pieceScr.myColor = boardPiece.color;

                Node2D pieceNode2D = (Node2D)pieceNode;
                pieceNode2D.GlobalPosition = new Vector2(x * 16 + offset.x, y * 16 + offset.y);
                
                this.AddChild(pieceNode);
            }
        }
    }

    //Update
    public override void _Process(float delta) {

    }
}