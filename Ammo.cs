using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject bullet1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            if(Input.GetMouseButton(1))
            {
                GameObject obj = Instantiate(bullet1,transform.position + new Vector3(0, 1.4f,0) + (transform.forward*1f),Quaternion.identity);
                obj.GetComponent<BulletMove>().direction = transform.forward;
                Destroy(obj,5f);
                //Debug.Log("atirando");
            }
        }
        */
        if (Input.GetMouseButtonUp(0) && Input.GetMouseButton(1))
        {
            RaycastHit hit;
            float maxDistance = 300f;
            if (Physics.Raycast(transform.position+new Vector3(0,1f,0), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                maxDistance = hit.distance;
                Debug.Log(hit.collider.name);
            }

            GameObject obj = Instantiate(bullet1,transform.position + new Vector3(0, 1.4f,0) + (transform.forward*1f),Quaternion.identity);
            obj.GetComponent<BulletMove>().direction = transform.forward;
            obj.GetComponent<BulletMove>().maxDistance = maxDistance;
            obj.GetComponent<BulletMove>().initialPosition = obj.transform.position;
            Destroy(obj,5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + new Vector3(0,1f,0), transform.position+transform.forward*30f);
    }
}
