using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public abstract class SpellBase : MonoBehaviour
{
    protected float damage;
    protected float fireRate = .5f;
    public float knockback = 0f;
    public ParticleSystem spellEffect;
    public ParticleSystem onHitEffect;
    public float speed = 15;
    public float lifeTime = 2;
    public SphereCollider cldr;
    
    void Start()
    {
        cldr = GetComponent<SphereCollider>();
        cldr.isTrigger = true;
        cldr.radius = 1.2f;
    }

    private IEnumerator KillMySelf()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        StartCoroutine(KillMySelf());
    }

    public virtual void OnTriggerEnter (Collider other) {
        if (!other.CompareTag("Player"))
        {
            EnemyHealth enemyHP = other.GetComponent<EnemyHealth>();
            if(enemyHP != null)
            {
                enemyHP.Damage(damage);
            }
            
			spellEffect.Stop();
            Instantiate(onHitEffect, transform.position,  transform.rotation * Quaternion.Euler(180,0,0));
            other.attachedRigidbody.AddExplosionForce(knockback, transform.position,20);
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }

    public float GetFireRate()
    {
        return fireRate;
    }
}
