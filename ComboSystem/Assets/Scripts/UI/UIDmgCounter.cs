using TMPro;
using UnityEngine;

public class UIDmgCounter : IObserver
{
    private float dmgCounter = 0;
    private TextMeshProUGUI textField;

    public UIDmgCounter(TextMeshProUGUI textField)
    {
        this.textField = textField;
    }
    
    public void Update(ISubject subject, float dmg)
    {
        dmgCounter += dmg;
        textField.text = dmgCounter.ToString();
    }
}
