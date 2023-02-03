using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinancesWPF.Validators
{
    public interface ICustomValidator
    {
        void Validate<T>(T entity);
    }
}
