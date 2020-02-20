using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontalscroll : MonoBehaviour
{
    public Rigidbody rig;
    public Transform tran;
    public float speed;

    void Start()
    {
        PlayerMove();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
    }
}
