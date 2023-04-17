using AngryBirds.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AngryBirds.Renderer
{
    internal class Display : FrameworkElement
    {
        Size area;
        IGameModel model;


        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
            this.model.Changed += (sender, eventargs) => this.InvalidateVisual();
        }
        public Brush BackgroundBrush
        { get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bg.png"), UriKind.RelativeOrAbsolute)));
            } 
        }
        public Brush TowerBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bertbullet.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush ErnieBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "ernie.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush BulletBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "bullet.png"), UriKind.RelativeOrAbsolute)));
            }
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (area.Width > 0 && area.Height > 0 && model != null)
            {
                drawingContext.DrawRectangle(BackgroundBrush, null, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawRectangle(TowerBrush, null, new Rect(0, area.Height - 80, 80, 80));

                foreach (var item in model.Bullets)
                {
                    drawingContext.DrawEllipse(BulletBrush, null, new Point(item.Center.X, item.Center.Y), 10, 10);
                }

                foreach (var item in model.Ernies)
                {
                    drawingContext.DrawEllipse(ErnieBrush, null, new Point(item.Center.X, item.Center.Y), 30, 30);
                }
            }
        }
    }
}
