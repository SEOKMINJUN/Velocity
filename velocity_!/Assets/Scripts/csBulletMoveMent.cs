using UnityEngine;
using System.Collections;

public class csBulletMoveMent : MonoBehaviour {

    public float speed;
    public float damage;

	void LateUpdate () {
        transform.Translate(speed * Vector2.up * Time.deltaTime);
        Destroy(gameObject, 4f);
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
