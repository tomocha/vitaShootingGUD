using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace vitaShootingGUD
{
    public partial class hpDialog : Dialog
    {
        public hpDialog()
            : base(null, null)
        {
            InitializeWidget();
        }
		
		public float PlayerHp{
			get{ return (float)playerHp.Progress; }
			set{ playerHp.Progress = (float)value; }
		}
		
		public float EnemyHp{
			get{ return (float)enemyHp.Progress; }
			set{ enemyHp.Progress = (float)value; }
		}
    }
}
