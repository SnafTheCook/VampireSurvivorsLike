using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;

public class TurnRedOnDamage : HealthDamagedObserver
{
    private SkinnedMeshRenderer _meshRendererer;
    private Color _baseColor;
    private int colorId;
    private Task _currentTask = null;
    private List<Material> _materialsList = new List<Material>();
    

    protected override void Awake()
    {
        base.Awake();
        colorId = Shader.PropertyToID("_BaseColor");
        _meshRendererer = GetComponentInChildren<SkinnedMeshRenderer>();
        _meshRendererer.GetMaterials(_materialsList);
        _baseColor = _materialsList[0].GetColor(colorId);
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
        _materialsList[0].SetColor(colorId, Color.red);
        await Awaitable.WaitForSecondsAsync(0.1f, destroyCancellationToken);
        _materialsList[0].SetColor(colorId, _baseColor);
    }
}
