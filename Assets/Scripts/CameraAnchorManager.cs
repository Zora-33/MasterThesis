//#if UNITY_WSA && !UNITY_EDITOR
//using UnityEngine.XR.WSA;
//using UnityEngine.XR.WSA.Persistence;
//#endif
//using UnityEngine;

//public class CameraAnchorManager : MonoBehaviour
//{
//#if UNITY_WSA && !UNITY_EDITOR
//    private WorldAnchorStore anchorStore;
//#endif

//    void Start()
//    {
//#if UNITY_WSA && !UNITY_EDITOR
//        WorldAnchorStore.GetAsync(AnchorStoreReady);
//#endif
//    }

//#if UNITY_WSA && !UNITY_EDITOR
//    private void AnchorStoreReady(WorldAnchorStore store)
//    {
//        anchorStore = store;
//        Debug.Log("WorldAnchorStore loaded.");
//        SaveAnchor();
//    }

//    public void SaveAnchor()
//    {
//        var anchor = gameObject.GetComponent<WorldAnchor>();
//        if (anchor == null)
//        {
//            anchor = gameObject.AddComponent<WorldAnchor>();
//        }

//        if (anchor.isLocated)
//        {
//            anchorStore.Save("MyAnchor", anchor);
//            Debug.Log("Anchor saved.");
//        }
//        else
//        {
//            anchor.OnTrackingChanged += Anchor_OnTrackingChanged;
//        }
//    }

//    private void Anchor_OnTrackingChanged(WorldAnchor self, bool located)
//    {
//        if (located)
//        {
//            Debug.Log("Anchor located.");
//            anchorStore.Save("MyAnchor", self);
//            self.OnTrackingChanged -= Anchor_OnTrackingChanged;
//        }
//    }
//#endif
//}