using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

class HighScore : IComparable<HighScore>
{
    public int score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public HighScore(int id, int score, string name) {

        this.score = score;
        this.Name = name;
        this.ID = id;
    }

    public int CompareTo(HighScore other)
    {
        if (other.score < this.score)
        {

            return -1;
        }
        else if (other.score > this.score) {

            return 1;
        }

        return 0;
    }
}
