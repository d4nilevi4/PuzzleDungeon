using System.Collections.Generic;

namespace Leontitas;

public class CustomFeature : Feature, IFixedExecuteSystem, IPreExecuteSystem
{
    private List<IFixedExecuteSystem> _fixedExecuteSystem = new ();
    private List<IPreExecuteSystem> _preExecuteSystem = new ();

    public override void Add(ISystem system)
    {
        base.Add(system);
        
        if (system is IFixedExecuteSystem fixedExecuteSystem)
        {
            _fixedExecuteSystem.Add(fixedExecuteSystem);
        }
        
        if (system is IPreExecuteSystem preExecuteSystem)
        {
            _preExecuteSystem.Add(preExecuteSystem);
        }
    }

    public void FixedExecute()
    {
        foreach (IFixedExecuteSystem fixedExecuteSystem in _fixedExecuteSystem)
        {
            fixedExecuteSystem.FixedExecute();
        }
    }

    public void PreExecute()
    {
        foreach (IPreExecuteSystem preExecuteSystem in _preExecuteSystem)
        {
            preExecuteSystem.PreExecute();
        }
    }
}