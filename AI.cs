using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    //Zombie3
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            float distance = Vector3.Distance(transform.position,GameObject.Find("Player").transform.position);
            if (distance < 20f)
            {
            transform.LookAt(GameObject.Find("Player").gameObject.transform);
            anim.Play("Z_Walk3");
            transform.position += transform.forward * 0.01f;
            }
        }
        else
        {
            anim.Play("Z_Idle3");
        }
    }
}
