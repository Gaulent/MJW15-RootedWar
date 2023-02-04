using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 10f;
    private Rigidbody2D _myRB;
    public Collider2D otherField;
    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _myRB = GetComponent<Rigidbody2D>();
        //Debug.Log(otherField.bounds.extents.y);
        
        //InvokeRepeating(nameof(Throw),1f,2f);
        
    }

    void Throw()
    {
        GameObject projectileGO = GameObject.Instantiate(projectilePrefab,transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.GoToPosition(GetRandomPointFromOtherField());
    }
    
    Vector3 GetRandomPointFromOtherField()
    {
        Bounds bounds = otherField.bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
 
        
        return bounds.center + new Vector3(offsetX, offsetY, offsetZ);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMoveAmount = Input.GetAxis("P"+playerNumber + "_Horizontal") * speed * Time.deltaTime;
        float yMoveAmount = Input.GetAxis("P"+playerNumber + "_Vertical") * speed * Time.deltaTime;
        //float xMoveAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yMoveAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += new Vector3(xMoveAmount, yMoveAmount, 0);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("P"+playerNumber + "_Fire"))
            Throw();
    }
    
}
