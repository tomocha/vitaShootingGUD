using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace vitaShootingGUD
{
	/// <summary>
	/// Bullet entity.
	/// </summary>
	public class BulletEntity : GameEntity
	{
		public BulletEntity (){}
		public BulletEntity(Vector2 pos,string path)
		{
			//座標設定
			this.Position = pos;
			
			//スプライト生成
			var texture_info = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			Sprite = createSprite (texture_info);
			
			//スプライトをNodeに追加する
			this.AddChild(Sprite);
		}
	}
}

