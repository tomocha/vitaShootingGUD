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
		
		//自機
		public Player Player{get;set;}
		//自機画像path
		public string playerGraphic ="/Application/assets/myship.png";
		
		public Vector2i ScreenSize{get;set;}
		
		//初期化 ･･･AppMainから呼ばれる
		public void Initialize()
		{
			var width = Director.Instance.GL.Context.GetViewport().Width;
			var height = Director.Instance.GL.Context.GetViewport().Height;
			
			Director.Instance.GL.Context.SetClearColor(Colors.Grey20);
			ScreenSize = new Vector2i(width,height);
			
			//sceneの作成
			Scene scene = new Scene();
			scene.Camera.SetViewFromViewport();
			
			//GameEngine2Dの設定・実行
			Director.Instance.RunWithScene(scene,true);
			
			World = new Node();
			scene.AddChild(World);
			
			//自弾敵弾はキューで管理
			AddQueue = new List<BulletEntity>();
			RemoveQueue = new List<BulletEntity>();
			
			//自機登録･･･(初期位置,自機画像path)で自機ノードを作成してworldに登録
			Player = new Player(new Vector2(50,Game.Instance.ScreenSize.Y/2),playerGraphic);
			World.AddChild(Player);
		}
		
		//定期的なアップデート処理･･･AppMainから呼ばれる
		public void FrameUpdate(){
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
			//各キューのクリア
			RemoveQueue.Clear();
			AddQueue.Clear ();
		}
	}
}

