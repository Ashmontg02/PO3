using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongController : MonoBehaviour
{
    public RawImage note1;
    public RawImage note2;
    public RawImage note3;
    public RawImage note4;

    public Texture purpleNote;
    public Texture blueNote;
    public Texture orangeNote;
    public Texture defaultTexture;

    public Text selfImprovement;
    public Text attackUp;
    public Text healthUp;
    public Text negateStamina;

    private HealthController HealthController;
    private CharacterController CharacterController;

    private List<string> notes = new List<string>();
    private string[] songs = new[]
{
   "TT", // SELF-IMPROVEMENT
   "TCCT", // ATTACK UP
   "BCTC", // HEALTH UP
   "TBCB" // NEGATE STAMINA
};

    public void storeNote(string note)
    {
        if(notes.Count == 4)
        {
            notes.RemoveAt(0);
        }
        notes.Add(note);
    }

    public void playSong()
    {
        var songToPlay = string.Join("", notes);
        notes.Clear();
        for (var song = 0; song < songs.Length; song++)
        {
            if (songToPlay == songs[song])
            {
                switch (song)
                {
                    case 0:
                        StartCoroutine("changeTextColor", selfImprovement);
                        StartCoroutine("changeMovementSpeed");
                        break;
                    case 1:
                        StartCoroutine("changeTextColor", attackUp);
                        break;
                    case 2:
                        StartCoroutine("changeTextColor", healthUp);
                        StartCoroutine("changeHealthValue");                        
                        break;
                    case 3:
                        StartCoroutine("changeTextColor", negateStamina);
                        StartCoroutine("changeStaminaValue");
                        break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthController = GetComponent<HealthController>();
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        note1.texture = defaultTexture;
        note2.texture = defaultTexture;
        note3.texture = defaultTexture;
        note4.texture = defaultTexture;
        if (notes.Count >= 1) note1.texture = getNoteTexture(notes[0]);
        if (notes.Count >= 2) note2.texture = getNoteTexture(notes[1]);
        if (notes.Count >= 3) note3.texture = getNoteTexture(notes[2]);
        if (notes.Count >= 4) note4.texture = getNoteTexture(notes[3]);
    }

    Texture getNoteTexture(string note)
    {
        switch (note)
        {
            case "T":return purpleNote;
            case "C":return blueNote;
            case "B":return orangeNote;
            default:return defaultTexture;
        }

    }

    IEnumerator changeTextColor(Text text)
    {
        yield return new WaitForSeconds(3.0f);
        text.color = Color.green;
        yield return new WaitForSeconds(5.0f);
        text.color = Color.white;
    }

    IEnumerator changeHealthValue()
    {
        yield return new WaitForSeconds(3.0f);
        HealthController.health = 100;
        yield return new WaitForSeconds(5.0f);
        HealthController.health = 50;
    }

    IEnumerator changeStaminaValue()
    {
        yield return new WaitForSeconds(3.0f);
        HealthController.stamina = 100;
        yield return new WaitForSeconds(5.0f);
        HealthController.stamina = 50;
    }

    IEnumerator changeMovementSpeed()
    {
        yield return new WaitForSeconds(3.0f);
        CharacterController.velocity = 10;
        yield return new WaitForSeconds(5.0f);
        CharacterController.velocity = 5;
    }
}
