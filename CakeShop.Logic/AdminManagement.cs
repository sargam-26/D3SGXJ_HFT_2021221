namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;
    using CakeShop.Repository;

    /// <summary>
    /// This class stores the method for admin management.
    /// </summary>
    public class AdminManagement : IAdminManagement
    {
        private readonly ICakeRepository cakeRepo;
        private readonly IDeliveryRepository deliveryRepository;
        private readonly IBakerRepository bakerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminManagement"/> class.
        /// </summary>
        /// <param name="cakeRepo">cakeRepo.</param>
        /// <param name="deliveryRepository">IDeliveryRepository.</param>
        /// <param name="bakerRepository">bakerRepository.</param>
        public AdminManagement(ICakeRepository cakeRepo, IDeliveryRepository deliveryRepository, IBakerRepository bakerRepository)
        {
            this.cakeRepo = cakeRepo;
            this.deliveryRepository = deliveryRepository;
            this.bakerRepository = bakerRepository;
        }

        /// <summary>
        /// This lists all the cake deliveries.
        /// </summary>
        /// <returns>ILIst.</returns>
        public IList<CakesDelivery> CakesDeliveries()
        {
            var q = from item in this.deliveryRepository.GetAll().ToList()
                    select new CakesDelivery
                    {
                        Person = item.Person,
                        Cakes = item.Cakes.ToList(),
                    };
            return q.ToList();
        }

        /// <summary>
        /// This lists the returns bakers cake price average.
        /// </summary>
        /// <returns>ListofAvergaeResulsts.</returns>
        public IList<AveragesResult> GetBakerCakePriceAverage()
        {
            var q2 = from cake in this.cakeRepo.GetAll().ToList()
                     group cake by new { cake.Baker.Id, cake.Baker.Name } into grp
                     select new AveragesResult { BakerName = grp.Key.Name, AveragePrice = (double)grp.Average(x => x.Price) };

            return q2.ToList();
        }

        /// <summary>
        /// This lists the total income earned by the baker.
        /// </summary>
        /// <returns>Lists income by baker.</returns>
        public IList<IncomeByBaker> TotalIncomeByBaker()
        {
            var q2 = from data in this.bakerRepository.GetAll().ToList()
                     select new IncomeByBaker
                     {
                         BakerName = data.Name,
                         Income = data.Cakes.Sum(cake => cake.Delivery.Income),
                     };

            return q2.ToList();
        }

        /// <summary>
        /// This method returns true or false if the baker is removed.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public bool RemoveBaker(int id)
        {
            return this.bakerRepository.Remove(id);
        }

        /// <summary>
        /// this method returns if cake is removed from the database.
        /// </summary>
        /// <param name="id">int id.</param>
        /// <returns>bool.</returns>
        public bool RemoveCake(int id)
        {
            return this.cakeRepo.Remove(id);
        }

        /// <summary>
        /// This methods checks if the delivery is removed from dtabase.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>bool.</returns>
        public bool RemoveDelivery(int id)
        {
            return this.deliveryRepository.Remove(id);
        }

        /// <summary>
        /// This method updates the slary of the baker based on bakerid.
        /// </summary>
        /// <param name="bakerId">id.</param>
        /// <param name="salary">salary.</param>
        public void UpdateBakerSalary(int bakerId, int salary)
        {
            this.bakerRepository.UpdateSalary(bakerId, salary);
        }

        /// <summary>
        /// This method gets one cake from the databse.
        /// </summary>
        /// <returns>Cakes.</returns>
        public Cake GetOne()
        {
            Cake cake = this.cakeRepo.RandomCake();
            this.cakeRepo.Add(cake);
            return this.cakeRepo.Search(cake.Name).FirstOrDefault();
        }

        /// <summary>
        /// This method selecte the cake.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool SelectCake(int id)
        {
            return this.cakeRepo.Select(id);
        }

        /// <summary>
        /// This method unselects the cake based on id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool UnSelectCake(int id)
        {
            return this.cakeRepo.UnSelect(id);
        }

        /// <summary>
        /// This method shows Guests.
        /// </summary>
        /// <returns>CakeList.</returns>
        public List<Cake> SelectedGuests()
        {
            return this.cakeRepo.GetAll().Where(x => x.Selected == true).ToList();
        }

        /// <summary>
        /// This method unselects the guests.
        /// </summary>
        /// <returns>Cakelist.</returns>
        public List<Cake> UnSelectedGuests()
        {
            return this.cakeRepo.GetAll().Where(x => x.Selected == false).ToList();
        }
    }
}
