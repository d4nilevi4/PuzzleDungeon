using System.Collections.Generic;

namespace Leontitas;

public class CustomFeature : Feature, IFixedExecuteSystem, IPreExecuteSystem, ILateExecuteSystem
{
    private List<IFixedExecuteSystem> _fixedExecuteSystem = new ();
    private List<IPreExecuteSystem> _preExecuteSystem = new ();
    private List<ILateExecuteSystem> _lateExecuteSystem = new ();

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
        
        if (system is ILateExecuteSystem lateExecuteSystem)
        {
            _lateExecuteSystem.Add(lateExecuteSystem);
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
    
    public void LateExecute()
    {
        foreach (ILateExecuteSystem lateExecuteSystem in _lateExecuteSystem)
        {
            lateExecuteSystem.LateExecute();
        }
    }
}