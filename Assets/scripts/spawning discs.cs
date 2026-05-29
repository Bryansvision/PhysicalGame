using UnityEngine;

public class spawningdiscs : MonoBehaviour
{
    public GameObject DiscPrefab;
    

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 randomPosition  = new Vector3(Random.Range(-10, 11),5,Random.Range(-10, 11));
            Instantiate(DiscPrefab, randomPosition,Quaternion.identity);
        }
    }
}
