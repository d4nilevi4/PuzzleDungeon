using Leontitas;
using PuzzleDungeon.Core.Logger;

namespace PuzzleDungeon.Gameplay;

public sealed class TestSystem : 
    IInitializeSystem, IFixedExecuteSystem, IPreExecuteSystem,
    IExecuteSystem, ILateExecuteSystem, ICleanupSystem, ITearDownSystem
{
    private readonly ILogger _logger;

    public TestSystem(
        ILogger logger
    )
    {
        _logger = logger;
    }

    public void Initialize()
    {
        _logger.LogInfo("TestSystem", "TestSystem Initialized");
    }

    public void FixedExecute()
    {
        _logger.LogInfo("TestSystem", "TestSystem FixedExecute");
    }

    public void PreExecute()
    {
        _logger.LogInfo("TestSystem", "TestSystem PreExecute");
    }

    public void Execute()
    {
        _logger.LogInfo("TestSystem", "TestSystem Execute");
    }

    public void LateExecute()
    {
        _logger.LogInfo("TestSystem", "TestSystem LateExecute");
    }

    public void Cleanup()
    {
        _logger.LogInfo("TestSystem", "TestSystem Cleanup");
    }

    public void TearDown()
    {
        _logger.LogInfo("TestSystem", "TestSystem TearDown");
    }
}