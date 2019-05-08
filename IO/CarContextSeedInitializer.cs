using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using REPO;

namespace IO
{
    public class CarContextSeedInitializer : DropCreateDatabaseIfModelChanges<CarContext>
    {
        IList<CarModel> defaultCarModel = new List<CarModel>();
        IList<Propellant> defaultPropellant = new List<Propellant>
        {
            new Propellant() { propellantName = "Benzin 95" },
            new Propellant() { propellantName = "Benzin 90" },
            new Propellant() { propellantName = "Diesel" },
            new Propellant() { propellantName = "Hybrid" },
            new Propellant() { propellantName = "Elektrisk" }
        };

        public CarContextSeedInitializer()
        {
            defaultCarModel.Add(new CarModel() { carModelName = "Ferrari" });
            defaultCarModel.Add(new CarModel() { carModelName = "Mercedes-Benz" });
            defaultCarModel.Add(new CarModel() { carModelName = "BMW" });
            defaultCarModel.Add(new CarModel() { carModelName = "Audi" });
            defaultCarModel.Add(new CarModel() { carModelName = "Volkswagen" });
            defaultCarModel.Add(new CarModel() { carModelName = "Ford" });
            defaultCarModel.Add(new CarModel() { carModelName = "Seat" });
            defaultCarModel.Add(new CarModel() { carModelName = "Suzuki" });
            defaultCarModel.Add(new CarModel() { carModelName = "Hyundai" });
            defaultCarModel.Add(new CarModel() { carModelName = "Nissan" });
            defaultCarModel.Add(new CarModel() { carModelName = "Aston Martin" });
            defaultCarModel.Add(new CarModel() { carModelName = "Toyota" });
            defaultCarModel.Add(new CarModel() { carModelName = "Porsche" });
            defaultCarModel.Add(new CarModel() { carModelName = "Lamborghini" });
            defaultCarModel.Add(new CarModel() { carModelName = "Maserati" });
            defaultCarModel.Add(new CarModel() { carModelName = "Bentley" });
            defaultCarModel.Add(new CarModel() { carModelName = "Honda" });
            defaultCarModel.Add(new CarModel() { carModelName = "Cadillac" });
            defaultCarModel.Add(new CarModel() { carModelName = "Chevrolet" });
            defaultCarModel.Add(new CarModel() { carModelName = "Rolls-Royce" });
            defaultCarModel.Add(new CarModel() { carModelName = "Bugatti" });
        }

        protected override void Seed(CarContext context)
        {
            foreach (CarModel carModel in defaultCarModel)
            {
                context.CarModel.Add(carModel);
            }

            foreach (Propellant propellant in defaultPropellant)
            {
                context.Propellant.Add(propellant);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
