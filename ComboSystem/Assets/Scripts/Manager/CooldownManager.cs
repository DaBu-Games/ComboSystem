using UnityEngine;

public class CooldownManager
{
    private float _lastUsedTime = 0f;
    private float _cooldownDuration = 0f;
    private bool _isOnCooldown = false;

    public void StartCooldown(float duration)
    {
        _lastUsedTime = Time.time;
        _cooldownDuration = duration;
        _isOnCooldown = true;
    }

    public bool IsOnCooldown()
    {
        if (!_isOnCooldown)
            return _isOnCooldown;

        if (Time.time - _lastUsedTime >= _cooldownDuration)
        {
            _isOnCooldown = false;
            return _isOnCooldown;
        }
        return true;
    }
}
