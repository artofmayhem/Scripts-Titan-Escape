using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyPrefab;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   IEnumerator SpawnEnemy()
    {
        //  while player is alive
      while (_stopSpawning == false)
      {
          //  spawn enemy
          Vector3 posToSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
          GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
          newEnemy.transform.parent = _enemyContainer.transform;
          yield return new WaitForSeconds(2.3f);
      }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
