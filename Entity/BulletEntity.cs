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
		//傾き設定
		public Vector2 Velocity{get;set;} 
		public BulletEntity (string path,float scale)
		{
			//スプライト生成
			var texture_info = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			Sprite = createSprite (texture_info);
			
			this.AddChild(Sprite);
		}
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
		public BulletEntity(Vector2 pos,string path,float scale,float radius)
		{
			//座標設定
			this.Position = pos;
			
			//スプライト生成
			var texture_info = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			Sprite = createSprite (texture_info,scale);		
			
			//スプライトをNodeに追加する
			this.AddChild(Sprite);
			
			//当たり判定に追加する
			CollisionDatas.Add(new HitTest.CollisionEntry(){
				type = checkEntityType(this),
				owner = this,
				center = () => GetCollisionCenter(Sprite),
				radius = () => radius
			});
		}
		
		/// <summary>
		/// Checks the remove position.
		/// </summary>
		/// <returns>
		/// screenSize外だとtrueを返す
		/// </returns>
		/// <param name='pos'>
		/// 判定したいposition
		/// </param>
		protected bool isRemovePosition(Vector2 pos)
		{
			return(pos.X + Sprite.TextureInfo.TextureSizef.X/2 < 0 ||
			   pos.X - Sprite.TextureInfo.TextureSizef.X/2 > Game.Instance.ScreenSize.X ||
			   pos.Y + Sprite.TextureInfo.TextureSizef.Y/2 < 0 ||
			   pos.Y - Sprite.TextureInfo.TextureSizef.Y/2 > Game.Instance.ScreenSize.Y);
		}
		
		//bulletEntity判定
		protected HitTest.CollisionEntityType checkEntityType(BulletEntity entity)
		{
			HitTest.CollisionEntityType checkedType = HitTest.CollisionEntityType.PlayerBullet;
			if(this is PlayerBulletDefault)
			{
				checkedType = HitTest.CollisionEntityType.PlayerBullet;
			}
			if(this is BossBulletKi || this is BossBulletGu)
			{
				checkedType = HitTest.CollisionEntityType.BossBullet;
			}
			return checkedType;
		}
	}
}
