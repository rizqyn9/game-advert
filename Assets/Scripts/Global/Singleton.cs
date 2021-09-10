using UnityEngine;

public abstract class Singleton<T>: MonoBehaviour where T : Component
{
    public virtual bool isDestroyed() => false;

    private static T _instance;
    public static T Instance {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    GameObject GO = new GameObject();
                    _instance = GO.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        _instance = this as T;
    }
}
