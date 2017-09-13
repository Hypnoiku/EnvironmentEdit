using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvironmentEdit
{
    public partial class Main : Form
    {
        private List<Variable> variables;
        RegistryController RegControl = new RegistryController();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadUserVariables();
            LoadSystemVariables();
        }

        private void LoadUserVariables()
        {
            variables = RegControl.LoadUserFromRegistry();

            for (int i = 0; i < variables.Count; i++)
            {
                ListViewItem VariableItem = new ListViewItem(variables[i].Name);

                string CombinedDataString = "";
                for (int j = 0; j < variables[i].Data.Count; j++)
                {
                    CombinedDataString += variables[i].Data[j].DataString;
                    CombinedDataString += ";";
                }
                VariableItem.SubItems.Add(CombinedDataString);
                VariableItem.Group = VariableListView.Groups[0];
                VariableListView.Items.Add(VariableItem);
            }
        }

        private void LoadSystemVariables()
        {
            variables = RegControl.LoadSystemFromRegistry();

            for (int i = 0; i < variables.Count; i++)
            {
                ListViewItem VariableItem = new ListViewItem(variables[i].Name);

                string CombinedDataString = "";
                for (int j = 0; j < variables[i].Data.Count; j++)
                {
                    CombinedDataString += variables[i].Data[j].DataString;
                    CombinedDataString += ";";
                }
                VariableItem.SubItems.Add(CombinedDataString);
                VariableItem.Group = VariableListView.Groups[1];
                VariableListView.Items.Add(VariableItem);
            }
        }
    }
}
