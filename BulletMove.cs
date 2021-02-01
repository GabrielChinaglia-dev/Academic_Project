using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 direction;
    public float spd = 0.1f;
    public Vector3 initialPosition;
    public float maxDistance = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=direction*spd;
        if (Vector3.Distance(transform.position,initialPosition) >= maxDistance)
        {
            Destroy(gameObject);
            Debug.Log("Destruido via raycast");
        }
    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log("Destruido via colisao com o objeto");
        Destroy(gameObject);
    }
}
