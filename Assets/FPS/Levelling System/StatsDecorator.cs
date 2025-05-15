public abstract class StatsDecorator : PlayerStats
{
    protected PlayerStats WrappedStats;

    public StatsDecorator(PlayerStats wrappedStats)
    {
        WrappedStats = wrappedStats;
    }

    public override float GetHealth() => WrappedStats.GetHealth();
    public override float GetSpeed() => WrappedStats.GetSpeed();
    public override float GetStrength() => WrappedStats.GetStrength();
}

// Increases health by a specified amount
public class HealthBuffDecorator : StatsDecorator
{
    private readonly float _extraHealth;

    public HealthBuffDecorator(PlayerStats wrappedStats, float extraHealth) : base(wrappedStats)
    {
        _extraHealth = extraHealth;
    }

    public override float GetHealth()
    {
        return base.GetHealth() + _extraHealth;
    }
}

public class SpeedBuffDecorator : StatsDecorator
{
    private readonly float _extraSpeed;

    public SpeedBuffDecorator(PlayerStats wrappedStats, float extraSpeed) : base(wrappedStats)
    {
        _extraSpeed = extraSpeed;
    }

    public override float GetSpeed()
    {
        return base.GetSpeed() + _extraSpeed;
    }
}

public class StrengthBuffDecorator : StatsDecorator
{
    private readonly float _extraStrength;

    public StrengthBuffDecorator(PlayerStats wrappedStats, float extraStrength) : base(wrappedStats)
    {
        _extraStrength = extraStrength;
    }

    public override float GetStrength()
    {
        return base.GetStrength() + _extraStrength;
    }
}
