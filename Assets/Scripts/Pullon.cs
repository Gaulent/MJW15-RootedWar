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
            Debug.Log("El pullon se ha plantao bro");
        }

    }
}



