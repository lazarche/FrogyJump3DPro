using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDispenserScript : MonoBehaviour
{
    [SerializeField] float dir = 1;
    [SerializeField] float speed = 4;
    [SerializeField] float time = 4;

    [SerializeField] GameObject star;

    // Update is called once per frame
    void Start(){
        InvokeRepeating("SpawnStar", time, time);
    }

    public void SpawnStar() {
        GameObject temp = Instantiate(star, transform.position + new Vector3(dir,0,0), star.transform.rotation);
        temp.GetComponent<NinjaStartScript>().dir = dir;
        temp.GetComponent<NinjaStartScript>().speed = speed;
        Debug.Log("Evo ga");
    }
}
