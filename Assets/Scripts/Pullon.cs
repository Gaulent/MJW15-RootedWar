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
    public float contadorPlantado = 3f;

    public int throwResistance = 3;


    public void SetOrigin(GameObject go)
    {
        origin = go;
    }
    
    public void SetDestiny(GameObject go)
    {
        destiny = go;
    }

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
        }

    }
    
    
    void Throw()
    {
        GameObject projectileGO = GameObject.Instantiate(projectilePrefab,transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.GoToPosition(GetRandomPointFromOtherField());
    }
    
    Vector3 GetRandomPointFromOtherField()
    {
        Bounds bounds = destiny.GetComponent<Collider2D>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
 
        
        return bounds.center + new Vector3(offsetX, offsetY, offsetZ);
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
            //Debug.Log("El pullon se ha plantao bro");
        }

    }
}



