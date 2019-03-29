using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(WeaponManager))]
public class BulletsParent : MonoBehaviour
{
    private GameObject bullet;

    private int ammo;

    [SerializeField]
    private Sprite bulletIcon;

    // Update is called once per frame
    void Awake()
    {
        ammo = PlayerShoot.ammo;

        while (ammo > transform.childCount) {
            bullet = new GameObject("Bullet");
            bullet.transform.SetParent(gameObject.transform, false);
            bullet.AddComponent<RectTransform>();
            bullet.AddComponent<Image>();
            bullet.GetComponent<RectTransform>().sizeDelta = new Vector2(15, 70);
            bullet.GetComponent<Image>().sprite = bulletIcon;
            Instantiate(bullet);
            bullet.transform.parent = transform;
        }
    }

    private void Update()
    {
        ammo = PlayerShoot.ammo;

        if (ammo < transform.childCount)
        {
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }
    }
}