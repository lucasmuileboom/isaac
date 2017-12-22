using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	public void Update()
	{
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
	}
    

}
