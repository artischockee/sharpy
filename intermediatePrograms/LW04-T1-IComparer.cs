using System;
using System.Collections.Generic;

namespace LabWork04
{
    public class DepartureTimeComparer : IComparer<Train>
    {
        public int Compare(Train x, Train y)
        {
            string[] xDep = x.DepartureTime;
            string[] yDep = y.DepartureTime;

            int hourCmp = String.Compare(xDep[0], yDep[0]);
            int minuteCmp = String.Compare(xDep[1], yDep[1]);

            if (hourCmp != 0)
                return hourCmp;
            else
                return minuteCmp;
        }
    }
}
