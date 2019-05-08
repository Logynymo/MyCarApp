using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using REPO;

namespace IO
{
    public class EntityConfigurationCar : EntityTypeConfiguration<Car>
    {
        public EntityConfigurationCar()
        {
            this.ToTable("Cars");

            this.HasKey<int>(c => c.carID);

            this.Property(c => c.carName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.PropellantID)
                .IsRequired();

            this.Property(c => c.CarModelID)
                .IsRequired();
        }
    }
}
