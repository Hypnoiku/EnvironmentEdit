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

            for (int i = 0; i < NameStrings.Length; i++)
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

        public Variable FindVariableInList(String Name, List<Variable> variables, bool SetEdit)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (Name == variables[i].Name)
                {
                    if (SetEdit)
                    {
                        variables[i] = SetEditor(variables[i], true);
                    }
                    else
                    {
                        return variables[i];
                    }

                }
            }

            return new Variable("ERR_VAR_NOT_FOUND");
        }

        public List<Variable> ReturnVariableToList(List<Variable> variables, Variable variable)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Editing = true)
                {
                    variable = SetEditor(variable, false);
                    variables[i] = variable;
                    return variables;
                }
            }

            List<Variable> errNotFound = new List<Variable>();
            errNotFound.Add(new Variable("ERR_VAR_NOT_FOUND"));
            return errNotFound;
        }

        private Variable SetEditor(Variable variable, bool EditorStatus)
        {
            variable.Editing = EditorStatus;
            return variable;
        }
    }
}
