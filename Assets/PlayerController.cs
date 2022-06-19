using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 dir;
    TrajectoryController tc;
    Rigidbody2D rig;

    [SerializeField] float stronk = 5;
    [SerializeField] GameObject joystick;
    // Start is called before the first frame update
    void Start()
    {
        tc = GetComponent<TrajectoryController>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && rig.velocity == new Vector2())
            LaunchFrog();

        dir = getInput() * stronk;
        tc.velocity = dir;
    }

    private void LaunchFrog()
    {
        Debug.Log(dir);
        rig.velocity = dir;
    }

    private Vector2 getInput()
    {
        return joystick.GetComponent<FloatingJoystick>().Direction;
    }
}
