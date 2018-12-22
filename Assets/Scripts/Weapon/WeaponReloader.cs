using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponReloader : MonoBehaviour {

    [SerializeField] int maxAmmo;
    [SerializeField] float reloadTime;
    [SerializeField] int clipSize;

    GunSound gunSound;

    public int ammo;
    public int shotsFiredInClip;
    bool isReloading;

    private Text ammos;
    private Text ammoInClip;


    public void Awake()
    {
        gunSound = transform.Find("GunSounds").GetComponent<GunSound>();
        ammo = maxAmmo;
        shotsFiredInClip = 0;

        ammos = GameObject.Find("Ammo").GetComponent<Text>();
        ammoInClip = GameObject.Find("AmmoInClip").GetComponent<Text>();

        ammos.text = ammo.ToString();
        ammoInClip.text = BulletsRemainigInClip.ToString();
    }

    public int BulletsRemainigInClip
    {
        get
        {   
            if(ammo == 0)
            {
                return 0;
            }
            else
            {
                return clipSize - shotsFiredInClip;
            }
            
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
        gunSound.Play(1);
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if (ammo <= 0)
            ammo = 0;
        ammos.text = ammo.ToString();
        ammoInClip.text = BulletsRemainigInClip.ToString();
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
        ammoInClip.text = BulletsRemainigInClip.ToString();
    }
}
