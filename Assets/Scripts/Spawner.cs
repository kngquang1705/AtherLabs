using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",3f ,1f);
    }
    
    private void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab,transform.position, Quaternion.identity);
        enemy.name = "Enemy";
        enemy.GetComponent<Enemy>().player = player;
    }
}
