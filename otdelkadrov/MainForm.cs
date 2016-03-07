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
    public partial class MainForm : Form
    {
        OtdelKadrovDatabase okDB = new OtdelKadrovDatabase();
        static public DateTime fireDate = DateTime.Now;
        public MainForm()
        {
            InitializeComponent();
            //сотрудники
            List<String[]> workers = okDB.getWorkersList();
            for (int i = 0; i < workers.Count; i++)
            {
                dgvWorkersList.Rows.Add(workers[i][1], workers[i][0]);
            }
            //подразделения
            Dictionary<int,string> departments = okDB.getDepartmentsList();
            cbDepartment.Items.Clear();
            cbChosenDepartment.Items.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                dgvDepartments.Rows.Add(departments.ElementAt(i).Key, departments.ElementAt(i).Value);
                cbDepartment.Items.Add(departments.ElementAt(i).Value);
                cbChosenDepartment.Items.Add(departments.ElementAt(i).Value);
            }
            //должности
            Dictionary<int, string> positions = okDB.getPositionsList();
            cbChosenPosition.Items.Clear();
            for (int i = 0; i < positions.Count; i++)
            {
                dgvPositions.Rows.Add(positions.ElementAt(i).Key, positions.ElementAt(i).Value);
                cbChosenPosition.Items.Add(positions.ElementAt(i).Value);

            }           
            
            //образование
            dgvEducationTypes.Rows.Clear();
            cbChosenEducation.Items.Clear();
            Dictionary<int, string> edu = okDB.getEducationTypes();
            for (int i = 0; i < edu.Count; i++)
            {
                dgvEducationTypes.Rows.Add(edu.ElementAt(i).Key, edu.ElementAt(i).Value);
                cbChosenEducation.Items.Add(edu.ElementAt(i).Value);
            }
            //родство
            dgvFamilyConnection.Rows.Clear();
            Dictionary<int, string> fc = okDB.getFamilyConnection();
            for (int i = 0; i < fc.Count; i++)
            {
                dgvFamilyConnection.Rows.Add(fc.ElementAt(i).Key, fc.ElementAt(i).Value);
            }

            //gender
            List<string> genders = okDB.getGenders();
            cbChosenGenderS.Items.Clear();
            for (int i = 0; i < genders.Count; i++)
            {
                cbChosenGenderS.Items.Add(genders[i]);
            }

            //семейное положение
            Dictionary<int, string> familystatus = okDB.getFamilyStatusList();
            cbChosenFamilyStatusS.Items.Clear();
            for (int i = 0; i < familystatus.Count; i++)
            {
                cbChosenFamilyStatusS.Items.Add(familystatus.ElementAt(i).Value);
            }

            //radio buttons
            rbDate.Checked = true;
            rbAllDepartments.Checked = true;
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            WorkerCard wc = new WorkerCard();
            wc.ShowDialog();
            List<String[]> workers = okDB.getWorkersList();
            dgvWorkersList.Rows.Clear();
            for (int i = 0; i < workers.Count; i++)
            {
                dgvWorkersList.Rows.Add(workers[i][1], workers[i][0]);
            }
        }

        private void dgvWorkersList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //workersListDG.Rows[e.RowIndex].Cells['id'].Value
            WorkerCard wc = new WorkerCard(dgvWorkersList.Rows[e.RowIndex].Cells[0].Value.ToString());
            wc.ShowDialog();
        }

        private void btnWorkerCard_Click(object sender, EventArgs e)
        {
            if (dgvWorkersList.SelectedRows.Count == 1)
            {
                int row = dgvWorkersList.SelectedRows[0].Index;
                WorkerCard wc = new WorkerCard(dgvWorkersList.Rows[row].Cells[0].Value.ToString());
                wc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать в таблице запись");
            }
        }

        private void btnDeleteWorker_Click(object sender, EventArgs e)
        {
            if (dgvWorkersList.SelectedRows.Count == 1)
            {
                
                int row = dgvWorkersList.SelectedRows[0].Index;
                if (!okDB.deleteWorker(dgvWorkersList.Rows[row].Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Запись не была удалена");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Данные о сотруднике удаляются по причине увольнения?", "Подтверждение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        FireDate fd = new FireDate();
                        DialogResult result1 = fd.ShowDialog();
                        while (result1 != DialogResult.OK)
                        {
                            MessageBox.Show("Необходимо указать дату увольнения");
                        }
                        okDB.fireWorker(fireDate, dgvWorkersList.Rows[row].Cells[0].Value.ToString());                       
                    }
                    dgvWorkersList.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать в таблице запись");
            }
        }

        private void educationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EducationTypes et = new EducationTypes();
            et.ShowDialog();
        }

        private void familyStatusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamilyConnection fs = new FamilyConnection();
            fs.ShowDialog();
        }

        private void familyConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamilyStatuses fc = new FamilyStatuses();
            fc.ShowDialog();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            if (tbDepartmentName.Text != "")
            {
                int res = okDB.addDepartment(tbDepartmentName.Text);
                if (res != -1)
                {
                    dgvDepartments.Rows.Add(res, tbDepartmentName.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 1)
            {
                int row = dgvDepartments.SelectedRows[0].Index;
                if (okDB.deleteDepartment(dgvDepartments.Rows[row].Cells[0].Value.ToString()))
                {
                    dgvDepartments.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            if (tbPositionName.Text != "")
            {
                int res = okDB.addPosition(tbPositionName.Text);
                if (res != -1)
                {
                    dgvPositions.Rows.Add(res, tbPositionName.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnDeletePosition_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 1)
            {
                int row = dgvPositions.SelectedRows[0].Index;
                if (okDB.deletePosition(dgvPositions.Rows[row].Cells[0].Value.ToString()))
                {
                    dgvPositions.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 1)
            {
                int row = dgvDepartments.SelectedRows[0].Index;
                DepartmentContent dc = new DepartmentContent(Convert.ToInt32(dgvDepartments.Rows[row].Cells[0].Value));
                dc.ShowDialog();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись");
            }
        }

        private void btnPotential_Click(object sender, EventArgs e)
        {
            int workersYesterday = 0;
            int newWorkers = 0;
            int firedWorkers = 0;
            double averCountWorkers = 0;
            bool goodPeriod = true;
            string department = "";
            if (rbChosenDepartment.Checked)
            {
                department = cbDepartment.SelectedItem.ToString();
            }

            if (rbDate.Checked)
            {
                //на дату
                averCountWorkers = okDB.getWorkersCount(dtpDate.Value, department);
                workersYesterday = okDB.getWorkersCount(dtpDate.Value.AddDays(-1), department);
                newWorkers = okDB.getNewWorkersCount(dtpDate.Value, department);
                firedWorkers = okDB.getFiredCount(dtpDate.Value, department);

            }
            else if (rbPeriod.Checked)
            {
                //период               
                if (dtpPotentialFrom.Value == dtpPotentialTo.Value)
                {
                    goodPeriod = false;
                    MessageBox.Show("Начало и конец периода не могут совпадать");
                }
                if (dtpPotentialFrom.Value > dtpPotentialTo.Value)
                {
                    goodPeriod = false;
                    MessageBox.Show("Начало периода не может быть больше, чем конец периода");
                }
                if (goodPeriod)
                {
                    DateTime tmpDate = dtpPotentialFrom.Value;
                    averCountWorkers = 0;
                    newWorkers = 0;
                    firedWorkers = 0;
                    double daysCnt = 0;
                    workersYesterday = okDB.getWorkersCount(tmpDate.AddDays(-1), department);
                    do
                    {
                        averCountWorkers += okDB.getWorkersCount(tmpDate, department);
                        newWorkers += okDB.getNewWorkersCount(tmpDate, department);
                        firedWorkers += okDB.getNewWorkersCount(tmpDate, department);

                        tmpDate = tmpDate.AddDays(1);
                        daysCnt++;
                    } while (tmpDate != dtpPotentialTo.Value);
                    averCountWorkers /= daysCnt;                    
                }
            }
            else
            {
                goodPeriod = false;
                MessageBox.Show("Данные могут быть расчитаны на определенную дату, либо на период. Необходимо сделать выбор, как делать расчет");
            }
            if (goodPeriod)
            {
                //движение
                tbMovement.Text = (workersYesterday + newWorkers - firedWorkers).ToString();
                if (averCountWorkers != 0)
                {
                    //общий оборот
                    tbCommonTurnover.Text = ((newWorkers - firedWorkers) / averCountWorkers).ToString();

                    //оборот по приему
                    tbAddTurnover.Text = (newWorkers / averCountWorkers).ToString();

                    //оборот по выбытию
                    tbLeaveTurnover.Text = (firedWorkers / averCountWorkers).ToString();
                }
                else
                {
                    MessageBox.Show("Параметры интенсивности кадров не могут быть рассчитаны, так как среднесписочное число сотрудников на выбранную дату равно 0");
                }
            }
        }

        private void tpPotential_Click(object sender, EventArgs e)
        {
            
        }

        private void dtpPotentialTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbEducationName.Text != "")
            {
                int res = okDB.addEducationType(tbEducationName.Text);
                if (res != -1)
                {
                    dgvEducationTypes.Rows.Add(res, tbEducationName.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEducationTypes.SelectedRows.Count == 1)
            {
                int row = dgvEducationTypes.SelectedRows[0].Index;
                if (okDB.deleteEducationType(dgvEducationTypes.Rows[row].Cells[0].Value.ToString()))
                {
                    dgvEducationTypes.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }

        private void btnDeleteFamilyConnection_Click(object sender, EventArgs e)
        {
            if (dgvFamilyConnection.SelectedRows.Count == 1)
            {
                int row = dgvFamilyConnection.SelectedRows[0].Index;
                if (okDB.deleteFamilyConnection(dgvFamilyConnection.Rows[row].Cells[0].Value.ToString()))
                {
                    dgvFamilyConnection.Rows.RemoveAt(row);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать запись для удаления");
            }
        }

        private void btnAddFamilyConnection_Click(object sender, EventArgs e)
        {
            if (tbFamilyConnection.Text != "")
            {
                int res = okDB.addFamilyConnection(tbFamilyConnection.Text);
                if (res != -1)
                {
                    dgvFamilyConnection.Rows.Add(res, tbFamilyConnection.Text);
                }
                else
                {
                    MessageBox.Show("Запись не была добавлена");
                }
            }
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 1)
            {
                int row = dgvDepartments.SelectedRows[0].Index;
                string id = dgvDepartments.Rows[row].Cells[0].Value.ToString();

                if (okDB.editDepartment(id, tbDepartmentName.Text))
                {
                    dgvDepartments.Rows[row].Cells[1].Value = tbDepartmentName.Text;
                }
                else
                {
                    MessageBox.Show("Запись не была изменена");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить в таблице запись для редактирования");
            }
        }

        private void btnEditPosition_Click(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 1)
            {
                int row = dgvPositions.SelectedRows[0].Index;
                string id = dgvPositions.Rows[row].Cells[0].Value.ToString();

                if (okDB.editPosition(id, tbPositionName.Text))
                {
                    dgvPositions.Rows[row].Cells[1].Value = tbPositionName.Text;
                }
                else
                {
                    MessageBox.Show("Запись не была изменена");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить в таблице запись для редактирования");
            }
        }

        private void tbWorkerSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbWorkerSearch.Text.Length < 3)
            {
                //сотрудники
                List<String[]> workers = okDB.getWorkersList();
                dgvWorkersList.Rows.Clear();
                for (int i = 0; i < workers.Count; i++)
                {
                    dgvWorkersList.Rows.Add(workers[i][1], workers[i][0]);
                }
            }
            else
            {
                List<String[]> workers = okDB.getWorkersList(tbWorkerSearch.Text);
                dgvWorkersList.Rows.Clear();
                for (int i = 0; i < workers.Count; i++)
                {
                    dgvWorkersList.Rows.Add(workers[i][1], workers[i][0]);
                }
            }
        }

        private void btnWorkersSearch_Click(object sender, EventArgs e)
        {
            string gender = "";
            string familyStatus = "";
            string education = "";
            string department = "";
            string position = "";
            if (cbSearchGender.Checked) gender = cbChosenGenderS.Text;
            dgvSearchResult.Columns[1].Visible = !cbSearchGender.Checked;

            if (cbSearchFamilyStatus.Checked) familyStatus = cbChosenFamilyStatusS.Text;
            dgvSearchResult.Columns[2].Visible = !cbSearchFamilyStatus.Checked;
            
            if (cbSearchEducation.Checked) education = cbChosenEducation.Text;
            dgvSearchResult.Columns[3].Visible = !cbSearchEducation.Checked;
            
            if (cbSearchDepartment.Checked) department = cbChosenDepartment.Text;
            dgvSearchResult.Columns[4].Visible = !cbSearchDepartment.Checked;
            
            if (cbSearchPosition.Checked) position = cbChosenPosition.Text;
            dgvSearchResult.Columns[5].Visible = !cbSearchPosition.Checked;

            List<String[]> res = okDB.searchWorkersByParams(gender, familyStatus, education, department, position);
            lblRes.Text = "Найдено записей: " + res.Count;
            dgvSearchResult.Rows.Clear();
            for (int i = 0; i < res.Count; i++)
            {
                dgvSearchResult.Rows.Add(res[i][0], res[i][1], res[i][2], res[i][3], res[i][4], res[i][5]);
            }
        }


    }
}
