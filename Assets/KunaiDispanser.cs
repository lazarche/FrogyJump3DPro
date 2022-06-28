using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiDispanser : MonoBehaviour
{
    
    [SerializeField] float time = 4;

    [SerializeField] GameObject kunai;

    // Update is called once per frame
    void Start(){
        InvokeRepeating("SpawnKunai", time, time);
    }

    public void SpawnKunai() {
        GameObject temp = Instantiate(kunai, transform.position + new Vector3(0,-0.5f,0), kunai.transform.rotation);
    }
}
