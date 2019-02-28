using UnityEngine;

public class BulletsParent : MonoBehaviour
{
    private static int ammo = 5;

    // Update is called once per frame
    void Update()
    {
        ammo = PlayerShoot.ammo;
    }
}