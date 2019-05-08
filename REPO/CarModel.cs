using System;
using System.Collections.Generic;
using System.Text;

namespace REPO
{
    public class CarModel : ClassNotify
    {
        private string _carModelName;
        private int _carModelID;

        public CarModel()
        {

        }

        public int CarModelID
        {
            get { return _carModelID; }
            set
            {
                if (value != _carModelID)
                {
                    _carModelID = value;
                    Notify("carModelID");
                }
            }
        }

        public string carModelName
        {
            get { return _carModelName; }
            set
            {
                if (value != _carModelName)
                {
                    _carModelName = value;
                    Notify("carModelName");
                }
            }
        }
    }
}
