//using System.Collections;
//using System.Collections.Generic;
//using Microsoft.MixedReality.Toolkit.Input;
//using UnityEngine;

//public class EyeTracker : MonoBehaviour
//{
//    void Update()
//    {
//        if (CoreServices.InputSystem?.EyeGazeProvider?.IsEyeTrackingEnabledAndValid == true)
//        {
//            Ray eyeRay = CoreServices.InputSystem.EyeGazeProvider.GazeRay;
//            Vector3 gazeOrigin = eyeRay.origin;
//            Vector3 gazeDirection = eyeRay.direction;

//            Debug.DrawRay(gazeOrigin, gazeDirection * 10, Color.red);
//            Debug.Log($"👁️ Gaze at: {gazeOrigin + gazeDirection * 10}");
//        }
//        else
//        {
//            Debug.Log("No valid eye tracking data");
//        }
//    } 
//}
