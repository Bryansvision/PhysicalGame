using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawningDiscs : MonoBehaviour
{
    public GameObject discPrefab;
    public GameObject spawnCube;
    public GameObject instanceDisc;
    public GameObject orbOne;
    public GameObject orbTwo;
    public GameObject orbThree;
    public GameObject wholeRig;
    public bool spawn = false;
    public bool alreadyrotate = false;
    public int rotation;

    private BoxCollider cubeCollider;

    void Start()
    {
        cubeCollider = spawnCube.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (spawn == false)
        {
            spawnCube.SetActive(true);

           StartCoroutine(spawningNow());
            rotation = Random.Range(0, 3);
        }

        switch (rotation) {
        case 0:
                if(alreadyrotate == false)
                wholeRig.transform.eulerAngles = new Vector3(0, 0, 90);
                alreadyrotate = true;
                break;
        case 1:
                if(alreadyrotate == false)
                    wholeRig.transform.eulerAngles = new Vector3(0, 0, 180);
                alreadyrotate = true;
                break;
            case 3:
                if(alreadyrotate == false)
                    wholeRig.transform.eulerAngles = new Vector3(0, 0, 270);
                break;
        }
        
    }

    void SpawningDisc()
    {
        Bounds bounds = cubeCollider.bounds;

        Vector3 spawnPosition = bounds.center;

        instanceDisc = Instantiate(discPrefab, spawnPosition, Quaternion.identity);

        instanceDisc.transform.Rotate(90, 0, 0);
    }

    IEnumerator spawningNow()
    {
        spawn = true;
        wholeRig.SetActive(true);
        orbOne.SetActive(false);
        orbTwo.SetActive(false);
        orbThree.SetActive(false);
        yield return new WaitForSeconds(1);
        spawnCube.SetActive(true);
        orbOne.SetActive(true);
        yield return new WaitForSeconds(1);
        orbTwo.SetActive(true);
        yield return new WaitForSeconds(1);
        orbThree.SetActive(true);
        yield return new WaitForSeconds(1);
        SpawningDisc();
        yield return new WaitForSeconds(5);
        spawn = false;
        alreadyrotate = false;
        Destroy(instanceDisc);
        wholeRig.SetActive(false);
        spawn = false;
        yield break;
    }
}