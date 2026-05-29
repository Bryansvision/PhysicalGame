using UnityEngine;

public class Touch : MonoBehaviour
{
    public bool alreadyHit = false;

    public AudioSource note;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hands" && alreadyHit == false)
        {
            note.Play();
            alreadyHit = true;
        }
    }
}
