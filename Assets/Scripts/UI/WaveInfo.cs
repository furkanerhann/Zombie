using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveInfo : MonoBehaviour
{
    public Text currentWaveText;
    public Text enemiesLeftText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentWaveText.text = "Current Wave: " + (EnemySpawner.currentWave + 1).ToString();
        enemiesLeftText.text = "Enemies Left: " + EnemySpawner.zombieCount;
    }
    void UpdateZombieCount()
    {
        EnemySpawner.zombieCount--;
    }
}
