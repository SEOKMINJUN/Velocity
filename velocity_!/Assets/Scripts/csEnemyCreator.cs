using UnityEngine;
using System.Collections;

public class csEnemyCreator : MonoBehaviour {

    public GameObject[] Enemy;
    public int enemyRange;
    public float delay;
    private int x;
    private int y;

    void Start()
    {
        StartCoroutine("CreateEnemyForDelay", delay);
    }

    IEnumerator CreateEnemyForDelay(float delayTime)
    {
        CreateEnemy();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine("CreateEnemyForDelay",delay);
    }

    void CreateEnemy()
    {
        y = (int)Random.Range(-enemyRange, enemyRange);
        x = (int)Random.Range(-enemyRange, enemyRange);
        Instantiate(Enemy[0], new Vector3(x, y, 0f), Quaternion.identity);
        
    }
}
