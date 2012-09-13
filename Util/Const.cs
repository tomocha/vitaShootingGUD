using System;

namespace vitaShootingGUD
{
	public struct Const
	{
		private static string ASSET_BASE = @"/Application/assets/";
		public static string BOSS_BULLET_GU_PATH = ASSET_BASE + @"bossbulletgu.png";
		public static string BOSS_BULLET_KI_PATH = ASSET_BASE + @"bossbullet.png";
		public static string PLAYER_BYLLET_DEFAULT_PATH = ASSET_BASE + @"mybulletdefault.png";
	
		public static string BOSS_SHIP_PATH = ASSET_BASE + @"boss.png";
		public static string PLAYER_SHIP_PATH = ASSET_BASE + @"myship.png";
		
		public static string BACKGROUND_PATH = ASSET_BASE + @"background.png";
		public static int ENEMY_BULLET_KI = 1;
	}
}

