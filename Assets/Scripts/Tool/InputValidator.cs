using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace Scripts.InterfaceTool
{
    [CreateAssetMenu(fileName = "Input Field Validator", menuName = "Input Field Validator")]
    public class InputValidator : TMP_InputValidator
    {
        public string pattern = @"";
        public int characterLimit;
        public override char Validate(ref string text, ref int pos, char ch)
        {
            if (Regex.IsMatch(ch.ToString(), pattern))
            {
                if(text.Length >= characterLimit)return ch;
                text = text.Insert(pos, ch.ToString());
                pos++;
                return ch;
            }
            return ch;
        }
    }
}