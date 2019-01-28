using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    private float rotation;

    public void SetRotation(float angle, float crosshairPosition, float aimPivotPosition)
    {
        
        if(crosshairPosition >= aimPivotPosition)
        {
            rotation = -angle;
        }
        else
        {
            rotation = angle;
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
