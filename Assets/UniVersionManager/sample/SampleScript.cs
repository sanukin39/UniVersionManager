using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class SampleScript : MonoBehaviour
{
    [SerializeField] Text versionText;
    [SerializeField] Text buildVersionText;

    public void Start ()
    {
        versionText.text = string.Format ("Version: {0}", UniVersionManager.GetVersion ());
        buildVersionText.text = string.Format ("Build Version: {0}", UniVersionManager.GetBuildVersion ());
    }
}
