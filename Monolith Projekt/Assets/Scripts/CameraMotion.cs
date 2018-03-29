using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    void Start()
    {   
        transform.Translate(0, 400, -888);
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * 500), Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * 500), Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * -500), Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * 500), Space.Self);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Translate(Vector3.down * (Time.deltaTime * 500), Space.Self);
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.Translate(Vector3.up * (Time.deltaTime * 500), Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * 115), Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * (Time.deltaTime * 115), Space.Self);
        }
    }
}
