using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public class Shopview:Control
    {
        public Shopview()
        {
            this.Size = new Size(60, 20);
            this.BackColor = Color.Black;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using (Brush brush = new SolidBrush(Color.White))
            {
                Font font = new Font("宋体",12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("花费200点血量上限，你可以：", font, brush, rect, format);

            }
        }
    }
    public class Addattack : Control
    {
        public bool paint_ = false;
        public Addattack()
        {
            this.Size = new Size(60, 20);
            this.BackColor = Color.Gray;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            Rectangle r = new Rectangle(0, 0, w, h);
            r.Inflate(-2, -2);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            if (paint_)
            {
                using (Pen pen = new Pen(Color.White))
                {
                    g.DrawRectangle(pen, r);
                }
                paint_ = false;
            }
            using (Brush brush = new SolidBrush(Color.White))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("增加100点攻击力", font, brush, rect, format);

            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.paint_ = true;
            Myvalue.attack += 100;
            Myvalue.maxhp -= 200;
            Myvalue.hp -= 200;
            Shop.shop1.addattack1.Invalidate();
            Shop.shop1.adddefend1.Invalidate();
        }
    }
    public class Adddefend : Control
    {
        public bool paint_ = false;
        public Adddefend()
        {
            this.Size = new Size(60, 20);
            this.BackColor = Color.Gray;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            Rectangle r = new Rectangle(0, 0, w, h);
            r.Inflate(-2, -2);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            if (paint_)
            {
                using (Pen pen = new Pen(Color.White))
                {
                    g.DrawRectangle(pen, r);
                }
                paint_ = false;
            }
            using (Brush brush = new SolidBrush(Color.White))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("增加100点防御力", font, brush, rect, format);

            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            paint_ = true;
            Myvalue.defend += 100;
            Myvalue.maxhp -= 200;
            Myvalue.hp -= 200;
            Shop.shop1.addattack1.Invalidate();
            Shop.shop1.adddefend1.Invalidate();
        }
    }
}
