using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentEdit
{
    class Data
    {
        public string DataString { get; set; }

        public Data(string DataString)
        {
            this.DataString = DataString;
        }
    }

    class Variable
    {
        public string Name { get; set; }
        public List<Data> Data = new List<Data>();
        public int UserType { get; set; } //0 for user variable; 1 for system variable

        public Variable(string VariableName)
        {
            this.Name = VariableName;
        }

        public Variable(string VariableName, int UserType)
        {
            this.Name = VariableName;
            this.UserType = UserType;
        }

        public Variable(string VariableName, List<Data> VariableData, int UserType)
        {
            this.Name = VariableName;
            this.Data = VariableData;
            this.UserType = UserType;
        }
    }
}
