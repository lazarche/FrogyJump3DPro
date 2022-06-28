using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag.Equals("Wall") || col.gameObject.tag.Equals("Danger") || col.gameObject.tag.Equals("Bound"))
            Destroy(this.gameObject);
    }
}
