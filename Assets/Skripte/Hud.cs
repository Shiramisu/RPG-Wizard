using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public TMP_Text Score_Text;
    public TMP_Text MP_Text;
    public TMP_Text HP_Text;
    public TMP_Text lvl_Text;
    public TMP_Text exp_Text;
    public TMP_Text skillpoints_Text;
    public Image mp_Image;
    public Image hp_Image;
    public static float exp;
    public static int score = 0;
    public static int skillpoints;

    void Start()
    {

    }

    void Update()
    {
        Wizard player = Wizard.instance;
        int mp = (int) player.mp;
        int hp = player.hp;
        stats playerstats = player.stats;

        float max_mp = playerstats.max_mp;
        float max_hp = playerstats.max_hp;
        int lvl = playerstats.lvl;

        skillpoints = player.stats.skillpoints;
        exp = player.stats.exp;


        Score_Text.text = "Score: " + score;
        MP_Text.text = "MP: " + mp + "/" + max_mp;
        HP_Text.text = "HP: " + hp + "/" + max_hp;
        lvl_Text.text = "Level: " + lvl;
        exp_Text.text = "Exp: " + exp;
        skillpoints_Text.text = "Skillpoints: " + skillpoints;

        float manaPercentage = mp / max_mp;
        mp_Image.transform.localScale = new Vector3((manaPercentage*1.5f), 0.2f, 1);
    }
}