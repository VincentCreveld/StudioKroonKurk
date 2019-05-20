using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerManager : MonoBehaviour, IInteracter
{
	public List<Vector3> pathPoints = new List<Vector3>();
	private List<GameObject> cornerObjects = new List<GameObject>();
	public float minInteractDistance;
    private NavMeshAgent agent;

	public LayerMask layersToHit;

	private Interactable prevInteractable;

	public Transform cursor;
	private Vector3 movePos;

	public Animator anim;

	public LineRenderer ln;

    private void Start ()
	{
        agent = gameObject.GetComponent<NavMeshAgent>();
		movePos = transform.position;
	}

    public void MoveTowards(Vector3 position)
    {
		if(!agent.enabled)
			return;

		agent.isStopped = false;
        agent.SetDestination(position);
		movePos = position;
		cursor.transform.position = new Vector3(movePos.x, movePos.y, movePos.z);
		cursor.gameObject.SetActive(true);
		ln.enabled = true;
	}

    private void Update ()
	{
		if(agent != null)
		{
			pathPoints.Clear();
			pathPoints.AddRange(agent.path.corners);

			ln.positionCount = pathPoints.Count;
			//Vector3 pos = transform.position + Vector3.up;
			//ln.SetPosition(0, pos);

			for(int i = 0; i < pathPoints.Count; i++)
			{
				ln.SetPosition(i, pathPoints[i] + Vector3.up);
			}
		}

		float disToPlayerCursor = Vector3.Distance(new Vector3(cursor.position.x, transform.position.y, cursor.position.z), transform.position);

		if(disToPlayerCursor < 1f || agent.velocity.magnitude <= 0.5f)
			StopMoving();

        if (agent.velocity.magnitude >= 1.5f)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        if (GameManager.instance.IsGameStateOpen() && Input.GetMouseButton(0) && Input.touchCount < 2)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, layersToHit))
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

					npc.Interact(this);
					MoveTowards(pos);
					prevInteractable = npc;
				}
			}
		}
	}

	private void StopMoving()
	{
		cursor.gameObject.SetActive(false);
		if(agent.enabled)
			agent.isStopped = true;
		anim.SetBool("IsWalking", false);
		ln.enabled = false;
	}

	public Vector3 GetPos()
	{
		return transform.position;
	}

	public void LookAtTarget(Vector3 targ)
	{
		IEnumerator e = LookAtTargLoop(targ);
		StartCoroutine(e);
	}

	private IEnumerator LookAtTargLoop(Vector3 targ)
	{
		agent.updateRotation = false;

		Quaternion startRot = transform.rotation;

		float totalTime = 0.5f;
		float curTime = 0;
		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;
			float step = curTime / totalTime;

			Vector3 targDir = targ - transform.position;
			targDir.y = 0;
			Quaternion targRotation = Quaternion.LookRotation(targDir);

			transform.rotation = Quaternion.Lerp(startRot, targRotation, step);

			//Quaternion.Slerp(transform.rotation, targRotation, curTime / totalTime);
			if(curTime > totalTime)
				break;
		}
		agent.updateRotation = true;
	}

	private IEnumerator LookAtTargLoop(Vector3 targ, bool t)
	{
		agent.updateRotation = false;
		transform.LookAt(targ);
		transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
		yield return new WaitForEndOfFrame();
		agent.updateRotation = true;
	}
}