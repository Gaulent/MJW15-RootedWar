using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Pullon : MonoBehaviour
{

    public enum EstadoPullon {
    plantado,
    noPlantado
    }

    public GameObject origin;
    public GameObject destiny;
    public GameObject projectilePrefab;
    public Sprite aliveSprite;
    public Sprite frozenSprite;
    private SpriteRenderer _mySR;
    
    
    
    public EstadoPullon estado = EstadoPullon.noPlantado;
    public float contadorPlantado = 3f;

    public int throwResistance = 3;


    public void SetOrigin(GameObject go)
    {
        origin = go;
    }

    public bool GetStatusThrowable()
    {
        return (estado == EstadoPullon.noPlantado);
    }
    
    public void SetDestiny(GameObject go)
    {
        destiny = go;
    }

    // Start is called before the first frame update
    void Start()
    {
        _mySR = GetComponent<SpriteRenderer>();

    }

    public bool TryThrow()
    {
        if (throwResistance > 0)
        {
            throwResistance--;
            return false;
        }
        Throw();

        Destroy(gameObject);
        return true;
    }
    
    
    void Throw()
    {
        GameObject projectileGO = GameObject.Instantiate(projectilePrefab,transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.SetOrigin(origin);
        projectile.SetDestiny(destiny);
        projectile.GoToPosition(GetRandomPointFromOtherField(0.8f));
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
                _mySR.sprite = frozenSprite;
                origin.GetComponent<Field>().SpawnAoE(transform.position);
            }
        }

        else if(estado == EstadoPullon.plantado)
        {

        }

    }



}