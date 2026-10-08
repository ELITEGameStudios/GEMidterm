using System.Collections.Generic;
using UnityEngine;
public class ObjectPooler : MonoBehaviour {
    
    public static ObjectPooler Instance {get; private set;}

    [SerializeField] private Bubble bubblePrefab;
    private List<Bubble> bubblePool;
    [SerializeField] private float bubbleObjectsCount = 10;

    void Awake()
    {
        if(Instance == null){Instance = this;}
        else if(Instance != this){Destroy(this);}
        SetupBubbleObjects();
    }

    void SetupBubbleObjects()
    {
        bubblePool = new();
        for (int i = 0; i < bubbleObjectsCount; i++)
        {
            bubblePool.Add(Instantiate(bubblePrefab, transform.position, transform.rotation));
            bubblePool[i].gameObject.SetActive(false);
        }
    }

    public Bubble GetBubble()
    {
        for (int i = 0; i < bubblePool.Count; i++)
        {
            if (!bubblePool[i].gameObject.activeInHierarchy)
            {
                return bubblePool[i];
            }
        }

        return null;
    }



}