using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 4)]
    public int enemyNumber = 3;
    public GameObject enemyPrefab;
    public List<GameObject> enemyList;
    // Start is called before the first frame update
    void Start()
    {
        BuildEnemyList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildEnemyList()
    {
        enemyList = new List<GameObject>();
        
        for (int i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
    }
}
