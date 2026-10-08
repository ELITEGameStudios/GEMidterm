using UnityEngine;

public class BlueBubbleSpawner :MonoBehaviour, IBubbleSpawner 
{
    public Color bubbleColor;
    public float time = 5;

    public void SpawnBubble(float directionVal, Vector2 position)
    {
        Bubble bubble = ObjectPooler.Instance.GetBubble();
        bubble.Setup(bubbleColor, Bubble.BehaviourType.BLUE, time, position, directionVal);
    }
}