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
    public partial class WorkerCard : Form
    {
        OtdelKadrovDatabase okDB = new OtdelKadrovDatabase();
        WorkerInfo wi;
        bool newworker = false;
        bool newworkersaved = true;
        bool newpositionsaved = true;
        public WorkerCard()
        {
            InitializeComponent();
            initializeComboBoxes();
            wi = new WorkerInfo();
            newworker = true;
            newworkersaved = false;
            newpositionsaved = false;
            tbCardNum.Text = okDB.getAvailableCardId().ToString();
        }

        public WorkerCard(string cardid)
        {
            InitializeComponent();
            initializeComboBoxes();
            newworker = false;
            wi = okDB.getWorker(cardid);

            //common info
            tbFio.Text = wi.commonInfo.fio;
            tbTabelNum.Text = wi.tabelId;
            tbCardNum.Text = wi.cardId;
            if (wi.commonInfo.birthDate < dpBirthDate.MinDate || wi.commonInfo.birthDate > dpBirthDate.MaxDate)
            {
                dpBirthDate.Value = DateTime.Now;
            }
            else dpBirthDate.Value = wi.commonInfo.birthDate;
            cbProfsojuz.Checked = wi.commonInfo.profsojuz;
            tbNationality.Text = wi.commonInfo.nationality;
            tbPassportNum.Text = wi.commonInfo.passportNum;
            tbPersonalNum.Text = wi.commonInfo.personalNum;
            tbVidan.Text = wi.commonInfo.passportFrom;
            if (wi.commonInfo.passportDateFrom < dpPassportFrom.MinDate || wi.commonInfo.passportDateFrom > dpPassportFrom.MaxDate)
            {
                dpPassportFrom.Value = DateTime.Now;
            }
            else dpPassportFrom.Value = wi.commonInfo.passportDateFrom;
            if (wi.commonInfo.passportDateTo < dpPassportTo.MinDate || wi.commonInfo.passportDateTo > dpPassportTo.MaxDate)
            {
                dpPassportTo.Value = DateTime.Now;
            }
            else dpPassportTo.Value = wi.commonInfo.passportDateTo;
            tbBirthCountry.Text = wi.commonInfo.birthCountry;
            tbBirthDistrict.Text = wi.commonInfo.birthDistrict;
            tbBirthRegion.Text = wi.commonInfo.birthRegion;
            tbBirthPlace.Text = wi.commonInfo.birthPlace;
            tbLivingCountry.Text = wi.commonInfo.livingCountry;
            tbLivingDistrict.Text = wi.commonInfo.livingDistrict;
            tbLivingRegion.Text = wi.commonInfo.livingRegion;
            tbLivingPlace.Text = wi.commonInfo.livingPlace;
            tbLivingAdress.Text = wi.commonInfo.livingAdress;
            tbLivingPhone.Text = wi.commonInfo.livingPhone;
            tbMobilePhone.Text = wi.commonInfo.mobilePhone;
            for(int i = 0; i<cbGender.Items.Count;i++){
                if (cbGender.Items[i].ToString().Equals(wi.commonInfo.gender))
                {
                    cbGender.SelectedIndex = i;
                    break;                  
                }                   
            }
            for (int i = 0; i < cbFamilyStatus.Items.Count; i++)
            {
                if (cbFamilyStatus.Items[i].ToString().Equals(wi.commonInfo.familyStatus))
                {
                    cbFamilyStatus.SelectedIndex = i;
                    break;
                }
            }

            //family
            dgvFamily.Rows.Clear();
            for (int i = 0; i < wi.family.Count; i++)
            {
                dgvFamily.Rows.Add(wi.family[i].connection, wi.family[i].fio, wi.family[i].birthDate.ToShortDateString(), wi.family[i].id);
            }
            if (wi.family.Count > 0) dgvFamily.Rows[0].Selected = true;

            //education
            dgvEducation.Rows.Clear();
            for (int i = 0; i < wi.education.Count; i++)
            {
                dgvEducation.Rows.Add(wi.education[i].id, wi.education[i].educationType, wi.education[i].eduPlace, wi.education[i].faculty, wi.education[i].specialization, wi.education[i].qualification, wi.education[i].diplomaNum, wi.education[i].diplomaDate.ToShortDateString());
            }
            if (wi.education.Count > 0) dgvEducation.Rows[0].Selected = true;

            //positon
            if (wi.position.startdate < dpStartDate.MinDate || wi.position.startdate > dpStartDate.MaxDate)
            {
                dpStartDate.Value = DateTime.Now;
            }else  dpStartDate.Value = wi.position.startdate;
            tbOrderNum.Text = wi.position.ordernum;
            cbMat.Checked = wi.position.mat;
            if (wi.position.currposfrom < dpCurrPosFrom.MinDate || wi.position.currposfrom > dpCurrPosFrom.MaxDate)
            {
                dpCurrPosFrom.Value = DateTime.Now;
            }
            else  dpCurrPosFrom.Value = wi.position.currposfrom;
            tbCurrPosOrderNum.Text = wi.position.currposordernum;
            tbCurrOrderNum.Text = wi.position.currordernum;
            if (wi.position.currorderfrom < dpCurrOrderFrom.MinDate || wi.position.currorderfrom > dpCurrOrderFrom.MaxDate)
            {
                dpCurrOrderFrom.Value = DateTime.Now;
            }
            else dpCurrOrderFrom.Value = wi.position.currorderfrom;
            if (wi.position.currorderto < dpCurrOrderTo.MinDate || wi.position.currorderto > dpCurrOrderTo.MaxDate)
            {
                dpCurrOrderTo.Value = DateTime.Now;
            }
            else dpCurrOrderTo.Value = wi.position.currorderto;
            for (int i = 0; i < cbDepartment.Items.Count; i++)
            {
                if (cbDepartment.Items[i].ToString().Equals(wi.position.department))
                {
                    cbDepartment.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < cbPosition.Items.Count; i++)
            {
                if (cbPosition.Items[i].ToString().Equals(wi.position.position))
                {
                    cbPosition.SelectedIndex = i;
                    break;
                }
            }
        }

        private void initializeComboBoxes()
        {
            //genders, familystatuses, familyconnections, educationsTypes, departments, positions
            List<string> genders = okDB.getGenders();
            cbGender.Items.Clear();
            for (int i = 0; i < genders.Count; i++)
            {
                cbGender.Items.Add(genders[i]);
            }

            Dictionary<int, string> familystatus = okDB.getFamilyStatusList();
            cbFamilyStatus.Items.Clear();
            for (int i = 0; i < familystatus.Count; i++)
            {
                cbFamilyStatus.Items.Add(familystatus.ElementAt(i).Value);
            }

            Dictionary<int, string> familyconnections = okDB.getFamilyConnectionList();
            cbFamilyConnections.Items.Clear();
            for (int i = 0; i < familyconnections.Count; i++)
            {
                cbFamilyConnections.Items.Add(familyconnections.ElementAt(i).Value);
            }

            Dictionary<int, string> educationtypes = okDB.getEducationTypeList();
            cbEducation.Items.Clear();
            for (int i = 0; i < educationtypes.Count; i++)
            {
                cbEducation.Items.Add(educationtypes.ElementAt(i).Value);
            }

            Dictionary<int, string> departments = okDB.getDepartmentsList();
            cbDepartment.Items.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                cbDepartment.Items.Add(departments.ElementAt(i).Value);
            }

            Dictionary<int, string> positions = okDB.getPositionsList();
            cbPosition.Items.Clear();
            for (int i = 0; i < positions.Count; i++)
            {
                cbPosition.Items.Add(positions.ElementAt(i).Value);
            }

        }

        private void dgvEducation_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count == 1)
            {
                int row = dgvEducation.SelectedRows[0].Index;
                tbEducationPlace.Text = wi.education[row].eduPlace;
                tbFaculty.Text = wi.education[row].faculty;
                tbSpecialization.Text = wi.education[row].specialization;
                tbQualification.Text = wi.education[row].qualification;
                tbDiplomaNum.Text = wi.education[row].diplomaNum;
                dpDiplomaDate.Value = wi.education[row].diplomaDate;
                for (int i = 0; i < cbEducation.Items.Count; i++)
                {
                    if (cbEducation.Items[i].ToString().Equals(wi.education[row].educationType))
                    {
                        cbEducation.SelectedIndex = i;
                        break;
                    }
                }
            }
            /*tbEducationPlace.Text = wi.education[e.RowIndex].eduPlace;
            tbFaculty.Text = wi.education[e.RowIndex].faculty;
            tbSpecialization.Text = wi.education[e.RowIndex].specialization;
            tbQualification.Text = wi.education[e.RowIndex].qualification;
            tbDiplomaNum.Text = wi.education[e.RowIndex].diplomaNum;
            dpDiplomaDate.Value = wi.education[e.RowIndex].diplomaDate;
            for (int i = 0; i < cbEducation.Items.Count; i++)
            {
                if (cbEducation.Items[i].ToString().Equals(wi.education[e.RowIndex].educationType))
                {
                    cbEducation.SelectedIndex = i;
                    break;
                }
            }*/
        }

        private void dgvFamily_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFamily.SelectedRows.Count == 1)
            {
                int row = dgvFamily.SelectedRows[0].Index;
                tbFamilyFio.Text = wi.family[row].fio;
                dpFamilyBirth.Value = wi.family[row].birthDate;
                for (int i = 0; i < cbFamilyConnections.Items.Count; i++)
                {
                    if (cbFamilyConnections.Items[i].ToString().Equals(wi.family[row].connection))
                    {
                        cbFamilyConnections.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            /*tbFamilyFio.Text = wi.family[e.RowIndex].fio;
            dpFamilyBirth.Value = wi.family[e.RowIndex].birthDate;
            for (int i = 0; i < cbFamilyConnections.Items.Count; i++)
            {
                if (cbFamilyConnections.Items[i].ToString().Equals(wi.family[e.RowIndex].connection))
                {
                    cbFamilyConnections.SelectedIndex = i;
                    break;
                }
            }*/
        }

        private void btnAddFamily_Click(object sender, EventArgs e)
        {
            WorkerFamilyMember newFM = new WorkerFamilyMember();
            newFM.birthDate = dpFamilyBirth.Value;
            newFM.fio = tbFamilyFio.Text;
            newFM.connection = cbFamilyConnections.SelectedItem.ToString();
            newFM = okDB.addFamilyMember(newFM, wi.cardId);
            if (newFM != null)
            {
                wi.family.Add(newFM);
                dgvFamily.Rows.Add(newFM.connection, newFM.fio, newFM.birthDate.ToShortDateString(), newFM.id);
            }
            else
            {
                MessageBox.Show("Запись не была добавлена");
            }
        }

        private void btnEditFamily_Click(object sender, EventArgs e)
        {
            if (dgvFamily.SelectedRows.Count == 1)
            {
                int row = dgvFamily.SelectedRows[0].Index;
                string id = wi.family[row].id;
                if (okDB.editFamilyMember(id, cbFamilyConnections.SelectedItem.ToString(), tbFamilyFio.Text, dpFamilyBirth.Value))
                {
                    dgvFamily.Rows[row].Cells[0].Value = wi.family[row].connection = cbFamilyConnections.SelectedItem.ToString();
                    dgvFamily.Rows[row].Cells[1].Value = wi.family[row].fio = tbFamilyFio.Text;
                    wi.family[row].birthDate = dpFamilyBirth.Value;
                    dgvFamily.Rows[row].Cells[2].Value = dpFamilyBirth.Value.ToShortDateString();
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

        private void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            if (dgvFamily.SelectedRows.Count == 1)
            {
                int row = dgvFamily.SelectedRows[0].Index;
                string id = wi.family[row].id;
                if (okDB.deleteFamilyMember(id))
                {
                    dgvFamily.ClearSelection();
                    dgvFamily.Rows.RemoveAt(row);
                    if (dgvFamily.Rows.Count > 0) dgvFamily.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Запись не была удалена");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить в таблице запись для удаления");
            }
            
        }

        private void btnAddEducation_Click(object sender, EventArgs e)
        {
            WorkerEducation newWE = new WorkerEducation();
            newWE.diplomaDate = dpDiplomaDate.Value;
            newWE.diplomaNum = tbDiplomaNum.Text;
            newWE.educationType = cbEducation.SelectedItem.ToString();
            newWE.eduPlace = tbEducationPlace.Text;
            newWE.faculty = tbFaculty.Text;
            newWE.qualification = tbQualification.Text;
            newWE.specialization = tbSpecialization.Text;
            newWE = okDB.addWorkerEducation(newWE, wi.cardId);
            if (newWE != null)
            {
                wi.education.Add(newWE);
                dgvEducation.Rows.Add(newWE.id, newWE.educationType, newWE.eduPlace, newWE.faculty, newWE.specialization, newWE.qualification, newWE.diplomaNum, newWE.diplomaDate.ToShortDateString());
            }
            else
            {
                MessageBox.Show("Запись не была добавлена");
            }
        }

        private void btnEditEducation_Click(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count == 1)
            {
                int row = dgvEducation.SelectedRows[0].Index;
                string id = wi.education[row].id;
                WorkerEducation newWE = new WorkerEducation();
                newWE.id = id;
                newWE.diplomaDate = dpDiplomaDate.Value;
                newWE.diplomaNum = tbDiplomaNum.Text;
                newWE.educationType = cbEducation.SelectedItem.ToString();
                newWE.eduPlace = tbEducationPlace.Text;
                newWE.faculty = tbFaculty.Text;
                newWE.qualification = tbQualification.Text;
                newWE.specialization = tbSpecialization.Text;
                if (okDB.editWorkerEducation(newWE))
                {
                    dgvEducation.Rows[row].Cells[7].Value = newWE.diplomaDate.ToShortDateString();
                    dgvEducation.Rows[row].Cells[6].Value = newWE.diplomaNum;
                    dgvEducation.Rows[row].Cells[1].Value = newWE.educationType;
                    dgvEducation.Rows[row].Cells[2].Value = newWE.eduPlace;
                    dgvEducation.Rows[row].Cells[3].Value = newWE.faculty;
                    dgvEducation.Rows[row].Cells[5].Value = newWE.qualification;
                    dgvEducation.Rows[row].Cells[4].Value = newWE.specialization;
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

        private void btnDeleteEducation_Click(object sender, EventArgs e)
        {
            if (dgvEducation.SelectedRows.Count == 1)
            {
                int row = dgvEducation.SelectedRows[0].Index;
                string id = wi.education[row].id;
                if (okDB.deleteWorkerEducation(id))
                {
                    dgvEducation.ClearSelection();
                    dgvEducation.Rows.RemoveAt(row);
                    if (dgvEducation.Rows.Count > 0) dgvEducation.Rows[0].Selected = true;
                }
                else
                {
                    MessageBox.Show("Запись не была удалена");
                }
            }
            else
            {
                MessageBox.Show("Необходимо выделить в таблице запись для удаления");
            }
        }

        private void btnSaveCommonInfo_Click(object sender, EventArgs e)
        {
            saveCommonInfo();
        }

        private void saveCommonInfo()
        {
            wi.cardId = tbCardNum.Text;
            wi.tabelId = tbTabelNum.Text;
            wi.commonInfo.birthCountry = tbBirthCountry.Text;
            wi.commonInfo.birthDate = dpBirthDate.Value;
            wi.commonInfo.birthDistrict = tbBirthDistrict.Text;
            wi.commonInfo.birthPlace = tbBirthPlace.Text;
            wi.commonInfo.birthRegion = tbBirthRegion.Text;
            wi.commonInfo.familyStatus = cbFamilyStatus.SelectedItem.ToString();
            wi.commonInfo.fio = tbFio.Text;
            wi.commonInfo.gender = cbGender.SelectedItem.ToString();
            wi.commonInfo.livingAdress = tbLivingAdress.Text;
            wi.commonInfo.livingCountry = tbLivingAdress.Text;
            wi.commonInfo.livingDistrict = tbLivingDistrict.Text;
            wi.commonInfo.livingPhone = tbLivingPhone.Text;
            wi.commonInfo.livingPlace = tbLivingPlace.Text;
            wi.commonInfo.livingRegion = tbLivingRegion.Text;
            wi.commonInfo.mobilePhone = tbMobilePhone.Text;
            wi.commonInfo.nationality = tbNationality.Text;
            wi.commonInfo.passportDateFrom = dpPassportFrom.Value;
            wi.commonInfo.passportDateTo = dpPassportTo.Value;
            wi.commonInfo.passportFrom = tbVidan.Text;
            wi.commonInfo.passportNum = tbPassportNum.Text;
            wi.commonInfo.personalNum = tbPersonalNum.Text;
            wi.commonInfo.profsojuz = cbProfsojuz.Checked;
            if (newworker)
            {
                if (!okDB.addWorker(wi)) MessageBox.Show("Данные не были сохранены");
                else newworkersaved = true;
            }
            else
            {
                if (!okDB.editWorker(wi)) MessageBox.Show("Данные не были сохранены");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            i = tabControl1.SelectedIndex;
            
        }

        private void tpCommonInfo_Leave(object sender, EventArgs e)
        {
            if (newworker && !newworkersaved)
            {
                DialogResult dialogResult = MessageBox.Show("Данные не были сохранены. Сохранить?", "Несохраненные данные", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveCommonInfo();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private void btnSavePosition_Click(object sender, EventArgs e)
        {
            savePosition();
        }

        private void savePosition()
        {
            wi.position.currorderfrom = dpCurrOrderFrom.Value;
            wi.position.currordernum = tbCurrOrderNum.Text;
            wi.position.currorderto = dpCurrOrderTo.Value;
            wi.position.currposfrom = dpCurrPosFrom.Value;
            wi.position.currposordernum = tbCurrPosOrderNum.Text;
            wi.position.department = cbDepartment.SelectedItem.ToString();
            wi.position.mat = cbMat.Checked;
            wi.position.ordernum = tbOrderNum.Text;
            wi.position.position = cbPosition.SelectedItem.ToString();
            wi.position.startdate = dpStartDate.Value;

            if (newworker)
            {
                int res = okDB.addPositionWorker(wi.position, wi.cardId);
                if (res != -1)
                {
                    wi.position.id = res.ToString();
                    newpositionsaved = true;
                }
                else
                {
                    
                    MessageBox.Show("Данные не были сохранены");
                }
            }
            else
            {
                if (!okDB.editWorkerPosition(wi.position)) MessageBox.Show("Данные не были сохранены");
            }
        }

        private void tpPosition_Leave(object sender, EventArgs e)
        {
            if (newworker && !newpositionsaved)
            {
                DialogResult dialogResult = MessageBox.Show("Данные не были сохранены. Сохранить?", "Несохраненные данные", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   savePosition();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
        }
    }
}
