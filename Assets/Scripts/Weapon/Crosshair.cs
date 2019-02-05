using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;
    [SerializeField] Transform aimPivot;

    float lookHeight;

    public float LookHeight(float value)
    {
        lookHeight += value;

        if (lookHeight > maxAngle || lookHeight < minAngle)
        {
            lookHeight -= value;
        }

        return lookHeight;

    }

    private void OnGUI()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, aimPivot.position.y - 13, aimPivot.position.y + 13),transform.position.z);
    }


}
