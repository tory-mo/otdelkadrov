using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otdelkadrov
{
    public partial class FamilyConnection : Form
    {
        OtdelKadrovDatabase okDb = new OtdelKadrovDatabase();
        public FamilyConnection()
        {
            InitializeComponent();

            Dictionary<int,string> edu = okDb.getFamilyStatus();
            for (int i = 0; i < edu.Count; i++)
            {
                dgvFamilyConnection.Rows.Add(edu.ElementAt(i).Key, edu.ElementAt(i).Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                int res = okDb.addFamilyStatus(tbName.Text);
                if (res != -1)
                {
                    dgvFamilyConnection.Rows.Add(res, tbName.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFamilyConnection.SelectedRows.Count == 1)
            {
                int row = dgvFamilyConnection.SelectedRows[0].Index;
                if (okDb.deleteFamilyStatus(dgvFamilyConnection.Rows[row].Cells[0].Value.ToString()))
                {
                    dgvFamilyConnection.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }
    }
}
