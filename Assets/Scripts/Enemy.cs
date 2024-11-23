using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Data data;
     public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) > .75f)
        {
            agent.SetDestination(player.transform.position);

        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision with object on correct layer: " + collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            data.HP -= 50;
            Destroy(collision.gameObject);
            if(data.HP <= 0)
            {
                GameManager.Instance.AddScore();
                Destroy(gameObject);
            }
        }    

    }
}
