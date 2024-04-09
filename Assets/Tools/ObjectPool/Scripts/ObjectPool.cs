using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _numberOfObjects;

    private List<GameObject> _objects = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < _numberOfObjects; i++)
        {
            var obj = Instantiate(_prefab);
            obj.SetActive(false);
            _objects.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (var obj in _objects)
        {
            if(!obj.activeSelf)
            {
                return obj;
            }
        }

        var newObject = Instantiate(_prefab);
        newObject.SetActive(false);
        _objects.Add(newObject);

        return newObject;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
