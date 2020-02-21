using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emeny : MonoBehaviour
{
    public bool useCharacterForward = false;

    public float distanceToMe;
    public GameObject me;
    public float isSeekDistance = 10.0f;
    public int state;
    public Animator ani;
    public bool move;
    public float enemy_speed;
    private float velocity;

    void Start()
    {
        me = GameObject.FindWithTag("Player");
    }
    void FixedUpdate()
    {
        switch (state)
        {
            case 0:
                Idle();
                break;
            case 1:
                Seek();
                break;
        }
        //    if (useCharacterForward)
        //        enemy_speed = Mathf.Abs(input.x) + input.y;
        //    else
        //        enemy_speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);

        //    enemy_speed = Mathf.Clamp(enemy_speed, 0f, 1f);
        //    enemy_speed = Mathf.SmoothDamp(ani.GetFloat("enemy_speed"), enemy_speed, ref velocity, 0.1f);
        //    ani.SetFloat("enemy_speed", enemy_speed);

        //    if (input.y < 0f && useCharacterForward)
        //        direction = input.y;
        //    else
        //        direction = 0f;

        //    ani.SetFloat("Direction", direction);

        //    // set sprinting
        //    isSprinting = ((Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && input != Vector2.zero && direction >= 0f);
        //    ani.SetBool("isSprinting", isSprinting);
        //}
        void Idle()
        {
            distanceToMe = Vector3.Distance(me.transform.position, this.transform.position);
            if (distanceToMe > isSeekDistance)
            {
                state = 0;
                if (Random.value > 0.5)
                {
                    this.transform.Rotate(Vector3.up * 5 * Time.deltaTime * enemy_speed);
                }
                else
                {
                    transform.Rotate(Vector3.up * -5.0f * Time.deltaTime * enemy_speed);
                }
                this.transform.Translate(Vector3.forward * 0.1f * Time.deltaTime * enemy_speed);
                ani.SetFloat("enemy_speed", enemy_speed);
            }
            else
            {
                state = 1;
            }
        }
        void Seek()
        {
            distanceToMe = Vector3.Distance(me.transform.position, this.transform.position);
            if (distanceToMe < isSeekDistance)
            {
                this.transform.LookAt(me.transform);
                this.transform.Translate(Vector3.forward * 0.1f * Time.deltaTime * enemy_speed);
            }
            if (distanceToMe == 5)
            {
                state = 0;

            }
            else
            {
                state = 0;
            }
        }

    }
}




