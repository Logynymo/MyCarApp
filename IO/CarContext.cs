using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using REPO;

namespace IO
{
    public class CarContext : DbContext
    {
        public CarContext() : base("EntityCarDB")
        {
            Database.SetInitializer(new CarContextSeedInitializer());
        }
        
        // DbSets representing the tables of the database.
        public DbSet<Car> Car { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Propellant> Propellant { get; set; }
        /// <summary>
        /// Overridden Method.
        /// Adds configurations to the Entities.
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EntityConfigurationCarModel());
            modelBuilder.Configurations.Add(new EntityConfigurationPropellant());
            modelBuilder.Configurations.Add(new EntityConfigurationCar());
        }
    }
}
