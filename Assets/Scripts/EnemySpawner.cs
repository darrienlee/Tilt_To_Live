using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float respawnTime; // = 1.0f;
    private Vector2 screenBounds;
    private Transform player; // player reference

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(spawner());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(EnemyPrefab) as GameObject; // instantiate enemy
        //a.transform.position = new Vector2(randomNum(-screenBounds.x, screenBounds.x), randomNum(-screenBounds.y, screenBounds.y)); // manipulate enemy spawn location
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y)); // manipulate enemy spawn location
    }

    IEnumerator spawner()
    {
        player = GameObject.FindWithTag("Player").transform;
        while (player != null) //true) // can replace with boolean while(gameStart)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    /*private float randomNum(float minimum, float maximum)
    {
        randomNum random = new randomNum();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }*/
    

}
