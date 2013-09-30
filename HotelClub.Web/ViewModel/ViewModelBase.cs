using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelClub.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HotelClub.Web.ViewModel
{
    public class ViewModelBase
    {
        private bool? _canEdit = null;
        private bool? _canDelete = null;

        private RoleEvaluator _evaluator = new RoleEvaluator();

        public bool CanEdit
        {
            get
            {
                if (!this._canEdit.HasValue)
                {
                    this._canEdit = this._evaluator.CanEdit;
                }
                return this._canEdit.Value;
            }
        }

        public bool CanDelete
        {
            get
            {
                if (!this._canDelete.HasValue)
                {
                    this._canDelete = this._evaluator.CanDelete;
                }
                return this._canDelete.Value;
            }
        }

    }

    public class ViewModelBaseG<T> : ViewModelBase where T : class
    {
        public IList<T> MyList { get; set; }

        public string ItemJSON
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var items = JsonConvert.SerializeObject(MyList, settings);
                return items;
            }
        }

        public string ImageUrlPrefix
        {
            get { return Web.Config.ImagesFolderPath; }
        }
    }
}