using UnityEngine;

public class Bubble : MonoBehaviour {

    public enum BehaviourType
    {
        RED,
        BLUE,
        GREEN
    }

    [SerializeField] SpriteRenderer sprite;
    [SerializeField] BehaviourType bType;
    [SerializeField] Vector2 initPos;
    [SerializeField] float timer, varTimer, direction;

    public void Setup(Color color, BehaviourType behaviourType, float time, Vector2 position, float faceDir)
    {
        sprite.color = color;
        bType = behaviourType;
        timer = time;
        varTimer = 0;
        initPos = position;
        transform.position = position;
        direction = faceDir;
    }    

    public void Update()
    {
        if(timer <= 0) gameObject.SetActive(false);
        switch (bType)
        {
            case BehaviourType.RED:
                transform.position += Vector3.right * direction * Time.deltaTime;
                break;
            case BehaviourType.GREEN:
                transform.position += Vector3.right * direction + Vector3.up * Mathf.Pow(varTimer, 2);
                break;
            // blue stays stationary
        }


        timer -= Time.deltaTime;

    }
}