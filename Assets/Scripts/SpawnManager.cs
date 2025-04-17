using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;
    
    private IEnumerator _spawnPowerRoutine;
    private IEnumerator _spawnEnemyRoutine;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        var posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
        var newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
        newEnemy.transform.SetParent(_enemyContainer.transform);
        yield return new WaitForSeconds(5.0f);
        _spawnEnemyRoutine = SpawnEnemyRoutine();
        StartCoroutine(_spawnEnemyRoutine);
    }

    IEnumerator SpawnPowerupRoutine()
    {
        Vector3 postToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
        Instantiate(_tripleShotPowerupPrefab, postToSpawn, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 8));
        _spawnPowerRoutine = SpawnEnemyRoutine();
        StartCoroutine(_spawnPowerRoutine);
    }

    public void OnPlayerDeath()
    {
        StopCoroutine(_spawnEnemyRoutine);
        StopCoroutine(_spawnPowerRoutine);
    }
}
