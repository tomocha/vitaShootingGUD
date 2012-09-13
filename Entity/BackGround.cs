using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace vitaShootingGUD
{
	public class BackGround : GameEntity
	{
		public TextureInfo texture_info;
		public BackGround ()
		{
		}
		
		public BackGround (Vector2 pos,string path,float scale)
		{
			//スプライト生成
			texture_info = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			Sprite = createSprite (texture_info,scale);
			
			//座標設定
			this.Position = pos;
			
			//スプライトをNodeに追加する
			this.AddChild(Sprite);
		}
		
		//フレーム描画時に呼ばれるメソッド
		public override void Tick(float dt)
		{
			base.Tick (dt);
			var pos = this.Position;			
			pos.X -= dt*10;
			
			if(pos.X < -this.texture_info.TextureSizef.X)
			{
				pos.X = Game.Instance.ScreenSize.X;
			}
			this.Position = pos;
		}
	}
}

