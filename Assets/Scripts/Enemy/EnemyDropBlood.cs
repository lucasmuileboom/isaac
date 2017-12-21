using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropBlood : MonoBehaviour
{
    [SerializeField] private GameObject[] blood;
    [SerializeField] private GameObject[] bloodondead;
    //[SerializeField] private GameObject[] bloodonhit;//??
    [SerializeField] private GameObject[] Bodypartondead;
    [SerializeField] private float bloodtimer;
    private float timer = 0;
    [SerializeField]private float dropdistance;
    //mischien rotation ook random van het bloed

    void Start ()
    {
        timer = bloodtimer;
    }
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            DropBlood();
            timer = bloodtimer;
        }
    }
    public void DropBloodOnDeath()
    {
        Instantiate(bloodondead[Random.Range(0, bloodondead.Length)], new Vector3(transform.position.x,transform.position.y,-0.5f), Quaternion.Euler(0, 0, 0));
        //GameObject bodypart = Instantiate(Bodypartondead[Random.Range(0, Bodypartondead.Length)], transform.position,Quaternion.Euler(0, 0, 0));
        //bodypart.GetComponent<Rigidbody2D>().AddForce();//drop bone
    }
    public void DropBloodOnHit()
    {
        //weet nog niet hoe het bloed hier moet
    }
    private void DropBlood()
    {
        Instantiate(blood[Random.Range(0, blood.Length)],transform.position, Quaternion.Euler(0,0,0));//moet nog het bot laten dropen       
    }
}
