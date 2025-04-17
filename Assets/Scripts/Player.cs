using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _speed = 20;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;


    private PlayerInputComponent _inputComponent;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 0);
        GameObject spawnManagerObj = GameObject.Find("Spawn_Manager");
        if (spawnManagerObj != null)
        {
            _spawnManager = spawnManagerObj.GetComponent<SpawnManager>();
        }
        else
        {
            Debug.LogError("Spawn_Manager GameObject not found!");
        }
        var trs = gameObject.transform;
        _inputComponent = new PlayerInputComponent(ref trs, _speed);
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        _inputComponent.Tick();

        if (_inputComponent.FirePressed)
        {
            FireLaser(); 
        }

        
    }

    void FireLaser()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            if (_isTripleShotActive)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }
        }
    }

    public void Damage()
    {
        _lives--;

        //check if dead
        //destroy us

        if(_lives < 1)
        {
            //communicate with spawnmanager

            _spawnManager.OnPlayerDeath();  //Find the GameObject. Then Get Component
            //Let them know to stop spawning
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }
}
