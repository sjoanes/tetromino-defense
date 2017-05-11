using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Siege : MonoBehaviour {

	public double health;
	public float speed;
	public Transform goal;

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.speed = this.speed;
		agent.destination = goal.position; 
	}
}