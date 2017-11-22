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

        public List<Variable> SetEdit(String Name, List<Variable> variables, bool EditorStatus)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (Name == variables[i].Name)
                {
                    variables[i] = SetEditor(variables[i], EditorStatus);
                    return variables;
                }
            }

            return ReturnVarNotFoundERR();
        }

        public Variable FindVariableInList(String Name, List<Variable> variables)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (Name == variables[i].Name)
                {
                    return variables[i];
                }
            }

            return new Variable("ERR_VAR_NOT_FOUND");
        }

        public List<Variable> ReturnVariableToList(List<Variable> variables, Variable variable)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[i].Editing)
                {
                    variables[i] = variable;
                    return variables;
                }
            }

            return ReturnVarNotFoundERR();
        }

        private Variable SetEditor(Variable variable, bool EditorStatus)
        {
            variable.Editing = EditorStatus;
            return variable;
        }

        private List<Variable> ReturnVarNotFoundERR()
        {
            List<Variable> errNotFound = new List<Variable>();
            errNotFound.Add(new Variable("ERR_VAR_NOT_FOUND"));
            return errNotFound;
        }

        public List<Variable> DeleteVar(List<Variable> variables, Variable variable)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                if (variable.Name == variables[i].Name)
                {
                    variables.RemoveAt(i);
                }
            }

            return variables;
        }

        public int FindPosInList(List<Variable> variables, Variable variable)
        {
            for(int i = 0; i < variables.Count; i++)
            {
                if (variable.Name == variables[i].Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public List<Variable> insertAt(List<Variable> variables, Variable variable, int pos)
        {
            variables.Insert(pos, variable);
            return variables;
        }

        public Variable SetName(Variable variable, string name)
        {
            variable.Name = name;
            return variable;
        }

        public Variable SetData(Variable variable, string RawData)
        {
            variable.Data.Clear();
            string data = null;
            for (int i = 0; i < RawData.Length; i++)
            {
                if (RawData[i] == ';')
                {
                    Data varData = new Data(data);
                    variable.Data.Add(varData);
                    data = null;
                }
                else
                {
                    data += RawData[i];

                    if (i == RawData.Length - 1)
                    {
                        Data varData = new Data(data);
                        variable.Data.Add(varData);
                    }
                }
            }

            return variable;
        }
    }
}
