namespace CakeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;
    using CakeShop.Repository;

    /// <summary>
    /// this class implements the mtehod declared in the interface.
    /// </summary>
    public class OrderManagement : IOrderManagement
    {
        private readonly ICakeRepository cakeRepo;
        private readonly IDeliveryRepository deliveryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderManagement"/> class.
        /// </summary>
        /// <param name="cakeRepo">cakeRepo.</param>
        /// <param name="deliveryRepository">DelvRepo.</param>
        public OrderManagement(ICakeRepository cakeRepo, IDeliveryRepository deliveryRepository)
        {
            this.cakeRepo = cakeRepo;
            this.deliveryRepository = deliveryRepository;
        }

        /// <summary>
        /// This method adds cake to the databse and shares all the info.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="shape">shape.</param>
        /// <param name="color">color.</param>
        /// <param name="price">price.</param>
        /// <param name="deliveryId">delvid.</param>
        /// <param name="bakerId">bakerid.</param>
        /// <param name="basePrice">bakerprice.</param>
        public void AddCake(string name, string shape, string color, int price, int deliveryId, int bakerId, int basePrice)
        {
            Cake cake = new Cake()
            {
                Name = name,
                Shape = shape,
                Color = color,
                Price = price,
                DeliveryId = deliveryId,
                BakerId = bakerId,
                BasePrice = basePrice,
            };
            this.cakeRepo.Add(cake);
        }

        /// <summary>
        /// This method adds cake to the databse and shares all the info.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="shape">shape.</param>
        /// <param name="color">color.</param>
        /// <param name="bakerId">bakerid.</param>
        /// <param name="basePrice">bakerprice.</param>
        public void AddCake(string name, string shape, string color, int bakerId, int basePrice)
        {
            Cake cake = new Cake()
            {
                Name = name,
                Shape = shape,
                Color = color,
                BakerId = bakerId,
                BasePrice = basePrice,
            };
            this.cakeRepo.Add(cake);
        }

        /// <summary>
        /// This method adds the delivery info based on given parameters.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="income">income.</param>
        /// <param name="time">time.</param>
        /// <param name="schedule">schedule.</param>
        public void AddDelivery(string name, int income, int time, int schedule)
        {
            Delivery delivery = new Delivery()
            {
                Person = name,
                Income = income,
                Mins = time,
                Schedule = schedule,
            };

            this.deliveryRepository.Add(delivery);
        }

        /// <summary>
        /// This method lists all the cakes.
        /// </summary>
        /// <returns>lists the cakes from the repo.</returns>
        public IList<Cake> GetAllCakes()
        {
            return this.cakeRepo.GetAll().ToList();
        }

        /// <summary>
        /// gets the cake info method.
        /// </summary>
        /// <param name="cakeId">cakeid.</param>
        /// <returns>cake.</returns>
        public Cake GetCakeInfo(int cakeId)
        {
            return this.cakeRepo.GetOne(cakeId);
        }

        /// <summary>
        /// this lists the deliveries from the database.
        /// </summary>
        /// <returns>list of all deiveries.</returns>
        public IList<Delivery> GetDeliveries()
        {
            return this.deliveryRepository.GetAll().ToList();
        }

        /// <summary>
        /// This method returns the wholenfo of the delivery vased on id.
        /// </summary>
        /// <param name="deliveryId">int id.</param>
        /// <returns>deliveryinfo.</returns>
        public Delivery GetDeliveryInfo(int deliveryId)
        {
            return this.deliveryRepository.GetOne(deliveryId);
        }

        /// <summary>
        /// Updates the cakeshape based on cakeid and shape as parameters.
        /// </summary>
        /// <param name="cakeId">int id.</param>
        /// <param name="shape">shape.</param>
        public void UpdateCakeShape(int cakeId, string shape)
        {
            this.cakeRepo.UpdateCakeShape(cakeId, shape);
        }

        /// <summary>
        /// This is UpdateCake method.
        /// </summary>
        /// <param name="cakeId">Cake id.</param>
        /// <param name="name">Cakeobj.</param>
        /// <param name="shape">Cake shape.</param>
        /// <param name="color">Cake color.</param>
        /// <param name="bakerId">Cake bakerid.</param>
        /// <param name="basePrice">Cake price.</param>
        public void UpdateCake(int cakeId, string name, string shape, string color, int bakerId, int basePrice)
        {
            this.cakeRepo.UpdateCake(cakeId, name, shape, color, bakerId, basePrice);
        }
    }
}
