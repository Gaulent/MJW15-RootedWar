using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetos : MonoBehaviour
{

    public GameObject pullon;

    public float timeSpawn = 1;
    public float repeatTimeSpawn = 3;

    public Transform esquina1;
    public Transform esquina2;
    public Transform esquina3;
    public Transform esquina4;
    public Transform esquina5;
    public Transform esquina6;
    public Transform esquina7;
    public Transform esquina8;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPullon1", timeSpawn, repeatTimeSpawn);
        InvokeRepeating("SpawnPullon2", timeSpawn, repeatTimeSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPullon1() {

        Vector3 spawnPosition = new Vector3(0,0,0);
        spawnPosition = new Vector3(Random.Range(esquina1.position.x,esquina2.position.x),Random.Range(esquina2.position.y,esquina3.position.y),0);
        GameObject Pullon = Instantiate(pullon, spawnPosition, gameObject.transform.rotation);

    }

    public void SpawnPullon2() {

        Vector3 spawnPosition = new Vector3(0,0,0);
        spawnPosition = new Vector3(Random.Range(esquina5.position.x,esquina6.position.x),Random.Range(esquina6.position.y,esquina7.position.y),0);
        GameObject Pullon = Instantiate(pullon, spawnPosition, gameObject.transform.rotation);

    }
}
