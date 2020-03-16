﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Prism.CommonDialogPack.Extensions
{
    public static class PathExtensions
    {
        /// <summary>
        /// <paramref name="encloseChar"/>で囲ってある内側の文字列を返す
        /// </summary>
        /// <param name="source"></param>
        /// <param name="encloseChar"></param>
        /// <returns></returns>
        public static IEnumerable<string> Unwind(this string source, char encloseChar)
        {
            bool isRange = false;
            var res = new List<char>();
            foreach (var c in source)
            {
                if (!isRange)
                {
                    isRange = c.Equals(encloseChar);
                    continue;
                }
                isRange = !c.Equals(encloseChar);
                if (isRange)
                    res.Add(c);
                else
                {
                    yield return string.Join(null, res);
                    res.Clear();
                }
            }
        }
    }
}
