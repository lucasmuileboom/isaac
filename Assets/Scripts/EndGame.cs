using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public GameObject Player;
    [SerializeField]
    int EndTime;

    private PlayerHealth health;

    void Start()
    {
        health = Player.GetComponent<PlayerHealth>();
    }

    void Update() {
        if(GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            StartCoroutine("EndTimer");
            
        }

        if (health.Health <= 0)
        {
            StartCoroutine("EndTimer");
        }
	}

    IEnumerator EndTimer()
    {
        print("Timer Start");
        yield return new WaitForSeconds(EndTime);
        SceneManager.LoadScene(0);
    }
    
}
