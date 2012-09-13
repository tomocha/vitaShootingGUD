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
	public class BossBulletKi : BulletEntity
	{
		public BossBulletKi():base(Const.BOSS_BULLET_KI_PATH,1.0f){}
		public BossBulletKi (Vector2 pos,Vector2 velocity):base(pos,Const.BOSS_BULLET_KI_PATH,1.0f,10.0f)
		{
			this.Velocity = velocity;
		}
		
		public override void Tick(float dt)
		{
			base.Tick(dt);
			var pos = this.Position;
			pos.X -= Velocity.X * dt;
			pos.Y -= Velocity.Y * dt;
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

