using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentEdit
{
    class VariableController
    {
        public List<Variable> CreateListOfVariables(String[] NameStrings, String[] DataStrings, int UserType)
        {
            List<Variable> variables = new List<Variable>();

            for(int i = 0; i < NameStrings.Length; i++)
            {
                String[] vDataStrings = DataStrings[i].Split(';');
                List<Data> varData = new List<Data>();

                for (int j = 0; j < vDataStrings.Length; j++)
                {
                    Data data = new Data(vDataStrings[j]);
                    varData.Add(data);
                }

                Variable variable = new Variable(NameStrings[i], varData, UserType);
                variables.Add(variable);
            }
            return variables;
        }
    }
}
