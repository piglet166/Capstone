using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    
    public Transform target;
    public float smoothing;

    Vector3 offset;
    float lowestY;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

        lowestY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 targetPOS = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPOS, smoothing * Time.deltaTime);

        if (transform.position.y < lowestY) transform.position = new Vector3(transform.position.x, lowestY, transform.position.z);
    }
}
