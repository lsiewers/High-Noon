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
    public static bool canShoot;
    public bool gameOver;

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

        gameOver = false;
        canShoot = false;

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

        if (canShoot && Input.GetButtonDown("Fire1") && !playerMotor.zoom && !gameOver)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        currentWeapon.bullets--;

        weaponManager.GetCurrentGraphics().muzzleFlash.Play();

        weaponManager.GetCurrentGraphics().GetComponent<AudioSource>().Play();


        RaycastHit _hit;

        // see if draw is called
        if (!roundManager.draw)
        {
            gameManager.GameOver("You shot too early, wait until 'Draw' is called", 1);
        }
        else
        {
            Debug.Log("I may shoot");
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 200f, mask))
            {
                if (_hit.collider.tag == "Opponent")
                {
                    if (_hit.collider.name == "Cowboy " + GameManager.data.tips[GameManager.activeTip].Answer + "(Clone)")
                    {
                        SceneManager.LoadScene("Succes");
                    }
                    else
                    {
                        gameManager.GameOver("Wrong opponent!", 2);
                        gameOver = true;    
                    }
                }
                else
                {
                    if (currentWeapon.bullets == 0)
                    {
                        Debug.Log("out of bullets");
                        gameManager.GameOver("Out of bullets!", 2);
                        gameOver = true;
                        return;
                    }
                }

                GameObject _hitEffect = (GameObject)Instantiate(weaponManager.GetCurrentGraphics().hitEffectPrefab, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(_hitEffect, 2f);
            }
        }
    }
}
