using UnityEngine;

public class Touch : MonoBehaviour
{

    public AudioSource note;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hands")
        {
            note.Play();
        }
    }
}
