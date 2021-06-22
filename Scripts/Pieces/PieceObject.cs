using Godot;
using System;

public class PieceObject : Node2D {
    private Vector2 spriteSize = new Vector2(16, 32);

    [Export] public PieceType myType = PieceType.None;
    [Export] public PieceColor myColor = PieceColor.White;
    public PieceData myData;

    public override void _Ready() {
        var myData = new PieceData(myType, myColor);
        
        Sprite mySprite = (Sprite)this.GetChild(0);
        AtlasTexture myAltasTex = (AtlasTexture)mySprite.Texture;

        Rect2 pieceRegion = new Rect2(new Vector2((int)myData.type * spriteSize.x, (int)myData.color * spriteSize.y), spriteSize);
        myAltasTex.Region = pieceRegion;
    }
}
