using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : MonoBehaviour
{

    private PlayerWeapon currentWeapon;
    private WeaponManager weaponManager;
    private PlayerMotor playerMotor;
    private GameManager gameManager;
    private RoundManager roundManager;

    public static int ammo;
    public static bool canShoot = false;

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
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = weaponManager.GetCurrentWeapon();
        ammo = currentWeapon.bullets;

        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1") && !playerMotor.zoom)
            {
                Shoot();
            }
        }

    }

    void Shoot()
    {

        if (currentWeapon.bullets == 0)
        {
            gameManager.GameOver("Out of bullets!");
            return;
        }

        currentWeapon.bullets--;

        weaponManager.GetCurrentGraphics().muzzleFlash.Play();

        RaycastHit _hit;

        // see if draw is called
        if (!roundManager.draw)
        {
            gameManager.GameOver("You shot too early, wait until 'Draw' is called");
        }
        else
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 100f, mask))
            {
                if (_hit.collider.tag == "Opponent")
                {
                    if (_hit.collider.name == "Cowboy " + GameManager.data.tips[GameManager.activeTip].Answer + "(Clone)")
                    {
                        SceneManager.LoadScene("Succes");
                    }
                    else
                    {
                        gameManager.GameOver("Wrong opponent!");
                    }
                }

                GameObject _hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hitEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);
            }
        }
    }
}
