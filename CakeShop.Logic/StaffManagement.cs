namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;
    using CakeShop.Repository;

    /// <summary>
    /// this class implements the methods declared in the IStaffmgmt interface.
    /// </summary>
    public class StaffManagement : IStaffManagement
    {
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IBakerRepository bakerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffManagement"/> class.
        /// </summary>
        /// <param name="deliveryRepository">deliveryrepo.</param>
        /// <param name="bakerRepository">bakerRepo.</param>
        public StaffManagement(IDeliveryRepository deliveryRepository, IBakerRepository bakerRepository)
        {
            this.deliveryRepository = deliveryRepository;
            this.bakerRepository = bakerRepository;
        }

        /// <summary>
        /// This method adds the baker info to the repo.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="position">position.</param>
        /// <param name="salary">salary.</param>
        /// <param name="workHours">workhrs.</param>
        public void AddBaker(string name, string position, int salary, int workHours)
        {
            Baker baker = new Baker()
            {
                Name = name,
                Position = position,
                Salary = salary,
                Workhours = workHours,
            };

            this.bakerRepository.Add(baker);
        }

        /// <summary>
        /// Lists all the bakers and return.
        /// </summary>
        /// <returns>list of all bakers.</returns>
        public IList<Baker> GetAllBaker()
        {
            return this.bakerRepository.GetAll().ToList();
        }

        /// <summary>
        /// Gets sthe baker info based on the id.
        /// </summary>
        /// <param name="bakerId">bakerid.</param>
        /// <returns>baker.</returns>
        public Baker GetBakerInfo(int bakerId)
        {
            return this.bakerRepository.GetOne(bakerId);
        }

        /// <summary>
        /// This method update sthe delivery man name based on id and name as paarameters.
        /// </summary>
        /// <param name="deliveryId">delvid.</param>
        /// <param name="name">name.</param>
        public void UpdateDeliveryPersonName(int deliveryId, string name)
        {
            this.deliveryRepository.UpdateDeliveryPersonName(deliveryId, name);
        }
    }
}
