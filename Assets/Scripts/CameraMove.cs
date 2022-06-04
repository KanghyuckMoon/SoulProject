using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public GameObject objTarget = null;
    private Transform cameraTransform = null;
    private Transform objTargetTransform = null;


    //추가된 높이
    public float height = 1.75f;
    public float heightDamp = 6f;
    public float rotateDamp = 3f;
    //떨어진 거리
    public float distance = 6f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();

        if (objTarget != null)
        {
            objTargetTransform = objTarget.transform;
        }
    }

    private void LateUpdate()
    {
        if (objTarget == null)
        {
            return;
        }
        if (objTargetTransform == null)
        {
            objTargetTransform = objTarget.transform;
        }

        ThirdCamera();
    }

    /// <summary>
    /// 3인칭 카메라
    /// </summary>
    private void ThirdCamera()
    {
        float objTargetRotationAngle = objTargetTransform.eulerAngles.y;
        float objHeight = objTargetTransform.position.y + height;
        float nowRotationAngle = cameraTransform.eulerAngles.y;
        float nowHeight = cameraTransform.position.y;

        nowRotationAngle = Mathf.LerpAngle(nowRotationAngle, objTargetRotationAngle, rotateDamp * Time.deltaTime);
        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        Quaternion nowRotate = Quaternion.Euler(0f, nowRotationAngle, 0f);

        cameraTransform.position = objTargetTransform.position;
        cameraTransform.position -= nowRotate * Vector3.forward * distance;
        cameraTransform.position = new Vector3(cameraTransform.position.x, nowHeight, cameraTransform.position.z);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseX * Time.deltaTime;
        rotationY += mouseY * Time.deltaTime;

        cameraTransform.LookAt(objTargetTransform);
        cameraTransform.eulerAngles += new Vector3(-rotationY, rotationX, 0);
    }


}
