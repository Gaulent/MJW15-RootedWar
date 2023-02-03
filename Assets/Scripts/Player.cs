using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMoveAmount = Input.GetAxis("Horizontal" + playerNumber) * speed * Time.deltaTime;
        float yMoveAmount = Input.GetAxis("Vertical" + playerNumber) * speed * Time.deltaTime;
        //float xMoveAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yMoveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(xMoveAmount, yMoveAmount, 0);
    }
}
