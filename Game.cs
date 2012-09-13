using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace vitaShootingGUD
{
	/**
	 * ゲームの初期化/管理
	 **/
	public class Game
	{
		public static Game Instance;
	
		//ワールド
		public Node World{get;set;}
		
		//キュー
		public List<BulletEntity> AddQueue{get;set;}
		public List<BulletEntity> RemoveQueue{get;set;}
		
		public hpDialog HpBar{get;set;}
		
		public HitTest HitTest{get;set;}
		
		//自機
		public Player Player{get;set;}
		
		//敵機
		public Boss Boss{get;set;}
		
		//背景
		public BackGround BackGround{get;set;}
		
		public Vector2i ScreenSize{get;set;}
		
		public bool flg = false;
		//初期化 ･･･AppMainから呼ばれる
		public void Initialize()
		{
			flg = false;
			var width = Director.Instance.GL.Context.GetViewport().Width;
			var height = Director.Instance.GL.Context.GetViewport().Height;
			
			Director.Instance.GL.Context.SetClearColor(Colors.Grey20);
			ScreenSize = new Vector2i(width,height);
			
			//sceneの作成
			Sce.PlayStation.HighLevel.GameEngine2D.Scene scene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene();
			scene.Camera.SetViewFromViewport();
			
			//GameEngine2Dの設定・実行
			Director.Instance.RunWithScene(scene,true);
			
			World = new Node();
			scene.AddChild(World);	
			
			//自弾敵弾はキューで管理
			AddQueue = new List<BulletEntity>();
			RemoveQueue = new List<BulletEntity>();
			
			HitTest = new HitTest();
			
			//背景登録
			for (int y = 0; y < 3; y++) {
				for (int x = 0; x < 3; x++) {
					var backGround = new BackGround (new Vector2 (x * 416f*2.5f, y * 232f * 2.5f),Const.BACKGROUND_PATH,2.5f);
					World.AddChild (backGround);
				}
			}
			
			//敵機登録
			Boss = new Boss(new Vector2(Game.Instance.ScreenSize.X-Game.Instance.ScreenSize.X/8,0),Const.BOSS_SHIP_PATH);
			World.AddChild (Boss);
			
			//自機登録･･･(初期位置,自機画像path)で自機ノードを作成してworldに登録
			Player = new Player(new Vector2(50,Game.Instance.ScreenSize.Y/2),Const.PLAYER_SHIP_PATH);
			World.AddChild(Player);	
			
			HpBar = new hpDialog();
		}
		
		//定期的なアップデート処理･･･AppMainから呼ばれる
		public void FrameUpdate(){
			if(!flg){
				HpBar.Show ();
				flg = true;
			}
			//当たり判定
			HitTest.Collide ();
			//削除キューにある弾をWorldから取り除く
			foreach(BulletEntity e in RemoveQueue)
			{
				World.RemoveChild(e,true);
			}
			//登録キューにある弾をWorldに追加する
			foreach(BulletEntity e in AddQueue)
			{
				World.AddChild(e);
			}
			World.RemoveChild (Player,false);
			World.AddChild (Player);
			//各キューのクリア
			RemoveQueue.Clear();
			AddQueue.Clear ();
		}
	}
}

