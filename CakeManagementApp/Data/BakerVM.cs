using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeManagementApp.Data
{
    /// <summary>
    /// this calss contains fields of baker table
    /// </summary>
    public class BakerVM : ObservableObject
    {
        private int id;
        private string name;
        private int salary;
        private string position;
        private int workHours;
        /// <summary>
        /// Gets or sets it gets and sets id of the baker
        /// </summary>
        public int ID
        {
            get { return id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Gets or sets and sets name of the baker
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets and sets salary of the baker
        /// </summary>
        public int Salary
        {
            get { return salary; }
            set { this.Set(ref this.salary, value); }
        }

        /// <summary>
        /// Gets or sets and sets position of the baker
        /// </summary>
        public string Position
        {
            get { return position; }
            set { this.Set(ref this.position, value); }
        }

        /// <summary>
        /// Gets or sets and sets workhrs
        /// </summary>
        public int WorkHours
        {
            get { return workHours; }
            set { this.Set(ref this.workHours, value); }
        }

        /// <summary>
        /// this method copies gets baker name as parameter
        /// </summary>
        /// <param name="baker">baker.</param>
        public void CopyFrom(BakerVM baker)
        {
            this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(baker)));
        }
    }
}