using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	IEnumerator Start () {
		for (int i = 0; i < 10; i++) {
			GameObject.Instantiate<GameObject>(enemy);
			yield return StartCoroutine(Wait());
		}
	}
	
	IEnumerator Wait() {
		yield return new WaitForSeconds(1);
	}
}
