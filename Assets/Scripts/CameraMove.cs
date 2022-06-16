using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{

    public GameObject objTarget = null;
    private Transform cameraTransform = null;
    private Transform objTargetTransform = null;

    //�߰��� ����
    public float height = 1.75f;
    public float heightDamp = 6f;
    public float rotateDamp = 3f;
    //������ �Ÿ�
    public float distance = 6f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public float multipleX = 1.0f;
    public float multipleY = 1.0f;

    private bool _isAnimation = false;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();

        if (objTarget != null)
        {
            objTargetTransform = objTarget.transform;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

        if(_isAnimation)
		{

		}
        else
		{
            ThirdCamera();
		}
    }

    public void AnimationCamera(Vector3 position, Vector3 forward)
	{
        _isAnimation = true;
        Vector3 movePositoin = position + (forward * 2f);
        Vector3 lookRotation = (position - movePositoin).normalized;
        Vector3 rotationVector = Quaternion.LookRotation(lookRotation).eulerAngles;

        transform.DOMove(movePositoin, 0.5f).SetUpdate(true);
        transform.DORotate(rotationVector, 0.5f).SetUpdate(true);
    }

    public void EndAnimationCamera()
	{
        _isAnimation = false;
	}

    /// <summary>
    /// 3��Ī ī�޶�
    /// </summary>
    private void ThirdCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseX * multipleX;
        rotationY += mouseY * multipleY;
        rotationY = Mathf.Clamp(rotationY, -5.0f, 1.5f);

        float objTargetRotationAngle = objTargetTransform.eulerAngles.y + rotationX;
        float objHeight = objTargetTransform.position.y + height - rotationY;
        float nowRotationAngle = cameraTransform.eulerAngles.y;
        float nowHeight = cameraTransform.position.y;

        nowRotationAngle = Mathf.LerpAngle(nowRotationAngle, objTargetRotationAngle, rotateDamp * Time.deltaTime);
        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        Quaternion nowRotate = Quaternion.Euler(0f, nowRotationAngle, 0f);

        cameraTransform.position = objTargetTransform.position;
        cameraTransform.position -= nowRotate * Vector3.forward * distance;
        cameraTransform.position = new Vector3(cameraTransform.position.x, nowHeight, cameraTransform.position.z);



        cameraTransform.LookAt(objTargetTransform);
    }


}
