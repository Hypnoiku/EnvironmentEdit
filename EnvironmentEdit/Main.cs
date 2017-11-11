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
        VariableController VarControl = new VariableController();

        private bool DEBUGEdit = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MessageBox.Show(this, "EnvironmentEdit can only read variables currently!");
            LoadUserVariables();
            LoadSystemVariables();
        }

        private void LoadUserVariables()
        {
            UserVariables = RegControl.LoadUserFromRegistry();
            LoadVarListView(UserVariables, 0);
        }

        private void LoadSystemVariables()
        {
            SystemVariables = RegControl.LoadSystemFromRegistry();
            LoadVarListView(SystemVariables, 1);
        }

        //VarType = 0; User Variable
        //VarType = 1; System Variable
        private void LoadVarListView(List<Variable> Variables, int VarType)
        {
            for (int i = 0; i < Variables.Count; i++)
            {
                ListViewItem VariableItem = new ListViewItem(Variables[i].Name);

                string CombinedDataString = "";
                for (int j = 0; j < Variables[i].Data.Count; j++)
                {
                    CombinedDataString += Variables[i].Data[j].DataString;
                    CombinedDataString += ";";
                }
                VariableItem.SubItems.Add(CombinedDataString);

                if (DEBUGEdit)
                {
                    if (Variables[i].Editing)
                    {
                        VariableItem.SubItems.Add("TRUE");
                    }
                    else
                    {
                        VariableItem.SubItems.Add("FALSE");
                    }
                }

                VariableItem.Group = VariableListView.Groups[VarType];
                VariableListView.Items.Add(VariableItem);
            }
        }

        public void UpdateVarListView()
        {
            VariableListView.Items.Clear();
            LoadVarListView(UserVariables, 0);
            LoadVarListView(SystemVariables, 1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VariableListView_ItemActivate(object sender, EventArgs e)
        {
            VarEditGUI VEGUI = new VarEditGUI();
            if (VariableListView.SelectedItems[0].Group.Name == "UserVars")
            {
                UserVariables = VarControl.FindVariableSetEdit(VariableListView.SelectedItems[0].Text, UserVariables);
                VEGUI.SendToEditor(VarControl.FindVariableInList(VariableListView.SelectedItems[0].Text, UserVariables));
            }
            else if (VariableListView.SelectedItems[0].Group.Name == "SystemVars")
            {
                SystemVariables = VarControl.FindVariableSetEdit(VariableListView.SelectedItems[0].Text, SystemVariables);
                VEGUI.SendToEditor(VarControl.FindVariableInList(VariableListView.SelectedItems[0].Text, SystemVariables));
            }
            VEGUI.Show();
        }

        private void showEditingStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showEditingStatusToolStripMenuItem.Checked == false)
            {
                VariableListView.BeginUpdate();
                DEBUGEdit = true;
                VariableListView.Columns.Add("Editing?");
                UpdateVarListView();
                VariableListView.EndUpdate();

                showEditingStatusToolStripMenuItem.Checked = true;
            }
            else
            {
                VariableListView.BeginUpdate();
                DEBUGEdit = false;
                VariableListView.Columns.RemoveAt(2);
                UpdateVarListView();
                VariableListView.EndUpdate();

                showEditingStatusToolStripMenuItem.Checked = false;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VariableListView.BeginUpdate();
            UpdateVarListView();
            VariableListView.EndUpdate();
        }
    }
}
