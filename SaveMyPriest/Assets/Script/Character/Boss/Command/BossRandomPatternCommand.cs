using UnityEngine;

public class BossRandomPatternCommand : ICommand
{
    private BossContext _bossContext;
    private int _pattern;

    public BossRandomPatternCommand(BossContext bossContext,int pattern)
    {
        _bossContext = bossContext;
        _pattern = pattern;
    }

    public void Execute()
    {
        _bossContext.NumberOfRandomPattern(_pattern);
    }
}
