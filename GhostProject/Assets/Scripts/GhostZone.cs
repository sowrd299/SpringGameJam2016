using UnityEngine;

[RequireComponent(typeof(GazeAwareComponent))]
public class GhostZone : MonoBehaviour
{
    private GazeAwareComponent _gazeAwareComponent;

    protected void Start()
    {
        _gazeAwareComponent = GetComponent<GazeAwareComponent>();
    }

    protected void Update()
    {
        if (_gazeAwareComponent.HasGaze)
        {
            if (Input.GetKeyDown("space"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
