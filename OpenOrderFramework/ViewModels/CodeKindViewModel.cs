using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.ViewModels
{
    public class CodeKindListViewModel
    {
        public CodeKindSearchModel SearchParameter { get; set; }

        public IPagedList<CodeKind> CodeKinds { get; set; }

        public SelectList Code_Kinds { get; set; }

        public IPagedList<Code> Codes { get; set; }

        public int PageIndex { get; set; }

        public Dictionary<string, string> CodeYN { get; set; }

    }

}