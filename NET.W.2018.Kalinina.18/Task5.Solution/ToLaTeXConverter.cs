﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.Solution
{
    public class ToLaTeXConverter : ITextConverter
    {
        public string Convert(IEnumerable<DocumentPart> parts)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var part in parts)
            {
                switch (part.GetType().Name)
                {
                    case "BoldText":
                        builder.Append("\\textbf{" + part.Text + "}\n");
                        break;
                    case "Hyperlink":
                        builder.Append("\\href{" + ((Hyperlink)part).Url + "}{" + part.Text + "}\n");
                        break;
                    case "PlainText":
                        builder.Append(part.Text + "\n");
                        break;
                    default:
                        throw new ArgumentException("Type is not defined.");
                }
            }

            return builder.ToString();
        }
    }
}
