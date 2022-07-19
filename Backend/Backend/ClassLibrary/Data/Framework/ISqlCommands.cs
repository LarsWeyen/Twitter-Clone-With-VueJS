using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam01.Data.Framework
{
    internal interface ISqlCommands<T>
    {
        SelectResult Select();
        InsertResult Insert(T t);
        
    }
}
