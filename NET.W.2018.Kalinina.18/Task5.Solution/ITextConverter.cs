﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public interface ITextConverter
    {
        string Convert(IEnumerable<DocumentPart> parts);
    }
}
