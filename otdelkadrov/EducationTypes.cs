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
    public partial class EducationTypes : Form
    {
        OtdelKadrovDatabase okDb = new OtdelKadrovDatabase();
        public EducationTypes()
        {
            InitializeComponent();

            Dictionary<int,string> edu = okDb.getEducationTypes();
            for (int i = 0; i < edu.Count; i++)
            {
                dataGridView1.Rows.Add(edu.ElementAt(i).Key, edu.ElementAt(i).Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "")
            {
                int res = okDb.addEducationType(tbName.Text);
                if (res != -1)
                {
                    dataGridView1.Rows.Add(res, tbName.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int row = dataGridView1.SelectedRows[0].Index;
                if (okDb.deleteEducationType(dataGridView1.Rows[row].Cells[0].Value.ToString()))
                {
                    dataGridView1.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }
    }
}
