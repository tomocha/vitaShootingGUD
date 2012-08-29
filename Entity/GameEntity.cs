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
	public class GameEntity : Node
	{
		//frame
		public int FrameCount{ get;set;}
		public SpriteTile Sprite {get; set;}
		public GameEntity()
		{
			Scheduler.Instance.Schedule(this,Tick,0.0f,false);
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
			
		//Tick
		public virtual void Tick(float dt)
		{
			FrameCount++;
		}
	}
}

