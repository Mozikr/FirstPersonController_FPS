using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem shootFlash;
    public GameObject impactEffect;
    Animator anim;
    Target target;

    [SerializeField]
    float shootDelay = 0.8f;
    float T_ShootDelay;
    public int hitted = 0;

    private void Start()
    {
        target = FindObjectOfType<Target>();
        T_ShootDelay = shootDelay;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (T_ShootDelay < shootDelay)
            T_ShootDelay += Time.deltaTime;


        if (Input.GetButtonDown("Fire1") && T_ShootDelay >= shootDelay)
        {
            T_ShootDelay = 0;
            Shoot();
            anim.SetBool("IsShooting", true);
        }
        else
        {
            anim.SetBool("IsShooting", false);
        }
    }

    void Shoot()
    {
        shootFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Target")
            {
                target.TargetHit();
                hitted++;
                Debug.Log(hitted);
                if(hitted == 3)
                {
                    target.TargetHitEnable();
                    target.TargetFall();
                    target.TargetDisappear();
                }
            }
        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, impactEffect.transform.rotation);
        Destroy(impactGO, 0.1f);
        
    }

}
