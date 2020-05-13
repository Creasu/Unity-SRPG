using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Part : IPart
{
    WeakReference owner = null;
    public IWhole whole
    {
        get { return owner != null ? owner.Target as IWhole : null; }
        set
        {
            owner = (value != null) ? new WeakReference(value) : null;
            Check();
        }
    }

    bool _allowed = true;
    public bool allowed
    {
        get { return _allowed; }
        set
        {
            if (_allowed == value)
                return;

            _allowed = value;
            Check();
        }
    }

    bool _running = false;
    bool _didAssemble = false;
    public bool running
    {
        get { return _running; }
        private set
        {
            if (_running == value)
                return;

            _running = value;
            if (_running)
            {
                if (!_didAssemble)
                {
                    _didAssemble = true;
                    Assemble();
                }
                Resume();
            }
            else
                Suspend();
        }
    }

    public void Check()
    {
        running = (allowed && whole != null && whole.running);
    }

    public virtual void Assemble()
    {

    }

    public virtual void Resume()
    {

    }

    public virtual void Suspend()
    {

    }

    public virtual void Disassemble()
    {

    }
}
