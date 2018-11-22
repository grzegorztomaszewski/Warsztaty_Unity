using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int HP = 5;
    public NavMeshAgent agent;
    public GameObject player;
    public GameObject particlePrefab;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<TankControler>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }	

	// Update is called once per frame
	void Update()
    {
		if(HP <=0)
        {
            Instantiate(particlePrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);           
        }

        agent.destination = player.transform.position;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);  //NISZCZENIE OBIEKTU
            HP = HP-25;                      //ZMNIEJSZANIE HP 
            Debug.Log("HP= " + HP);           //Debug, sprawdzenie
        }
    }
}
