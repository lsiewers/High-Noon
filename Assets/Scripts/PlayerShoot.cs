using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : MonoBehaviour
{

    private PlayerWeapon currentWeapon;
    private WeaponManager weaponManager;
    private PlayerMotor playerMotor;
    private GameManager gameManager;

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
        playerMotor = GetComponent<PlayerMotor>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();
        ammo = currentWeapon.bullets;

        if (Input.GetButtonDown("Fire1") && !playerMotor.zoom)
        {
            Shoot();
        }

    }

    void Shoot()
    {

        if (currentWeapon.bullets <= 0)
        {
            gameManager.gameOver();
            return;
        }

        currentWeapon.bullets--;

        weaponManager.GetCurrentGraphics().muzzleFlash.Play();

        RaycastHit _hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, mask))
        {
            if (_hit.collider.tag == "Opponent")
            {
                Debug.Log("You shot:" + _hit.collider.name);
                if (_hit.collider.name == "Cowboy " + GameManager.data.tips[GameManager.activeTip].Answer + "(Clone)")
                {
                    Debug.Log("You killed the right one!!!");
                }
                else
                {
                    Debug.Log("You killed the wrong one!!!");
                }
            }


            GameObject _hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hitEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(_hitEffect, 2f);
        }
    }

    void NextRound()
    {
        gameManager.nextRound();
    }
}
