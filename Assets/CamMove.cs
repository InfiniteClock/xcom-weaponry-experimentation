using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float speed;
    public float cameraSensitivity;

    float rotX = 0f;
    float rotY = 0f;

    Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        LookAround();
        MoveAround();
    }

    private void LookAround()
    {
        rotX += Input.GetAxis("Mouse Y") * -0.5f * cameraSensitivity;
        rotY += Input.GetAxis("Mouse X") * cameraSensitivity;
        transform.localEulerAngles = new Vector3(rotX, rotY, 0f);
    }
    private void MoveAround()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
            velocity.y = 1f;
        else if (Input.GetKey(KeyCode.LeftAlt))
            velocity.y = -1f;
        else
            velocity.y = 0f;

        transform.Translate(velocity * speed * Time.deltaTime);
    }
}
