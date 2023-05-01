using UnityEngine;
using UnityEngine.Events;

public class BlocoFilho : MonoBehaviour
{
    public UnityEvent Destroyed;

    private void OnDestroy()
    {
        Destroyed.Invoke();
    }
}