using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : MonoBehaviour
{

    private PlayerWeapon currentWeapon;
    private WeaponManager weaponManager;

    public static int ammo;

    [SerializeField]
    private GameObject weaponGFX;

    [SerializeField]
    private Transform weaponHolder;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
        }


        weaponManager = GetComponent<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();

        if (currentWeapon.fireRate <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                InvokeRepeating("Shoot", 0f, 1f / currentWeapon.fireRate);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                CancelInvoke("Shoot");
            }
        }
    }

    void Shoot()
    {
        if (currentWeapon.bullets <= 0)
        {
            GameManager.gameOver();
            return;
        }

        currentWeapon.bullets--;
        ammo = currentWeapon.bullets;

        weaponManager.GetCurrentGraphics().muzzleFlash.Play();

        RaycastHit _hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, mask))
        {
            if (_hit.collider.tag == "Opponent")
            {
                Debug.Log("You shot:" + _hit.collider.name);
                Invoke("NextRound", 2);
            }


            GameObject _hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hitEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(_hitEffect, 2f);
        }
    }

    void NextRound()
    {
        GameManager.nextRound();
    }
}
