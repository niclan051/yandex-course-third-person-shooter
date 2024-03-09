using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    [SerializeField] private Vector3 startScale, endScale;
    [SerializeField] private float scaleUpTime;
    private float _time;
    private void Start() {
        transform.localScale = startScale;
    }

    private void Update()
    {
        if (_time >= scaleUpTime) Destroy(gameObject);
        transform.localScale = Vector3.Lerp(startScale, endScale, _time / scaleUpTime);
        _time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var health = other.GetComponent<BaseHealth>();
        if (health != null)
        {
            health.Damage(10);
        }
    }
}
