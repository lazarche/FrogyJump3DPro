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


    public bool pass = false;
    Vector3 target;

    [SerializeField] Vector3 ledgeFix = new Vector3(0.4f, 1.9f, 0);
    [SerializeField] float stronk = 6;
    [SerializeField] GameObject joystick, ledgeCheck, ledgeWallCheck, model;
    [SerializeField] Animator ani;
    [SerializeField] AudioSource uh;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        tc = GetComponent<TrajectoryController>();
        rig = GetComponent<Rigidbody2D>();
        uh = GetComponent<AudioSource>();
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
                target = new Vector3(transform.position.x, ledge.transform.position.y, transform.position.z) - new Vector3(ledgeFix.x * -MoveCheckers(), ledgeFix.y, ledgeFix.z);
            }
        }

        if(ledge) {
            transform.position = Vector3.Lerp(transform.position, target, 0.5f);
            ani.SetBool("ledge", true);
            rig.velocity = new Vector3();
            CheckForLaunch();
        } else {
            ani.SetBool("ledge", false);
        }

        

        dir = getInput() * stronk;
        tc.velocity = dir;
            
    }

    void ResetGrab() {
        canGrab = true;
    }
    void ResetPass() {
        pass = false;
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
        uh.Play();
        pass = true;
        Invoke("ResetPass", 1f);
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
            ani.SetBool("dead", true);
            GameObject.Find("GameManager").GetComponent<GameManager>().LoseGame();
            Debug.Log("Dumro sam!" + collision.gameObject);
        }


    }
    private float MoveCheckers() {
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

        return Mathf.Sign(temp.x);
    }

    private Vector2 getInput()
    {
        return joystick.GetComponent<FloatingJoystick>().Direction;
    }

    private void SetAnimator(bool inAir) { 
        if(ledge)
            ani.SetBool("inAir", true);
            else
            ani.SetBool("inAir", inAir);
    }


}
