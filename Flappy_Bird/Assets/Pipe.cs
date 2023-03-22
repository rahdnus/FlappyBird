using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float speed;
    Vector3 despawnPoint;
    System.Action<GameObject> onDespawn;
    public void Init(System.Action<GameObject> _onDespawn,float _speed,Vector3 _despawnPoint)
    {
        this.despawnPoint = _despawnPoint;
        this.onDespawn = _onDespawn;
        this.speed = _speed;
    }
    void Update()
    {
        transform.position+=Vector3.left*speed*Time.deltaTime;    
        if(transform.position.x<despawnPoint.x)
        {
            onDespawn(gameObject);
            Destroy(gameObject,0.1f);
        }
    }
}
