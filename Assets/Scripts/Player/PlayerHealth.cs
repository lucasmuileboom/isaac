using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{ 
    public int Health;
    [SerializeField]
    private int TimerDur;

    [SerializeField]
    GameObject Heart1;
    [SerializeField]
    GameObject Heart2;
    [SerializeField]
    GameObject Heart3;
    [SerializeField]
    GameObject Heart4;
    [SerializeField]
    GameObject Heart5;
    [SerializeField]
    GameObject Heart6;

    private bool Invincible = false;

    private void Start()
    {
        Health = 6;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Invincible == false)
        {
            //Start the Couroutine
            Invincible = true;
            StartCoroutine("HitTimer");
            
            Health--;
        }

        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        switch (Health)
        {
            case 5:
                Destroy(Heart6);
                break;
            case 4:
                Destroy(Heart5);
                break;
            case 3:
                Destroy(Heart4);
                break;
            case 2:
                Destroy(Heart3);
                break;
            case 1:
                Destroy(Heart2);
                break;
            case 0:
                Destroy(Heart1);
                break;
        }
    }

    //Couroutine Timer for invincibility
    IEnumerator HitTimer()
    {
        if (Invincible == false)
        {
            Invincible = true;

            yield return new WaitForSeconds(TimerDur);
            Invincible = false;
        }

        else
        {
            yield return new WaitForSeconds(TimerDur);
            Invincible = false;
        }
    }
}
