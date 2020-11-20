﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Utils
{
    public abstract class Entity:INotifyPropertyChanged
    {
        public string Id { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
