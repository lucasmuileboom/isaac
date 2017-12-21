using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	int damage = 4;
    private Vector2 startposision;
    [SerializeField] private GameObject bulletanim;
    void Start()
    {
        startposision = transform.position;
    }
	void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.gameObject.tag == "Enemy")
		{
			coll.gameObject.GetComponent<EnemyHealth> ().Takedamage(damage, startposision);
            Instantiate(bulletanim, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(this.gameObject);
        }

		if (coll.gameObject.tag == "Wall") 
		{
            Instantiate(bulletanim, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy (this.gameObject);
		}
	}
}