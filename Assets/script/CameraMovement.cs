using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public float movementSpeed = 5f;      // 摄像头移动速度
    public float rotationSpeed = 50f;    // 摄像头旋转速度

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
    }

    void Update()
    {
        // 按下W键向前移动
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // 按下S键向后移动
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

        // 按下A键向左移动
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }

        // 按下D键向右移动
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        // 获取鼠标移动距离
        float mouseX = Input.GetAxis("Mouse X")*10;
        float mouseY = Input.GetAxis("Mouse Y")*10;

        // 根据鼠标移动距离旋转摄像头
        rotationX -= mouseY * rotationSpeed * Time.deltaTime;
        rotationY += mouseX * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}
