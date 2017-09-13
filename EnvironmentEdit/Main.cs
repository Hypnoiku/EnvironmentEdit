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

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            RegistryController RegControl = new RegistryController();
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

                VariableListView.Items.Add(VariableItem);
            }
        }
    }
}
