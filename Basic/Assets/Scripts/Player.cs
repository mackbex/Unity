using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform tf_Target;

  
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(tf_Target.position, Vector3.up, speed * Time.deltaTime);
    }
}
