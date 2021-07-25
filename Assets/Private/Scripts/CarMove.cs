using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    // 初期位置
    [SerializeField] private Transform initTransform;

    // 移動
    [SerializeField] private List<AxleInfo> axleInfos; 
    [SerializeField] private float maxMotorTorque; 

    [SerializeField] private float maxSteeringAngle; 

    // 復帰
    [SerializeField] private TimeController timeController;
    private bool isReadyRestart = true;

    private void Start()
    {
        Restart();
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
            Restart();
            Invoke("SetIsReadyRestart", 3.0f);

            // 復帰するたびにペナルティとして残り時間が減らされる
            timeController.AddTimeLimit(-20f);
        }
    }


    private void Restart()
    {
        // 初期位置に配置し、速度をゼロにする
        transform.position = initTransform.position;
        transform.rotation = initTransform.rotation;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
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