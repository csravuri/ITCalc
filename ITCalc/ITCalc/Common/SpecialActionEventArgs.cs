using System;
using System.Collections.Generic;
using System.Text;

namespace ITCalc
{
    public class SpecialActionEventArgs : EventArgs
    {
        public string ControlName { get; }

        public SpecialActionEventArgs(string controlName)
        {
            ControlName = controlName;
        }
    }
}
