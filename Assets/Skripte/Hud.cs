using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Hud : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text Score_Text;
    public TMP_Text MP_Text;
    public TMP_Text HP_Text;
    public TMP_Text lvl_Text;
    public TMP_Text exp_Text;
    public TMP_Text skillpoints_Text;
    public static float hp;
    public static float mp;
    public static float max_hp;
    public static float max_mp;
    public static int lvl;
    public static float exp;
    public static int score = 0;
    public static int skillpoints;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Wizard player = Wizard.instance;
        mp = player.stats.mp;
        hp = player.stats.hp; 
        lvl = player.stats.lvl;
        exp = player.stats.exp;
        max_mp = player.stats.max_mp;
        max_hp = player.stats.max_hp;   
        skillpoints = player.stats.skillpoints;


        Score_Text.text = "Score: " + score;
        MP_Text.text = "MP: " + mp +"/"+ max_mp;
        HP_Text.text = "HP: " + hp + "/" + max_hp;
        lvl_Text.text = "Level: " + lvl;
        exp_Text.text = "Exp: " + exp;
        skillpoints_Text.text = "Skillpoints: " + skillpoints;
    }
}
