using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bug : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent nma;
    // Start is called before the first frame update
    void Start()
    {
        this.nma = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.nma.enabled)
        {
            this.nma.SetDestination(this.target.position);
        }
    }
}
