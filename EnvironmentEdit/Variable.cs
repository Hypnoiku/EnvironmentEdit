using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentEdit
{
    public class Data
    {
        public string DataString { get; set; }

        public Data(string DataString)
        {
            this.DataString = DataString;
        }
    }

    public class Variable
    {
        public string Name { get; }
        public List<Data> Data = new List<Data>();
        public int UserType { get; } //0 for user variable; 1 for system variable
        public bool Editing { get; set; }

        public Variable(string VariableName)
        {
            this.Name = VariableName;
            this.Editing = false;
        }

        public Variable(string VariableName, int UserType)
        {
            this.Name = VariableName;
            this.UserType = UserType;
            this.Editing = false;
        }

        public Variable(string VariableName, List<Data> VariableData, int UserType)
        {
            this.Name = VariableName;
            this.Data = VariableData;
            this.UserType = UserType;
            this.Editing = false;
        }
    }
}
