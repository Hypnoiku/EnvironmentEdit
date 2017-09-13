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
        private List<Variable> UserVariables;
        private List<Variable> SystemVariables;
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
            UserVariables = RegControl.LoadUserFromRegistry();

            for (int i = 0; i < UserVariables.Count; i++)
            {
                ListViewItem VariableItem = new ListViewItem(UserVariables[i].Name);

                string CombinedDataString = "";
                for (int j = 0; j < UserVariables[i].Data.Count; j++)
                {
                    CombinedDataString += UserVariables[i].Data[j].DataString;
                    CombinedDataString += ";";
                }
                VariableItem.SubItems.Add(CombinedDataString);
                VariableItem.Group = VariableListView.Groups[0];
                VariableListView.Items.Add(VariableItem);
            }
        }

        private void LoadSystemVariables()
        {
            SystemVariables = RegControl.LoadSystemFromRegistry();

            for (int i = 0; i < SystemVariables.Count; i++)
            {
                ListViewItem VariableItem = new ListViewItem(SystemVariables[i].Name);

                string CombinedDataString = "";
                for (int j = 0; j < SystemVariables[i].Data.Count; j++)
                {
                    CombinedDataString += SystemVariables[i].Data[j].DataString;
                    CombinedDataString += ";";
                }
                VariableItem.SubItems.Add(CombinedDataString);
                VariableItem.Group = VariableListView.Groups[1];
                VariableListView.Items.Add(VariableItem);
            }
        }
    }
}
