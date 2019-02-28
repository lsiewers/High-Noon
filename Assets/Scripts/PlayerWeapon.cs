using UnityEngine;

[System.Serializable]
public class PlayerWeapon
{

    public string name = "Revolver";

    public float fireRate = 0f;

    public int maxBullets = 5;
    [HideInInspector]
    public int bullets;

    public GameObject graphics;

    public PlayerWeapon()
    {
        bullets = maxBullets;
    }

}