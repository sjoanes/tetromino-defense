using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Siege : MonoBehaviour {

	public int health;
	public Transform goal;

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}
}