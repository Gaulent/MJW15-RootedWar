using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetos : MonoBehaviour
{
    private Collider2D _myCollider;
    public GameObject pullon;
    public GameObject otherField;

    public float timeSpawn = 1f;
    public float repeatTimeSpawn = 5f;

    void Start()
    {
        _myCollider = GetComponent<Collider2D>();
        InvokeRepeating("SpawnPullon", timeSpawn, repeatTimeSpawn); 
    }

    Vector3 GetRandomPoint(float margin)
    {
        Bounds bounds = _myCollider.bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
 
        
        return bounds.center + new Vector3(offsetX, offsetY, -1) * margin;
    }
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPullon() {
        
        Vector3 spawnPosition = GetRandomPoint(0.8f);
        GameObject Pullon = Instantiate(pullon, spawnPosition, gameObject.transform.rotation);

        Pullon.GetComponent<Pullon>().SetOrigin(gameObject);
        Pullon.GetComponent<Pullon>().SetDestiny(otherField);

    }
    
}


