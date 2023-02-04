using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pullon : MonoBehaviour
{

    public enum EstadoPullon {
    plantado,
    noPlantado
    }

    public GameObject origin;
    public GameObject destiny;
    public GameObject projectilePrefab;

    
    
    
    public EstadoPullon estado = EstadoPullon.noPlantado;
    public float contadorPlantado = 30; 


    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void TryThrow()
    {
        if (throwResistance > 0)
            throwResistance--;
        else
        {
            Throw();
            Destroy(gameObject);
        }

    }
    
    
    void Throw()
    {
        GameObject projectileGO = GameObject.Instantiate(projectilePrefab,transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.SetOrigin(origin);
        projectile.SetDestiny(destiny);
        projectile.GoToPosition(GetRandomPointFromOtherField(0.9f));
    }
    
    Vector3 GetRandomPointFromOtherField(float margin)
    {
        Bounds bounds = destiny.GetComponent<Collider2D>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
 
        
        return bounds.center + new Vector3(offsetX, offsetY, offsetZ) * margin;
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
        if(estado == EstadoPullon.noPlantado) {
            contadorPlantado -= Time.deltaTime;
            if(contadorPlantado <= 0) {
                estado = EstadoPullon.plantado;
            }
        }

        else if(estado == EstadoPullon.plantado) {
            GameObject ZonaCreciente = Instantiate(zonaCreciente, pullon.transform.position, gameObject.transform.rotation);
            x += 0.01f*Time.deltaTime;
            y += 0.01f*Time.deltaTime;
            z += 0.01f*Time.deltaTime;
            ZonaCreciente.transform.localScale = new Vector3(x, y, z);
        }

    }
}



