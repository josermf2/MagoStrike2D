using UnityEngine;

public class Blocks : MonoBehaviour
{
    public AudioSource destroySound;

    private void Start()
    {
        // Loop through all child objects and add a DestroyListener to each one
        foreach (Transform child in transform)
        {
            BlocoFilho block = child.GetComponent<BlocoFilho>();
            if (block != null)
            {
                block.Destroyed.AddListener(OnBlockDestroyed);
            }
        }
    }

    private void OnBlockDestroyed()
    {
        destroySound.Play();
    }
}
