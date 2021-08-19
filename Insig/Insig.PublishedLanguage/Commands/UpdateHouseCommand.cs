using Insig.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.PublishedLanguage.Commands
{
    public class UpdateHouseCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SizeInMeters { get; set; }
        public bool SingleFloor { get; set; }
    }
}
