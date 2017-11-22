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
    public partial class VarEditGUI : Form
    {
        private Main masterForm;
        private Variable variable;
        private Variable oldVar;
        VariableController VarControl = new VariableController();

        public VarEditGUI(Main main)
        {
            masterForm = main;
            InitializeComponent();
        }

        private void VarEditGUI_Load(object sender, EventArgs e)
        {

        }

        public void SendToEditor(Variable newVar)
        {
            variable = newVar;
            oldVar = newVar;

            if (variable.Editing == false)
            {
                MessageBox.Show(this, "Variable, " + variable.Name + ", not prepared for editing.");
                this.Close();
                return;
            }

            LoadEditor();
        }

        private void LoadEditor()
        {
            NameTB.Text = variable.Name;

            for (int i = 0; i < variable.Data.Count; i++)
            {
                DataTB.Text += variable.Data[i].DataString + ";";
            }

            this.Show();
        }

        private void CancelB_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKB_Click(object sender, EventArgs e)
        {
            variable = VarControl.SetName(variable, NameTB.Text);
            variable = VarControl.SetData(variable, DataTB.Text);

            if (variable.Name != oldVar.Name)
            {
                masterForm.overwriteVar(variable, oldVar);
            }
            else
            {
                masterForm.updateVar(variable);
            }

            this.Close();
        }
    }
}
