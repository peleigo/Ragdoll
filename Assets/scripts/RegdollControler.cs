using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegdollControler : MonoBehaviour
{
    [SerializeField] Collider myCollider;
    [SerializeField] float respawnTime = 30f;
    Rigidbody[] rb;
    bool bIsRagdoll = false;
    void Start()
    {
        rb = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!bIsRagdoll && collision.gameObject.tag == "Projectile")
        {
            ToggleRagdoll(false);
            StartCoroutine(GetBackUp());
        }
    }
    private void ToggleRagdoll(bool bisAnimating)
    {
        bIsRagdoll = !bisAnimating;
        myCollider.enabled = bisAnimating;
        foreach (Rigidbody ragdoolBone in rb)
        {
            ragdoolBone.isKinematic = bisAnimating;
        }
        GetComponent<Animator>().enabled = bisAnimating;
        if (bisAnimating)
        {
            RandomAnimation();
        }
    }
    private IEnumerator GetBackUp()
    {
        yield return new WaitForSeconds(respawnTime);
        ToggleRagdoll(true);
    }
    void RandomAnimation()
    {
        int randomNum = Random.Range(0,2);
        Animation anim = GetComponent<Animation>();
        
    }
}
