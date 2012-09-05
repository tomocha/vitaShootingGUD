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
	public class BulletFactory
	{
		//弾を保持する
		//0 : 味方の弾 1:敵弾奇数弾 2:敵偶数弾
		private TextureInfo[] bulletTextureInfoList = new TextureInfo[4];
		private SpriteTile[] bulletSpriteList = new SpriteTile[4];
		int ID = 0;
		private BulletEntity[] bulletEntityList = new BulletEntity[4];
		
		public BulletEntity getBullet(Vector2 position,Vector2 velocity,int bulletId)
		{
			switch(bulletId){
			case 1:
				if(bulletEntityList[1] == null)
				{
					bulletEntityList[1] = new BossBulletKi();
				}
				var bullet = bulletEntityList[1];
				bullet.Position = position;
				bullet.Velocity = velocity;
				return bullet;
			}
			return null;
		}
		
		/// <summary>
		/// Gets the bullet.
		/// </summary>
		/// <returns>
		/// The bullet.
		/// </returns>
		/// <param name='path'>
		/// 作りたい弾の画像パス
		/// </param>
		private TextureInfo getBulletTextureInfo(string path)
		{
			if(bulletTextureInfoList[ID] == null)
			{
				bulletTextureInfoList[ID] = new TextureInfo(new Texture2D(path,false),new Vector2i(1,1));
			}
			return bulletTextureInfoList[ID];
		}
		
		/// <summary>
		/// Gets the sprite.
		/// </summary>
		/// <returns>
		/// The sprite.
		/// </returns>
		/// <param name='textureInfo'>
		/// Texture info.
		/// </param>
		public SpriteTile getSprite(string path)
		{
			switch (path){
			case "/Application/assets/bossbulletGu.png":
				ID = 2;
				break;
			case "/Application/assets/bossbulletKi.png":
				ID = 1;
				break;
			default:
				ID=0;
				break;
			}
			if(bulletSpriteList[ID] == null)
			{
				bulletSpriteList[ID] = createSprite(getBulletTextureInfo(path));
			}
			return bulletSpriteList[ID];
		}
		
		public virtual SpriteTile createSprite(TextureInfo texture_info, float world_scale=1.5f)
		{
			SpriteTile sprite;
			
			//スプライト生成
			sprite = new SpriteTile(){TextureInfo = texture_info};
			//表示するテクスチャID
			sprite.TileIndex1D=0;
			//拡大率
			sprite.Quad.S = sprite.CalcSizeInPixels() * world_scale;
			//スプライトの中心と座標の中心を一致させる
			sprite.CenterSprite();
			//輝度設定
			sprite.Color=new Vector4(1.0f,1.0f,1.0f,1.00f);
			//表示の混合設定
			sprite.BlendMode = BlendMode.Normal;
			
			return sprite;
		}
	}
}
