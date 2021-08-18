using Insig.Common.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.PublishedLanguage.Commands
{
    public class DeleteHouseCommand : ICommand
    {
        public string Name { get; set; }
    }
}
