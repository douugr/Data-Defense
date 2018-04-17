using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 10f;
	private float countdown = 5f;
	private int waveIndex = 0;

	public Text waveCountdownText;


	void Update()
	{
		if (countdown <= 0f) 
		{
			StartCoroutine(SpawnWave ());
			countdown = timeBetweenWaves;
		
		}

		countdown -= Time.deltaTime;

		waveCountdownText.text = countdown.ToString("0.0");
	}
	IEnumerator SpawnWave()
	{
		waveIndex++;
		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds (0.5f);
		}

	}
	void SpawnEnemy()
	{
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
		
}
