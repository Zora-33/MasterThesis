using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    public string targetDoorName = "Door_right5";
    public ArrowSaveManager saveManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Camera>() != null && gameObject.name == targetDoorName)
        {
            Debug.Log($"🚩 已到达目标门：{targetDoorName}");
            saveManager.OnDestinationReached();
        }
    }
}