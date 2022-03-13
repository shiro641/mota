using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public class Battleview:Control
    {
        public Player player = new Player();
        public bool go_on = true;
        public int skillvaluep = -1;
        public int skillvaluem = -1;
        public Gamedatabattle data = new Gamedatabattle();
        public Battleview()
        {
            this.Size = new Size(575, 600);

            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            int w = this.Width, h = this.Height;
            Rectangle bnub = new Rectangle(0, 0, w / 6, h/18);
            Rectangle mnub = new Rectangle(0, h / 18, w / 6, h / 18);
            Rectangle sword = new Rectangle(0, 2 * h / 18, w / 6, h / 18);
            Rectangle mblood = new Rectangle(w/6, 0, w-w/6, h / 18);
            Rectangle mmagic = new Rectangle(w/6, h / 18, w-w/6, h / 18);
            Rectangle mstate = new Rectangle(w/6, 2 * h / 18, w-w/6, h / 18);
            Rectangle mpitcture = new Rectangle(0, h / 6, 2 * w / 3, h / 3);
            Rectangle mskills = new Rectangle(2 * w / 3, h / 6, w / 3, h / 3);
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, mblood);
                g.DrawRectangle(pen, mmagic);
                g.DrawRectangle(pen, mstate);
                g.DrawRectangle(pen, mpitcture);
                g.DrawRectangle(pen, mskills);
            }

            //blood;
            using (Brush brush = new SolidBrush(Color.LightPink))
            {
                double tmpw;
                tmpw = (data.monsters[Myvalue.monsternub].blood*1.0) / (data.monsters[Myvalue.monsternub].maxblood*1.0);
                Rectangle tmp1 = new Rectangle();
                tmp1.X = mblood.X;
                tmp1.Y = mblood.Y;
                tmp1.Width = (int)(tmpw * mblood.Width);
                tmp1.Height = mblood.Height;
                g.FillRectangle(brush, tmp1);
            }
            using(Brush brush= new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(" "+data.monsters[Myvalue.monsternub].blood, font,brush,bnub,format);

            }
            using(Pen pen=new Pen(Color.Black))
            {
                g.DrawRectangle(pen, bnub);
            }
            //magic
            using (Brush brush = new SolidBrush(Color.LightBlue))
            {
                double tmpw;
                tmpw = (data.monsters[Myvalue.monsternub].magic*1.0) / (data.monsters[Myvalue.monsternub].maxmagic*1.0);
                Rectangle tmp2 = new Rectangle();
                tmp2.X = mmagic.X;
                tmp2.Y = mmagic.Y;
                tmp2.Width = (int)(tmpw*mmagic.Width);
                tmp2.Height = mmagic.Height;
                g.FillRectangle(brush, tmp2);
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(" " +data.monsters[Myvalue.monsternub].magic, font, brush, mnub, format);

            }
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, mnub);
            }
            //state,skills 背景;
            using (Brush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, mstate);
                g.FillRectangle(brush, mskills);
            }
            //状态;
            if (data.monsters[Myvalue.monsternub].states.Count > 0)
            {
                for (int i = 0; i < data.monsters[Myvalue.monsternub].states.Count; i++) {
                    Rectangle r = new Rectangle();
                    r.Width = mstate.Width / (data.monsters[Myvalue.monsternub].states.Count);
                    r.Height = mstate.Height;
                    r.X = i * r.Width+mstate.X;
                    r.Y = mstate.Y;
                    using (Pen pen = new Pen(Color.Black))
                    {
                        g.DrawRectangle(pen, r);
                    }
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        Font font = new Font("宋体", 8);
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        g.DrawString(data.monsters[Myvalue.monsternub].states[i].name, font, brush, r, format);
                    }
                }
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("状态", font, brush,sword, format);

            }
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, sword);
            }
            //技能
            for (int i = 0; i < 4; i++)
            {
                Rectangle rs = new Rectangle();
                rs.Width = mskills.Width;
                rs.Height = mskills.Height / 4;
                rs.X = mskills.X;
                rs.Y = mskills.Y+ rs.Height * i;
                using (Pen pen = new Pen(Color.Black))
                {
                    g.DrawRectangle(pen, rs);
                }
                if (i < data.monsters[Myvalue.monsternub].skills.Count)
                {
                    g.DrawImage(data.monsters[Myvalue.monsternub].skills[i].picture, rs);
                }
            }
            //monster;
            g.DrawImage(data.monsters[Myvalue.monsternub].picture, mpitcture);
            //玩家板块
            //blood
            Rectangle pbnub = new Rectangle(0, h/2, w / 6, h / 18);
            Rectangle pmnub = new Rectangle(0, h/2+h / 18, w / 6, h / 18);
            Rectangle psword = new Rectangle(0, h/2+2 * h / 18, w / 6, h / 18);
            Rectangle pblood = new Rectangle(w / 6, h/2 , w-w/6, h / 18);
            Rectangle pmagic = new Rectangle(w / 6, h/2+h / 18, w-w/6, h / 18);
            Rectangle pstate = new Rectangle(w / 6, h/2+2 * h / 18, w-w/6, h / 18);
            Rectangle pskills = new Rectangle(0, h / 2 + h / 6, w, h / 6);
            Rectangle describe = new Rectangle(0, 5 * h / 6, w, h / 8);
            Rectangle pname = new Rectangle(0, 23*h / 24, w, h / 24);

            player.maxblood = Myvalue.maxhp;
            player.maxmagic = Myvalue.maxnp;
            player.maxexp = Myvalue.exp;
            player.blood = Myvalue.hp;
            player.magic = Myvalue.np;
            player.exp = Myvalue.exp;
            player.attack = Myvalue.attack;
            player.defend = Myvalue.defend;
            player.setplayerskill();

            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, pblood);
                g.DrawRectangle(pen, pmagic);
                g.DrawRectangle(pen, pstate);
                g.DrawRectangle(pen, pskills);
                g.DrawRectangle(pen, describe);
                g.DrawRectangle(pen, pname);
                g.DrawRectangle(pen, pbnub);
                g.DrawRectangle(pen, pmnub);
            }
            //blood
            using (Brush brush = new SolidBrush(Color.LightPink))
            {
                Rectangle temp = new Rectangle();
                temp.X = pblood.X;
                temp.Y = pblood.Y;
                temp.Height = pblood.Height;
                temp.Width = (int)(((double )((player.blood*1.0)/(player.maxblood*1.0)))*pblood.Width);
                g.FillRectangle(brush, temp);
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(" " + player.blood, font, brush, pbnub, format);

            }
            //magic
            using (Brush brush = new SolidBrush(Color.LightBlue))
            {
                Rectangle temp = new Rectangle();
                temp.X = pmagic.X;
                temp.Y = pmagic.Y;
                temp.Height = pmagic.Height;
                temp.Width = (int)(((double )((player.magic*1.0) / (player.maxmagic*1.0))) * pmagic.Width);
                g.FillRectangle(brush, temp);
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString(" " + player.magic, font, brush, pmnub, format);
            }
            //技能及状态
            using (Brush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, pstate);
                g.FillRectangle(brush, pskills);
            }
            //状态;
            if (player.states.Count> 0)
            {
                for (int i = 0; i < player.states.Count; i++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = pstate.Width / (player.states.Count);
                    r.Height = pstate.Height;
                    r.X = i * r.Width+pstate.X;
                    r.Y = pstate.Y;
                    using (Pen pen = new Pen(Color.Black))
                    {
                        g.DrawRectangle(pen, r);
                    }
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        Font font = new Font("宋体", 8);
                        StringFormat format = new StringFormat();
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        g.DrawString(player.states[i].name, font, brush, r, format);
                    }
                }
            }
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("状态", font, brush, psword, format);

            }
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, psword);
            }
            //技能
            for (int i = 0; i < 4; i++)
            {
                Rectangle rs = new Rectangle();
                rs.Width = pskills.Width/4;
                rs.Height = pskills.Height;
                rs.X = pskills.X+rs.Width*i;
                rs.Y = pskills.Y;
                using (Pen pen = new Pen(Color.Black))
                {
                    g.DrawRectangle(pen, rs);
                }
                if (i < player.skills.Count)
                {
                    g.DrawImage(player.skills[i].picture, rs);
                }
            }
            //战斗名
            using(Brush brush=new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 8);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                g.DrawString("玩家vs" + data.monsters[Myvalue.monsternub].name, font,brush, pname, format);
            }
            if (skillvaluem != -1 && skillvaluep != -1)
            {
                Rectangle rp = new Rectangle(describe.X, describe.Y, describe.Width, describe.Height / 2);
                Rectangle rm = new Rectangle(describe.X, describe.Y + describe.Height / 2, describe.Width, describe.Height / 2);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    Font font = new Font("宋体", 9);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Near;
                    format.LineAlignment = StringAlignment.Near;
                    g.DrawString("你使用了"+player.skills[skillvaluep].name+":"+player.skills[skillvaluep].description, font, brush, rp);
                    g.DrawString(data.monsters[Myvalue.monsternub].name+ "使用了"+ data.monsters[Myvalue.monsternub].skills[skillvaluem].name+":"+data.monsters[Myvalue.monsternub].skills[skillvaluem].description, font, brush, rm);
                }
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int h = this.Height, w = this.Width;
            bool releaseskill = false;
            int x = e.X, y = e.Y;
            Role aim;
                if (y >= 2 * h / 3 && y <= 5 * h / 6) 
                {
                if (x >= 0 && x < w / 4)
                {
                    if (go_on)
                    {
                        //你的回合
                        if (player.magic >= player.skills[0].skillmagic)
                        {
                            releaseskill = true;
                            aim = player.skills[0].chooseaim(player, data.monsters[Myvalue.monsternub]);
                            aim.behit(player.skills[0], player);
                            skillvaluep = 0;
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                        }
                        else
                        {
                            releaseskill = false;
                            MessageBox.Show("法力不足，无法释放该技能");
                        }
                        player.jiesuan();
                        if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                        {
                            player.exp += data.monsters[Myvalue.monsternub].exp;
                            Myvalue.exp = player.exp;
                            if (player.exp >= Myvalue.maxexp)
                                player.levelup();
                        }
                    }
                    if (go_on)
                    {
                        if (releaseskill)
                        {
                            //怪物回合
                            Skill skill;
                            skill = data.monsters[Myvalue.monsternub].chooseskill();
                            aim = skill.chooseaim(data.monsters[Myvalue.monsternub], player);
                            aim.behit(skill, data.monsters[Myvalue.monsternub]);
                            skillvaluem = Myvalue.mskv;
                            data.monsters[Myvalue.monsternub].jiesuan();
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                            if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                            {
                                player.exp += data.monsters[Myvalue.monsternub].exp;
                                Myvalue.exp = player.exp;
                                if (player.exp >= Myvalue.maxexp)
                                    player.levelup();
                            }
                        }
                    }
                }
                else if (x >= w / 4 && x < w * 2 / 4)
                {
                    if (go_on)
                    {
                        //你的回合
                        player.jiesuan();
                        if (player.magic >= player.skills[1].skillmagic)
                        {
                            releaseskill = true;
                            aim = player.skills[1].chooseaim(player, data.monsters[Myvalue.monsternub]);
                            aim.behit(player.skills[1], player);
                            skillvaluep = 1;
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                        }
                        else
                        {
                            releaseskill = false;
                            MessageBox.Show("法力不足，无法释放该技能");
                        }
                        player.jiesuan();
                        if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                        {
                            player.exp += data.monsters[Myvalue.monsternub].exp;
                            Myvalue.exp = player.exp;
                            if (player.exp >= Myvalue.maxexp)
                                player.levelup();
                        }
                    }
                    if (go_on)
                    {
                        if (releaseskill)
                        {
                            //怪物回合
                            Skill skill;
                            skill = data.monsters[Myvalue.monsternub].chooseskill();
                            aim = skill.chooseaim(data.monsters[Myvalue.monsternub], player);
                            aim.behit(skill, data.monsters[Myvalue.monsternub]);
                            skillvaluem = Myvalue.mskv;
                            data.monsters[Myvalue.monsternub].jiesuan();
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                            if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                            {
                                player.exp += data.monsters[Myvalue.monsternub].exp;
                                Myvalue.exp = player.exp;
                                if (player.exp >= Myvalue.maxexp)
                                    player.levelup();
                            }
                        }
                    }
                }
                else if (x >= 2 * w / 4 && x < 3 * w / 4)
                {
                    if (go_on)
                    {
                        //你的回合
                        if (player.magic >= player.skills[2].skillmagic)
                        {
                            releaseskill = true;
                            aim = player.skills[2].chooseaim(player, data.monsters[Myvalue.monsternub]);
                            aim.behit(player.skills[2], player);
                            skillvaluep = 2;
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                        }
                        else
                        {
                            releaseskill = false;
                            MessageBox.Show("法力不足，无法释放该技能");
                        }
                        player.jiesuan();
                        if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                        {
                            player.exp += data.monsters[Myvalue.monsternub].exp;
                            Myvalue.exp = player.exp;
                            if (player.exp >= Myvalue.maxexp)
                                player.levelup();
                        }
                    }
                    if (go_on)
                    {
                        if (releaseskill)
                        {
                            //怪物回合
                            Skill skill;
                            skill = data.monsters[Myvalue.monsternub].chooseskill();
                            aim = skill.chooseaim(data.monsters[Myvalue.monsternub], player);
                            aim.behit(skill, data.monsters[Myvalue.monsternub]);
                            skillvaluem = Myvalue.mskv;
                            data.monsters[Myvalue.monsternub].jiesuan();
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                            if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                            {
                                player.exp += data.monsters[Myvalue.monsternub].exp;
                                Myvalue.exp = player.exp;
                                if (player.exp >= Myvalue.maxexp)
                                    player.levelup();
                            }
                        }
                    }
                }
                else if (x >= 3 * w / 4 && x <= w)
                {
                    if (go_on)
                    {
                        //你的回合
                        if (player.magic >= player.skills[3].skillmagic)
                        {
                            releaseskill = true;
                            aim = player.skills[3].chooseaim(player, data.monsters[Myvalue.monsternub]);
                            aim.behit(player.skills[3], player);
                            skillvaluep = 3;
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                        }
                        else
                        {
                            releaseskill = false;
                            MessageBox.Show("法力不足，无法释放该技能");
                        }
                        player.jiesuan();
                        if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                        {
                            player.exp += data.monsters[Myvalue.monsternub].exp;
                            Myvalue.exp = player.exp;
                            if (player.exp >= Myvalue.maxexp)
                                player.levelup();
                        }
                    }
                    if (go_on)
                    {
                        if (releaseskill)
                        {
                            //怪物回合
                            Skill skill;
                            skill = data.monsters[Myvalue.monsternub].chooseskill();
                            aim = skill.chooseaim(data.monsters[Myvalue.monsternub], player);
                            aim.behit(skill, data.monsters[Myvalue.monsternub]);
                            skillvaluem = Myvalue.mskv;
                            data.monsters[Myvalue.monsternub].jiesuan();
                            if (player.blood <= 0 || data.monsters[Myvalue.monsternub].blood <= 0)
                                go_on = false;
                            if (data.monsters[Myvalue.monsternub].blood == 0 && player.blood > 0)
                            {
                                player.exp += data.monsters[Myvalue.monsternub].exp;
                                Myvalue.exp = player.exp;
                                if (player.exp >= Myvalue.maxexp)
                                    player.levelup();
                            }
                        }
                    }
                }
            }
            if (!go_on)
            {
                if (player.blood > 0)
                {
                    MessageBox.Show("恭喜你，战斗胜利，游戏继续");
                    Myvalue.success = true;
                }
                else
                {
                    MessageBox.Show("很遗憾，战斗失败，游戏结束");
                    Myvalue.success = false;
                }
            }
            Myvalue.hp = player.blood;
            Myvalue.np = player.magic;
            this.Invalidate();
        }
    }
}
