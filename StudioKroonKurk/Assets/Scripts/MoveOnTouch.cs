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

	public Transform cursor;
	private Vector3 movePos;


    void Start ()
	{
        agent = gameObject.GetComponent<NavMeshAgent>();
		movePos = transform.position;
	}

    public void MoveTowards(Vector3 position)
    {
		if(!agent.enabled)
			return;
        agent.SetDestination(position);
		movePos = position;
		cursor.transform.position = new Vector3(movePos.x, 0, movePos.z);
		cursor.gameObject.SetActive(true);
	}

    private void Update ()
	{
		float disToPlayerCursor = Vector3.Distance(cursor.position, transform.position);
		
		if(disToPlayerCursor < 1f)
			cursor.gameObject.SetActive(false);
			
		if(GameManager.instance.IsGameStateOpen() && Input.GetMouseButton(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, layersToHit))
			{
				if(prevInteractable != null)
				{
					prevInteractable.DropTarget();
					prevInteractable = null;
				}
				if(hit.transform.tag == "Terrain")
				{
					MoveTowards(hit.point);
				}
				if(hit.transform.GetComponent<Interactable>())
				{
					Interactable npc = hit.transform.GetComponent<Interactable>();
					Vector3 pos = npc.GetInteractPos();
					float dis = Vector3.Distance(transform.position, pos);

					npc.Interact(transform);
					MoveTowards(pos);
					prevInteractable = npc;
				}
			}
		}
	}
}