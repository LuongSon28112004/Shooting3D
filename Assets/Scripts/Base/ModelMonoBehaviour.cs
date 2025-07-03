using UnityEngine;

public class ModelMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset() {
        this.LoadComponents();
    }

    protected virtual void Update()
    {
       
    }

    protected virtual void Start()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        // This method can be overridden in derived classes to load specific components
    }
}
