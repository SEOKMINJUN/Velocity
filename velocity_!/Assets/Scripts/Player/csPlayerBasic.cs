using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class csPlayerBasic : MonoBehaviour {

    public float maxHealth;
    public float health;
    public float speed;
    public Object bulletObject;
    public Text healthText;
    public Text gameoverText;
    public GameObject enemyCreate;


    void Start()
    {
        healthText.text = "Health : " + health;
        gameoverText.text = "";
    }

    void Update () {

        if (health <= 0)
            GameOver();
        if (maxHealth <= health)
            health = maxHealth;
        Move();
        Fire();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift))        // Dash
        {
            if (Input.GetKeyDown(KeyCode.W))//up                                    
                gameObject.transform.position += new Vector3(0f, speed*2, 0f);
            if (Input.GetKeyDown(KeyCode.S))//down
                gameObject.transform.position -= new Vector3(0f, speed*2, 0f);
            if (Input.GetKeyDown(KeyCode.D))//right
                gameObject.transform.position += new Vector3(speed*2, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.A))//left
                gameObject.transform.position -= new Vector3(speed*2, 0f, 0f);

           // Debug.Log("Pressed");
        }
        else                                        //defalut
        {
            if (Input.GetKeyDown(KeyCode.W))//up
                gameObject.transform.position += new Vector3(0f, speed, 0f);
            if (Input.GetKeyDown(KeyCode.S))//down
                gameObject.transform.position -= new Vector3(0f, speed, 0f);
            if (Input.GetKeyDown(KeyCode.D))//right
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            if (Input.GetKeyDown(KeyCode.A))//left
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
           // Debug.Log("not Pressed");
        }
    }
    
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject instance = (GameObject)Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
            instance.transform.Rotate(new Vector3(0f, 0f, 0f));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject instance = (GameObject)Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
            instance.transform.Rotate(new Vector3(0f, 0f, 180f));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject instance = (GameObject)Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
            instance.transform.Rotate(new Vector3(0f, 0f, 270f));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject instance = (GameObject)Instantiate(bulletObject, gameObject.transform.position, Quaternion.identity);
            instance.transform.Rotate(new Vector3(0f, 0f, 90f));
        }
    }

    void Damage(int damage)
    {
        health -= (float)damage;
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Enemy"))
        {
            Damage(col.gameObject.GetComponent<csEnemy>().damage);
            SetHealthText();

        }
        if(col.CompareTag("Health"))
        {
            Damage(-(col.gameObject.GetComponent<csHealthFull>().health));
            SetHealthText();
        }
    }
    void SetHealthText()
    {
        healthText.text = "Health : " + health;
    }

    void GameOver()
    { 
        int time = (int)Time.fixedTime;
        
        gameoverText.text = "Game Over! \nYour Time : " + time.ToString() + "sec.";
        Destroy(enemyCreate);
        gameObject.transform.Translate(new Vector3(10000f, 10000f, 0f));
        healthText.text = "Health : 0";
        Damage(-10);
    }
}
