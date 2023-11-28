using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GameManage : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeablePrefabs;
    private bool hasExecuted1 = false;
    private bool hasExecuted2 = false;
    private bool hasExecuted3 = false;
    private bool hasExecuted4 = false;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    public ARTrackedImageManager trackedImageManager;

    GameObject animalPrefab;

    private void Awake()
    {
        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void Update()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage trackedImage in obj.added)
        {
            switch (trackedImage.referenceImage.name)
            {
                case "f15":
                    Instantiate(placeablePrefabs[0], trackedImage.transform);
                    break;
                case "c5":
                    Instantiate(placeablePrefabs[1], trackedImage.transform);
                    break;
                case "c17":
                    Instantiate(placeablePrefabs[2], trackedImage.transform);
                    break;
                case "c130":
                    Instantiate(placeablePrefabs[3], trackedImage.transform);
                    break;
            }
        }
        foreach (ARTrackedImage trackedImage in obj.updated)
        {
            //UpdateImage(trackedImage);
            switch (trackedImage.referenceImage.name)
            {
                case "f15":
                    if (!hasExecuted1)
                    {
                        animalPrefab = spawnedPrefabs["f15"];
                        trackedImage.transform.Rotate(-90f, 180f, 0);
                        animalPrefab.transform.rotation = trackedImage.transform.rotation;
                        animalPrefab.transform.position = trackedImage.transform.position;
                        animalPrefab.SetActive(true);
                        animalPrefab.SetActive(true);
                        hasExecuted1 = true;
                    }
                    break;
                case "c5":
                    if (!hasExecuted2)
                    {
                        animalPrefab = spawnedPrefabs["c5"];
                        trackedImage.transform.Rotate(-90f, 180f, 0);
                        animalPrefab.transform.rotation = trackedImage.transform.rotation;
                        animalPrefab.transform.position = trackedImage.transform.position;
                        animalPrefab.SetActive(true);
                        hasExecuted2 = true;
                    }
                    break;
                case "c17":
                    if (!hasExecuted3)
                    {
                        animalPrefab = spawnedPrefabs["c17"];
                        trackedImage.transform.Rotate(-90f, 180f, 0);
                        animalPrefab.transform.rotation = trackedImage.transform.rotation;
                        animalPrefab.transform.position = trackedImage.transform.position;
                        animalPrefab.SetActive(true);
                        hasExecuted3 = true;
                    }
                    break;
                case "c130":
                    if (!hasExecuted4)
                    {
                        animalPrefab = spawnedPrefabs["c130"];
                        trackedImage.transform.Rotate(-90f, 180f, 0);
                        animalPrefab.transform.rotation = trackedImage.transform.rotation;
                        animalPrefab.transform.position = trackedImage.transform.position;
                        animalPrefab.SetActive(true);
                        hasExecuted4 = true;
                    }
                    break;
            }
        }
        foreach (ARTrackedImage trackedImage in obj.removed)
        {
            spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
        }
    }
}