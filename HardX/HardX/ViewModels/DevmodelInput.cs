using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Models;

namespace HardX.ViewModels
{
    public class DevmodelInput
    {
        public Devmodel TheDevmodel;

        public List<Matmodel> MatmodelSelections { get; set; }

        public List<int> SelectedMatmodel { get; set; }
    }
}