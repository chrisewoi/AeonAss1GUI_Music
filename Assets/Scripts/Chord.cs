using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chord
{
    // For storing the notes of a chord
    public Note[] notes;
    public string name;
    public ChordType type;
}
public enum ChordType
{
    Maj,
    Min,
    Dom,
    Aug,
    Dim,
}
