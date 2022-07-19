using System.Collections.Generic;
using System.Data;

namespace ClassLibTeam01.Data.Framework
{
    public abstract class BaseResult
    {
        public int Rows { get; set; }
        public DataTable DataTable { get; set; }
        private List<string> errors = new List<string>();
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors => errors;

        public void AddErrors(string error)
        {
            errors.Add(error);
        }
    }
}