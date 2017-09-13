using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace EnvironmentEdit
{
    class RegistryController
    {
        public List<Variable> LoadUserFromRegistry()
        {
            RegistryKey EnvironmentKey = Registry.CurrentUser.OpenSubKey("Environment");
            String[] VarNames = EnvironmentKey.GetValueNames();
            String[] VarData = KeyDataToArray(EnvironmentKey, VarNames);

            VariableController varControl = new VariableController();;

            List<Variable> variables = varControl.CreateListOfVariables(VarNames, VarData, 0);

            return variables;
        }

        public List<Variable> LoadSystemFromRegistry()
        {
            RegistryKey EnvironmentKey =
                Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Environment");
            String[] VarNames = EnvironmentKey.GetValueNames();
            String[] VarData = KeyDataToArray(EnvironmentKey, VarNames);

            VariableController varControl = new VariableController(); ;

            List<Variable> variables = varControl.CreateListOfVariables(VarNames, VarData, 0);

            return variables;
        }

        private String[] KeyDataToArray(RegistryKey key, String[] VarNames)
        {
            String[] KeyList = new String[key.ValueCount];

            for (int i = 0; i < key.ValueCount; i++)
            {
                KeyList[i] = (String) key.GetValue(VarNames[i]);
            }

            return KeyList;
        }
    }
}
