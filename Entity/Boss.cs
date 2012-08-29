using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace vitaShootingGUD
{
	public class Boss:ShipEntity
	{
		//ボスが発射する弾のベクトル
		Vector2 bossBulletVec;
		//奇数弾ベクトル
		public float[] bulletAnglesKi = new float[]{FMath.PI*5/8,FMath.PI*6/8,FMath.PI*7/8,FMath.PI*8/8,-FMath.PI*7/8,-FMath.PI*6/8,-FMath.PI*5/8};
		
		public Boss ()
		{
		}
		enum POWER{ONE,TWO,THREE}
		POWER bossPower;
		public Boss(Vector2 pos,string path) : base(pos,path)
		{
			new Vector2(pos.X,texture_info.TextureSizef.Y);
			this.Position =new Vector2(pos.X,texture_info.TextureSizef.Y);
			bossPower = POWER.ONE;
		}
		
		public override void Tick(float dt)
		{
			base.Tick (dt);
			var pos = this.Position;
			pos.Y += 3.3f * FMath.Sin (FrameCount * 0.015f);
			this.Position=pos;
			
			if(FrameCount%10 == 0)
			{
				shot ();
			}
		}
		
		/// <summary>
		/// Shot.
		/// </summary>
		private void shot(){
			//自機-敵機のベクトルの向きを計算する
			float xVector = Game.Instance.Player.Position.X - this.Position.X;
			float yVector = Game.Instance.Player.Position.Y - this.Position.Y;
			bossBulletVec = new Vector2(xVector/FMath.Sqrt(xVector*xVector + yVector*yVector)*500,yVector/FMath.Sqrt(xVector*xVector + yVector*yVector)*500);
			
			switch(bossPower)
			{
			case POWER.ONE:
			case POWER.TWO:
			case POWER.THREE:				
				foreach(float val in bulletAnglesKi){
					Game.Instance.AddQueue.Add (new BossBullet(this.Position,bossBulletVec.Rotate(val)));
				}
				break;
			default:
				break;
			}
		}
	}
}

