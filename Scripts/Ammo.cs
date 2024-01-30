using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI ammo_text;

    Gun gun;
    int ammo_amout = 5;

    Animator anim;

    [SerializeField]
    float shootDelay_ammo = 0.8f;
    float T_ShootDelay_ammo;

    private void Start()
    {
        T_ShootDelay_ammo = shootDelay_ammo;
        gun = GetComponent<Gun>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (T_ShootDelay_ammo < shootDelay_ammo)
            T_ShootDelay_ammo += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && T_ShootDelay_ammo >= shootDelay_ammo)
        {
            T_ShootDelay_ammo = 0;
            AmmoController();
        }
    }

    void AmmoController()
    {
        ammo_amout -= 1;
        ammo_text.text = ammo_amout.ToString();
        if (ammo_amout == 0)
        {
            gun.enabled = false;
            ammo_amout = 0;
            ammo_text.text = ammo_amout.ToString();
            anim.SetBool("Reload", true);
            Reload();
        }
        else
        {
            anim.SetBool("Reload", false);
        }
    }

    void Reload()
    {
        ammo_amout = 5;
        ammo_text.text = ammo_amout.ToString();
        gun.enabled = true;

    }
}
