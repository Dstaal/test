using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class QustonaireHandler : MonoBehaviour
{

    public static QustonaireHandler StaticRef;

    // public Button maleBnt;
    public Toggle mToogle;
    // public Button femaleBnt;
    public Toggle fToogle;
    // public Button ccontinuedBnt;
    public Dropdown ageDrop;
    public Toggle ageToggle;
    public InputField occupationIn;
    public Toggle oToggle;

    public Text notAllAveswered;

    string genderChossen = null;
    string ageChossen = null;
    string occupationAnswered = null;


    private float cTimer = 0;

    public string fileName = "myfile.csv";

    void Awake()
    {
        if (StaticRef == null) // if theres is not allerdaye a static ref makes this the static ref
        {
            DontDestroyOnLoad(gameObject);
            StaticRef = this;
        }
        else if (StaticRef != this) // is the allready is a ref , destory this
        {
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        //   mToogle = maleBnt.GetComponentInChildren<UnityEngine.UI.Toggle>();
        //   fToogle = femaleBnt.GetComponentInChildren<UnityEngine.UI.Toggle>();
    }

    // Update is called once per frame
    void Update()
    {

        cTimer = cTimer - Time.deltaTime;

        if (cTimer <= 0)
        {
            notAllAveswered.text = " ";
        }
    }

    public void maleClicked()
    {
        if (!mToogle.isOn)
        {
            mToogle.isOn = true;
            fToogle.isOn = false;
            genderChossen = "Male";
        }

    }

    public void femaleClicked()
    {
        if (!fToogle.isOn)
        {
            fToogle.isOn = true;
            mToogle.isOn = false;
            genderChossen = "Female";
        }

    }

    public void ageSelected()
    {
        if (ageDrop.value == 0 || ageDrop == null)
        {
            Debug.Log("age not chosen yet");
            ageToggle.isOn = false;
        }
        if (ageDrop.value != 0 && ageDrop != null)
        {
            ageToggle.isOn = true;
        }
        if (ageDrop.value == 1)
        {
            ageChossen = "18 - 25";
        }
        if (ageDrop.value == 2)
        {
            ageChossen = "26 - 30";
        }
        if (ageDrop.value == 3)
        {
            ageChossen = "31 - 35";
        }
        if (ageDrop.value == 4)
        {
            ageChossen = "36 - 40";
        }
        if (ageDrop.value == 5)
        {
            ageChossen = "40 - 50";
        }
        if (ageDrop.value == 6)
        {
            ageChossen = "50 +";
        }


    }

    public void continuedClick()
    {
        if (genderChossen == null)
        {
            Debug.Log("no gender choosen yet");
        }
        else if (genderChossen != null)
        {
            Debug.Log("genderChossen chosen = : " + genderChossen);
        }
        if (ageDrop.value == 0 || ageDrop == null)
        {
            Debug.Log("age not chosen yet");
        }
        else if (ageDrop.value != 0 || ageDrop != null)
        {
            Debug.Log("age chosen = : " + ageChossen);
        }
        if (occupationAnswered == null)
        {
            Debug.Log("no gender occupationAnswered yet");
        }
        else
        {
            Debug.Log("occupationAnswered is : " + occupationAnswered);
        }


        if (genderChossen == null || ageDrop.value == 0 || occupationIn == null)
        {
            notAllAveswered.text = ("plase anwser all the questions");
            cTimer = 2;

        }
        else
        {
            Debug.Log("contuinesd press and everying is selected. it's okey to contuines");

            saveToFile();
            Save();

            int rand = Random.Range(1, 101);

            if (rand <= 50)
            {
                GameController_script.StaticRef.currentScenario = GameController_script.scenario.scenario_C;
                GameController_script.StaticRef.currentState = GameController_script.State.starting;
            }
            else
            {
                GameController_script.StaticRef.currentScenario = GameController_script.scenario.scenario_R;
                GameController_script.StaticRef.currentState = GameController_script.State.starting;
            }

            GameController_script.StaticRef.demograhpicQuestion.alpha = 0;
            GameController_script.StaticRef.demograhpicQuestion.blocksRaycasts = false;
            GameController_script.StaticRef.demograhpicQuestion.interactable = false;

        }


    }

    public void occupationInExit()
    {
        occupationAnswered = occupationIn.text;

        if (occupationIn.text != null && occupationIn.text != "" && occupationIn.text != " " && occupationIn.text != "  " && occupationIn.text != "   " && occupationIn.text != "    " && occupationIn.text != "     " && occupationIn.text != "      ")
        {
            oToggle.isOn = true;
        }
        else
        {
            oToggle.isOn = false;
        }
    }

    public void saveToFile()
    {
        string filePath = Application.persistentDataPath + "\test_data.txt";

        File.WriteAllText("\test_data.txt", "This is text that goes into the text file");
        //   System.IO.File.WriteAllText(Application.persistentDataPath + "/test_data2.txt", "This is text that goes into the text file");
        //  System.IO.File.WriteAllText(Application.persistentDataPath + "\test_data3.csv", "This is text that goes into the text file");
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/test_data4.csv", "This is text that goes into the text file");

        Debug.Log("tryed to save");
    }


    void Save()
    {

        var path = Path.Combine(Application.dataPath, this.fileName);
        Debug.Log(string.Concat("Creating file at: ", path));

        using (var file = File.CreateText(path))
        {
            file.WriteLine("first-value,");
            file.WriteLine("43,");
            file.WriteLine("44,");
            file.WriteLine("4536.65443");
        }
    }

}



