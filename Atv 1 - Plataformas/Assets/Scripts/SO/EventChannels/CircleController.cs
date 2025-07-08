using UnityEngine;

public class CircleController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    [Header("Recebendo...")]
    public VoidEventChannel circleColorEvent;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        circleColorEvent.OnEventRaised += MudaCor;
    }
    
    private void OnDisable()
    {
        circleColorEvent.OnEventRaised -= MudaCor;
    }

    public void MudaCor()
    {
        _spriteRenderer.color = Random.ColorHSV();
    }
}
