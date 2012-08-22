using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace vitaShootingGUD
{
	public class Player : ShipEntity
	{	
		enum POWER{ONE,TWO,THREE}
		POWER playerPower;
		public Player(Vector2 pos,string path) : base(pos,path)
		{
			playerPower = POWER.ONE;
		}
		
		//GameEntityのTickをオーバーライド
		public override void Tick (float dt)
		{
			float speed=0;//移動スピード
			Vector2 position = this.Position;
			base.Tick (dt);
			
			//キー入力はInput2から取得できる
			//×ボタン(Cross)が押されている間は移動スピードを落とす
			if(Input2.GamePad0.Cross.Down)
			{
				speed = 100;
				//TODO 慎重に動いているときは機体の色変えたりとか
			}
			if(!Input2.GamePad0.Cross.Down)
			{
				speed = 600;
			}
			
			//○ボタン(Circle)が押されている間は弾を撃つ
			if(Input2.GamePad0.Circle.Down)
			{
				shot();
			}
			
			//上(Up)が押されている(Down)
			if(Input2.GamePad0.Up.Down)
			{
				position.Y += speed*dt;
				if(position.Y > Game.Instance.ScreenSize.Y){
					position.Y = Game.Instance.ScreenSize.Y;
				}
			}
			
			//下(Down)が押されている(Down)
			if(Input2.GamePad0.Down.Down)
			{
				position.Y -= speed*dt;
				if(position.Y<0)
				{
					position.Y = 0;
				}
			}
			
			//左(Left)が押されている(Down)
			if(Input2.GamePad0.Left.Down)
			{
				position.X -= speed*dt;
				if(position.X<0)
				{
					position.X = 0;
				}
			}
				
			//右(Right)が押されている(Down)
			if(Input2.GamePad0.Right.Down)
			{
				position.X += speed*dt;
				if(position.X > Game.Instance.ScreenSize.X)
				{
					position.X = Game.Instance.ScreenSize.X;
				}
			}
			
			this.Position = position;
		}
		/// <summary>
		/// Shot this instance.
		/// </summary>
		private void shot()
		{
			BulletEntity bullet;
			switch(playerPower)
			{
			case POWER.ONE:
			case POWER.TWO:
			case POWER.THREE:
				bullet = new PlayerBulletDefault(this.Position);
				break;
			default:
				bullet = new PlayerBulletDefault(this.Position);
				break;
			}
			Game.Instance.AddQueue.Add (bullet);
		}
	}
}

