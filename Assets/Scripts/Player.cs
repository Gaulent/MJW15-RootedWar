using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    //[SerializeField] private ParticleSystem particulas;
    public int playerNumber = 1;
    public float speed = 10f;
    private Rigidbody2D _myRB;
    public Collider2D otherField;
    public GameObject projectilePrefab;
    public Collider2D _myCollider;
    List <GameObject> currentCollisions = new List <GameObject> ();
    
    // Start is called before the first frame update
    void Start()
    {
        _myRB = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<Collider2D>();
        //Debug.Log(otherField.bounds.extents.y);

        //InvokeRepeating(nameof(Throw),1f,2f);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        float xMoveAmount = Input.GetAxis("P"+playerNumber + "_Horizontal") * speed * Time.deltaTime;
        float yMoveAmount = Input.GetAxis("P"+playerNumber + "_Vertical") * speed * Time.deltaTime;
        //float xMoveAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yMoveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(xMoveAmount, yMoveAmount, 0);
        //particulas.Play();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("P" + playerNumber + "_Fire"))
        {

            foreach (GameObject gObject in currentCollisions)
            {
                if (gObject.layer == LayerMask.NameToLayer("Pullon") )
                {
                    if (gObject.GetComponent<Pullon>().GetStatusThrowable())
                    {
                        gObject.GetComponent<Pullon>().TryThrow();
                        break;
                    }
                }
            }
        }

    }
/*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (tryThrow)
        {
            tryThrow = false;
            //Throw();

            //Debug.Log("Hola");

            //if (other.gameObject.layer == LayerMask.NameToLayer("Pullon"))
            //{
                Debug.Log(other.gameObject.layer);
                other.GetComponent<Pullon>().TryThrow();
            //}

        }
    
        

    }
*/
/*
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject);
    }*/
    
    
    
    private void OnTriggerEnter2D (Collider2D col) {
 
        // Add the GameObject collided with to the list.
        currentCollisions.Add (col.gameObject);
 
        // Print the entire list to the console.
        //foreach (GameObject gObject in currentCollisions) {
            //print (gObject.name);
        //}
    }
 
    private void OnTriggerExit2D (Collider2D col) {
 
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (col.gameObject);
 
        // Print the entire list to the console.
        //foreach (GameObject gObject in currentCollisions) {
        //    print (gObject.name);
        //}
    }
}
