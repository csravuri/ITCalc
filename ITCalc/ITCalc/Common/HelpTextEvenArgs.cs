using System;
using System.Collections.Generic;
using System.Text;

namespace ITCalc
{
    public class HelpTextEvenArgs : EventArgs
    {
        public string HelpText { get; }
        public HelpTextEvenArgs(string helpText)
        {
            HelpText = helpText;
        }
    }
}
