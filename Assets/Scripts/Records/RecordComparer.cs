using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordComparer : IComparer<SRecord>
{
    public int Compare(SRecord r1, SRecord r2)
    {
        if (r1.Score < r2.Score)
        {
            return 1;
        }

        if (r1.Score > r2.Score)
        {
            return -1;
        }

        return 0;
    }
}
