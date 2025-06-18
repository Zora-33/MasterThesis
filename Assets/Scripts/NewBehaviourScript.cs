//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using MixedReality.Toolkit;
//using UnityEngine.XR.Interaction.Toolkit;

//public class NewBehaviourScript : MonoBehaviour
//{
//    [SerializeField]
//    private StatefulInteractable interactable;

//    private void OnEnable()
//    {
//        if (interactable != null)
//        {
//            interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
//            interactable.lastSelectExited.AddListener(OnLastSelectExited);
//        }
//    }

//    private void OnDisable()
//    {
//        if (interactable != null)
//        {
//            interactable.firstSelectEntered.RemoveListener(OnFirstSelectEntered);
//            interactable.lastSelectExited.RemoveListener(OnLastSelectExited);
//        }
//    }

//    private void OnFirstSelectEntered(SelectEnterEventArgs args)
//    {
//        Debug.Log("✅ 注视停留触发（firstSelectEntered）");
//        // 在这里添加你的逻辑，比如弹窗、播放动画等
//    }

//    private void OnLastSelectExited(SelectExitEventArgs args)
//    {
//        Debug.Log("❎ 注视离开（lastSelectExited）");
//    }
//}