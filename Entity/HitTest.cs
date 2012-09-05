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
	// 当たり判定
	public class HitTest
	{
		public enum CollisionEntityType
		{
			Player,       // 自機
			PlayerBullet, // 自弾
			Boss,         // ボスキャラ
			BossBullet    // 敵弾
		}
		
		public delegate Vector2 GetCenterDelegate ();

		public delegate float GetRadiusDelegate ();
		
		public struct CollisionEntry
		{
			public CollisionEntityType type; // キャラクターの種類
			public GameEntity owner; // 当たり判定のオブジェクト
			public GetCenterDelegate center; // 中心の座標
			public GetRadiusDelegate radius; // 半径の大きさ
		}
		
		List<List<CollisionEntry>> typed_entries;
		
		public HitTest ()
		{
			typed_entries = new List<List<CollisionEntry>> ();
			typed_entries.Add (new List<CollisionEntry> ()); // Player
			typed_entries.Add (new List<CollisionEntry> ()); // PlayerBullet
			typed_entries.Add (new List<CollisionEntry> ()); // Boss
			typed_entries.Add (new List<CollisionEntry> ()); // BossBullet
		}
		
		public void Add (CollisionEntityType type, GameEntity owner, GetCenterDelegate center, GetRadiusDelegate radius)
		{	
			CollisionEntry entry = new CollisionEntry () { type = type, owner = owner, center = center, radius = radius };
			List<CollisionEntry> entries = typed_entries [(int)type];
			entries.Add (entry);
		}
		
		public void Add (CollisionEntry entry)
		{
			List<CollisionEntry> entries = typed_entries [(int)entry.type];
			entries.Add (entry);
		}

        // 円同士で当たり判定を取る
		private void CollideEntities (List<CollisionEntry> collider, List<CollisionEntry> collidee)
		{
			for (int i = 0; i < collider.Count; ++i) {
				GameEntity collider_owner = collider [i].owner;
				Vector2 collider_center = collider [i].center ();
				float collider_radius = collider [i].radius ();
						
				for (int j = 0; j < collidee.Count; ++j) {
					GameEntity collidee_owner = collidee [j].owner;
					// 同じオブジェクト同士だったら次へ
					if (collider_owner == collidee_owner)
						continue;
					// 中心座標と半径を取得		
					Vector2 collidee_center = collidee [j].center ();
					float collidee_radius = collidee [j].radius ();
					float r = collider_radius + collidee_radius;

                    // 中心座標同士の距離を取得
					Vector2 offset = collidee_center - collider_center;
					float lensqr = offset.LengthSquared ();	
							
                    // 当たり判定
					if (lensqr < r * r) {
                        // 衝突した
						collider_owner.Hit (collidee_owner);
						collidee_owner.Hit (collider_owner);
					}
				}
			}
		}

        // 当たり判定
		public void Collide ()
		{	
            // ボスキャラと自機
			CollideEntities (typed_entries [(int)CollisionEntityType.Boss], typed_entries [(int)CollisionEntityType.Player]);
            // 敵弾と自機
			CollideEntities (typed_entries [(int)CollisionEntityType.BossBullet], typed_entries [(int)CollisionEntityType.Player]);
            // 自弾とボスキャラ
			CollideEntities (typed_entries [(int)CollisionEntityType.PlayerBullet], typed_entries [(int)CollisionEntityType.Boss]);
			Clear (); // データをクリア
		}
		
		public void Clear ()
		{
			foreach (List<CollisionEntry> entries in typed_entries)
				entries.Clear ();
		}
	}
}

