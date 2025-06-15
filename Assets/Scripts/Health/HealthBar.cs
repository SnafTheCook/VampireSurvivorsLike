using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static Camera mainCam;

    [SerializeField] private HealthBarData _healthBarData;
    private Slider _slider;
    [System.NonSerialized] public Transform targetTransform;

    private float _targetValue = 100;
    

    private void OnEnable()
    {
        if (mainCam == null)
            mainCam = Camera.main;

        _slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        UpdateHealthBarPosition();
        UpdateHealthValueOverTime();
    }

    public void UpdateHealthBar(int percent)
    {
        _targetValue = percent;
    }

    private void UpdateHealthValueOverTime()
    {
        if (_slider.value != _targetValue)
        _slider.value = Mathf.Lerp(_slider.value, _targetValue, _healthBarData.changeSpeed * Time.deltaTime);
    }

    private void UpdateHealthBarPosition()
    {
        Vector3 newPosition = Vector3.Lerp(gameObject.transform.position, mainCam.WorldToScreenPoint(targetTransform.position) + new Vector3(0, _healthBarData.offset, 0), 1f * Time.deltaTime);
        gameObject.transform.position = newPosition;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}

[System.Serializable]
public struct HealthBarData
{
    public float offset;
    public float changeSpeed;
}
