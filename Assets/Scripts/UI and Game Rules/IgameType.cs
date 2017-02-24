using UnityEngine;
using System.Collections;

public interface IgameType{
    string getGameType();
    void incScore(ThrowObj thrown);
    int getScore();
}