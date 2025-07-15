using UnityEngine;
using System;
public class BulletController : MonoBehaviour
{
    public Action<BulletController> OnDestroyBullet;
    public float speed;
    
    public Vector2 direction;

    private void OnEnable()
    {
        Invoke("DestroyBullet", 2f);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        OnDestroyBullet?.Invoke(this);
    }
}
