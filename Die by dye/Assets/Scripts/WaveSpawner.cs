//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class WaveSpawner : MonoBehaviour {
//
//	public enum SpawnState {SPAWNING, WAITING, COUNTING};
//
//	[System.Serializable]
//	public class Wave
//	{
//		public string nameOfWave;
//		public Transform enemy;
//		public int count;
//		public float spawnRate;
//	}
//
//	public Wave[] waves;
//	private int nextWave = 0;
//
//	public float timeBtwWaves = 2.0f;
//	public float waveCountTime = 0;
//
//	private float searchCountDown = 1f;
//
//	private SpawnState state = SpawnState.COUNTING;
//
//	void Start(){
//		waveCountTime = timeBtwWaves;
//	
//	}
//
//	void Update(){
//
//		if(state == SpawnState.WAITING){
//			//Check if enemies are still alive
//			if (!EnemyIsAlive ()) {
//				//Begin a new round
//				Debug.Log("WAVE COMPLEATED");
//				return;
//			} 
//			else {
//				return;
//			}
//
//		}
//
//		if (waveCountTime <= 0) {
//			if (state != SpawnState.SPAWNING) {
//				//Start spawning waves
//				StartCoroutine(SpawnWave(waves[nextWave]));
//			}
//		} else {
//			waveCountTime -= Time.deltaTime;
//		}
//	
//	}
//
//	bool EnemyIsAlive(){
//		searchCountDown -= Time.deltaTime;
//		if(searchCountDown <= 0f){
//			
//			searchCountDown = 1f;
//			if (GameObject.FindGameObjectWithTag ("Enemy") == null) {
//				return false;
//			}	
//		}
//
//		return true;
//	}
//
//	IEnumerator SpawnWave(Wave _wave){
//
//		state = SpawnState.SPAWNING;
//
//		//Spawn
//		for (int i = 0; i < _wave.count; i++) {
//			spawnEnemy (_wave.enemy);
//			yield return new WaitForSeconds (1f/_wave.spawnRate);
//		
//		}
//
//		state = SpawnState.WAITING;
//	
//		yield break;
//	}
//
//	void spawnEnemy(Transform _enemy)
//	{
//		Debug.Log ("SPAWN ENEMY: " + _enemy.name);
//		Instantiate (_enemy, transform.position, Quaternion.identity);
//
//	}
//
//
//}
