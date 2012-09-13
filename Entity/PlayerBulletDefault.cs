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
	/// デフォルトの自機弾クラス.
	/// </summary>
	public class PlayerBulletDefault : BulletEntity
	{
		public PlayerBulletDefault (Vector2 pos):base(pos,Const.PLAYER_BYLLET_DEFAULT_PATH,1.0f,5.0f)
		{
		}
		
		/// <summary>
		/// 定期的な処理.
		/// </summary>
		/// <param name='dt'>
		/// 前回に呼ばれてからの経過時間.
		/// </param>
		public override void Tick(float dt)
		{
			const float speed = 3000f;
			base.Tick(dt);
			var pos = this.Position;
			pos.X += speed * dt;
			this.Position = pos;
			//画面の外に出たら消す
			if(pos.X > Game.Instance.ScreenSize.X)
			{
				this.RemoveChild(Sprite,true);
				Game.Instance.RemoveQueue.Add(this);
			}
		}
	}
}

