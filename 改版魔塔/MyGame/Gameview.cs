using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{

    public class Gameview:Control
    {
        const int heng=13;
        const int shu=13;
        public playermodelpicture1 xuetiao = new playermodelpicture1();
        public playermodelpicture2 lantiao = new playermodelpicture2();
        public playermodelpicture3 huangtiao = new playermodelpicture3();
        public playermodel_data1 xueliang = new playermodel_data1();
        public playermodel_data2 lanliang = new playermodel_data2();
        public playermodel_data3 huangliang = new playermodel_data3();
        public playermodel_data4 yaoshi = new playermodel_data4();
        public playermodel_data5 gongji = new playermodel_data5();
        public playermodel_data6 fangyu = new playermodel_data6();
        Rectangle[,] cells = new Rectangle[heng, shu];
        public Gamedata data = new Gamedata();
        Bitmap player_p = Properties.Resources.player;
        Bitmap bluestone_p = Properties.Resources.bluestone;
        Bitmap door_p = Properties.Resources.door;
        Bitmap ground_p = Properties.Resources.ground;
        Bitmap key_p = Properties.Resources.key;
        Bitmap monster1_p = Properties.Resources.monster1;
        Bitmap redstone_p = Properties.Resources.redstone;
        Bitmap stairs_p = Properties.Resources.stairs;
        Bitmap wall_p = Properties.Resources.wall;
        Bitmap monster2_p = Properties.Resources.monster2;
        Bitmap monster3_p = Properties.Resources.monster3;
        Bitmap blood_p = Properties.Resources.blood;
        Bitmap magic_p = Properties.Resources.magi;
        Bitmap upstairs_p = Properties.Resources.upstairs;
        Bitmap downstairs_p = Properties.Resources.downstairs;
        Bitmap jian_shang = Properties.Resources.jian_shang;
        public Gameview()
        {
            this.Size = new Size(390, 390);
            this.BackColor = Color.White;

            // 允许获得焦点 
            this.SetStyle(ControlStyles.Selectable, true);
            //双缓冲，减少闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            //设置玩家初始位置
            data.getplayerlocation(data.mapsave[data.mapnub]);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // 平滑绘制
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            if (Myvalue.ischangetower!=0)
            {
                data.getplayerlocation(data.mapsave[data.mapnub]);
                Myvalue.ischangetower = 0;
            }
            for(int hang = 0; hang < heng; hang++)
            {
                for(int lie = 0; lie < shu; lie++)
                {
                    Rectangle cell = cells[hang, lie];
                    if (data.mapsave[data.mapnub][hang, lie] == 0)
                    {
                        g.DrawImage(ground_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 1)
                    {
                        g.DrawImage(wall_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 2)
                    {
                        g.DrawImage(redstone_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 3)
                    {
                        g.DrawImage(bluestone_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 4)
                    {
                        g.DrawImage(monster1_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 5)
                    {
                        g.DrawImage(monster2_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 6)
                    {
                        g.DrawImage(monster3_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 7)
                    {
                        g.DrawImage(blood_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 8)
                    {
                        g.DrawImage(magic_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 9)
                    {
                        g.DrawImage(upstairs_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 10)
                    {
                        g.DrawImage(key_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 11)
                    {
                        g.DrawImage(door_p, cell);
                    }
                     else if (data.mapsave[data.mapnub][hang, lie] == 12)
                     {
                         g.DrawImage(downstairs_p, cell);
                     }
                    else if (data.mapsave[data.mapnub][hang, lie] == -1)
                    {
                        g.DrawImage(player_p, cell);
                    }
                    else if (data.mapsave[data.mapnub][hang, lie] == 20)
                    {
                        g.DrawImage(jian_shang, cell);
                    }
                }
            }

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            
            this.Invalidate();
            int w = this.Width, h = this.Height;
            int cellsw = w / heng;
            int cellsh = h / shu;
            for(int hang = 0; hang < heng; hang++)
            {
                for(int lie = 0; lie < shu; lie++)
                {
                    Rectangle rect = new Rectangle();
                    rect.X = hang * cellsh;
                    rect.Y = lie * cellsw;
                    rect.Width = cellsw;
                    rect.Height = cellsh;
                    cells[hang, lie] = rect;
                }
            }
        }
 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            // 鼠标点击时获取焦点
            this.Focus(); // 申请焦点
        }

        //控制移动
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
             
            switch (e.KeyCode)
            {
                case Keys.Left:
                    data.Move(data.mapsave[data.mapnub],-1, 0);
                    //重绘全部构件
                    this.Invalidate();
                    Form1.form1.playermodel_data11.Invalidate();
                    Form1.form1.playermodel_data21.Invalidate();
                    Form1.form1.playermodel_data31.Invalidate();
                    Form1.form1.playermodelpicture11.Invalidate();
                    Form1.form1.playermodelpicture21.Invalidate();
                    Form1.form1.playermodelpicture31.Invalidate();
                    Form1.form1.playermodel_data41.Invalidate();
                    Form1.form1.playermodel_data51.Invalidate();
                    Form1.form1.playermodel_data61.Invalidate();
                    Form1.form1.playermodel_datalevel1.Invalidate();
                    break;
                case Keys.Right:
                    data.Move(data.mapsave[data.mapnub],1, 0);
                    this.Invalidate();
                    Form1.form1.playermodel_data11.Invalidate();
                    Form1.form1.playermodel_data21.Invalidate();
                    Form1.form1.playermodel_data31.Invalidate();
                    Form1.form1.playermodelpicture11.Invalidate();
                    Form1.form1.playermodelpicture21.Invalidate();
                    Form1.form1.playermodelpicture31.Invalidate();
                    Form1.form1.playermodel_data41.Invalidate();
                    Form1.form1.playermodel_data51.Invalidate();
                    Form1.form1.playermodel_data61.Invalidate();
                    Form1.form1.playermodel_datalevel1.Invalidate();
                    break;
                case Keys.Up:
                    data.Move(data.mapsave[data.mapnub],0, -1);
                    this.Invalidate();
                    Form1.form1.playermodel_data11.Invalidate();
                    Form1.form1.playermodel_data21.Invalidate();
                    Form1.form1.playermodel_data31.Invalidate();
                    Form1.form1.playermodelpicture11.Invalidate();
                    Form1.form1.playermodelpicture21.Invalidate();
                    Form1.form1.playermodelpicture31.Invalidate();
                    Form1.form1.playermodel_data41.Invalidate();
                    Form1.form1.playermodel_data51.Invalidate();
                    Form1.form1.playermodel_data61.Invalidate();
                    Form1.form1.playermodel_datalevel1.Invalidate();
                    break;
                case Keys.Down:
                    data.Move(data.mapsave[data.mapnub],0, 1);
                    this.Invalidate();
                    Form1.form1.playermodel_data11.Invalidate();
                    Form1.form1.playermodel_data21.Invalidate();
                    Form1.form1.playermodel_data31.Invalidate();
                    Form1.form1.playermodelpicture11.Invalidate();
                    Form1.form1.playermodelpicture21.Invalidate();
                    Form1.form1.playermodelpicture31.Invalidate();
                    Form1.form1.playermodel_data41.Invalidate();
                    Form1.form1.playermodel_data51.Invalidate();
                    Form1.form1.playermodel_data61.Invalidate();
                    Form1.form1.playermodel_datalevel1.Invalidate();
                    break;
            }
        }
       
    }
    //生命数字
    public class playermodel_data1 : Control
    {
        
        public playermodel_data1()
        {
            this.Size = new Size(60, 20);
            //禁止其接收焦点
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

            using(Brush brush=new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format= new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(Myvalue.hp+"/"+Myvalue.maxhp, font, brush, rect,format);

            }
        }
    }
    //生命文字
    public class playermodel_data11 : Control
    {

        public playermodel_data11()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 9);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("生命", font, brush, rect, format);

            }
        }
    }
    //法力数字
    public class playermodel_data2 : Control
    {

        public playermodel_data2()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(Myvalue.np+"/"+Myvalue.maxnp, font, brush, rect, format);

            }
        }
    }
    //法力文字
    public class playermodel_data22 : Control
    {

        public playermodel_data22()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 9);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("法力", font, brush, rect, format);

            }
        }
    }
    //经验数字
    public class playermodel_data3 : Control
    {

        public playermodel_data3()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(Myvalue.exp+"/"+Myvalue.maxexp, font, brush, rect, format);

            }
        }
    }
    //经验文字
    public class playermodel_data33 : Control
    {

        public playermodel_data33()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 9);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("经验", font, brush, rect, format);

            }
        }
    }
    //红条
    public class playermodelpicture1:Control
    {
        public playermodelpicture1()
        {
            this.Size = new Size(100,10);
            this.BackColor = Color.Gray;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            int rectw;
            rectw = (int)((Myvalue.hp*1.0 / Myvalue.maxhp*1.0) * w);
            Rectangle rect = new Rectangle(0, 0, rectw, h);
            
            using(Brush brush=new SolidBrush(Color.LightPink))
            {
                g.FillRectangle(brush, rect);
            }
        }
    }
    //蓝条
    public class playermodelpicture2 : Control
    {
        public playermodelpicture2()
        {
            this.Size = new Size(100, 10);
            this.BackColor = Color.Gray;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            int rectw;
            rectw = (int)((Myvalue.np*1.0 / Myvalue.maxnp*1.0) * w);
            Rectangle rect = new Rectangle(0, 0, rectw, h);

            using (Brush brush = new SolidBrush(Color.LightSkyBlue))
            {
                g.FillRectangle(brush, rect);
            }
        }
    }
    //黄条
    public class playermodelpicture3 : Control
    {
        public playermodelpicture3()
        {
            this.Size = new Size(100, 10);
            this.BackColor = Color.Gray;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            int rectw;
            rectw = (int)((Myvalue.exp*1.0 / Myvalue.maxexp*1.0) * w);
            Rectangle rect = new Rectangle(0, 0, rectw, h);

            using (Brush brush = new SolidBrush(Color.LightYellow))
            {
                g.FillRectangle(brush, rect);
            }
        }
        public void changeit()
        {
            this.Invalidate();
        }
    }
    //钥匙
    public class playermodel_data4 : Control
    {

        public playermodel_data4()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("钥匙数量:"+Myvalue.key, font, brush, rect, format);
            }

        }
    }
    //攻击力
    public class playermodel_data5 : Control
    {

        public playermodel_data5()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("攻击力:" + Myvalue.attack, font, brush, rect, format);

            }
        }
    }
    //防御力
    public class playermodel_data6 : Control
    {

        public playermodel_data6()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString( "防御力:" + Myvalue.defend, font, brush, rect, format);

            }
        }
    }
    //技能条
    public class playerskill:Control
    {
        public Player player = new Player();
        public int clickarea=-1;
        public playerskill()
        {
            this.Size = new Size(200,50);
            this.SetStyle(ControlStyles.Selectable, false);
            //每次新建player的时候，设置一下参数
            player.blood = Myvalue.hp;
            player.magic = Myvalue.np;
            player.exp = Myvalue.exp;
            player.level = Myvalue.level;
            player.attack = Myvalue.attack;
            player.defend = Myvalue.defend;
            player.key = Myvalue.key;
            player.setplayerskill();
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            int w = this.Width, h = this.Height;
            for(int i = 0; i < 4; i++)
            {
                Rectangle playerskill = new Rectangle();
                playerskill.Width = w / 4;
                playerskill.Height = h;
                playerskill.X = i * playerskill.Width;
                playerskill.Y = 0;
                g.DrawImage(player.skills[i].picture, playerskill);
            }
            if (clickarea!=-1)
            {
                Rectangle r1 = new Rectangle();
                r1.X = clickarea * w / 4;
                r1.Y = 0;
                r1.Width = w / 4;
                r1.Height = h;
                using(Pen pen=new Pen(Color.White))
                {
                    pen.Width = 4.0f;
                    g.DrawRectangle(pen, r1);
                }
            }

        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int x = e.X,w=this.Width;
            Rectangle rect = new Rectangle();
            rect.Width = w / 4;
            rect.Height = this.Height;
            rect.Y = 0;
            if (x >= 0 && x < w / 4)
            {
                clickarea = 0;
                this.Invalidate();
                MessageBox.Show(player.skills[0].name + ": " + player.skills[0].description);
            }
            if (x >= w / 4 && x < 2 * (w / 4))
            {
                clickarea = 1;
                this.Invalidate();
                MessageBox.Show(player.skills[1].name + ": " + player.skills[1].description);
            }
            if (x >= 2 * (w / 4) && x < 3 * (w / 4))
            {
                clickarea = 2;
                this.Invalidate();
                MessageBox.Show(player.skills[2].name + ": " + player.skills[2].description);
            }
            if (x >= 3 * (w / 4) && x <= w)
            {
                clickarea = 3;
                this.Invalidate();
                MessageBox.Show(player.skills[3].name + ": " + player.skills[3].description);
            }

        }
    }
    //技能文字
    public class playerskill1 : Control
    {

        public playerskill1()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 9);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("技能", font, brush, rect, format);

            }
        }
    }
    //等级
    public class playermodel_datalevel : Control
    {

        public playermodel_datalevel()
        {
            this.Size = new Size(60, 20);
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

            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 12);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Near;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("玩家等级:" + Myvalue.level, font, brush, rect, format);
            }

        }
    }
    public class replay : Control
    {
        public replay()
        {
            this.Size = new Size(100, 50);
            this.BackColor = Color.White;
            this.SetStyle(ControlStyles.Selectable, false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            int w = this.Width, h = this.Height;
            Rectangle rect = new Rectangle(0, 0, w, h);
            rect.Inflate(-2,- 2);
            using(Pen pen=new Pen(Color.SkyBlue))
            {
                g.DrawRectangle(pen, rect);
            }
            using(Brush brush=new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 10);
                StringFormat format=new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("重置游戏", font, brush, rect, format);
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Form1.form1.gameview2.data.mapnub = 0;
            for(int i = 0; i < 13; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    Form1.form1.gameview2.data.map1[i, j] = Form1.form1.gameview2.data.map1_[i, j];
                    //....
                }
            }

            Myvalue.maxhp=Myvalue.hp = 1000;
            Myvalue.maxnp=Myvalue.np = 100;
            Myvalue.exp = 0;
            Myvalue.maxexp = 100;
            Myvalue.key = 0;
            Myvalue.level = 1;
            Form1.form1.gameview2.data.getplayerlocation(Form1.form1.gameview2.data.map1);
            Form1.form1.gameview2.Invalidate();
            Form1.form1.playermodel_data11.Invalidate();
            Form1.form1.playermodel_data21.Invalidate();
            Form1.form1.playermodel_data31.Invalidate();
            Form1.form1.playermodelpicture11.Invalidate();
            Form1.form1.playermodelpicture21.Invalidate();
            Form1.form1.playermodelpicture31.Invalidate();
            Form1.form1.playermodel_data41.Invalidate();
            Form1.form1.playermodel_data51.Invalidate();
            Form1.form1.playermodel_data61.Invalidate();
            Form1.form1.playermodel_datalevel1.Invalidate();

        }
    }

}
