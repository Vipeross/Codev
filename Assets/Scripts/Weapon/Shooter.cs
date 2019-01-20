using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour {

    [SerializeField] float fireRate;
    [SerializeField] AssaultRiffleBullet projectile;
    [SerializeField] Transform hand;
    [SerializeField] protected Transform crosshair;

    protected Transform muzzle;

    protected GunSound gunSound;

    private WeaponReloader reloader;

    float nextFireAllowed;
    public bool canFire;

	void Awake () {

        gunSound = transform.Find("GunSounds").GetComponent<GunSound>();
        muzzle = transform.GetChild(0).transform.GetChild(0);
        reloader = GetComponent<WeaponReloader>();

        transform.SetParent(hand);
    }




    public void Reload()
    {
        if(reloader == null)
        {
            return;
        }
        reloader.Reload();
    }

    public virtual void Fire()
    {
        canFire = false;

        if(Time.time < nextFireAllowed)
        {
            return;
        }

        if(reloader != null)
        {
            if(reloader.IsReloading())
            {
                return;
            }
            if(reloader.ammo == 0 && reloader.BulletsRemainigInClip == 0)
            {
                return;
            }
            if(reloader.BulletsRemainigInClip == 0)
            {
                reloader.Reload();
                return;
            }
            reloader.TakeFromClip(1);

        }

        nextFireAllowed = Time.time + fireRate;

        Instantiate(projectile, muzzle.position, muzzle.rotation);

        canFire = true;
    }

    
}
