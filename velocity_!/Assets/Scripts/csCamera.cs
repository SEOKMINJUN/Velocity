using UnityEngine;
using System.Collections;

public class csCamera : MonoBehaviour {

    public GameObject player;

	void Update () {
        if (GameObject.Find("Player") != null)
            gameObject.transform.position = player.transform.position + new Vector3(0f, 0f, -10f);
	}
}
