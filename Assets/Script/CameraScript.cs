using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] bool vertical = true, horizontal = false;
    [SerializeField] GameObject target;
    [SerializeField] float spd;

    float yy, xx;
    private void Start()
    {
        yy = 0;
        xx = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (vertical)
            yy = target.transform.position.y;

        if (yy < 2)
            yy = 2;

        if (horizontal)
            xx = target.transform.position.x;

        transform.position = Vector3.Lerp(transform.position, new Vector3(xx, yy, 0), spd);
    }
}
