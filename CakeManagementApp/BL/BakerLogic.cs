using CakeManagementApp.Data;
using CakeShop.Data;
using CakeShop.Repository;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeManagementApp.BL
{/// <summary>
/// this class implements the methods in interface BakerLogic
/// </summary>
    public class BakerLogic : IBakerLogicVM
    {
        private readonly IMessenger messengerService;
        private readonly IBakerRepository bakerRepository;
        private readonly IEditorService editService;
        /// <summary>
        /// Initializes a new instance of the <see cref="BakerLogic"/> class.
        /// this constructor initializes the editService, messangerService and bakerRepository of the bkaer
        /// </summary>
        /// <param name="editService">editService.</param>
        /// <param name="messengerService">Name.</param>
        /// <param name="bakerRepository">bakerRepo.</param>
        public BakerLogic(IEditorService editService, IMessenger messengerService, IBakerRepository bakerRepository)
        {
            this.editService = editService;
            this.messengerService = messengerService;
            this.bakerRepository = bakerRepository;
        }

        /// <summary>
        /// this method adds the ist of the bakers.
        /// </summary>
        /// <param name="bakerList">add list.</param>
        public void Add(IList<BakerVM> bakerList)
        {
            if (bakerList != null)
            {
                BakerVM baker = new BakerVM();
                if (this.editService.EditBaker(baker) == true)
                {
                    bakerList.Add(baker);
                    Baker bakerRepo = new Baker()
                    {
                        Name = baker.Name,
                        Position = baker.Position,
                        Salary = baker.Salary,
                        Workhours = baker.WorkHours,
                    };
                    this.bakerRepository.Add(bakerRepo);
                    this.messengerService.Send("Add Ok", "LogicResult");
                }
                else
                {
                    this.messengerService.Send("Add Canceled", "LogicResult");
                }
            }
        }

        /// <summary>
        /// this method deletes the baker from the bakerList
        /// </summary>
        /// <param name="bakerList">bakerList.</param>
        /// <param name="baker">Baker.</param>
        public void Delete(IList<BakerVM> bakerList, BakerVM baker)
        {
            if (bakerList != null && baker != null)
            {
                this.bakerRepository.Remove(baker.ID);
                bakerList.Remove(baker);
                this.messengerService.Send("Successfuly Deleted", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Delete Failed", "LogicResult");
            }
        }

        /// <summary>
        /// this method edits the info of the baker.
        /// </summary>
        /// <param name="baker">baker.</param>
        public void EditBaker(BakerVM baker)
        {
            if (baker == null)
            {
                this.messengerService.Send("Edit failed", "LogicResult");
                return;
            }

            BakerVM clone = new BakerVM();
            clone.CopyFrom(baker);

            if (this.editService.EditBaker(clone) == true)
            {
                baker.CopyFrom(clone);
                Baker modifiedBaker = new Baker()
                {
                    Salary = baker.Salary,
                    Name = baker.Name,
                    Position = baker.Position,
                    Workhours = baker.WorkHours,
                };
                this.bakerRepository.EditBaker(baker.ID, modifiedBaker);
                this.messengerService.Send("Edit Ok", "LogicResult");
            }
            else
            {
                this.messengerService.Send("Edit failed", "LogicResult");
            }
        }

        /// <summary>
        /// this method gets or lsits all the bakers of the baker table
        /// </summary>
        /// <returns>All bakers.</returns>
        public IList<BakerVM> GetAllBakers()
        {
            IList<Baker> list = this.bakerRepository.GetAll().ToList();
            IList<BakerVM> bakers = new List<BakerVM>();

            foreach (var item in list)
            {
                BakerVM baker = new BakerVM
                {
                    ID = item.Id,
                    Name = item.Name,
                    Position = item.Position,
                    Salary = item.Salary,
                    WorkHours = item.Workhours,
                };

                bakers.Add(baker);
            }

            return bakers;

        }
    }
}
