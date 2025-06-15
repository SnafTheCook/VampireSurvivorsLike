using System.Threading.Tasks;
using UnityEngine;

public class TurnRedOnDamage : HealthDamagedObserver
{
    private SkinnedMeshRenderer _meshRendererer;
    private Color _baseColor;
    private int colorId;
    private Task _currentTask = null;
    

    protected override void Awake()
    {
        base.Awake();
        colorId = Shader.PropertyToID("_BaseColor");
        _meshRendererer = GetComponentInChildren<SkinnedMeshRenderer>();
        _baseColor = _meshRendererer.materials[0].GetColor(colorId);
    }
    public override void ExecuteEffect()
    {
        if (destroyCancellationToken.IsCancellationRequested)
            return;

        if (_currentTask == null || _currentTask.IsCompleted)
            _currentTask = DoEffect();
    }

    private async Task DoEffect()
    {
        _meshRendererer.materials[0].SetColor(colorId, Color.red);
        await Awaitable.WaitForSecondsAsync(0.1f, destroyCancellationToken);
        _meshRendererer.materials[0].SetColor(colorId, _baseColor);
    }
}
