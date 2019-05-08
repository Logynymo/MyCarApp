using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REPO;

namespace IO
{
    public class EntityConfigurationPropellant : EntityTypeConfiguration<Propellant>
    {
        public EntityConfigurationPropellant()
        {
            this.ToTable("Propellant");

            this.HasKey<int>(p => p.propellantID);

            this.Property(p => p.propellantName)
                .HasMaxLength(25)
                .IsRequired();

        }
    }
}
