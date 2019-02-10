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
    public int bulletsInClip;
    bool isReloading;

    private Text ammos;
    private Text ammoInClip;


    public void Awake()
    {
        gunSound = transform.Find("GunSounds").GetComponent<GunSound>();
        ammo = maxAmmo;
        bulletsInClip = clipSize;
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
            return bulletsInClip;
            
        }
    }

    public bool IsReloading()
    {
        return isReloading;
    }

    public void Reload()
    {
        gunSound.Play(1);
        if (isReloading)
            return;
        isReloading = true;
        GameManagerTPS.instance.timer.Add(executeReload, reloadTime);
    }

    private void executeReload()
    {
        isReloading = false;


        if (ammo < clipSize)
        {
            bulletsInClip = ammo;
            ammoInClip.text = ammo.ToString();

        }
        else
        {
            bulletsInClip = clipSize;
            ammoInClip.text = clipSize.ToString();

        }


        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        if (ammo <= 0)
            ammo = 0;

        ammos.text = ammo.ToString();

        
        
    }

    public void TakeFromClip(int amount)
    {
        shotsFiredInClip += amount;
        bulletsInClip -= amount;
        ammoInClip.text = BulletsRemainigInClip.ToString();
    }
}
