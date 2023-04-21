using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class PositionListViewModel
    {
        public PositionSearchModel SearchParameter { get; set; }

        public IPagedList<Position> Positions { get; set; }

        public SelectList PositionIDs { get; set; }

        public int PageIndex { get; set; }

    }

}