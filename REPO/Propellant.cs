using System;
using System.Collections.Generic;
using System.Text;

namespace REPO
{
    public class Propellant : ClassNotify
    {
        public Propellant()
        {

        }

        private int _propellantID;
        private string _propellantName;

        public int propellantID
        {
            get { return _propellantID; }
            set
            {
                if (value != _propellantID)
                {
                    _propellantID = value;
                    Notify("propellantID");
                }
            }
        }


        public string propellantName
        {
            get { return _propellantName; }
            set
            {
                if (value != _propellantName)
                {
                    _propellantName = value;
                    Notify("propellantName");
                }
            }
        }

    }
}
