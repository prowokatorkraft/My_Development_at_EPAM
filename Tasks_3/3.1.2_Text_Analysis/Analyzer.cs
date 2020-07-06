﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _3._1._2_Text_Analysis
{
    internal class Analyzer
    {
        protected Dictionary<string, int> _words;

        public EnumСondition Condition { get; protected set; }

        public Analyzer(string str)
        {
            _words = new Dictionary<string, int>();

            GroupWords(str);
            СalculateCondition();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in _words)
            {
                if (item.Value > 1)
                {
                    builder.AppendLine($"{item.Key} ({item.Value})");
                }
            }

            builder.AppendLine($"Condition: {Condition}");

            return builder.ToString();
        }

        private void GroupWords(string str)
        {
            string[] array = str.ToLower().Split(
                new string[] { Environment.NewLine, " ", ".", ",", "!", "?", "<", ">", "(", ")", "'", "\"", },
                StringSplitOptions.RemoveEmptyEntries
                );

            foreach (var item in array)
            {
                if (_words.ContainsKey(item))
                {
                    _words[item]++;
                }
                else
                {
                    _words[item] = 1;
                }
            }
        }
        private void СalculateCondition()
        {
            double _count = _words.Sum(d => d.Value);

            if (_count / _words.Count < 1.2)
            {
                Condition = EnumСondition.Manifold;
            }
            else if (_count / _words.Count > 1.2)
            {
                Condition = EnumСondition.Monotony;
            }
            else if (_count / _words.Count <= 0)
            {
                Condition = EnumСondition.None;
            }
        }
    }
}
