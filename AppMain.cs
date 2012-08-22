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
/// App main.
/// </summary>
	public class AppMain
	{		
		public static void Main (string[] args)
		{
			//初期化
			Initialize ();
			
			//ゲームループ･･･selectボタンが押されるまでループする
			while (!Input2.GamePad0.Select.Press) {
				SystemEvents.CheckEvents ();
				Update ();
				Render ();
			}
		}
		
		/// <summary>
		/// Initialize.
		/// </summary>
		public static void Initialize ()
		{
			// Set up the graphics system
			GraphicsContext graphics = new GraphicsContext ();
			
			//GameEngine2Dの初期化
			Director.Initialize(500,400,graphics);
			
			// Gameインスタンスの作成・初期化
			Game.Instance = new Game();
			Game.Instance.Initialize();
			
		}
		
		/// <summary>
		/// Updateメソッド.
		/// </summary>
		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
			
			//Gameのupdateを呼び出す
			var game = Game.Instance;
			game.FrameUpdate();
			
			//GameEngine2Dのupdateを呼び出す
			Director.Instance.Update();
		}
		
		/// <summary>
		/// Render this instance.
		/// </summary>
		public static void Render ()
		{
			//GameEngine2Dを使うときはデフォルトの設定では駄目
			//GameEngine2Dでの描画処理
			Director.Instance.Render ();
			//UIの描画処理
			//UISystem.Render();
			
			//フレームバッファのスワップを行う
			Director.Instance.GL.Context.SwapBuffers ();
			Director.Instance.PostSwap ();
		}
	}
}
