using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject enemy;

	private const int MAX_LEVEL = 5;
	private float[] health = new float[MAX_LEVEL] {50f, 150f, 500f, 600f, 500f};
	private float[] speed = new float[MAX_LEVEL] {4f, 0.5f, 0.5f, 0.5f, 1.5f};


	// Use this for initialization
	IEnumerator Start () {
		for (int level = 0; level < MAX_LEVEL; level++) {
			for (int i = 0; i < 10; i++) {
				GameObject e = GameObject.Instantiate<GameObject>(enemy);
				Siege s = (Siege)e.GetComponent ("Siege");
				s.health = health[level];
				s.speed = speed[level];

				yield return StartCoroutine(Wait(2));
			}

			yield return StartCoroutine(Wait(10));
		}
	}
	
	IEnumerator Wait(int seconds) {
		yield return new WaitForSeconds(seconds);
	}
}
