using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject TargetPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        float x = 15.6f*Random.value -7.8f;
        float y = 8f*Random.value -4f;
        Instantiate(TargetPrefab, new Vector3(x,y,0), Quaternion.identity);

        Destroy(gameObject);
        Hud.score += 1;

        Wizard player = Wizard.instance;
        player.stats.exp += 10;
        player.stats.GetXp();
        
    }

}