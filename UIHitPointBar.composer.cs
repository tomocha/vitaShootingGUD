// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace vitaShootingGUD
{
    partial class UIHitPointBar
    {
        ProgressBar enemyHP;
        ProgressBar playerHP;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            enemyHP = new ProgressBar();
            enemyHP.Name = "enemyHP";
            playerHP = new ProgressBar();
            playerHP.Name = "playerHP";

            // enemyHP
            enemyHP.Progress = 1f;

            // playerHP
            playerHP.Progress = 1f;

            // UIHitPointBar
            this.RootWidget.AddChildLast(enemyHP);
            this.RootWidget.AddChildLast(playerHP);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.DesignWidth = 544;
                    this.DesignHeight = 960;

                    enemyHP.SetPosition(452, 227);
                    enemyHP.SetSize(362, 16);
                    enemyHP.Anchors = Anchors.Height;
                    enemyHP.Visible = true;

                    playerHP.SetPosition(16, 38);
                    playerHP.SetSize(362, 16);
                    playerHP.Anchors = Anchors.Height;
                    playerHP.Visible = true;

                    break;

                default:
                    this.DesignWidth = 960;
                    this.DesignHeight = 544;

                    enemyHP.SetPosition(27, 12);
                    enemyHP.SetSize(900, 16);
                    enemyHP.Anchors = Anchors.Height;
                    enemyHP.Visible = true;

                    playerHP.SetPosition(27, 516);
                    playerHP.SetSize(200, 16);
                    playerHP.Anchors = Anchors.Height;
                    playerHP.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
        }

        private void onShowing(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        private void onShown(object sender, EventArgs e)
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

    }
}
