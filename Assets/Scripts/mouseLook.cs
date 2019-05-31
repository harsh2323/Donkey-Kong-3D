using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public float rotX = 0.0f;
    public float rotY = 0.0f;

    public float clampAngle = 90.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotX = rotation.x;
        rotY = rotation.y;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse X");
        float mouseX = -Input.GetAxis("Mouse Y");

        rotX += mouseX * sensitivity * Time.deltaTime;
        rotY += mouseY * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion locaRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = locaRotation;
    }
}
