using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace vitaShootingGUD
{   
	/// <summary>
	/// 奇数弾クラス.
	/// </summary>
	public class BossBulletGu : BulletEntity
	{
		//傾き設定
		Vector2 velocity;
		
		public BossBulletGu (Vector2 pos,Vector2 velocity):base(pos,Const.BOSS_BULLET_GU_PATH,5.0f)
		{
			this.velocity = velocity;
		}
		
		public override void Tick(float dt)
		{
			base.Tick(dt);
			//弾を動かす
			var pos = this.Position;
			pos.X -= velocity.X * dt;
			pos.Y -= velocity.Y * dt;
			this.Position = pos;
			
			//画面の外に出たら消す
			if(isRemovePosition(pos))
			{
				this.RemoveChild(Sprite,true);
				Game.Instance.RemoveQueue.Add(this);
			}
		}
	}
}

