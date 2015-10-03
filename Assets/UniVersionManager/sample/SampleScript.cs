using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class SampleScript : MonoBehaviour
{
    [SerializeField] Text versionText;

    public void Start ()
    {
        versionText.text = UniVersionManager.GetVersion();
    }
}
