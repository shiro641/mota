using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Role
    {
        public List<Skill> skills = new List<Skill>();
        public List<State> states = new List<State>();
        public int key;
        public int blood;
        public int magic;
        public int attack;

        public int maxblood,maxmagic;
        public int level;
        public int exp;
        public int maxexp;
        public void addblood(int num)
        {
            this.blood += num;
            if (this.blood >= Myvalue.maxhp)
                this.blood = Myvalue.maxhp;
        }
        public void addmagic(int num)
        {
            this.magic += num;
            if (this.magic >= Myvalue.maxnp)
                this.magic = Myvalue.maxnp;
        }
        public void costblood(int num)
        {
            this.blood -= num;
            if (this.blood <= 0)
                this.blood = 0;
        }
        public void costmagic(int num)
        {
            this.magic -= num;
        }
        public void levelup()
        {
            this.exp = 0;
            maxexp = (int)((double)Myvalue.maxexp* 1.8);
            maxblood =(int)((double)Myvalue.maxhp*1.1);
            maxmagic = (int)((double)Myvalue.maxnp * 1.5);
            Myvalue.exp = 0;
            this.level++;
            Myvalue.level++;
            
            //升级时应更新最大红蓝黄
            Myvalue.maxhp = maxblood;
            Myvalue.maxnp = maxmagic;
            Myvalue.maxexp = maxexp;
            //血蓝回满
            this.blood = Myvalue.maxhp;
            this.magic = Myvalue.maxnp;
        }
        public void behit(Skill item,Role sender)
        {
            switch (item.type) 
            {
                case Skilltype.attack:
                    this.costblood(item.skillcost);
                    sender.costmagic(item.skillmagic);
                    break;
                case Skilltype.heal:
                    this.addblood(item.skillcost);
                    sender.costmagic(item.skillmagic);
                    break;
                case Skilltype.buff:
                    this.states.Add(item.state.copy());
                    sender.costmagic(item.skillmagic);
                    break;
            }
        }
        public void jiesuan()
        {
              foreach(State buff in states)
              {
                  if (buff.time == 0)
                      continue;
                  if (buff.statetype == Statetype.care)
                  {
                      this.addblood(buff.nub);
                  }
                  else if (buff.statetype == Statetype.cost)
                  {
                      this.costblood(buff.nub);
                  }
              buff.time--;
              }
              for(int i = states.Count - 1; i >= 0; i--)
              {
                  if (states[i].time == 0)
                  {
                      this.states.RemoveAt(i);
                  }
              }
        }
    }
    public class Player : Role
    {
        public Bitmap playerattack = Properties.Resources.attack;
        public Bitmap playerheal = Properties.Resources.heal;
        public Bitmap playerbuffheal = Properties.Resources.buffheal;
        public Bitmap playerfire = Properties.Resources.fire;
        public int defend;

        public Player()
        {
            maxblood = 1000;
            maxmagic = 100;
            maxexp = 100;
            key = 0;
            blood = 1000;
            magic = 100;
            level = 1;
            defend = 100;
            attack = 100;
            exp = 0;
        }
        public void setplayerskill()
        {
            this.skills.Add(Skill.Createattack(this.attack, "普通攻击", playerattack, 0, "很普通的攻击"));
            this.skills.Add(Skill.Createheal(this.attack*4, "治愈术", playerheal, 30, "释放技能，回复己方"+this.attack*4+"点血量"));
            State state1 = new State(Statetype.cost, (int)((double)(this.attack)*0.8), 3,"灼烧");
            this.skills.Add(Skill.Createbuff(state1, "火球术", playerfire, 20, "释放技能,为敌方附加两回合灼烧状态。灼烧：每回合受到"+ (int)((double)(this.attack) * 0.8) + "点伤害"));
            State state2 = new State(Statetype.care, this.attack*2, 2,"愈合");
            this.skills.Add(Skill.Createbuff(state2, "复苏", playerbuffheal, 15, "释放技能，为己方附加两回合愈合状态。愈合：每回合回复"+ this.attack * 2 + "点血量"));
        }
    }
    public class Monster : Role
    {
        public string name;
        public Bitmap picture;
        private Random random = new Random();
        public Skill chooseskill()
        {
            Skill skill = null;
            while (skill == null)
            {
                Myvalue.mskv = random.Next(0, skills.Count);
                skill = this.skills[Myvalue.mskv];
                if (this.magic < skill.skillmagic)
                    skill = null;
            }
            return skill;
        }
    }
}
