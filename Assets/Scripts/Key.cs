using System;using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class Key
{
    public static readonly string[] CircleOfFifths = new string[] { "C", "G", "D", "A", "E", "B", "Gb", "Db", "Ab", "Eb", "Bb", "F" };
    public static Keys currentKey = Keys.C;
    
    public static Text keyText;
    public static Text keyDetailsText;

    public static Degrees degrees;
    public static int[] DegreeID = new int[] {0, 2, 4, 5, 7, 9, 11};

    public static void SetKeyTo(Keys key)
    {
        currentKey = key;
    }

    public static void SetKeyTo(int key)
    {

        currentKey = (Keys)key;
        
        keyText = GameObject.Find("CurrentKeyText").GetComponent<Text>();
        keyText.text = "Current key: " + Key.CircleOfFifths[key];
        
        keyDetailsText = GameObject.Find("CurrentKeyDetailsText").GetComponent<Text>();
        keyDetailsText.text = "";
        for(int i = 0; i < Enum.GetNames(typeof(Degrees)).Length; i++)
        {
            keyDetailsText.text += Enum.GetName(typeof(Degrees), i) + "\t";
            keyDetailsText.text += Enum.GetName(typeof(Keys),((int)currentKey + (int)DegreeID[i]) % 12) + "\n";
        }
    }

    public static string GetCircleOfFifths(int key)
    {
        return CircleOfFifths[key];
    }

    public enum Degrees
    {
        I,
        ii,
        iii,
        IV,
        V,
        vi,
        vii
    }

    public enum Keys
    {
        C,
        Db,
        D,
        Eb,
        E,
        F,
        Gb,
        G,
        Ab,
        A,
        Bb,
        B
    }

    /*public enum Intervals
    {
        1,
        "b2",
        2,
        "b3",
        3,
        4,
        "T",
        5,
        "b6",
        6,
        "b7",
        7
    }*/
}

public static class Music
{
    //public static Note[] notes = new[] {};
}

public static class KeyLibrary
{
    public static readonly KeyRoot[] AllKeys = new KeyRoot[12];

    static KeyLibrary()
    {
        for (int i = 0; i < 12; i++)
        {
            AllKeys[i] = new KeyRoot(new Note(i));
        }
    }
}

public class Note
{
    // name[0] for flat, name[1] for sharp
    public readonly string[] Name = new string[2];
    public readonly int ID;
    public readonly bool Sign; // Does the note have a sign (# or b)?
    

    public Note(int id)
    {
        // if out of note range, wrap around to C again
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

public class Chord
{
    public string Name;
    public Note[] Notes;
    public ChordType chordType;

    public Note[] AvailableNotes;
    //public int ID;

    public Chord(int[] id)
    {
        Notes = new Note[id.Length];
        int positionInChord = 0;

        foreach(int noteID in id)
        {
            Notes[positionInChord] = new Note(noteID);
        
            positionInChord++;
        }
    }

    public Chord(int rootID, int numberOfNotes, ChordType chordType)
    {
        this.chordType = chordType;
        Notes = new Note[numberOfNotes];
        AvailableNotes = BuildAvailableNotes(chordType, rootID); // Gets all chord notes and extensions

        for (int i = 0; i < numberOfNotes; i++)
        {
            Notes[i] = AvailableNotes[i]; //Builds the chord note by note
        }
    }

    public enum ChordType
    {
        Maj,
        Min,
        Dom,
        Aug,
        Dim,
    }

    public Note[] BuildAvailableNotes(ChordType chordType, int rootID)
    {
        List<Note> builtNotes = new List<Note>();
        switch (chordType)
        {
            case ChordType.Maj:
                builtNotes.Add(new Note(rootID));
                builtNotes.Add(new Note(rootID + 4));
                builtNotes.Add(new Note(rootID + 7));
                builtNotes.Add(new Note(rootID + 11));
                builtNotes.Add(new Note(rootID + 14));
                builtNotes.Add(new Note(rootID + 17));
                builtNotes.Add(new Note(rootID + 21));
                return builtNotes.ToArray();
            case ChordType.Min:
                builtNotes.Add(new Note(rootID));
                builtNotes.Add(new Note(rootID + 3));
                builtNotes.Add(new Note(rootID + 7));
                builtNotes.Add(new Note(rootID + 10));
                builtNotes.Add(new Note(rootID + 14));
                builtNotes.Add(new Note(rootID + 17));
                builtNotes.Add(new Note(rootID + 21));
                return builtNotes.ToArray();
            case ChordType.Dom:
                builtNotes.Add(new Note(rootID));
                builtNotes.Add(new Note(rootID + 4));
                builtNotes.Add(new Note(rootID + 7));
                builtNotes.Add(new Note(rootID + 10));
                builtNotes.Add(new Note(rootID + 14));
                builtNotes.Add(new Note(rootID + 17));
                builtNotes.Add(new Note(rootID + 21));
                return builtNotes.ToArray();
            case ChordType.Aug:
                break;
            case ChordType.Dim:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(chordType), chordType, null);
        }
        return builtNotes.ToArray();
    }
}

public class KeyRoot
{
    public Note Root;
    public Note[] Notes = new Note[7];

    public KeyRoot(Note root)
    {
        Root = root;
        int magic = 0;
        for (int i = 0; i < 7; i++)
        {
            if (i > 2) magic = -1;
            Notes[i] = new Note(Root.ID + magic + (i * 2));
        }
    }
}
