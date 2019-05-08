using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace REPO
{
    public class Car : ClassNotify, ICloneable
    {
        private int _carID;
        private string _carName;
        private CarModel _carModel;
        private Propellant _propellant;
        public Car()
        {
            carID = 0;
            CarModel = new CarModel();
            Propellant = new Propellant();
        }

        public Car(Car toCopy)
        {
            carID = toCopy.carID;
            carName = toCopy.carName;
            CarModel = toCopy.CarModel;
            PropellantID = toCopy.PropellantID;
            
        }

        public int carID
        {
            get { return _carID; }
            set
            {
                if (value != _carID)
                {
                    _carID = value;
                    Notify("carID");
                }
            }
        }

        public string carName
        {
            get { return _carName; }
            set
            {
                if (value != _carName)
                {
                    _carName = value;
                    Notify("carName");
                }
            }
        }


        private string _licensePlate;

        public string licensePlate
        {
            get { return _licensePlate; }
            set
            {
                if (value != _licensePlate)
                {
                    _licensePlate = value;
                    Notify("licensePlate");
                }
            }
        }

        [ForeignKey("CarModel")]
        public int CarModelID { get; set; }
        public CarModel CarModel
        {
            get { return _carModel; }
            set
            {
                if (value != _carModel)
                {
                    _carModel = value;
                    if (_carModel != null)
                    {
                        CarModelID = _carModel.CarModelID;
                    }

                    Notify("CarModel");
                }
            }
        }

        [ForeignKey("Propellant")]
        public int PropellantID { get; set; }
        public Propellant Propellant
        {
            get { return _propellant; }
            set
            {
                if (value != _propellant)
                {
                    _propellant = value;
                    if (_propellant != null)
                    {
                        PropellantID = _propellant.propellantID;
                    }

                    Notify("Propellant");
                }
            }
        }

        public object Clone()
        {
            return new Car(this);
        }
    }
}
