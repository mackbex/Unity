using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private BoxCollider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;

        Debug.Log(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.position = new Vector3(0, 2, 0);
    }
}
