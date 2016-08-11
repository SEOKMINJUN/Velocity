using UnityEngine;
using System.Collections;

public class csEnemy : MonoBehaviour {

    public int damage;
    public int health;

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
	void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Bullet"))
            health -= 2; 
	}
};