using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

using Sce.PlayStation.Core.Imaging;

namespace vitaShootingGUD
{
	//自機・敵機の基底クラス
	public class ShipEntity : GameEntity
	{
		public TextureInfo texture_info;
		public ShipEntity(){
			
		}
		public ShipEntity(Vector2 pos,string path)
		{
			//スプライト生成
			texture_info = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			Sprite = createSprite (texture_info);
			
			//座標設定
			this.Position = pos;
			
			//スプライトをNodeに追加する
			this.AddChild(Sprite);
		}
		//TODO:HPとかのいんたーふぇいす
	}
}

