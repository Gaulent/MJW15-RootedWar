using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Field : MonoBehaviour
{
    private SpriteRenderer _mySR;
    public GameObject checkPointPrefab;
    private Collider2D _myCollider;
    private CircleCollider2D[] hijos;
    public GameObject zonaCrecientePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _mySR = GetComponent<SpriteRenderer>();
        _myCollider = GetComponent<Collider2D>();

        CreateMesh();

        hijos = GetComponentsInChildren<CircleCollider2D>();
        

        
    }

    // Update is called once per frame
    void Update()
    {

        int count = 0;

        for (int i = 0; i < hijos.Length; i++)
        {
            if(hijos[i].IsTouchingLayers(LayerMask.GetMask("Cover")))
                count++;
        }
        
        //Debug.Log(count);
    }
    
    
    void CreateMesh()
    {
        Bounds bounds = _myCollider.bounds;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float offsetX = bounds.extents.x * 2 * i / 9 - bounds.extents.x;
                float offsetY = bounds.extents.y * 2 * j / 9 - bounds.extents.y;
                Instantiate(checkPointPrefab, bounds.center + new Vector3(offsetX, offsetY, 0), quaternion.identity,
                    transform);
            }
        }
        
    }
    
    public void SpawnAoE(Vector3 pos)
    {
        Instantiate(zonaCrecientePrefab, pos, quaternion.identity);
    }
}
