using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{

    public class Gamedata
    {
        public int mapnub;
        public int maxmapnub=3;
        public int player_heng=6, player_shu=11;
        public const int lon_g = 13;
        public int[,] map1 = new int[lon_g, lon_g];
        public int[,] map2 = new int[lon_g, lon_g];
        public int[,] map3 = new int[lon_g, lon_g];
        public int[,] map1_ = new int[lon_g, lon_g];
        public List<int[,]> mapsave = new List<int[,]>();
        public Player player = new Player();
        int heng;
        int shu;
        //地图初始化;
        public Gamedata()
        {
            mapnub = 0;
            //map1初始化;
            for (heng = 0, shu = 0; heng < lon_g; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 0, shu = lon_g - 1; heng < lon_g; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 0, shu = 0; shu < lon_g; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = lon_g - 1, shu = 0; shu < lon_g; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 0, shu = 2; heng <= 10; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 4, shu = 2; shu <= 12; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 6, shu = 2; shu <= 7; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 10, shu = 2; shu <= 7; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 6, shu = 7; heng <= 10; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 0, shu = 8; heng <= 4; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 4, shu = 9; heng <= 12; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 8, shu = 9; shu <= 12; shu++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 0, shu = 5; heng <= 4; heng++)
            {
                map1[heng, shu] = 1;
            }
            for (heng = 6, shu = 5; heng <= 10; heng++)
            {
                map1[heng, shu] = 1;
            }
            map1[1, 3] = 7; map1[2, 4] = 5; map1[1, 1] = 9; map1[3, 1] = map1[4, 1] = map1[5, 1] = 4;
            map1[7, 3] = 2; map1[8, 3] = 10; map1[7, 4] = 3; map1[8, 4] = 7; map1[7, 6] = 4; map1[8, 6] = 6;
            map1[9, 6] = 4; map1[1, 6] = 10; map1[2, 7] = 5; map1[1, 10] = 7; map1[3, 10] = 10; map1[5, 10] = 10;
            map1[10, 10] = 5; map1[1, 11] = 7; map1[6, 11] = -1; map1[9, 11] = 5; map1[10, 11] = 8;
            map1[11, 11] = 5; map1[3, 11] = 10; map1[2, 8] = 11; map1[2, 5] = 11; map1[4, 3] = 11; map1[6, 6] = 11; map1[9, 5] = 11;
            map1[6, 9] = map1[10, 9] = 11;
            //map2初始化
            for (heng = 0, shu = 0; heng < lon_g; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 0, shu = lon_g - 1; heng < lon_g; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 0, shu = 0; shu < lon_g; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = lon_g - 1, shu = 0; shu < lon_g; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 3, shu = 0; shu <= 10; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 0, shu = 4; heng <= 4; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 7, shu = 0; shu <= 12; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 9, shu = 0; shu <= 4; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 9, shu = 6; shu <= 12; shu++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 9, shu = 3; heng <= 12; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 0, shu = 6; heng <= 3; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 0, shu = 10; heng <= 4; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 9, shu = 6; heng <= 12; heng++)
            {
                map2[heng, shu] = 1;
            }
            for (heng = 9, shu = 9; heng <= 12; heng++)
            {
                map2[heng, shu] = 1;
            }
            map2[1, 1] = 10;map2[1, 3] = 6; map2[1, 4] = 11;map2[1, 6] = 11;map2[1, 7] = 5;map2[1, 9] = 7;
            map2[1, 11] = 12;map2[2, 1] = 3;map2[2, 2] = 7;map2[2, 8] = 10;map2[2, 9] = 2;
            map2[3, 5] = 4;map2[4, 1] = 10;map2[4, 2] = 8;map2[4, 3] = 10;map2[5, 1] = 8;map2[5, 2] = 10;
            map2[6, 1] = 10;map2[6, 2] = 8;map2[6, 3] = 10;map2[6, 4] = 1;map2[6, 10] = 1;map2[6, 7] = 1;
            map2[4, 7] = 1;map2[9, 2] = 11;map2[9, 8] = 11;map2[9, 11] = 11;map2[10, 2] = 4;map2[10, 8] = 6;
            map2[11, 1] = 7;map2[11, 4] = 6;map2[11, 7] = 7;map2[11,8] = 10;map2[11, 11] = 9;map2[7,5] = 4;
            //map3
            for (heng = 0, shu = 0; heng < lon_g; heng++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 0, shu = lon_g - 1; heng < lon_g; heng++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 0, shu = 0; shu < lon_g; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = lon_g - 1, shu = 0; shu < lon_g; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 4, shu = 0; shu <= 6; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 8, shu = 0; shu <= 4; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 2, shu = 8; shu <= 12; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 6, shu = 8; shu <= 12; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 10, shu = 8; shu <= 12; shu++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 0, shu = 4; heng <= 12; heng++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 4, shu = 6; heng <= 12; heng++)
            {
                map3[heng, shu] = 1;
            }
            for (heng = 0, shu = 8; heng <= 12; heng++)
            {
                map3[heng, shu] = 1;
            }
            map3[1, 2] = 7;map3[1, 7] = 4;map3[1, 8] = 11;map3[1, 11] = 9;map3[2, 1] = 10;map3[2, 4] = 11;
            map3[2, 5] = 6;map3[3, 2] = 10;map3[3, 7] = 4;map3[3, 10] = 4;map3[3, 11] = 10;map3[4, 5] = 11;
            map3[4, 8] = 11;map3[4, 9] = 4;map3[4, 10] = 10;map3[4, 11] = 4;map3[5, 10] = 10;map3[6, 1] = 20;
            map3[6, 4] = 11;map3[6, 5] = 4;map3[7, 10] = 2;map3[8, 9] = 6;map3[8, 11] = 4;map3[9, 2] = 10;map3[9, 5] = 5;
            map3[9, 10] = 7;map3[10, 1] = 6;map3[10, 3] = 5;map3[10, 4] = 11;map3[11, 2] = 8;map3[11, 8] = 11;map3[11, 11] = 12;
            //and so on....
            for (int i = 0; i < lon_g; i++)
            {
                for(int j = 0; j < lon_g; j++)
                {
                    map1_[i,j] = map1[i,j];
                    //and so on...
                }
            }
            mapsave.Add(map1);
            mapsave.Add(map2);
            mapsave.Add(map3);

        }

        public void getplayerlocation(int[,] map)
        {
            if (map == map1 && Myvalue.ischangetower==0)
            {
                player_heng = 6;
                player_shu = 11;
            }
            else if (map == map1)
            {
                //下到map1
                if (Myvalue.ischangetower == -1)
                {
                    player_heng = 2;
                    player_shu = 1;
                }
            }
            else if (map == map2)
            {
                //上到map2
                if (Myvalue.ischangetower == 1)
                {
                    player_heng = 2;
                    player_shu = 11;
                }
                //下到map2
                else if (Myvalue.ischangetower == -1)
                {
                    player_heng = 10;
                    player_shu = 11;
                }
            }
            else if (map == map3)
            {
                //上到map3
                if (Myvalue.ischangetower == 1)
                {
                    player_heng = 11;
                    player_shu = 10;
                }
            }
            map[player_heng, player_shu] = -1;
        }
        public void Move(int[,]map,int dx, int dy)
        {
            //每次新建player的时候，设置一下参数
            player.blood = Myvalue.hp;
            player.magic = Myvalue.np;
            player.exp = Myvalue.exp;
            player.level = Myvalue.level;
            player.attack = Myvalue.attack;
            player.defend = Myvalue.defend;
            player.key = Myvalue.key;
            int he = player_heng;
            int sh = player_shu;
            map[he, sh] = 0;
        
            he += dx;
            sh += dy;
            //撞墙;
            if (map[he, sh] == 1)
            {
                sh -= dy;
                he -= dx;
            }
            //撞门
            else if (map[he, sh] == 11)
            {
                if (player.key > 0) 
                    player.key--;
                else
                {
                    sh -= dy;
                    he -= dx;
                }
                Myvalue.key = player.key;
            }
            //红药
            else if (map[he, sh] == 7)
            {
                player.addblood(500);
                Myvalue.hp = player.blood;
            }
            //蓝药
            else if (map[he, sh] == 8)
            {
                player.addmagic(100);
                Myvalue.np = player.magic;
            }
            //钥匙
            else if (map[he, sh] == 10)
            {
                player.key++;
                Myvalue.key = player.key;
            }
            //红宝石
            else if (map[he, sh] ==2)
            {
                player.attack += 10;
                Myvalue.attack = player.attack;
            }
            //蓝宝石
            else if (map[he, sh] == 3)
            {
                player.defend += 5;
                Myvalue.defend = player.defend;
            }
            //触发战斗；
            else if (map[he, sh] == 4||map[he,sh]==5||map[he,sh]==6)
            {
                Myvalue.monsternub = map[he, sh];
                Battle4form battle4 = new Battle4form();
                battle4.ShowDialog();
                if (!Myvalue.success)
                {
                    sh -= dy;
                    he -= dx;
                }
                Myvalue.success = false;
            }
            else if (map[he, sh] == 20)
            {
                Shop shop = new Shop();
                shop.ShowDialog();
            }
            //上楼
            else if (map[he, sh]==9)
            {
                Myvalue.ischangetower = 1;
                mapnub++;
                if (mapnub >= maxmapnub)
                {
                    MessageBox.Show("更多内容，尽请期待");
                    mapnub = maxmapnub-1;
                    Myvalue.ischangetower = 0;
                    sh -= dy;
                    he -= dx;
                }
            }
            //下楼
            else if (map[he, sh] == 12)
            {
                Myvalue.ischangetower = -1;
                mapnub--;
                if (mapnub <= 0)
                {
                    mapnub = 0;
                }
            }
            player_heng = he;
            player_shu = sh;
            if(map[player_heng,player_shu]!=9&&map[player_heng,player_shu]!=12)
                map[player_heng, player_shu] = -1;
        }
        
    }
}

