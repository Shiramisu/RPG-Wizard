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
    public static int hp;
    public static int mp;
    public static int score = 0;

    void Start()
    {
        hp = 100;
        mp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score: " + score;
        MP_Text.text = "MP: " + mp;
        HP_Text.text = "HP: "+ hp;
    }
}
