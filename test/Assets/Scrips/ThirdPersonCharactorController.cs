using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharactorController : MonoBehaviour
{
    public float speed;
    public Rigidbody rig;
    public float jumpspeed;
    public bool isGround;
    float mouseX, mouseY;
    public float RotationSpeed;
    public Transform player;

    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 PlayerMovement = new Vector3(h, 0f, v) * speed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed*Time.deltaTime;//定義滑鼠X數值
        // mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;//定義滑鼠Y數值
       // mouseY = Mathf.Clamp(mouseY, -35, 60);//限制角度
        //target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

}