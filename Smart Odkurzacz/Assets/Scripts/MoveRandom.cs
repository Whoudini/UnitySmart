using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandom : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float newPathTimer;
    Vector3 target;
    bool inCoroutine;
    bool validPath;
    public Transform obj;
    LineRenderer ln;
   

     void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        ln = gameObject.GetComponent<LineRenderer>();
        
    }

    void Update()
    {
        if (!inCoroutine )
        {
            StartCoroutine(Do());
        }   
    }
    Vector3 getRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator Do()
    {
        inCoroutine = true;
        yield return new WaitForSeconds(newPathTimer);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);
        if (!validPath) Debug.Log(" Found Invalid path moverandom.cs");
        
            while (!validPath)
            {
                yield return new WaitForSeconds(0.01f);
                GetNewPath();
                validPath = navMeshAgent.CalculatePath(target, path);
                ln.SetPosition(0, target);
                ln.SetPosition(1, obj.position);

            }
        inCoroutine = false;

    }

    void GetNewPath()
    {
        target = getRandomPosition();
        navMeshAgent.SetDestination(target);
        
    }
    void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
