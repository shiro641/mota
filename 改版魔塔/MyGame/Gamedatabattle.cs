using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Gamedatabattle
    {
        public Monster[] monsters = new Monster[20];
        public Monster m1 = new Monster();
        public Monster m2 = new Monster();
        public Monster m3 = new Monster();
        public Monster m1_ = new Monster();
        public Monster m2_ = new Monster();
        public Monster m3_ = new Monster();
        Bitmap attack = Properties.Resources.attack;
        Bitmap skill_1 = Properties.Resources.kuwei;
        Bitmap skill_2 = Properties.Resources.bingfengbao;
        Bitmap skill_3 = Properties.Resources.shuangdong;
        Bitmap monster1_p = Properties.Resources.monster4;
        Bitmap monster2_p = Properties.Resources.monster5;
        Bitmap monster3_p = Properties.Resources.monster6;
        public Gamedatabattle()
        {
            m1.name = "史莱姆";
            m1.attack = 200;
            m1_.blood=m1.blood = 500;
            m1_.magic=m1.magic = 10;
            m1.maxblood = 500;
            m1.maxmagic = 10;
            m1.exp = 50;
            m1.picture = monster1_p;
            m1.skills.Add(Skill.Createattack(m1.attack-Myvalue.defend, "普通攻击", attack, 0, "很普通的攻击"));
            m2.name = "骷髅";
            m2.attack = 400;
            m2_.blood=m2.blood = 700;
            m2_.magic=m2.magic = 100;
            m2.maxblood = 700;
            m2.maxmagic = 100;
            m2.exp = 150;
            m2.picture = monster2_p;
            m2.skills.Add(Skill.Createattack(m2.attack-Myvalue.defend, "普通攻击", attack, 0, "很普通的攻击"));
            State state1 = new State(Statetype.cost, 100, 2,"中毒");
            m2.skills.Add(Skill.Createbuff(state1, "枯萎", skill_1, 30, "释放技能，为敌方附加两回合的中毒状态。中毒：每回合损失200血量"));
            m3.name = "冰霜法师";
            m3.attack = 600;
            m3_.blood=m3.blood = 800;
            m3_.magic=m3.magic = 200;
            m3.maxblood = 800;
            m3.maxmagic = 200;
            m3.exp = 300;
            m3.picture = monster3_p;
            m3.skills.Add(Skill.Createattack(m3.attack-Myvalue.defend, "普通攻击", attack, 0, "很普通的攻击"));
            m3.skills.Add(Skill.Createattack(500, "冰风暴", skill_2, 80, "释放技能，造成500点伤害，无视防御"));
            State state2 = new State(Statetype.cost, 80, 3,"冻伤");
            m3.skills.Add(Skill.Createbuff(state2, "霜冻", skill_3, 40, "释放技能，为敌方附加三回合的冻伤状态。冻伤：每回合受到80点伤害"));
            //此处的数组下标对应Gamedata中地图初始化的怪物数字
            monsters[4] = m1;
            monsters[5] = m2;
            monsters[6] = m3;



        }
    }
}
