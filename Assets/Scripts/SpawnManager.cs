using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

	void Start () 
    {
        StartCoroutine(SpawnRoutine());
	}
	
	void Update () 
    {
		
	}

    IEnumerator SpawnRoutine()
    {

        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(9f, -9f), 6.4f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
