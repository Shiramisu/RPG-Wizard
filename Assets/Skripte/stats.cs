using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class stats
{
    public float mp = 100;
    public float hp = 100;
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
        max_hp += 10;
        max_mp += 10;
        castTime -= 0.5f;
    }
    public void Skills()
    {
        switch (lvl)
        {
            case 0:
                max_hp += 10;
                break; 
            case 1:
                max_mp += 10;
                break;
            case 2:
                castTime -= 0.5f;
                break;
        }
    }

}