using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateInputValidator : TMP_InputValidator
{
    public override char Validate(ref string text, ref int pos, char ch)
    {
        // Permitir apenas números e caracteres de barra (/)
        if (!char.IsDigit(ch) && ch != '/')
        {
            return (char)0;
        }

        // Limitar a entrada a 10 caracteres (formato DD/MM/YYYY)
        if (text.Length >= 10)
        {
            return (char)0;
        }

        // Inserir automaticamente uma barra (/) após o dia e o mês
        if ((pos == 2 || pos == 5) && ch != '/')
        {
            text = text.Insert(pos, "/");
            pos++;
        }

        // Permitir apenas a entrada de caracteres válidos
        if ((pos == 2 || pos == 5) && ch == '/')
        {
            text = text.Insert(pos, ch.ToString());
            pos++;
        }

        return ch;
    }
}
