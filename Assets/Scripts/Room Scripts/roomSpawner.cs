using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawner : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab;
    [SerializeField] List<GameObject> elementList;
    [SerializeField] List<int> elementNumberMean;
    [SerializeField] List<int> elementNumberVariance;
    void Start()
    {
        //se inicializa la habitacion
        var roomInstance = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, transform);

        //por cada elemento de roomSpawner se inicializa en la habitacion
        elementSpawner roomScript = roomInstance.GetComponent<elementSpawner>();
        for(int i=0; i<elementList.Count; i++)
        {
            int number = Random.Range(elementNumberMean[i] - elementNumberVariance[i], elementNumberMean[i] + elementNumberVariance[i]);
            roomScript.initializeElement(elementList[i], roomInstance.transform, number);
        }
    }
}
