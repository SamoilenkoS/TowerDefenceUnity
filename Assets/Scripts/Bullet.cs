using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject hitEffect = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(hitEffect, 5f);
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
       
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        colliders = colliders.Where(collider => collider.tag == "Enemy").ToArray();
        foreach (Collider collider in colliders)
        {
            Damage(collider.transform);
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
