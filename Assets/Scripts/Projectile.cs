using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;

public class Projectile : MonoBehaviour
{
    public float timeToArrival = 2f;
    private float _startTime;
    private Vector3 _startPos;
    private Vector3 _finishPos;
    public GameObject shadowPrefab;
    private Transform shadow;
    public GameObject destiny;
    public GameObject origin;
    public GameObject pullonPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        _startTime = Time.time;
        _startPos = transform.position;
        //Debug.Log(_startPos);
        shadow = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - _startTime) < timeToArrival)
        {
            transform.position = Parabola(_startPos, _finishPos, 3f, (Time.time - _startTime) / timeToArrival);
            shadow.position = _startPos + (_finishPos - _startPos) * (Time.time - _startTime) / timeToArrival;
        }
        else
        {
            GameObject _newPullon = Instantiate(pullonPrefab, transform.position, quaternion.identity);

            _newPullon.GetComponent<Pullon>().SetDestiny(origin);
            _newPullon.GetComponent<Pullon>().SetOrigin(destiny);
            Invoke(nameof(delayedDeletion), 0.3f);
            
        }
    }

    void delayedDeletion()
    {
        Destroy(gameObject);
    }
    
    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }
    


    public void GoToPosition(Vector3 targetPosition)
    {
        _finishPos = targetPosition;
        //Debug.Log(targetPosition);
    }
    
    
    public void SetOrigin(GameObject go)
    {
        origin = go;
    }
    
    public void SetDestiny(GameObject go)
    {
        destiny = go;
    }
}