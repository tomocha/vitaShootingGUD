// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace vitaShootingGUD
{
    partial class hpDialog
    {
        ProgressBar playerHp;
        Label Label_1;
        Label Label_2;
        ProgressBar enemyHp;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            playerHp = new ProgressBar();
            playerHp.Name = "playerHp";
            Label_1 = new Label();
            Label_1.Name = "Label_1";
            Label_2 = new Label();
            Label_2.Name = "Label_2";
            enemyHp = new ProgressBar();
            enemyHp.Name = "enemyHp";

            // playerHp
            playerHp.Progress = 1f;

            // Label_1
            Label_1.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_1.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            Label_1.LineBreak = LineBreak.Character;

            // Label_2
            Label_2.TextColor = new UIColor(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_2.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            Label_2.LineBreak = LineBreak.Character;

            // enemyHp
            enemyHp.Progress = 1f;

            // hpDialog
            this.BackgroundFilterColor = new UIColor(255f / 255f, 255f / 255f, 255f / 255f, 0f / 255f);
            this.AddChildLast(playerHp);
            this.AddChildLast(Label_1);
            this.AddChildLast(Label_2);
            this.AddChildLast(enemyHp);
            this.HideEffect = new TiltDropEffect();

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetPosition(0, 0);
                    this.SetSize(544, 960);
                    this.Anchors = Anchors.None;

                    playerHp.SetPosition(48, 512);
                    playerHp.SetSize(362, 16);
                    playerHp.Anchors = Anchors.Height;
                    playerHp.Visible = true;

                    Label_1.SetPosition(0, 508);
                    Label_1.SetSize(214, 36);
                    Label_1.Anchors = Anchors.None;
                    Label_1.Visible = true;

                    Label_2.SetPosition(0, 0);
                    Label_2.SetSize(214, 36);
                    Label_2.Anchors = Anchors.None;
                    Label_2.Visible = true;

                    enemyHp.SetPosition(199, 0);
                    enemyHp.SetSize(362, 16);
                    enemyHp.Anchors = Anchors.Height;
                    enemyHp.Visible = true;

                    break;

                default:
                    this.SetPosition(0, 0);
                    this.SetSize(960, 544);
                    this.Anchors = Anchors.None;

                    playerHp.SetPosition(88, 516);
                    playerHp.SetSize(200, 16);
                    playerHp.Anchors = Anchors.Height;
                    playerHp.Visible = true;

                    Label_1.SetPosition(0, 505);
                    Label_1.SetSize(88, 38);
                    Label_1.Anchors = Anchors.None;
                    Label_1.Visible = true;

                    Label_2.SetPosition(0, 0);
                    Label_2.SetSize(88, 36);
                    Label_2.Anchors = Anchors.None;
                    Label_2.Visible = true;

                    enemyHp.SetPosition(88, 10);
                    enemyHp.SetSize(850, 16);
                    enemyHp.Anchors = Anchors.Height;
                    enemyHp.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            Label_1.Text = "player";

            Label_2.Text = "enemy";
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
