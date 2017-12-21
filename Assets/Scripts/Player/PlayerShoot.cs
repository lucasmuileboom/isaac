using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



public class PlayerShoot : MonoBehaviour
{
	[SerializeField]
	private GameObject bulletPrefab;
	[SerializeField]
	private Transform bulletSpawn;
	[SerializeField]
	private int speed;
	public float ShootTime;

    private bool Up;
    private bool Down;
    private bool Right;
    private bool Left;

	bool Shoot = true;

    Animator headAni;

    private void Start()
    {
        headAni = GetComponent<Animator>();
    }

    void Update()
	{
        
		if (Input.GetKey(KeyCode.UpArrow))
		{ 
            Up = true;
            Down = false;
            Left = false;
            Right = false;

            if (Up == true && Shoot == true)
            {
                headAni.Play("headup", -1, 0f);
            }
            else if (Shoot == true)
            {
                headAni.Play("headup");
            }
            Fire(1);
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
            Up = false;
            Down = false;
            Left = false;
            Right = true;

            if (Right == true && Shoot == true)
            {
                headAni.Play("headright", -1, 0f);
            }
            else if (Shoot == true)
            {
                headAni.Play("headright");
            }
                Fire(4);
            
        }

		if (Input.GetKey(KeyCode.LeftArrow))
		{
            Up = false;
            Down = false;
            Left = true;
            Right = false;

            if (Left == true && Shoot == true)
            {
                headAni.Play("headleft", -1, 0f);
            }
            else if (Shoot == true)
            {
                headAni.Play("headleft");
            }

            Fire(2);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
            Up = false;
            Down = true;
            Left = false;
            Right = false;

            if (Down == true && Shoot == true)
            {
                headAni.Play("headdown", -1, 0f);
            }
            else if(Shoot == true)
            {
                headAni.Play("headdown");
            }
            Fire(3);
		}
	}


	void Fire(int rot)
	{
		if (Shoot == true)
		{
			Shoot = false;
			StartCoroutine ("ShootTimer");
			var bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.Euler (0,0,rot*90));
			bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed;
		}
	}
    IEnumerator ShootTimer()
	{
		yield return new WaitForSeconds (ShootTime);
		Shoot = true;

	}
}