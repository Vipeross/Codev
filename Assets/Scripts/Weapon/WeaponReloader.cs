using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour {

    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;

    int ammo;
    public int shotsFiredInClip;
    bool isReloading;

    public int BulletsRemainigInClip
    {
        get
        {
            return clipSize - shotsFiredInClip;
        }
    }

    public bool IsReloading()
    {
        return isReloading;
    }

    public void Reload()
    {
        if (isReloading)
            return;
        isReloading = true;
        GameManagerTPS.instance.timer.Add(executeReload, reloadTime);
    }

    private void executeReload()
    {
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if(ammo < 0)
        {
            ammo = 0;
            shotsFiredInClip -= ammo;
        }
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }
}
