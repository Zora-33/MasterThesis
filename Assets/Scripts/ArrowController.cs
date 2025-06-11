using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color triggeredColor = Color.white;
    private bool hasTriggered = false;
    public static List<string> triggeredArrows = new List<string>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        // 检查是否是 XR Rig 下的 Camera 触发
        if (!hasTriggered && other.GetComponentInChildren<Camera>())
        {
            hasTriggered = true;
            spriteRenderer.color = triggeredColor;
            triggeredArrows.Add(gameObject.name);
        }
    }
}