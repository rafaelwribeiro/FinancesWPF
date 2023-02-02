using FinancesWPF.Entities;
using FinancesWPF.Types;
using FluentNHibernate.Mapping;
using NHibernate.Engine;

namespace FinancesWPF.Mapping
{
    public class MovementMap : ClassMap<Movement>
    {
        
        public MovementMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Date);
            Map(x => x.Value);
            Map(x => x.Description);
            Map(x => x.Type).CustomType<NHibernate.Type.EnumCharType<MovementType>>();
            References(x => x.Category)
            .Column("CategoryId")
            .ForeignKey("FK_Movement_Category")
            .Cascade.All();

            Table("Movements");
        }
    }
}
