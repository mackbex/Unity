
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Object_Toggle_Sharp : UdonSharpBehaviour
{
    public GameObject Target;

    private void Interact()
    {
        Target.SetActive(!Target.activeSelf);
    }
}
