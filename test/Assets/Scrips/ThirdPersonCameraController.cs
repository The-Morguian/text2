using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public float RotationSpeed;
    public Transform player, target;
    float mouseX, mouseY;

    //穿牆內容
    public Transform Obstruction;
    float zoomspeed = 2.0f;

    private void Start()
    {
        Obstruction = target;
        Cursor.visible = false;//鼠標消失
        Cursor.lockState = CursorLockMode.Locked;//鼠標限制在視窗
    }
    private void LateUpdate()
    {
        CamControl();
        ViewObstructed();
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;//定義滑鼠X數值
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;//定義滑鼠Y數值
        mouseY = Mathf.Clamp(mouseY, -35, 60);//限制角度

        transform.LookAt(target);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
       else
        {
            target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    //穿牆
    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, target.position - transform.position, out hit, 4.5f))
        {
            if(hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                //if(Vector3.Distance(Obstruction.position,transform.position) >= 3f && Vector3.Distance(transform.position,target.position) >= 1.5f)
                //{
                  //  transform.Translate(Vector3.forward * zoomspeed * Time.deltaTime);
                //}
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
               // if(Vector3.Distance(transform.position,target.position) < 4.5f)
                //{
                  //  transform.Translate(Vector3.back * zoomspeed * Time.deltaTime);
                //}
            }
        }
    }
}
