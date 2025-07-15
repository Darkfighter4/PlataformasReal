using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    
    public BulletController bulletPrefab;
    public ObjectPool<BulletController> bulletPool;
    public float speed = 5;
    public SpriteRenderer _spriteRenderer;
    
    
    [Header("Recebendo...")]
    public VoidEventChannel circleColorEvent;
    public ColorEventChannel circleSpecificColorEvent;
    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        bulletPool = new ObjectPool<BulletController>(CreateBullet, GetBullet, ReleaseBullet, DestroyBullet, false, 10, 20);
    }

    private void DestroyBullet(BulletController obj)
    {
        obj.OnDestroyBullet -= bulletPool.Release;
        Destroy(obj.gameObject);
    }

    private void ReleaseBullet(BulletController obj)
    {
        obj.gameObject.SetActive(false);
        obj.OnDestroyBullet -= bulletPool.Release;
    }

    private void GetBullet(BulletController obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = transform.position;
        obj.OnDestroyBullet += bulletPool.Release;
    }

    private BulletController CreateBullet()
    {
       BulletController bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
       bullet.OnDestroyBullet += bulletPool.Release;
       return bullet;
    }

    private void OnEnable()
    {
        circleColorEvent.OnEventRaised += MudaCor;
        circleSpecificColorEvent.OnEventRaised += MudaCorEspecifica;
    }
    
    private void OnDisable()
    {
        circleColorEvent.OnEventRaised -= MudaCor;
        circleSpecificColorEvent.OnEventRaised -= MudaCorEspecifica;
    }

    public void MudaCor()
    {
        _spriteRenderer.color = Random.ColorHSV();
    }

    private void MudaCorEspecifica(Color corEspecifica)
    {
        _spriteRenderer.color = corEspecifica;
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            bulletPool.Get();
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            transform.position += Vector3.left* (speed *Time.deltaTime);
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            transform.position += Vector3.right* (speed *Time.deltaTime);
        }
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            transform.position += Vector3.up* (speed *Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            transform.position += Vector3.down* (speed *Time.deltaTime);
        }
    }
}
