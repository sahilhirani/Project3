﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	public GameObject asteroid;
	public Vector3 spawnValues;
	public int asteroidCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start() {
		StartCoroutine(spawnWaves ());
	}

	IEnumerator spawnWaves() {
		yield return new WaitForSeconds (startWait);

		Debug.Log (Time.time);

		while(true) {
			for (int i = 0; i < asteroidCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (waveWait * (1 / (i+1)));
			}
		}
	}
}


