using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class WaveManager : MonoBehaviour
{
    public static WaveManager ins;
    public int currentWave;
    public List<WaveData> waves;
    public List<Transform> spawnPoints;
    [Space(15)]
    public bool spawnEnemies;
    public float spawnMaxOffset;
    [Space(15)]
    [SerializeField] List<EnemyController> spawnedEnemies;
    public bool isActiveWave;

    // Start is called before the first frame update
    void Start()
    {
        ins = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemies == true)
        {
            if(currentWave >= 0)
            {
                SpawnEnemies();
            }
            else
            {
                Debug.LogWarning("Invalid wave number = " + currentWave + "\n Starting from 0");
                currentWave = 0;
                SpawnEnemies();
            }
        }
    }

    void SpawnEnemies()
    {
        foreach (EnemyWaveData enemies in waves[currentWave].enemies)
        {
            int currentpoint = 0;
            for (int i = 0; i < enemies.count; i++)
            {
                GameObject temp = Instantiate(enemies.enemy);
                Vector2 randomPoint = new Vector2(Random.Range(-spawnMaxOffset, spawnMaxOffset), (Random.Range(-spawnMaxOffset, spawnMaxOffset)));
                temp.transform.position = spawnPoints[currentpoint].position + (Vector3)randomPoint;

                EnemyController enemy = temp.GetComponent<EnemyController>();
                spawnedEnemies.Add(enemy);
                enemy.ai.target = PlayerController.ins.transform;

                currentpoint++;
                if (currentpoint >= spawnPoints.Count)
                {
                    currentpoint = 0;
                }
            }
        }
        spawnEnemies = false;
    }
    public void CreateNextWave()
    {
        isActiveWave = true;
        currentWave++;

        if(currentWave >= 14)
        {
            MessageController.ins.ShowGameCompletedWindow();
            return;
        }

        SpawnEnemies();
    }

    public void RemoveEnemyFromList(EnemyController enemy)
    {
        spawnedEnemies.Remove(enemy);
        if(spawnedEnemies.Count <= 0)
        {
            isActiveWave = false;
            GameController.ins.ChangeState(ENUM_CurrentGameState.spawningRewards);

        }
    }
    public void ClearAllEnemies()
    {
        foreach(EnemyController enemy in spawnedEnemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
