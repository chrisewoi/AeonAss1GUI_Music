using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    // name[0] for flat, name[1] for sharp
    public string[] Name = new string[2];
    public int ID;
    public bool Sign; // Does the note have a sign (# or b)?
    public int Octave;
    


    public Note(int id)
    {
        BuildNote(id);
    }

    public Note(int id, int octave)
    {
        BuildNote(id * octave);
    }

    private void BuildNote(int id)
    {
        // Get Octave
        Octave = Mathf.FloorToInt(id % 12);
        ID = id % 12;
        switch (ID)
        {
            case 0:
                Name[0] = "C";
                Name[1] = "C";
                Sign = false;
                break;
            case 1:
                Name[0] = "Db";
                Name[1] = "C#";
                Sign = true;
                break;
            case 2:
                Name[0] = "D";
                Name[1] = "D";
                Sign = false;
                break;
            case 3:
                Name[0] = "Eb";
                Name[1] = "D#";
                Sign = true;
                break;
            case 4:
                Name[0] = "E";
                Name[1] = "E";
                Sign = false;
                break;
            case 5:
                Name[0] = "F";
                Name[1] = "F";
                Sign = false;
                break;
            case 6:
                Name[0] = "Gb";
                Name[1] = "F#";
                Sign = true;
                break;
            case 7:
                Name[0] = "G";
                Name[1] = "G";
                Sign = false;
                break;
            case 8:
                Name[0] = "Ab";
                Name[1] = "G#";
                Sign = true;
                break;
            case 9:
                Name[0] = "A";
                Name[1] = "A";
                Sign = false;
                break;
            case 10:
                Name[0] = "Bb";
                Name[1] = "A#";
                Sign = true;
                break;
            case 11:
                Name[0] = "B";
                Name[1] = "B";
                Sign = false;
                break;
        }
    }
}
