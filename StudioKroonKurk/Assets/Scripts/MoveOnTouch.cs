using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class MoveOnTouch : MonoBehaviour
{

	public float minInteractDistance;
    private NavMeshAgent agent;

	public LayerMask layersToHit;

	private Interactable prevInteractable;

    void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}

    public void MoveTowards(Vector3 position)
    {
        agent.SetDestination(position);
    }

    private void Update () {
		//if(GameManager.instance.IsGameStateOpen() && Input.touchCount == 1)
		//{
		//	RaycastHit hit;
		//	Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
		//	if(Physics.Raycast(ray, out hit))
		//	{
		//		if(hit.transform.tag == "Terrain")
		//		{
		//			agent.SetDestination(hit.point);
		//		}
		//	}
		//	return;
		//}
		if(GameManager.instance.IsGameStateOpen() && Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, layersToHit))
			{
				Debug.Log(hit.transform.name);

				if(prevInteractable != null)
				{
					prevInteractable.DropTarget();
					prevInteractable = null;
				}
				if(hit.transform.tag == "Terrain")
				{
					agent.SetDestination(hit.point);
				}
				if(hit.transform.GetComponent<Interactable>())
				{
					Interactable npc = hit.transform.GetComponent<Interactable>();
					Vector3 pos = npc.GetInteractPos();
					float dis = Vector3.Distance(transform.position, pos);

					npc.Interact(transform);
					agent.SetDestination(npc.GetInteractPos());
					
					prevInteractable = npc;
				}
			}
		}
	}
}