using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 dir;
    TrajectoryController tc;
    Rigidbody2D rig;

    bool ledge = false;

    Vector3 target;

    [SerializeField] float stronk = 6;
    [SerializeField] GameObject joystick, ledgeCheck, ledgeWallCheck;
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

        if(!ledge)
        if(CheckLedge()) {
            ledge = true;
            target = ledgeWallCheck.transform.position;
        }

        if(ledge) {
            transform.position = Vector3.MoveTowards(transform.position, target, 10f * Time.deltaTime);
            rig.velocity = rig.velocity/4;
            if(Vector3.Distance(transform.position, target) < 0.1f)
                ledge = false;
        }
            
    }

    private void LaunchFrog()
    {
        rig.velocity = dir;
        MoveCheckers();
    }

    private bool CheckLedge() {
        bool ledge = ledgeCheck.GetComponent<ChildCollisionScript>().getCollision();
        bool ledgewall = ledgeWallCheck.GetComponent<ChildCollisionScript>().getCollision();
        if(ledge && !ledgewall)
            return true;
            else 
            return false;
    }

    private void MoveCheckers() {
        var temp =  ledgeCheck.transform.localPosition;
        var temp1 = ledgeWallCheck.transform.localPosition;
        if(Mathf.Sign(temp.x) != Mathf.Sign(rig.velocity.x)) {
            temp.x *= -1;
            temp1.x *= -1;
        }
            
        ledgeWallCheck.transform.localPosition = temp1;
        ledgeCheck.transform.localPosition = temp;
    }

    private Vector2 getInput()
    {
        return joystick.GetComponent<FloatingJoystick>().Direction;
    }
}
