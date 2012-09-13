// AUTOMATICALLY GENERATED CODE

using System;
using System.Collections.Generic;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.HighLevel.UI;

namespace vitaShootingGUD
{
    partial class UIHp
    {
        ProgressBar enemyHp;
        Label Label_1;
        Label Label_2;
        ProgressBar playerHp;

        private void InitializeWidget()
        {
            InitializeWidget(LayoutOrientation.Horizontal);
        }

        private void InitializeWidget(LayoutOrientation orientation)
        {
            enemyHp = new ProgressBar();
            enemyHp.Name = "enemyHp";
            Label_1 = new Label();
            Label_1.Name = "Label_1";
            Label_2 = new Label();
            Label_2.Name = "Label_2";
            playerHp = new ProgressBar();
            playerHp.Name = "playerHp";

            // Label_1
            Label_1.TextColor = new UIColor(255f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);
            Label_1.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            Label_1.TextTrimming = TextTrimming.Word;
            Label_1.LineBreak = LineBreak.Character;
            Label_1.TextShadow = new TextShadowSettings()
            {
                Color = new UIColor(128f / 255f, 128f / 255f, 128f / 255f, 127f / 255f),
                HorizontalOffset = 2f,
                VerticalOffset = 2f,
            };

            // Label_2
            Label_2.TextColor = new UIColor(36f / 255f, 0f / 255f, 254f / 255f, 255f / 255f);
            Label_2.Font = new UIFont(FontAlias.System, 25, FontStyle.Regular);
            Label_2.LineBreak = LineBreak.Character;
            Label_2.TextShadow = new TextShadowSettings()
            {
                Color = new UIColor(128f / 255f, 128f / 255f, 128f / 255f, 127f / 255f),
                HorizontalOffset = 2f,
                VerticalOffset = 2f,
            };

            // UIHp
			enemyHp.Progress = 1f;
			playerHp.Progress = 1f;
            this.BackgroundColor = new UIColor(153f / 255f, 153f / 255f, 153f / 255f, 0f / 255f);
            this.Clip = true;
            this.AddChildLast(enemyHp);
            this.AddChildLast(Label_1);
            this.AddChildLast(Label_2);
            this.AddChildLast(playerHp);

            SetWidgetLayout(orientation);

            UpdateLanguage();
        }

        private LayoutOrientation _currentLayoutOrientation;
        public void SetWidgetLayout(LayoutOrientation orientation)
        {
            switch (orientation)
            {
                case LayoutOrientation.Vertical:
                    this.SetSize(544, 960);
                    this.Anchors = Anchors.None;

                    enemyHp.SetPosition(578, 16);
                    enemyHp.SetSize(362, 16);
                    enemyHp.Anchors = Anchors.Height;
                    enemyHp.Visible = true;

                    Label_1.SetPosition(364, 6);
                    Label_1.SetSize(214, 36);
                    Label_1.Anchors = Anchors.None;
                    Label_1.Visible = true;

                    Label_2.SetPosition(9, 6);
                    Label_2.SetSize(214, 36);
                    Label_2.Anchors = Anchors.None;
                    Label_2.Visible = true;

                    playerHp.SetPosition(90, 16);
                    playerHp.SetSize(362, 16);
                    playerHp.Anchors = Anchors.Height;
                    playerHp.Visible = true;

                    break;

                default:
                    this.SetSize(960, 544);
                    this.Anchors = Anchors.None;

                    enemyHp.SetPosition(90, 19);
                    enemyHp.SetSize(850, 16);
                    enemyHp.Anchors = Anchors.Height;
                    enemyHp.Visible = true;

                    Label_1.SetPosition(5, 9);
                    Label_1.SetSize(85, 36);
                    Label_1.Anchors = Anchors.None;
                    Label_1.Visible = true;

                    Label_2.SetPosition(9, 497);
                    Label_2.SetSize(81, 36);
                    Label_2.Anchors = Anchors.None;
                    Label_2.Visible = true;

                    playerHp.SetPosition(90, 507);
                    playerHp.SetSize(200, 16);
                    playerHp.Anchors = Anchors.Height;
                    playerHp.Visible = true;

                    break;
            }
            _currentLayoutOrientation = orientation;
        }

        public void UpdateLanguage()
        {
            Label_1.Text = "Enemy";

            Label_2.Text = "Player";
        }

        public void InitializeDefaultEffect()
        {
            switch (_currentLayoutOrientation)
            {
                case LayoutOrientation.Vertical:
                    break;

                default:
                    break;
            }
        }

        public void StartDefaultEffect()
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
