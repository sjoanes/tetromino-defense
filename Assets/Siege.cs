using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Siege : MonoBehaviour {

	public double health;
	public Transform goal;

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.speed = 0.5f;
		agent.destination = goal.position; 
	}
}