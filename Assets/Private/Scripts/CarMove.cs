using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    // 初期位置
    [SerializeField] private Transform initTransform;

    // 移動
    [SerializeField] private List<AxleInfo> axleInfos; 
    [SerializeField] private float maxMotorTorque; 

    [SerializeField] private float maxSteeringAngle; 

    // 復帰
    private bool isReadyRestart = true;

    private void Start()
    {
        transform.position = initTransform.position;
        transform.rotation = initTransform.rotation;
    }

    private void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
 
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }

        // 復帰
        if (Input.GetKey(KeyCode.R) && isReadyRestart)
        {
            isReadyRestart = false;
            transform.position = initTransform.position;
            transform.rotation = initTransform.rotation;
            Invoke("SetIsReadyRestart", 3.0f);
        }
    }

    private void SetIsReadyRestart()
    {
        isReadyRestart = true;
    }
}


[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; 
    public bool steering; 
}