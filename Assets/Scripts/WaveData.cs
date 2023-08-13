using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaveData
{
    public GameObject enemy;
    public int count;
}

[CreateAssetMenu(fileName ="Wave_",menuName ="Custom/Wave")]
public class WaveData : ScriptableObject
{
    [SerializeField]
    public List<EnemyWaveData> enemies;
}
