using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 手枪
/// </summary>
public class GunObject : MonoBehaviour
{
    Transform firepoint;
    Transform FirePoint
    {
        get
        {
            if (firepoint == null)
                firepoint = transform.Find("FirePoint");
            return firepoint;
        }
    }

    //子弹的预制体
    GameObject bulletPrefab;

    //射击的力度
    public float shotForece = 1000;

    void Awake()
    {
        bulletPrefab = ResourcesManager.Instance.Load<GameObject>("Prefabs/Bullet");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //生成子弹
            //GameObject go = Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
            GameObject go = ObjectPoolsManager.Instance.Spawn(bulletPrefab, FirePoint.position, Quaternion.identity);

            //发射子弹
            go.GetComponent<Rigidbody>().AddForce(Vector3.forward * shotForece);

            //5秒后销毁子弹
            //Destroy(go, 5);
            ObjectPoolsManager.Instance.Despawn(go,5);
        }



    }


}
