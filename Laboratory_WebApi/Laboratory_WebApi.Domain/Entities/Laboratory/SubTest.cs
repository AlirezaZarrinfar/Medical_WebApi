using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Domain.Entities.Laboratory
{
    public class SubTest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public TestsGroup TestsGroup { get; set; }
        public long TestsGroupId { get; set; }
    }
}
