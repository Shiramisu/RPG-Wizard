using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public static Wizard instance;
    public GameObject fireballPrefab;
    private Vector3 lastMovement = Vector3.right;
    public static Vector3 movement;
    public float timer = 0;
    private Animator animator;
    public stats stats;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stats = new stats();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movement = new Vector3(0,0,0);
        if (Input.GetKey("w"))
        {
            movement = movement + new Vector3(0f,1f,0f);
        }
        if (Input.GetKey("s"))
        {
            movement = movement + new Vector3(0f,-1f,0f);
        }
        if (Input.GetKey("a"))
        {
            movement = movement + new Vector3(-1f,0,0f);
            transform.rotation = Quaternion.Euler(0f,180f,0f);
        }
        if (Input.GetKey("d"))
        {
            movement = movement + new Vector3(1f,0,0f);
            transform.rotation = Quaternion.Euler(0f,0f,0f);
        }

        movement = movement.normalized;

        transform.position = transform.position + movement * Time.deltaTime * stats.speed;

        if (movement.y != 0 || movement.x != 0)
        {
            lastMovement=movement;
            animator.SetBool("Walking", true);
        } else animator.SetBool("Walking", false);
        

        //GetKomponent<Fireball>().
        // Casting
        stats.castTime += Time.deltaTime;
        
        if (stats.castTime > 1 && Input.GetKeyDown(KeyCode.Space) && stats.mp != 0)
        {
            GameObject obj = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            obj.GetComponent<Fireball>().direction = lastMovement;
            stats.castTime = 0;
            animator.SetBool("Attack", true);

            stats.mp -= 10;
            Hud.mp = stats.mp;
            
        } else if(Input.GetKeyUp(KeyCode.Space)) animator.SetBool("Attack", false);

        timer += Time.deltaTime;

        if (movement == Vector3.zero){
            if(stats.mp != stats.max_mp){
                if (timer > 3){
                stats.mp += stats.manaReg;
                Hud.mp = stats.mp;
                timer = 0;
                }
            }
        }

    
    }
}