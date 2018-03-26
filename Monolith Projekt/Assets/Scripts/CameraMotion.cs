using UnityEngine;

public class CameraMotion : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(15,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-50,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,1,1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,-1,-1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,1,0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-1,0);
        }
    }
}
