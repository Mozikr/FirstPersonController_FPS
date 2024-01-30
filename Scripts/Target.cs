using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("IsShoted", false);
    }
    public void TargetHit()
    {
        anim.SetBool("IsShoted", true);
    }
    public void TargetFall()
    {
        anim.SetBool("Fall", true);
    }
    public void TargetHitEnable()
    {
        anim.SetBool("IsShoted", false);
    }
    public void TargetDisappear()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
