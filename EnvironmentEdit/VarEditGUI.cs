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
        private Variable variable;
        VariableController VarControl = new VariableController();

        public VarEditGUI()
        {
            InitializeComponent();
        }

        private void VarEditGUI_Load(object sender, EventArgs e)
        {

        }

        public void SendToEditor(Variable newVar)
        {
            variable = newVar;
            LoadEditor();
        }

        private void LoadEditor()
        {
            NameTB.Text = variable.Name;

            for (int i = 0; i < variable.Data.Count; i++)
            {
                DataTB.Text += variable.Data[i].DataString + ";";
            }
        }

        private void CancelB_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void OKB_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Not implemented!");
        }
    }
}
