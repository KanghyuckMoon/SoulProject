using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public bool IsLookOn
	{
        get
		{
            return _isLookOn;
		}
	}


    public GameObject objTarget = null;
    private Transform cameraTransform = null;
    private Transform objTargetTransform = null;

    //추가된 높이
    public float height = 1.75f;
    public float heightDamp = 6f;
    public float rotateDamp = 3f;
    //떨어진 거리
    public float _distance = 6f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public float multipleX = 1.0f;
    public float multipleY = 1.0f;
    public float _lookOnSpeed = 1.0f;

    private bool _isAnimation = false;
    private bool _isLookOn = false;
    private Transform _lookOnObject = null;

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
            if(_isLookOn)
			{
                ThirdLookOnCamera();
            }
            else
			{
                ThirdCamera();
			}
            SetDistance();

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
    /// 3인칭 카메라
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
        cameraTransform.position -= nowRotate * Vector3.forward * _distance;
        cameraTransform.position = new Vector3(cameraTransform.position.x, nowHeight, cameraTransform.position.z);

        cameraTransform.LookAt(objTargetTransform);
    }

    /// <summary>
    /// 록온한다
    /// </summary>
    /// <param name="Target"></param>
    public void SetLookOn(Transform target)
	{
		_lookOnObject = target;
        _isLookOn = true;
    }

    /// <summary>
    /// 록온 해제
    /// </summary>
    /// <param name="Target"></param>
    public void SetLookOff()
    {
        _lookOnObject = null;
        _isLookOn = false;
    }

    /// <summary>
    /// 3인칭 록온 카메라
    /// </summary>
    private void ThirdLookOnCamera()
    {
        Vector3 rotationVector = (_lookOnObject.position - objTarget.transform.position).normalized;
        rotationVector.y = 0;
        float objHeight = objTargetTransform.position.y + height;
        float nowHeight = cameraTransform.position.y;

        nowHeight = Mathf.Lerp(nowHeight, objHeight, heightDamp * Time.deltaTime);

        Vector3 velocity = Vector3.zero;
        cameraTransform.forward = Vector3.SmoothDamp(cameraTransform.forward, rotationVector,ref velocity, _lookOnSpeed * Time.deltaTime);
        cameraTransform.position = objTargetTransform.position;
        cameraTransform.position -= rotationVector * _distance;
        cameraTransform.position = new Vector3(cameraTransform.position.x, nowHeight, cameraTransform.position.z);

    }

    private void SetDistance()
	{
        float wheelInput = Input.GetAxis("Mouse ScrollWheel"); 
        
        if (wheelInput > 0)
		{
            if(_distance > 2)
			{
                _distance -= Time.deltaTime * 50;
			}
		}
        else if(wheelInput < 0)
        {
            if(_distance < 10)
			{
                _distance += Time.deltaTime * 50;
			}
        }

    }
}
