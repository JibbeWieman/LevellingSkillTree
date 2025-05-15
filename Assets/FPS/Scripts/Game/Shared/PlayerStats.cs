using Unity.FPS.Game;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Health m_Health;

    public float BaseHealth { get; private set; } = 100;
    public float BaseSpeed { get; private set; } = 5f;
    public float BaseStrength { get; private set; } = 10f;

    public virtual float GetHealth() => BaseHealth;
    public virtual float GetSpeed() => BaseSpeed;
    public virtual float GetStrength() => BaseStrength;
}
