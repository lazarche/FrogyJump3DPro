using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStartScript : MonoBehaviour
{
   public float dir = 1;
   public float speed = 3;
    Rigidbody2D rig;
    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed * dir, 0);
        transform.Rotate(new Vector3(0, speed * dir * 240 * Time.deltaTime, 0));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Danger") || col.gameObject.tag.Equals("Bound"))
            Destroy(this.gameObject);
    }
}
