using CakeShop.Data;
using CakeShop.Repository;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Logic
{
    /// <summary>
    /// BakerLogic class inherits fromm IbakerLogic implements methods.
    /// </summary>
    public class BakerLogic : IBakerLogic
    {
        protected IEditorService editService;

        protected IBakerRepository bakerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BakerLogic"/> class.
        /// </summary>
        /// <param name="editService"></param>
        /// <param name="bakerRepository"></param>
        public BakerLogic(IEditorService editService, IBakerRepository bakerRepository)
        {
            this.editService = editService;
            this.bakerRepository = bakerRepository;
        }

        /// <inheritdoc/>
        public void Add(IList<Baker> bakerList)
        {
            Baker baker = new Baker();
            if (this.editService.EditBaker(baker) == true)
            {
                bakerList.Add(baker);
            }
        }

        /// <inheritdoc/>
        public void Delete(IList<Baker> list, Baker baker)
        {
            list.Remove(baker);
        }

        /// <inheritdoc/>
        public void EditBaker(Baker baker)
        {
            Baker clone = new Baker();
            clone.CopyFrom(baker);
            if (this.editService.EditBaker(clone) == true)
            {
                baker.CopyFrom(clone);
            }
        }

        /// <inheritdoc/>
        public IList<Baker> GetAllBakers()
        {
            return this.bakerRepository.GetAll().ToList();

        }
    }
}
