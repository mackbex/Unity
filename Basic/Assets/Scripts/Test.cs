using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    private float createTime = 1f;
    private float currentTcrateTime;

    [SerializeField] private GameObject go_BulletPrefab;


    private void Update()
    {

        Collider[] col = Physics.OverlapSphere(transform.position, 5f);

        if (col.Length > 0)
        {
            for (int i = 0; i < col.Length; i++)
            {
                Transform tf_target = col[i].transform;

                if (tf_target.tag == "Player")
                {
                    transform.rotation = Quaternion.LookRotation(tf_target.position - transform.position);
                    currentTcrateTime += Time.deltaTime;

                    if (currentTcrateTime >= createTime)
                    {
                        GameObject _temp = Instantiate(go_BulletPrefab, transform.position, transform.rotation);
                        Physics.IgnoreCollision(_temp.GetComponent<Collider>(), tf_target.GetComponent<Collider>());
                        currentTcrateTime = 0;
                    }
                }
            }
        }
    }
}

