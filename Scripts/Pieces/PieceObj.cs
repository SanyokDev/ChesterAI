using Godot;
using System;

namespace TheWinterDev {
    public class PieceObj : Node2D {
        private Vector2 spriteSize = new Vector2(16, 32);
        public PData myData;
        
        public void SetData(PData _data) {
            myData = _data;
        }

        public void SetData(int _file, int _rank, PType _type, PColor _color) {
            myData = new PData(_file, _rank, _type, _color);
        }

        private Vector2 GetSpriteRegion(PData data) {
            return new Vector2((int)data.type * spriteSize.x, ((int)data.color - 1) * spriteSize.y);
        }
        
        public override void _Ready() {
            Sprite mySprite = GetNode<Sprite>("PieceIcon");

            AtlasTexture myAltasTex = mySprite.Texture as AtlasTexture;
            myAltasTex.Region = new Rect2(GetSpriteRegion(myData), spriteSize);;
        }
    }
}
