using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otdelkadrov
{
    class WorkerInfo
    {
        public string cardId;
        public string tabelId;
        public CommonWorkerInfo commonInfo = new CommonWorkerInfo();
        public List<WorkerEducation> education = new List<WorkerEducation>();
        public List<WorkerFamilyMember> family = new List<WorkerFamilyMember>();
        public WorkerPosition position = new WorkerPosition();

    }

    class CommonWorkerInfo
    {
        public string gender;
        public string familyStatus;
        public string fio;
        public DateTime birthDate;
        public string birthCountry;
        public string birthDistrict;
        public string birthRegion;
        public string birthPlace;
        public bool profsojuz;
        public string nationality;
        public string passportNum;
        public string personalNum;
        public string passportFrom;
        public DateTime passportDateFrom;
        public DateTime passportDateTo;
        public string livingCountry;
        public string livingDistrict;
        public string livingRegion;
        public string livingPlace;
        public string livingAdress;
        public string livingPhone;
        public string mobilePhone;
    }

    class WorkerEducation
    {
        public string id;
        public string educationType;
        public string eduPlace;
        public string faculty;
        public string specialization;
        public string qualification;
        public DateTime diplomaDate;
        public string diplomaNum;
    }

    class WorkerFamilyMember
    {
        public string id;
        public string connection;
        public string fio;
        public DateTime birthDate;
    }

    class WorkerPosition
    {
        public string id;
        public string department;
        public string position;
        public DateTime startdate;
        public string ordernum;
        public string currordernum;
        public DateTime currorderfrom;
        public DateTime currorderto;
        public bool mat;
        public DateTime currposfrom;
        public string currposordernum;
    }
}
