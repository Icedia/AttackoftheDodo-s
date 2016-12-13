using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    
    [System.Serializable]
    public class Wave 
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private EnemyMovement _movementSpeed;

	void Start ()
    {
        waveCountdown = timeBetweenWaves;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
               WaveCompleted();
            } else {
                return;
            }
        }
        if (waveCountdown <= 0 && !EnemyIsAlive())
        {
            StartCoroutine(SpawnWave(waves[nextWave]));
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
	}

    void WaveCompleted()
    {

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        //_movementSpeed.EnemySpeed += 2;


        if (nextWave + 1 > waves.Length - 1) 
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE LOOPING");
        }

        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true; 
    }
    IEnumerator SpawnWave(Wave _wave) 
    {
        waveCountdown = 3;
       // Debug.Log("Spawning Wave:" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++) 
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

            //Spawn

        state = SpawnState.WAITING;

        yield break;
    }
    void SpawnEnemy(Transform _enemy) 
    {

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);  
    }
}
