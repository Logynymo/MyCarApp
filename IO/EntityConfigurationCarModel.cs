using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    public class EntityConfigurationCarModel : EntityTypeConfiguration<CarModel>
    {
        public EntityConfigurationCarModel()
        {
            this.ToTable("CarModel");

            this.HasKey<int>(c => c.CarModelID);

            this.Property(g => g.carModelName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
