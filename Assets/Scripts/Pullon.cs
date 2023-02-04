using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pullon : MonoBehaviour
{

    public enum EstadoPullon {
    plantado,
    noPlantado
    } 

    public EstadoPullon estado = EstadoPullon.noPlantado;
    public float contadorPlantado = 30; 

    public GameObject pullon; 
    public GameObject zonaCreciente;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(estado == EstadoPullon.noPlantado) {
            contadorPlantado -= 0.1f;
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



