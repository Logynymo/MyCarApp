using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;
using IO;
using System.Windows;
using System.Data.Entity;
using System.Windows.Input;
using System.Data.SqlClient;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private CarContext getData = new CarContext();
        private ObservableCollection<Car> _Cars;
        private ObservableCollection<CarModel> _carModels;
        private ObservableCollection<Propellant> _propellants;
        private Car _selectedCar;


        public ClassBIZ()
        {
            Cars = new ObservableCollection<Car>(getData.Car.ToList());
            carModels = new ObservableCollection<CarModel>(getData.CarModel.ToList());
            propellants = new ObservableCollection<Propellant>(getData.Propellant.ToList());
            selectedCar = new Car();
        }



        public ObservableCollection<Car> Cars
        {
            get { return _Cars; }
            set
            {
                if (value != _Cars)
                {
                    _Cars = value;
                    Notify("Cars");
                }
            }
        }

        public ObservableCollection<CarModel> carModels
        {
            get { return _carModels; }
            set
            {
                if (value != _carModels)
                {
                    _carModels = value;
                    Notify("carModels");
                }
            }
        }

        public ObservableCollection<Propellant> propellants
        {
            get { return _propellants; }
            set
            {
                if (value != _propellants)
                {
                    _propellants = value;
                    Notify("propellants");
                }
            }
        }

        public Car selectedCar
        {
            get { return _selectedCar; }
            set
            {
                if (value != _selectedCar)
                {
                    _selectedCar = value;
                    Notify("selectedCar");
                }
            }
        }

        public void MakeDataBase()
        {
            try
            {
                using (CarContext ctx = new CarContext())
                {
                    ctx.Database.CreateIfNotExists();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var t in ex.EntityValidationErrors)
                {
                   MessageBox.Show(t.ValidationErrors.First().ErrorMessage);
                }
            }
        }

        public void SaveCar()
        {
            using (CarContext acx = new CarContext())
            {
                acx.Propellant.Attach(selectedCar.Propellant);
                acx.CarModel.Attach(selectedCar.CarModel);
                acx.Car.AddOrUpdate(selectedCar);
                acx.SaveChanges();
            }
            selectedCar = new Car();
            Cars.Clear();
            GetAllCars();
        }

        public void DeleteCar()
        {
            using (CarContext context = new CarContext())
            {
                context.Car.Attach(selectedCar);
                context.Car.Remove(selectedCar);
                context.SaveChanges();
            }
            selectedCar = new Car();
            Cars.Clear();
            GetAllCars();
        }

        public void GetAllCars()
        {
            using (CarContext acx = new CarContext())
            {
                List<Car> listCars = acx.Car
                    .Include("CarModel")
                    .Include("Propellant")
                    .ToList() as List<Car>;
                foreach (Car car in listCars)
                {
                    Cars.Add(car);
                }
            }
        }
    }
}
