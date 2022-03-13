using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum Skilltype
    {
        attack=1,
        heal,
        buff,
    }
    public enum Statetype
    {
        cost=1,
        care,
    }
    public class Skill
    {
        public Skilltype type;
        public int skillcost;
        public string name;
        public Bitmap picture;
        public State state;
        public int skillmagic;
        public string description;
        static public Skill Createattack(int skillcost,string name,Bitmap picture,int skillmagic,string description)
        {
            Skill askill = new Skill();
            askill.type = Skilltype.attack;
            askill.skillcost = skillcost;
            askill.name = name;
            askill.picture = picture;
            askill.skillmagic = skillmagic;
            askill.description = description;
            return askill;
        }
        static public Skill Createheal(int skillheal,string name,Bitmap picture,int skillmagic,string description)
        {
            Skill hskill = new Skill();
            hskill.type = Skilltype.heal;
            hskill.skillcost = skillheal;
            hskill.name = name;
            hskill.picture = picture;
            hskill.skillmagic = skillmagic;
            hskill.description = description;
            return hskill;
        }
        static public Skill Createbuff(State state,string name,Bitmap picture,int skillmagic,string description)
        {
            Skill bskill = new Skill();
            bskill.type = Skilltype.buff;
            bskill.state = state;
            bskill.name = name;
            bskill.picture = picture;
            bskill.skillmagic = skillmagic;
            bskill.description = description;
            return bskill;
        }
        public Role chooseaim(Role self,Role other)
        {
            if (this.type == Skilltype.attack)
            {
                return other;
            }
            else if (this.type == Skilltype.heal)
            {
                return self;
            }
            else if (this.type == Skilltype.buff)
            {
                if (this.state.statetype == Statetype.care)
                    return self;
                else
                    return other;
            }
            else
                return null;
        }
    }
    public class State
    {
        public Statetype statetype;
        public int nub;
        public int time;
        public string name;
        public State(Statetype statetype,int nub,int time,string name)
        {
            this.statetype = statetype;
            this.nub = nub;
            this.time = time;
            this.name = name;
        }
        public State copy()
        {
            return new State(this.statetype, this.nub, this.time,this.name);
        }
    }
}
