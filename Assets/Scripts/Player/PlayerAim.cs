using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    private float rotation;

    public void SetRotation(float amount, float crosshairPosition)
    {
        //transform.eulerAngles = new Vector3(transform.eulerAngles.x - amount, transform.eulerAngles.y, transform.eulerAngles.z);
        if(crosshairPosition >= 0f)
        {
            rotation = -amount;
        }
        else
        {
            rotation = amount;
        }
        
    }

    
    public float GetAngle()
    {
        //return CheckAngle(transform.eulerAngles.x);
        return rotation;
    }
    /*
    public float CheckAngle(float value)
    {
        float angle = value - 180;

        if(angle > 0)
        {
            return angle - 180;
        }
        return angle + 180;
    }*/


}
