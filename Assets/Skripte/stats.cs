using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class stats
{
    public int manaReg = 10;
    public int healthReg = 10;
    public float max_mp = 100;
    public float max_hp = 100;
    public float speed = 2;
    public float castTime = 5;
    public float exp = 0;
    public int lvl = 0;
    public int skillpoints = 0;

    public void GetXp()
    {
        if (exp >= 100)
        {
            exp -= 100;
            LevelUp();
        }
    }
    public void LevelUp()
    {
        lvl++;
        skillpoints++;
        Skills();
    }
    public void Skills()
    {
        switch ((int)Random.value*4)
        {
            case 0:
                skillpoints--;
                max_hp += 10;
                break; 
            case 1:
                skillpoints--;
                max_mp += 10;
                break;
            case 2:
                skillpoints--;
                castTime -= 0.5f;
                break;
            case 3:
                skillpoints--;
                speed += 0.5f;
                break;
        }
    }

}
