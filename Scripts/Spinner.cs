
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinSpeed=500;

    [SerializeField] [Range(min: -1, max: 1)]
    private int spinDirection=1;
    void Update()
    {
        transform.Rotate(0f,0f,spinDirection*spinSpeed*Time.deltaTime,Space.Self);
    }
}
