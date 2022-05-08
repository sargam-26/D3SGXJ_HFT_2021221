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
    public class BakerLogic// : IBakerLogic
    {
        // IEditorService editService;
        // IMessenger messengerService;
        // IBakerRepository bakerRepository;

        // public BakerLogic(IEditorService editService, IMessenger messengerService, IBakerRepository bakerRepository)
        // {
        //    this.editService= editService;
        //    this.messengerService = messengerService;
        //    this.bakerRepository = bakerRepository;
        // }

        // public void Add(IList<Baker> bakerList)
        // {
        //    Baker baker = new Baker();
        //    if (this.editService.EditBaker(baker) == true)
        //    {
        //        bakerList.Add(baker);
        //    }
        // }

        // public void Delete(IList<Baker> list, Baker baker)
        // {
        //  list.Remove(baker);
        // }

        // public void EditBaker(Baker baker)
        // {
        //    Baker clone = new Baker();
        //    clone.CopyFrom(baker);
        //    if (this.editService.EditBaker(clone) == true)
        //    {
        //        baker.CopyFrom(clone);
        //    }
        // }

        // public IList<Baker> getAllBakers()
        // {
        //    return this.bakerRepository.GetAll().ToList();

        // }
    }
}
