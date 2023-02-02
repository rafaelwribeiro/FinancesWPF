using FinancesWPF.Entities;
using FluentNHibernate.Mapping;

namespace FinancesWPF.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Table("Categories");
        }
    }
}
