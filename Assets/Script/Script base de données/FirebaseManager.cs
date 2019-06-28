using UnityEngine;

namespace SimpleFirebaseUnity
{
    public class FirebaseManager : MonoBehaviour
    {

        private static FirebaseManager _instance;
        private static object _lock = new object();

        #region INSTANCE_LOGICS
        public static FirebaseManager Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Firebase Manager] Instance already destroyed on application quit." +
                        " Won't create again - returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        FirebaseManager[] managers = FindObjectsOfType<FirebaseManager>();

                        _instance = (managers.Length > 0) ? managers[0] : null;

                        if (managers.Length > 1)
                        {
                            Debug.LogError("[Firebase Manager] Something went really wrong " +
                                " - there should never be more than 1 Firebase Manager!" +
                                " Reopening the scene might fix it.");

                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<FirebaseManager>();
                            singleton.name = "Firebase Manager [Singleton]";

                            DontDestroyOnLoad(singleton);

                            Debug.Log("[Firebase Manager] Instance '" + singleton +
                                "' was generated in the scene with DontDestroyOnLoad.");
                        }
                        else
                        {
                            Debug.Log("[Firebase Manager] Using instance already created: " +
                                _instance.gameObject.name);
                        }
                    }

                    return _instance;
                }
            }
        }

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
            {
                if (Instance != this)
                    Destroy(this);
            }
        }


        private static bool applicationIsQuitting = false;
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        public void OnDestroy()
        {
            if (Application.isPlaying)
                applicationIsQuitting = true;
        }

        #endregion


    }
}
