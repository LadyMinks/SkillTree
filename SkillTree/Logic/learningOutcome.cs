using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class learningOutcome
    {

        public learningOutcome(String name, String description)
        {
            this.Name = name.Substring(2);
            this.Description = description;
        }
        private string Name;
        public string name { get => Name; }

        private string Grade;
        public String grade { get => Grade; }


        private List<string> OutcomeIds;

        public List<string> outcomeIds { get => OutcomeIds; }

        private DateTime? Lastsubmission;
        public DateTime? lastsubmission { get => Lastsubmission; }

        private string Description;
        public string description { get => Description; }


        public void addOutcomeIds(String newId)
        {
            if (outcomeIds == null)
            {
                this.OutcomeIds = new List<string>();
                this.OutcomeIds.Add(newId);
            }
            else
            {
                this.OutcomeIds.Add(newId);
            }
        }

        public void changegrade(String _grade)
        {
            this.Grade = _grade;
        }

        public void changelastsubmission(DateTime? date)
        {
            this.Lastsubmission = date;
        }
    }
}
