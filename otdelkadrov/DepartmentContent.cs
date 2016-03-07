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
    public partial class DepartmentContent : Form
    {
        OtdelKadrovDatabase okDb = new OtdelKadrovDatabase();
        public DepartmentContent(int id)
        {
            InitializeComponent();

            List<String[]> workers = okDb.getWorkersByDepartment(id);
            for (int i = 0; i < workers.Count; i++)
            {
                dgvDepartmentContent.Rows.Add(workers[i][0], workers[i][1]);
            }
        }
    }
}
