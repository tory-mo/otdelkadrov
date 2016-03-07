using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace otdelkadrov
{
    class OtdelKadrovDatabase
    {
        private string connectionString = "Server=127.0.0.1;User Id=postgres;Password=postgres;Database=otdelkadrov;";
        public List<String[]> getWorkersList(){
            List<String[]> res = new List<string[]>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select fio, cardid from commoninfo order by fio", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(new string[2] { dr[0].ToString(), dr[1].ToString() });                    
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public List<String[]> getWorkersList(string fio)
        {
            List<String[]> res = new List<string[]>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select fio, cardid from commoninfo where fio like '%" + fio + "%' order by fio", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(new string[2] { dr[0].ToString(), dr[1].ToString() });
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public List<string> getGenders(){
            List<string> res = new List<string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT unnest(enum_range(NULL::gendertype))", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(dr[0].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public Dictionary<int, string> getFamilyStatusList()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from familystatuses", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public Dictionary<int, string> getEducationTypeList()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from educationtypes", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }


            return res;
        }

        public Dictionary<int, string> getFamilyConnectionList()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * from familyconnections", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }


            return res;
        }

        public Dictionary<int, string> getDepartmentsList()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT id,departmentname from departments", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }


            return res;
        }

        public Dictionary<int, string> getPositionsList()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT id,positionname from positions", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                //Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }


            return res;
        }

        public WorkerInfo getWorker(string cardId)
        {
            WorkerInfo res = new WorkerInfo();
            res.cardId = cardId;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select commoninfo.*, familystatuses.statusname from commoninfo INNER join familystatuses on familystatuses.id=commoninfo.familystatus where cardid=" + cardId, conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();
                res.commonInfo = new CommonWorkerInfo();
                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.tabelId = dr[0].ToString();
                    res.commonInfo.gender = dr[2].ToString();
                    res.commonInfo.familyStatus = dr[24].ToString();
                    res.commonInfo.fio = dr[4].ToString();
                    res.commonInfo.birthDate = Convert.ToDateTime(dr[5]);
                    res.commonInfo.birthCountry = dr[6].ToString();
                    res.commonInfo.birthDistrict = dr[7].ToString();
                    res.commonInfo.birthRegion = dr[8].ToString();
                    res.commonInfo.birthPlace = dr[9].ToString();
                    res.commonInfo.profsojuz = Convert.ToBoolean(dr[10]);
                    res.commonInfo.nationality = dr[11].ToString();
                    res.commonInfo.passportNum = dr[12].ToString();
                    res.commonInfo.personalNum = dr[13].ToString();
                    res.commonInfo.passportFrom = dr[14].ToString();
                    res.commonInfo.passportDateFrom = Convert.ToDateTime(dr[15]);
                    res.commonInfo.passportDateTo = Convert.ToDateTime(dr[16]);
                    res.commonInfo.livingCountry = dr[17].ToString();
                    res.commonInfo.livingDistrict = dr[18].ToString();
                    res.commonInfo.livingRegion = dr[19].ToString();
                    res.commonInfo.livingPlace = dr[20].ToString();
                    res.commonInfo.livingAdress = dr[21].ToString();
                    res.commonInfo.livingPhone = dr[22].ToString();
                    res.commonInfo.mobilePhone = dr[23].ToString();
                }

                cmd = new NpgsqlCommand("select familycontent.*, familyconnections.connectionname from familycontent INNER join familyconnections on familycontent.familyconnection=familyconnections.id where workerid=" + cardId, conn);
                dr = cmd.ExecuteReader();
                WorkerFamilyMember fm;
                while (dr.Read())
                {
                    fm = new WorkerFamilyMember();
                    fm.id = dr[0].ToString();
                    fm.connection = dr[5].ToString();
                    fm.fio = dr[2].ToString();
                    fm.birthDate = Convert.ToDateTime(dr[3]);
                    res.family.Add(fm);
                }

                cmd = new NpgsqlCommand("select education.*, educationtypes.educationname from education INNER join educationtypes on education.educationtype=educationtypes.id where workerid=" + cardId, conn);
                dr = cmd.ExecuteReader();
                WorkerEducation ed;
                while (dr.Read())
                {
                    ed = new WorkerEducation();
                    ed.id = dr[0].ToString();
                    ed.educationType = dr[9].ToString();
                    ed.eduPlace = dr[3].ToString();
                    ed.faculty = dr[4].ToString();
                    ed.specialization = dr[5].ToString();
                    ed.qualification = dr[6].ToString();
                    ed.diplomaDate = Convert.ToDateTime(dr[7]);
                    ed.diplomaNum = dr[8].ToString();
                    res.education.Add(ed);
                }

                cmd = new NpgsqlCommand("select workerspositions.*, positions.positionname, departments.departmentname from workerspositions" 
	                                        +" join positions on workerspositions.positionid=positions.id"
                                            +" join departments on departments.id=workerspositions.departmentid"
                                            +" where workerid=" + cardId, conn);
                dr = cmd.ExecuteReader();
                res.position = new WorkerPosition();
                while (dr.Read())
                {
                    
                    res.position.id = dr[0].ToString();
                    res.position.department = dr[13].ToString();
                    res.position.position = dr[12].ToString();
                    res.position.startdate = Convert.ToDateTime(dr[4]);
                    res.position.ordernum = dr[5].ToString();
                    res.position.currordernum = dr[6].ToString();
                    res.position.currorderfrom = Convert.ToDateTime(dr[7]);
                    res.position.currorderto = Convert.ToDateTime(dr[8]);
                    res.position.mat = Convert.ToBoolean(dr[9]);
                    res.position.currposfrom = Convert.ToDateTime(dr[10]);
                    res.position.currposordernum = dr[11].ToString();
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public WorkerFamilyMember addFamilyMember(WorkerFamilyMember fm, string cardid)
        {
            WorkerFamilyMember res = null;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find familyconnection id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familyconnections where connectionname like '" + fm.connection+"'", conn);
                int familyconnection = Convert.ToInt32(cmd.ExecuteScalar());

                //check existance
                cmd = new NpgsqlCommand("select id from familycontent where fio like '" + fm.fio + "' and familyconnection=" + familyconnection+" and birthdate='"+fm.birthDate.ToShortDateString()+"'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такой член семьи уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from familycontent ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into familycontent values(" + index + ", " + familyconnection + ",'" + fm.fio + "','" + fm.birthDate.ToShortDateString() + "'," + cardid + ")", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = fm;
                        res.id = index.ToString();
                    }
                }
                
                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool editFamilyMember(string id, string connection, string fio, DateTime birthDate)
        {
            bool res = false;

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find familyconnection id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familyconnections where connectionname like '" + connection+"'", conn);
                int familyconnection = Convert.ToInt32(cmd.ExecuteScalar());


                // Define a query
                cmd = new NpgsqlCommand("update familycontent set familyconnection="+ familyconnection + ", fio='" + fio + "', birthdate='" + birthDate.ToShortDateString() + "'where id="+id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool deleteFamilyMember(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from familycontent where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public WorkerEducation addWorkerEducation(WorkerEducation we, string cardid)
        {
            WorkerEducation res = null;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find educationtype id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from educationtypes where educationname like '" + we.educationType + "'", conn);
                int educationtype = Convert.ToInt32(cmd.ExecuteScalar());

                //check existance
                cmd = new NpgsqlCommand("select id from education where diplomanum like '" + we.diplomaNum + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись об образовании уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from education ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into education"
                    + " values(" + index + ", " + cardid + "," + educationtype + ",'" + we.eduPlace + "','"+we.faculty +"', '"+we.specialization+"','"+we.qualification+"','"+we.diplomaDate.ToShortDateString()+"','"+we.diplomaNum + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = we;
                        res.id = index.ToString();
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool editWorkerEducation(WorkerEducation we)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find familyconnection id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from educationtypes where educationname like '" + we.educationType + "'", conn);
                int educationtype = Convert.ToInt32(cmd.ExecuteScalar());


                // Define a query
                cmd = new NpgsqlCommand("update education set"
                    + " educationtype=" + educationtype + ",eduplace='" + we.eduPlace + "',faculty='" + we.faculty + "', specialization='" + we.specialization + "',qualification='" + we.qualification + "',diplomadate='" + we.diplomaDate.ToShortDateString() + "',diplomanum='" + we.diplomaNum + "' where id="+we.id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteWorkerEducation(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from education where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool addWorker(WorkerInfo wi)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find educationtype id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familystatuses where statusname like '" + wi.commonInfo.familyStatus + "'", conn);
                int familystatus = Convert.ToInt32(cmd.ExecuteScalar());

                //check existance
                cmd = new NpgsqlCommand("select cardid from commoninfo where personalnum like '" + wi.commonInfo.personalNum + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такой работник уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select cardid from commoninfo ORDER BY cardid DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    string str = "insert into commoninfo "
                                            + " values(" + wi.tabelId + ", " + wi.cardId + ",'"
                                            + wi.commonInfo.gender + "'," + familystatus + ",'"
                                            + wi.commonInfo.fio + "', '" + wi.commonInfo.birthDate.ToShortDateString() + "','"
                                            + wi.commonInfo.birthCountry + "','" + wi.commonInfo.birthDistrict + "','"
                                            + wi.commonInfo.birthRegion + "','" + wi.commonInfo.birthPlace + "','"
                                            + wi.commonInfo.profsojuz + "','" + wi.commonInfo.nationality + "','"
                                            + wi.commonInfo.passportNum + "','" + wi.commonInfo.personalNum + "','"
                                            + wi.commonInfo.passportFrom + "','" + wi.commonInfo.passportDateFrom.ToShortDateString() + "','"
                                            + wi.commonInfo.passportDateTo.ToShortDateString() + "','" + wi.commonInfo.livingCountry + "','"
                                            + wi.commonInfo.livingDistrict + "','" + wi.commonInfo.livingRegion + "','"
                                            + wi.commonInfo.livingPlace + "','" + wi.commonInfo.livingAdress + "','"
                                            + wi.commonInfo.livingPhone + "','" + wi.commonInfo.mobilePhone + "')";
                    // Define a query
                    cmd = new NpgsqlCommand("insert into commoninfo "
                                            + " values(" + wi.tabelId + ", " + wi.cardId + ",'" 
                                            + wi.commonInfo.gender + "'," + familystatus + ",'" 
                                            + wi.commonInfo.fio + "', '" + wi.commonInfo.birthDate.ToShortDateString() + "','"
                                            + wi.commonInfo.birthCountry + "','" + wi.commonInfo.birthDistrict + "','"
                                            + wi.commonInfo.birthRegion + "','" + wi.commonInfo.birthPlace + "','"
                                            + wi.commonInfo.profsojuz + "','" + wi.commonInfo.nationality + "','"
                                            + wi.commonInfo.passportNum + "','" + wi.commonInfo.personalNum + "','"
                                            + wi.commonInfo.passportFrom + "','" + wi.commonInfo.passportDateFrom.ToShortDateString() + "','"
                                            + wi.commonInfo.passportDateTo.ToShortDateString() + "','" + wi.commonInfo.livingCountry + "','"
                                            + wi.commonInfo.livingDistrict + "','" + wi.commonInfo.livingRegion + "','"
                                            + wi.commonInfo.livingPlace + "','" + wi.commonInfo.livingAdress + "','"
                                            + wi.commonInfo.livingPhone + "','" + wi.commonInfo.mobilePhone + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    res = (rowsaffected == 1);
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool editWorker(WorkerInfo wi)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find educationtype id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familystatuses where statusname like '" + wi.commonInfo.familyStatus + "'", conn);
                int familystatus = Convert.ToInt32(cmd.ExecuteScalar());


                // Define a query
                cmd = new NpgsqlCommand("update commoninfo set"
                                            + " tabelid=" + wi.tabelId + ", gender='"
                                            + wi.commonInfo.gender + "',familystatus=" + familystatus + ",fio='"
                                            + wi.commonInfo.fio + "', birthdate='" + wi.commonInfo.birthDate.ToShortDateString() + "',birthcountry='"
                                            + wi.commonInfo.birthCountry + "',birthdistrict='" + wi.commonInfo.birthDistrict + "',birthregion='"
                                            + wi.commonInfo.birthRegion + "',birthplace='" + wi.commonInfo.birthPlace + "',profsojuz='"
                                            + wi.commonInfo.profsojuz + "',nationality='" + wi.commonInfo.nationality + "',passportnum='"
                                            + wi.commonInfo.passportNum + "',personalnum='" + wi.commonInfo.personalNum + "',passportfrom='"
                                            + wi.commonInfo.passportFrom + "',passportdatefrom='" + wi.commonInfo.passportDateFrom + "',passportdateto='"
                                            + wi.commonInfo.passportDateTo + "',livingcountry='" + wi.commonInfo.livingCountry + "',livingdistrict='"
                                            + wi.commonInfo.livingDistrict + "',livingregion='" + wi.commonInfo.livingRegion + "',livingplace='"
                                            + wi.commonInfo.livingPlace + "',livingadress='" + wi.commonInfo.livingAdress + "',livingphone='"
                                            + wi.commonInfo.livingPhone + "',mobilephone='" + wi.commonInfo.mobilePhone + "' where cardid="+wi.cardId, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public int getAvailableCardId()
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                //find new id
                NpgsqlCommand cmd = new NpgsqlCommand("select cardid from commoninfo ORDER BY cardid DESC", conn);
                res = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public int addPositionWorker(WorkerPosition wp, string cardid)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find educationtype id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from departments where departmentname like '" + wp.department + "'", conn);
                int departmentid = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new NpgsqlCommand("select id from positions where positionname like '" + wp.position + "'", conn);
                int positionid = Convert.ToInt32(cmd.ExecuteScalar());

                //check existance
                cmd = new NpgsqlCommand("select id from workerspositions where ordernum like '" + wp.ordernum + "' and currordernum like '"+wp.currordernum+"' and currposordernum like '"+wp.currposordernum+"'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такое назначение уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from workerspositions ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into workerspositions"
                                            + " values(" + index + ", " + cardid + ","
                                            + departmentid + "," + positionid + ",'"
                                            + wp.startdate.ToShortDateString() + "', '" + wp.ordernum + "','"
                                            + wp.currordernum + "','" + wp.currorderfrom.ToShortDateString() + "','"
                                            + wp.currorderto.ToShortDateString() + "','" + wp.mat + "','"
                                            + wp.currposfrom.ToShortDateString() + "','" + wp.currposordernum + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }
        public bool editWorkerPosition(WorkerPosition wp)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find educationtype id
                NpgsqlCommand cmd = new NpgsqlCommand("select id from departments where departmentname like '" + wp.department + "'", conn);
                int departmentid = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new NpgsqlCommand("select id from positions where positionname like '" + wp.position + "'", conn);
                int positionid = Convert.ToInt32(cmd.ExecuteScalar());


                // Define a query
                cmd = new NpgsqlCommand("update workerspositions set"
                                            + " departmentid=" + departmentid + ",positionid=" + positionid + ",startdate='"
                                            + wp.startdate.ToShortDateString() + "', ordernum='" + wp.ordernum + "',currordernum='"
                                            + wp.currordernum + "',currorderfrom='" + wp.currorderfrom.ToShortDateString() + "',currorderto='"
                                            + wp.currorderto.ToShortDateString() + "',mat='" + wp.mat + "',currposfrom='"
                                            + wp.currposfrom.ToShortDateString() + "',currposordernum='" + wp.currposordernum + "' where id="+wp.id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteWorker(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from commoninfo where cardid=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public Dictionary<int,string> getEducationTypes()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select * from educationtypes", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public int addEducationType(string name)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //check existance
                NpgsqlCommand cmd = new NpgsqlCommand("select id from educationtypes where educationname like '" + name + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись об образовании уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from educationtypes ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into educationtypes " + " values(" + index + ",'" + name + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteEducationType(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from educationtypes where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public Dictionary<int, string> getFamilyStatus()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select * from familystatuses", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public int addFamilyStatus(string name)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //check existance
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familystatuses where statusname like '" + name + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from familystatuses ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into familystatuses " + " values(" + index + ",'" + name + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteFamilyStatus(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from familystatuses where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public Dictionary<int, string> getFamilyConnection()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select * from familyconnections", conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public int addFamilyConnection(string name)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //check existance
                NpgsqlCommand cmd = new NpgsqlCommand("select id from familyconnections where connectionname like '" + name + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from familyconnections ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into familyconnections " + " values(" + index + ",'" + name + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteFamilyConnection(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from familyconnections where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public int addDepartment(string name)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //check existance
                NpgsqlCommand cmd = new NpgsqlCommand("select id from departments where departmentname like '" + name + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from departments ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into departments " + " values(" + index + ",'" + name + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deleteDepartment(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from departments where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public int addPosition(string name)
        {
            int res = -1;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //check existance
                NpgsqlCommand cmd = new NpgsqlCommand("select id from positions where positionname like '" + name + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from positions ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into positions " + " values(" + index + ",'" + name + "')", conn);
                    Int32 rowsaffected;
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                    if (rowsaffected == 1)
                    {
                        res = index;
                    }
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool deletePosition(string id)
        {
            bool res = false;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("delete from positions where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public List<String[]> getWorkersByDepartment(int id)
        {
            List<String[]> res = new List<string[]>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("select commoninfo.fio, positions.positionname from commoninfo "
                                    +" join workerspositions on  workerspositions.id=commoninfo.cardid "
                                    + " join positions on  workerspositions.id=positions.id "
                                    +"where workerspositions.departmentid="+id, conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(new string[2] { dr[0].ToString(), dr[1].ToString() });
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public int getWorkersCount(DateTime date, string department)
        {
            int res = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd;
                if(department.Length==0)
                    cmd= new NpgsqlCommand("select count(commoninfo.cardid) from commoninfo "
                                    + " join workerspositions on  workerspositions.id=commoninfo.cardid "
                                    + "where workerspositions.startdate<='" + date.ToShortDateString()+"'", conn);
                else
                    cmd = new NpgsqlCommand("select count(commoninfo.cardid) from commoninfo "
                                    + " join workerspositions on  workerspositions.id=commoninfo.cardid "
                                    + " join departments on  workerspositions.departmentid=departments.id "
                                    + "where workerspositions.startdate<='" + date.ToShortDateString() + "' and departments.departmentname like '"+department+"'", conn);

                res = Convert.ToInt32(cmd.ExecuteScalar());

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        //прибывшие
        public int getNewWorkersCount(DateTime date, string department)
        {
            int res = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd;
                if(department.Length==0)
                    cmd= new NpgsqlCommand("select count(commoninfo.cardid) from commoninfo "
                                    + " join workerspositions on  workerspositions.id=commoninfo.cardid "                                  
                                    + "where workerspositions.startdate='" + date.ToShortDateString() + "'", conn);
                else 
                {
                    cmd = new NpgsqlCommand("select count(commoninfo.cardid) from commoninfo "
                                    + " join workerspositions on  workerspositions.id=commoninfo.cardid "
                                    + " join departments on  workerspositions.departmentid=departments.id "
                                    + "where workerspositions.startdate='" + date.ToShortDateString() + "' and departments.departmentname like '"+department+"'", conn);
                }
                    
                res = Convert.ToInt32(cmd.ExecuteScalar());

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public void fireWorker(DateTime date, string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                Int32 rowsaffected;
                //check existance

                NpgsqlCommand cmd = new NpgsqlCommand("select departments.departmentname from departments "
                                    + " join workerspositions on workerspositions.departmentid=departments.id "
                                    + " join commoninfo on commoninfo.cardid=workerspositions.workerid "
                                    + " where commoninfo.cardid='" + id + "'", conn);
                Object obj = cmd.ExecuteScalar();
                string department = obj.ToString();
                cmd = new NpgsqlCommand("select id, firedcount from firedworkers where firedate = '" + date.ToShortDateString() + "' and departmentname like '" + department + "'", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    cmd = new NpgsqlCommand("update firedworkers " + " set firedcount=" + (Convert.ToInt32(dr[1])+1) + "where id ="+dr[0].ToString(), conn);
                    dr.Close();
                    rowsaffected = cmd.ExecuteNonQuery();
                }
                else
                {
                    //find new id
                    cmd = new NpgsqlCommand("select id from firedworkers ORDER BY id DESC", conn);
                    int index = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                    // Define a query
                    cmd = new NpgsqlCommand("insert into firedworkers " + " values(" + index + ",'" + date.ToShortDateString() + "',1,'"+department+"')", conn);
                    
                    // Execute a query
                    rowsaffected = cmd.ExecuteNonQuery();
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
        }

        public int getFiredCount(DateTime date, string department)
        {
            int res = 0;
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();

                // Define a query
                NpgsqlCommand cmd;
                if(department.Length==0)
                    cmd = new NpgsqlCommand("select sum(firedcount) from firedworkers "
                                    + "where firedate='" + date.ToShortDateString() + "'", conn);
                else
                    cmd = new NpgsqlCommand("select sum(firedcount) from firedworkers "
                                    + "where firedate='" + date.ToShortDateString() + "' and departmentname like '"+department+"'", conn);
                res = Convert.ToInt32(cmd.ExecuteScalar());

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }
            return res;
        }

        public bool editDepartment(string id, string name)
        {
            bool res = false;

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find familyconnection id

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("update departments set departmentname='" + name + "' where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public bool editPosition(string id, string name)
        {
            bool res = false;

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                //find familyconnection id

                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand("update positions set positionname='" + name + "' where id=" + id, conn);
                Int32 rowsaffected;
                // Execute a query
                rowsaffected = cmd.ExecuteNonQuery();
                res = (rowsaffected == 1);

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }

        public List<String[]> searchWorkersByParams(string gender, string familyStatus, string education, string department, string position)
        {
            List<String[]> res = new List<string[]>();

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
                string sql = "select commoninfo.fio, commoninfo.gender, familystatuses.statusname, educationtypes.educationname, departments.departmentname, positions.positionname "
                + " from commoninfo join familystatuses on commoninfo.familystatus=familystatuses.id "
                + " join education on education.workerid = commoninfo.cardid "
                + " join workerspositions on workerspositions.workerid = commoninfo.cardid "
                + " join departments on departments.id=workerspositions.departmentid "
                + " join positions on positions.id=workerspositions.positionid "
                + " join educationtypes on educationtypes.id=education.educationtype ";
                
                if (gender.Length > 0 || familyStatus.Length > 0 || education.Length > 0 || department.Length > 0 || position.Length > 0)
                {
                    string where = "";
                    if (gender.Length > 0) where += " commoninfo.gender = '" + gender + "' ";
                    if (familyStatus.Length > 0)
                    {
                        if (where.Length > 0) where += " and ";
                        where += " familystatuses.statusname like '" + familyStatus + "' ";
                    }
                    if (education.Length > 0)
                    {
                        if (where.Length > 0) where += " and ";
                        where += " educationtypes.educationname like '" + education + "' ";
                    }
                    if (department.Length > 0)
                    {
                        if (where.Length > 0) where += " and ";
                        where += " departments.departmentname like '" + department + "' ";
                    }
                    if (position.Length > 0)
                    {
                        if (where.Length > 0) where += " and ";
                        where += " positions.positionname like '" + position + "' ";
                    }
                    sql += " where "+where;
                }

                sql += " ORDER BY commoninfo.fio asc;";
                // Define a query
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                // Execute a query
                NpgsqlDataReader dr = cmd.ExecuteReader();

                // Read all rows and output the first column in each row
                while (dr.Read())
                {
                    res.Add(new string[6] { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString() });
                }

                // Close connection
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
            }

            return res;
        }
    }
}
