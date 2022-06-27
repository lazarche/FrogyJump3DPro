using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 dir;
    TrajectoryController tc;
    Rigidbody2D rig;

    GameObject ledge = null;
    bool canGrab = true, dead = false;

    Vector3 target;

    [SerializeField] float stronk = 6;
    [SerializeField] GameObject joystick, ledgeCheck, ledgeWallCheck, model;
    [SerializeField] Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        tc = GetComponent<TrajectoryController>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mrtav je hihi
        if (dead)
            return;


        if(rig.velocity == new Vector2())
            SetAnimator(false);
            else
            SetAnimator(true);

        CheckForLaunch();

    
        if(ledge == null && canGrab) {
            GameObject t = CheckLedge();
            if(t != null) {
                ledge = t;
                float fix = (transform.localScale.y - t.transform.localScale.y) /2;
                target = new Vector3(transform.position.x, ledge.transform.position.y, transform.position.z) - new Vector3(0,fix,0);
            }
        }

        if(ledge) {
            transform.position = Vector3.Lerp(transform.position, target, 0.5f);
            rig.velocity = new Vector3();
            CheckForLaunch();
        }

        dir = getInput() * stronk;
        tc.velocity = dir;
        
        // Stari penj
        // if(!ledge)
        // if(CheckLedge()) {
        //     ledge = true;
        //     target = ledgeWallCheck.transform.position + new Vector3(0,0.4f,0);
        //     Debug.Log(target);
        // }

        // if(ledge) {
        //     // rig.velocity = rig.velocity * 0;
        //     // transform.position = Vector3.MoveTowards(transform.position, target, 15f * Time.deltaTime);
        //     Vector3 dir = (this.transform.position - target).normalized;
        //     rig.velocity = dir * -10f;
        //     if(target.y > transform.position.y)
        //         rig.velocity = rig.velocity + Vector2.up * 10;

        //     Debug.DrawRay(transform.position, dir);

        //     if(Vector3.Distance(transform.position, target) < 0.1f) {
        //         ledge = false;
        //         rig.velocity = rig.velocity * 0;
        //     }
                
        // }
            
    }

    void ResetGrab() {
        canGrab = true;
    }

    private void CheckForLaunch() {
        if (Input.GetMouseButtonUp(0) && rig.velocity == new Vector2()) {
            LaunchFrog();
            ledge = null;
            canGrab = false;
            Invoke("ResetGrab", 0.25f);
            Debug.Log(rig.velocity);
            Debug.Log(dir);
        }
    }

    private void LaunchFrog()
    {
        rig.velocity = dir;
        MoveCheckers();
    }

    private GameObject CheckLedge() {
        bool ledge = ledgeCheck.GetComponent<ChildCollisionScript>().getCollision() != null;
        bool ledgewall = ledgeWallCheck.GetComponent<ChildCollisionScript>().getCollision() != null;
        if(ledge && !ledgewall)
            return ledgeCheck.GetComponent<ChildCollisionScript>().getCollision();
            else 
            return null;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        MoveCheckers();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Danger"))
        {
            dead = true;
            Debug.Log("Dumro sam!" + collision.gameObject);
        }
    }
    private void MoveCheckers() {
        var temp =  ledgeCheck.transform.localPosition;
        var temp1 = ledgeWallCheck.transform.localPosition;
        if(Mathf.Sign(temp.x) != Mathf.Sign(rig.velocity.x)) {
            temp.x *= -1;
            temp1.x *= -1;
        }

        if(temp.x < 0)
            model.transform.rotation = Quaternion.Euler(0,270,0);
            else
            model.transform.rotation = Quaternion.Euler(0,90,0);
            
        ledgeWallCheck.transform.localPosition = temp1;
        ledgeCheck.transform.localPosition = temp;
    }

    private Vector2 getInput()
    {
        return joystick.GetComponent<FloatingJoystick>().Direction;
    }

    private void SetAnimator(bool inAir) { 
        ani.SetBool("inAir", inAir);
    }


}
