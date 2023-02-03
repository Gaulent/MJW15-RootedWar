using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToArrival = 2f;
    private float _startTime;
    private Vector3 _startPos;
    private Vector3 _finishPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _startPos = transform.position;
        Debug.Log(_startPos);
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.time - _startTime) < timeToArrival)
            transform.position = _startPos + (_finishPos - _startPos) * (Time.time - _startTime) / timeToArrival;
        else
            Destroy(gameObject);
    }

    public void GoToPosition(Vector3 targetPosition)
    {
        _finishPos = targetPosition;
        //Debug.Log(targetPosition);
    }
}