using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord
{
    // For storing the notes of a chord
    public Note[] Notes;
    // The name of the Note the chord is made from
    public string Name;
    public ChordType Type;
    public Note Root;
    public Inversion Inversion;


    public Chord(Note note, ChordType ct)
    {
        
    }
    public Chord(Note[] notes)
    {
        Notes = notes;
        Root = Notes[(int)Inversion.Root];
    }

    public Chord(Note[] notes, Inversion inv)
    {
        Notes = notes;
        Inversion = inv;
        Root = Notes[(int)Inversion];
    }

    public void FindAndSetChordType(Chord chord)
    {
        
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

public enum Inversion
{
    Root,
    First,
    Second,
    Third,
}
