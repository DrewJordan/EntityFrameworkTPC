using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInheritanceTest
{
    public abstract class DataFileParent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int MyDataField { get; set; }
        public string MyOtherDataField { get; set; }
    }
}
