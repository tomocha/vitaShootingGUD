using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace vitaShootingGUD
{
	//敵の動きを制御するクラス
	public class Boss:ShipEntity
	{
		//奇数弾ベクトル
		public float[] bulletAnglesKi = new float[]
		{
			FMath.PI*6/8,
			FMath.PI*7/8,
			FMath.PI,
			-FMath.PI*7/8,
			-FMath.PI*6/8,
		};
		
		//偶数弾ベクトル
		public float[] bulletAnglesGu = new float[]
		{
			FMath.PI*9/10,
			-FMath.PI*9/10,
		};
		
		public Boss ()
		{
		}
		
		//敵弾を切り替えるためのenum
		enum POWER{ONE,TWO,THREE}
		POWER bossPower;
		
		BulletFactory bulletFactory = new BulletFactory();
		
		public Boss(Vector2 pos,string path) : base(pos,path)
		{
			new Vector2(pos.X,texture_info.TextureSizef.Y);
			this.Position =new Vector2(pos.X,texture_info.TextureSizef.Y);
			bossPower = POWER.ONE;
		}
		
		//フレーム描画時に呼ばれるメソッド
		public override void Tick(float dt)
		{
			try{
			base.Tick (dt);
			var pos = this.Position;
			pos.Y += 3.3f * FMath.Sin (FrameCount * 0.015f);
			this.Position=pos;
			
			if(FrameCount%20 == 0)
			{
				bossPower = POWER.ONE;
				shot ();
			}
			if(FrameCount%200 == 0)
			{
				bossPower = POWER.TWO;
				shot ();
			}
			}catch(Exception e){
			Console.WriteLine(e.ToString());
			}
		}
		
		/// <summary>
		/// Shot.
		/// </summary>
		private void shot(){
			switch(bossPower)
			{
			case POWER.ONE:
				foreach(float val in bulletAnglesKi){
					Game.Instance.AddQueue.Add (new BossBulletKi(this.Position,calcShotVector().Rotate(val)));
					//Game.Instance.AddQueue.Add (bulletFactory.getBullet(this.Position,calcShotVector().Rotate (val),Const.ENEMY_BULLET_KI));
				}
				break;
			case POWER.TWO:
			case POWER.THREE:				
				foreach(float val in bulletAnglesGu){
					Game.Instance.AddQueue.Add (new BossBulletGu(this.Position,calcShotVector().Rotate(val)));
				}
				break;
			default:
				break;
			}
		}
		
		/// <summary>
		/// Calculates the shot vector.
		/// </summary>
		/// <returns>
		/// The shot vector.
		/// </returns>
		private Vector2 calcShotVector(){
			float xVector = Game.Instance.Player.Position.X - this.Position.X;
			float yVector = Game.Instance.Player.Position.Y - this.Position.Y;
			float speed;
			switch(bossPower)
			{
			case POWER.ONE:
				speed = 500;
				break;
			case POWER.TWO:
			case POWER.THREE:
			default:
				speed = 200;
				break;
			}
			return new Vector2(xVector/FMath.Sqrt(xVector*xVector + yVector*yVector)*speed,yVector/FMath.Sqrt(xVector*xVector + yVector*yVector)*speed);
		}
	}
}

